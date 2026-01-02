using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Aplikasi_Manajemen_Sampah // Pastikan ini sama dengan namespace project Anda
{
    public class GlassPanel : Panel
    {
        // Tingkat transparansi (0 - 255). 150 = setengah transparan gelap.
        private int opacity = 150;

        public int Opacity
        {
            get { return opacity; }
            set
            {
                opacity = value;
                this.Invalidate(); // Gambar ulang kalau nilai berubah
            }
        }

        public GlassPanel()
        {
            // Set agar panel support background transparan
            this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.UserPaint, true);

            // Warna dasar transparan
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Setting grafis biar halus (tidak bergerigi)
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Bikin kuas warna hitam semi-transparan
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(opacity, 0, 0, 0)))
            {
                // Bikin kotak dengan sudut melengkung (Rounded)
                int radius = 20;
                Rectangle rect = this.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;

                GraphicsPath path = new GraphicsPath();
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                // Warnai panel
                e.Graphics.FillPath(brush, path);
            }
        }
    }
}