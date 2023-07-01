namespace OcrFromScreenShot
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var screenshotManager = new ScreenshotManager();

            var screen = screenshotManager.Take(Screen.PrimaryScreen.Bounds.Width,
                                                Screen.PrimaryScreen.Bounds.Height,
                                                Screen.PrimaryScreen.Bounds.X,
                                                Screen.PrimaryScreen.Bounds.Y);

            var screenshot = new Screenshot();
            screenshot.BackgroundImage = screen;

            screenshot.ShowDialog();
        }    
    }
}