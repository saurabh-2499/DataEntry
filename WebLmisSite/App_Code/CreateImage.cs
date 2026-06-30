using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Reflection;
using NReco.ImageGenerator;
using System.IO;
using System.Xml.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
/// <summary>
/// Summary description for CreateImage
/// </summary>
public static class HtmlToImageConverter
{
	public static  Bitmap CreateImage(string html,bool IsPreview)
	{


            var htmlToImageConv = new NReco.ImageGenerator.HtmlToImageConverter();
            var jpegBytes = htmlToImageConv.GenerateImage(html, NReco.ImageGenerator.ImageFormat.Jpeg);
            System.Drawing.Bitmap first = (System.Drawing.Bitmap)byteArrayToImage(jpegBytes);
            Bitmap second ;
            if (IsPreview)
            {
                 second = ConvertToBitmap(HttpContext.Current.Server.MapPath("~/Image/pre_view.png"));
            }
            else
            {
                 second = ConvertToBitmap(HttpContext.Current.Server.MapPath("~/Image/view.png"));
            }
            //second.MakeTransparent();
       
            List<Bitmap> images = new List<Bitmap>();

           
        Bitmap finalImage = new Bitmap(first.Width , first.Height);
           
            for (int i = 0; i < first.Height; i++)
            {
                images.Add(second);               
                i += second.Height;               
            }
            first.MakeTransparent();
            images.Add(first);
            using (Graphics g = Graphics.FromImage(finalImage))
            {
                g.Clear(Color.Black);
                int x = 0;
                int offset = 0;
                foreach (Bitmap image in images)
                {    
                    if(images.Count==x+1)
                    {
                        offset = 0;
                    }
                    g.DrawImage(image, new Rectangle(0, offset, first.Width , image.Height));
                    if (x >= 0)
                   {
                        offset = offset + second.Height;
                    }
                    x++;
                }
                return finalImage;
            }
        
       
	}


    public static byte[] GetImageBytes(System.Drawing.Image image)
    {
        byte[] byteArray = new byte[0];
        using (MemoryStream stream = new MemoryStream())
        {
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            stream.Close();

            byteArray = stream.ToArray();
        }
        return byteArray;

    }
    public static System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
    {
        MemoryStream ms = new MemoryStream(byteArrayIn);
        System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
        return returnImage;
    }

    public static Bitmap ConvertToBitmap(string fileName)
    {
        Bitmap bitmap;
        using (Stream bmpStream = System.IO.File.Open(fileName, System.IO.FileMode.Open))
        {
            System.Drawing.Image image = System.Drawing.Image.FromStream(bmpStream);
          
            bitmap = new Bitmap(image);

        }
        return bitmap;
    }
}