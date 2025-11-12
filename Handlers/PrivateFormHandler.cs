using BankeKhodroBot.Options;
using BankeKhodroBot.TelegramApi;
using Microsoft.Extensions.Options;
using Telegram.Bot.Types;

// برای رفع ابهام WebAppInfo بین پکیج خودمان و Telegram.Bot.Types
using TelegramWebAppInfo = BankeKhodroBot.TelegramApi.WebAppInfo;

namespace BankeKhodroBot.Handlers;

public class PrivateFormHandler
{
    private readonly ITgSender _tg;
    private readonly BotOptions _opts;

    public PrivateFormHandler(ITgSender tg, IOptions<BotOptions> opts)
    {
        _tg = tg; _opts = opts.Value;
    }

    public async Task Handle(Message m, CancellationToken ct)
    {
        var text = (m.Text ?? string.Empty).Trim();

        if (string.Equals(text, "/post", StringComparison.OrdinalIgnoreCase))
        {
            // دامنه‌ی Backend روی Render
            const string apiBase = "https://bankekhoddro-back.onrender.com";

            // آدرس WebApp (GitHub Pages)
            var webappBase = (_opts.WebAppUrl ?? "").Trim().TrimEnd('/');

            // فرم را با پارامتر ?api= باز کنیم تا فرانت بداند کجا POST بزند
            var url = $"{webappBase}/?api={Uri.EscapeDataString(apiBase)}";

            var kb = new InlineKeyboardMarkupDto(new[]
            {
                new [] {
                    new InlineKeyboardButtonDto(
                        "📝 باز کردن فرم آگهی",
                        WebApp: new TelegramWebAppInfo(url)
                    )
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
