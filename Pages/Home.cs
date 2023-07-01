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

            using (Screenshot screenshot = new Screenshot())
            {
                screenshot.Owner = this;
                screenshot.BackgroundImage = screen;
                screenshot.ShowDialog();
            }

        }

        public void GetText(string text)
        {
            this.TextBox.Text = text;
        }

        private void On_Resize(object sender, EventArgs e)
        {
            TextBox.Width = this.Width; TextBox.Height = this.Height;
        }
    }
}