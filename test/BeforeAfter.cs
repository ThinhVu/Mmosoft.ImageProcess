using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace test
{
    public class BeforeAfter : Control
    {
        private Image _before;
        private Image _after;

        public Image Before { get { return _before; } set { _before = value; Invalidate(); } }
        public Image After { get { return _after; } set { _after = value; Invalidate(); } }

        private Point _mouseLocation;
        private Pen _separatePen;

        public BeforeAfter()
        {
            DoubleBuffered = true;
            _separatePen = new Pen(Color.FromArgb(128, Color.Black));
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            _mouseLocation = e.Location;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            if (_after != null)
                g.DrawImageUnscaledAndClipped(_after, new Rectangle(0, 0, _after.Width, _after.Height));

            if (_before != null)
            {
                int w = (int)Math.Min(_mouseLocation.X, _before.Width);
                g.DrawImageUnscaledAndClipped(_before, new Rectangle(0, 0, w, _before.Height));
            }
             

            if (_mouseLocation.X <= _before.Width)
                g.DrawLine(_separatePen, new Point(_mouseLocation.X, 0), new Point(_mouseLocation.X, this.Height));
        }

        protected override void Dispose(bool disposing)
        {            
            base.Dispose(disposing);
            if (disposing)
            {
                _separatePen.Dispose();
            }
        }
    }
}
