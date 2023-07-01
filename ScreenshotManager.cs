namespace OcrFromScreenShot
{
    public class ScreenshotManager
    {
        public Bitmap Take(int width, int height, int sourceX, int sourceY)
        {
            Bitmap screenCapture = new Bitmap(width, height);

            using Graphics g = Graphics.FromImage(screenCapture);
            g.CopyFromScreen(sourceX,
                             sourceY,
                             0, 0,
                             screenCapture.Size,
                             CopyPixelOperation.SourceCopy);

            return screenCapture;
        }
    }
}
