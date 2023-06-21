using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Drawable
    {
        public float Left { get; set; }
        public float Top { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public Color Color { get; set; }
        public Drawable(float left, float top, float width, float height, Color color)
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
            Color = color;
        }
    }
}
