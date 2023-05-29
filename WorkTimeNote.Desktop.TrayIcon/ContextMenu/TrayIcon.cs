using System.Drawing;
using System.Windows.Forms;

namespace WorkTimeNote.TrayIcon
{
    internal partial class TrayIcon
    {
        internal static int? PendenciaPointingTime { get; set; } = null;

        internal static State UserPointingState { get; set; } = State.Stopped;

        private static Icon Icon
        {
            get
            {
                switch (UserPointingState)
                {
                    case State.PointingTime: return Properties.Resources.worktimenote_working_64x64;
                    case State.Waiting: return Properties.Resources.worktimenote_sand_timer_64x64;
                    case State.Stopped: return Properties.Resources.worktimenote_x_64x64;
                    default:  return null;
                }
            }
        }

        private static NotifyIcon notifyIcon = new NotifyIcon()
        {
            Visible = true,
            ContextMenu = new ContextMenu()
        };


        public TrayIcon()
        {
            RefreshMenuItems();
        }


        public static void Start()
        {
            UserPointingState = State.PointingTime;
            RefreshMenuItems();
        }

        public static void Save()
        {
            // Save to database
            UserPointingState = State.Stopped;
            RefreshMenuItems();
        }

        public static void Pause()
        {
            UserPointingState = State.Waiting;
            RefreshMenuItems();
        }

        public static void Cancel()
        {
            UserPointingState = State.Stopped;
            PendenciaPointingTime = null;
            RefreshMenuItems();
        }


        internal enum WorkTimeNoteStyle { Legacy, New }

        public enum State { PointingTime, Waiting, Stopped }
    }
}
