using System.Windows.Forms;

namespace Common.Utilities
{
    public class NotifyIconBalloonTips
    {
        private static NotifyIcon NotifyIcon { get; set; }

        public NotifyIconBalloonTips(NotifyIcon notifyIcon) => NotifyIcon = notifyIcon;

        public static void Info(string body, string title) => ShowBalloonTip(body, title, ToolTipIcon.Info);

        public static void Warning(string body, string title) => ShowBalloonTip(body, title, ToolTipIcon.Warning);

        public static void Error(string body, string title) => ShowBalloonTip(body, title, ToolTipIcon.Error);

        public static void ShowBalloonTip(string body, string title, ToolTipIcon toolTipIcon) => NotifyIcon.ShowBalloonTip(500, body, title, toolTipIcon);
    }
}
