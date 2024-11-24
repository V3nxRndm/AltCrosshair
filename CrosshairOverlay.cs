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
    public partial class CrosshairOverlay : Form
    {
        private int size;
        private int lineWidth;
        private Color color;

        public CrosshairOverlay(int size, int lineWidth, Color color)
        {
            this.size = size;
            this.lineWidth = lineWidth;
            this.color = color;

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Magenta;
            this.TransparencyKey = Color.Magenta;
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            this.ShowInTaskbar = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            Pen pen = new Pen(color, lineWidth);
            int centerX = this.Width / 2;
            int centerY = this.Height / 2;

            g.DrawLine(pen, centerX - size / 2, centerY, centerX + size / 2, centerY);
            g.DrawLine(pen, centerX, centerY - size / 2, centerX, centerY + size / 2);
        }
    }


}


