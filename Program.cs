using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CrosshairFree
{
    internal static class Program
    {
        private static NotifyIcon trayIcon;
        private static Mutex mutex = new Mutex(true, "{4D4E897F-7C6C-40D9-9F59-11C78C9C83D7}");
        
        [STAThread]
        public static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                InitializeTrayIcon();

                ShowSettingsForm();

                Application.Run();
            }
            else
            {
                MessageBox.Show("Die Anwendung läuft bereits.");
            }
        }

        private static void InitializeTrayIcon()
        {
            trayIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                Visible = true,
                Text = "Crosshair App"
            };

            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Open Settings", null, (s, e) => ShowSettingsForm());
            contextMenu.Items.Add("Exit", null, (s, e) => ExitApplication());

            trayIcon.ContextMenuStrip = contextMenu;

            trayIcon.ShowBalloonTip(3000, "Crosshair App", "Die Anwendung läuft im Hintergrund.", ToolTipIcon.Info);
        }

        private static void ShowSettingsForm()
        {
            using (var settingsForm = new SettingsForm())
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    var crosshairOverlay = new CrosshairOverlay(
                        settingsForm.crosshairSize,
                        settingsForm.lineWidth,
                        settingsForm.crosshairColor
                    );
                    crosshairOverlay.Show();
                }
            }
        }

        private static void ExitApplication()
        {
            trayIcon.Dispose();
            mutex.ReleaseMutex();  
            Application.Exit();
        }
    }
}
