namespace BankeKhodroBot.Options;

/// <summary>
/// گزینه‌های قابل پیکربندی از appsettings یا متغیّرهای محیطی
/// (در Render با پیشوند <c>Bot__</c>).
/// </summary>
public class BotOptions
{
    /// <summary>توکن ربات تلگرام</summary>
    public string Token { get; set; } = string.Empty;

    /// <summary>تلفن تماسِ نمایش‌داده‌شده داخل گروه</summary>
    public string ContactPhone { get; set; } = "09127475355";

    /// <summary>نام صاحب تلفن تماس</summary>
    public string ContactName { get; set; } = "کیوان راشدی";

    /// <summary>
    /// URL استاتیک Web‑App (فایل ‎<see lang="html">index.html</see>‎).  
    /// **دقّت:** باید انتهای آن «‎<c>/</c>‎» داشته باشد.
    /// </summary>
    public string WebAppUrl { get; set; } = "https://hasanzadehoseyn27-pixel.github.io/banke-khodro/";

    /// <summary>
    /// آدرس عمومی API که در پارامتر ‎<c>?api=</c>‎ به Web‑App پاس می‌کنیم؛
    /// معمولاً همان دامنهٔ Render است.
    /// مثال: <c>https://bankekhoddro-back.onrender.com</c>
    /// </summary>
    public string PublicApiBase { get; set; } = "https://bankekhoddro-back.onrender.com";
}
