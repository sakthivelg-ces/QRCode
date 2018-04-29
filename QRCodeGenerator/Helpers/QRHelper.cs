using System;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.Mvc;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

namespace QRCodeGenerator.Helpers
{
    public static class QRHelper
    {
        public static string GenerateQRCode(string data, int height = 250,
                                              int width = 250, int margin = 0, string alt="QR Code")
        {

            var barcodeWritter = new BarcodeWriter();
            barcodeWritter.Format = BarcodeFormat.QR_CODE;

            var options = new EncodingOptions()
            {
                Height = height,
                Width = width,
                Margin = margin,
            };

            options.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.L);

            barcodeWritter.Options = options;

            using (var barcodeWritterOutput = barcodeWritter.Write(data))
            {
                using (var barcodeMemoryStream = new MemoryStream())
                {
                    barcodeWritterOutput.Save(barcodeMemoryStream, ImageFormat.Png);
                    return Convert.ToBase64String(barcodeMemoryStream.ToArray());
                    //var img = new TagBuilder("img");
                    //img.Attributes.Add("src", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(barcodeMemoryStream.ToArray())));
                    //img.Attributes.Add("alt", alt);
                    //return MvcHtmlString.Create(img.ToString(TagRenderMode.SelfClosing));
                }
            }
        }
    }
}