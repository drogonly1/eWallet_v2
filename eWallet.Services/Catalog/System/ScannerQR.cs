using IronBarCode;
using QRCoder;
using System;
using System.Drawing;
using System.Linq;
using ZXing.QrCode.Internal;

namespace eWallet.Services.Catalog.System
{
    public class ScannerQR
    {
        private ScannerQR() { }
        private static ScannerQR instance = null;
        public static ScannerQR Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScannerQR();
                }
                return instance;
            }
        }
        public void Start(string id, string data)
        {
            QRCodeGenerator QrGenerator = new QRCodeGenerator();
            QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            QRCode QrCode = new QRCode(QrCodeInfo);
            Bitmap QrBitmap = QrCode.GetGraphic(60);
            byte[] BitmapArray = QrBitmap.BitmapToByteArray();
            string QrUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));
        }
    }
}
