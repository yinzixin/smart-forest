using SF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using ThoughtWorks.QRCode.Codec;

namespace SF.Web
{
    public class TreeTagPainter
    {
        public static byte[]  Paint(Tree t,string host)
        {
           
 
            var bitmap = new Bitmap(1800, 1200);
            bitmap.MakeTransparent();
            var heiti = new FontFamily("黑体");
            var font12B = new Font(heiti, 75.0f, FontStyle.Regular);
            var font40B = new Font(heiti, 150.0f, FontStyle.Bold);
            var font60=new Font(heiti,60f,FontStyle.Regular);

            using(var graph=Graphics.FromImage(bitmap))
            {
                graph.DrawString("古树名木调查资料", new Font(heiti, 40.0f, FontStyle.Regular),Brushes.Black, 650, 50);
                graph.DrawString(t.Number, font12B, Brushes.Black, 80, 130);

                var font = font40B;
                while (graph.MeasureString(t.Name, font).Width > 900)
                {
                    font = new Font(heiti, (float)(font.Size * 0.9), FontStyle.Regular);
                }
                var size = graph.MeasureString(t.Name, font);
                var left = (1100 - size.Width) / 2;

                graph.DrawString(t.Name, font, Brushes.Black, left, 320);

                var latin = "拉丁名 " + t.NameLatin;
                font = font60;
                while (graph.MeasureString(latin, font).Width > 1000)
                {
                    font = new Font(heiti, (float)(font.Size * 0.9), FontStyle.Regular);
                }
                graph.DrawString(latin,font,Brushes.Black, 80, 600);
               
                var codec = new QRCodeEncoder();
                codec.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                codec.QRCodeScale = 4;
                var barcode = codec.Encode("http://"+host + "/tree/view/" + t.ID);
                
                var rec = new Rectangle(1100, 300, 600, 600);
                graph.DrawImage(barcode, rec, new Rectangle(0, 0, barcode.Width, barcode.Height), GraphicsUnit.Pixel);
                
                MemoryStream stream = new MemoryStream();
                bitmap.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}