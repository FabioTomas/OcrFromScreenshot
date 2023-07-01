using Tesseract;

namespace OcrFromScreenShot
{
    public class OcrManager
    {
        public string ReadImage(Bitmap image, string language)
        {
            using (var engine = new TesseractEngine(@"./Tesseract/tessdata_fast",
                                                    language,
                                                    EngineMode.Default))
            {
                using (var page = engine.Process(image))
                {
                    return page.GetText();
                }
            };
        }
    }
}
