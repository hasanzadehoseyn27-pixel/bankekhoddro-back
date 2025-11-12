using BankeKhodroBot.Options;
using BankeKhodroBot.TelegramApi;
using Microsoft.Extensions.Options;
using Telegram.Bot.Types;

namespace BankeKhodroBot.Handlers;

public class PrivateFormHandler
{
    private readonly ITgSender _tg;
    private readonly BotOptions _opt;

    public PrivateFormHandler(ITgSender tg, IOptions<BotOptions> opt)
    {
        _tg = tg;
        _opt = opt.Value;
    }

    public async Task Handle(Message m, CancellationToken ct)
    {
        var text = (m.Text ?? string.Empty).Trim();

        if (string.Equals(text, "/post", StringComparison.OrdinalIgnoreCase))
        {
            var web = (_opt.WebAppUrl ?? "").TrimEnd('/');
            var api = (_opt.PublicApiBase ?? "").TrimEnd('/');

            var url = string.IsNullOrWhiteSpace(api)
                ? web
                : $"{web}?api={Uri.EscapeDataString(api)}";

            var kb = new InlineKeyboardMarkupDto(new[]
            {
                new [] {
                    new InlineKeyboardButtonDto(
                        "📝 باز کردن فرم آگهی",
                        WebApp: new BankeKhodroBot.TelegramApi.WebAppInfo(url))
                }
            });

            await _tg.SendText(
                m.Chat.Id,
                "برای ثبت آگهی روی دکمه زیر بزن:",
                parseMode: "HTML",
                replyMarkup: kb,
                ct: ct);
            return;
        }

        if (string.Equals(text, "/start", StringComparison.OrdinalIgnoreCase))
        {
            await _tg.SendText(m.Chat.Id, "سلام! برای ثبت آگهی «/post» را بزن و فرم را پر کن.", ct: ct);
        }
    }
}
