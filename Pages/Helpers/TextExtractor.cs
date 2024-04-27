using IronOcr;

namespace Pages.Helpers
{
    public static class TextExtractor
    {

        public static string ExtractFromPdf(string path)
        {
            
            var ocr = new IronTesseract();
            ocr.Language = OcrLanguage.Russian;

            using (var ocrInput = new OcrInput())
            {
                ocrInput.LoadPdf(path);
                
                var ocrResult = ocr.Read(ocrInput);
                return ocrResult.Text;
            }
                
        }
    }
}
