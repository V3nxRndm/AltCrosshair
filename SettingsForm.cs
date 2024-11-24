using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrosshairFree
{

    public partial class SettingsForm : Form
    {
        public Color crosshairColor = Color.Red;
        public int crosshairSize = 40;
        public int lineWidth = 2;
        private NotifyIcon trayIcon;

        public SettingsForm()
        {
            InitializeComponent();

            sizeSlider.Scroll += (s, e) => { crosshairSize = sizeSlider.Value; previewPanel.Invalidate(); };
            lineWidthSlider.Scroll += (s, e) => { lineWidth = lineWidthSlider.Value; previewPanel.Invalidate(); };
            colorPickerButton.Click += (s, e) => OpenColorPicker();
            applyButton.Click += (s, e) => ApplySettings();

            previewPanel.Paint += (s, e) => DrawPreview(e.Graphics);

            InitializeTrayIcon();
        }

        private void OpenColorPicker()
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    crosshairColor = dialog.Color;
                    colorPickerButton.BackColor = crosshairColor;
                    previewPanel.Invalidate();
                }
            }
        }

        private void ApplySettings()
        {
            CrosshairOverlay overlay = new CrosshairOverlay(crosshairSize, lineWidth, crosshairColor);
            overlay.Show();
        }

        private void DrawPreview(Graphics g)
        {
            g.Clear(Color.White);

            Pen pen = new Pen(crosshairColor, lineWidth);
            int centerX = previewPanel.Width / 2;
            int centerY = previewPanel.Height / 2;

            g.DrawLine(pen, centerX - crosshairSize / 2, centerY, centerX + crosshairSize / 2, centerY);
            g.DrawLine(pen, centerX, centerY - crosshairSize / 2, centerX, centerY + crosshairSize / 2);
        }

        private void InitializeTrayIcon()
        {
            trayIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                Visible = true,
                Text = "Crosshair App"
            };

            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Open Settings", null, (s, e) => Show());
            contextMenu.Items.Add("Exit", null, (s, e) => Application.Exit());

            trayIcon.ContextMenuStrip = contextMenu;

            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            this.Hide();
            e.Cancel = true; // Schließen verhindern
        }
    }

}

