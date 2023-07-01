using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OcrFromScreenShot;

namespace OcrFromScreenShot
{
    public partial class Screenshot : Form
    {

        Color SelectedColor = Color.LightGreen;
        List<DrawingRectangle> _drawingRects = new List<DrawingRectangle>();

        public Screenshot()
        {
            this.DoubleBuffered = true;
            this.Cursor = Cursors.Cross;
            InitializeComponent();
        }

        private void Mouse_Down(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _drawingRects.Add(new DrawingRectangle()
            {
                Location = e.Location,
                Size = Size.Empty,
                StartPosition = e.Location,
                Owner = (Control)sender,
                DrawingcColor = SelectedColor // <= Shape's Border Color
            });
        }

        private void Mouse_Move(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            var dr = _drawingRects[_drawingRects.Count - 1];
            if (e.Y < dr.StartPosition.Y) { dr.Location = new Point(dr.Rect.Location.X, e.Y); }
            if (e.X < dr.StartPosition.X) { dr.Location = new Point(e.X, dr.Rect.Location.Y); }

            dr.Size = new Size(Math.Abs(dr.StartPosition.X - e.X), Math.Abs(dr.StartPosition.Y - e.Y));
            this.Invalidate();
        }

        private void Mouse_Up(object sender, MouseEventArgs e)
        {
            var dr = _drawingRects.Last();            
            
            var screenshotManager = new ScreenshotManager();
            var screenshot = screenshotManager.Take(dr.Size.Width,
                                                    dr.Size.Height,
                                                    dr.Location.X,
                                                    dr.Location.Y);

            //screenshot.Save("screenshotPart.jpg", ImageFormat.Jpeg);
            var text = new OcrManager().ReadImage(screenshot, "eng");

            Home parent = (Home)this.Owner;
            parent.GetText(text);

            this.Close();
        }


        private void DrawShapes(Graphics g)
        {
            if (_drawingRects.Count == 0) return;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            foreach (var dr in _drawingRects)
            {
                using (Pen pen = new Pen(dr.DrawingcColor, dr.PenSize))
                {
                    g.DrawRectangle(pen, dr.Rect);
                }
            }
        }

        private void Select_Area(object sender, PaintEventArgs e)
        {
            DrawShapes(e.Graphics);
        }
    }
}
