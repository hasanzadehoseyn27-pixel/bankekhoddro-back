namespace BankeKhodroBot.Options;

public class BotOptions
{
    public string Token { get; set; } = string.Empty;

    public long AdminChatId { get; set; } = 0;
    public long GroupChatId { get; set; } = 0;

    public string AdminPhone { get; set; } = "";
    public string ContactPhone { get; set; } = "09127475355";
    public string ContactName { get; set; } = "کیوان راشدی";

    // برای دکمه‌ی /post
    public string WebAppUrl { get; set; } = "https://hasanzadehoseyn27-pixel.github.io/banke-khodro/";
    public string PublicApiBase { get; set; } = "https://bankekhoddro-back.onrender.com";
}
