# ---- Build stage ----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# فقط csproj ها را کپی کن تا restore کش شود
COPY *.csproj ./
RUN dotnet restore

# بقیه سورس
COPY . ./
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# ---- Runtime stage ----
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Kestrel روی 8080 گوش بده (داخل کانتینر)
ENV ASPNETCORE_URLS=http://+:8080
# زمان/فرهنگ اختیاری
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

COPY --from=build /app/publish ./

# پورت سرویس داخل کانتینر
EXPOSE 8080

# اجرای اپ
ENTRYPOINT ["dotnet", "BankeKhodroBot.dll"]
