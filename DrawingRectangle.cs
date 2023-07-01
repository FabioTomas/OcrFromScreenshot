namespace OcrFromScreenShot
{
    public class DrawingRectangle
    {
        public Rectangle Rect => new Rectangle(Location, Size);
        public Size Size { get; set; }
        public Point Location { get; set; }
        public Control? Owner { get; set; }
        public Point StartPosition { get; set; }
        public Color DrawingcColor { get; set; } = Color.LightGreen;
        public float PenSize { get; set; } = 3f;
    }
}
