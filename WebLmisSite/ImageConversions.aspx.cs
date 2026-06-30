using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class ImageConversions : System.Web.UI.Page
{
    protected void page_Init(object sender, EventArgs e)
    {
        base.OnPreInit(e);
        //HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
       // HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
        //HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
       //HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        //HttpContext.Current.Response.Cache.SetNoStore();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        CreatePhoto();
    }

    void CreatePhoto()
    {
        try
        {
            // convert the byte code into image and store the image in local 
           // int[] intArray;
          //  int i=0;
          //  intArray = new int[100]; 
            
            string strPhoto = Request.Form["imageData"]; //Get the image from flash file
            byte[] photo = Convert.FromBase64String(strPhoto);
            Session["photo"] = strPhoto;

         //   intArray[i++] = BitConverter.ToInt32(photo,0);
            if (Session["TahsilFlag"].ToString() == "1")
            {
                string sys = "sysadm";
                FileStream fs = new FileStream(MapPath("~/PhotoData/" + sys + ".jpg"), FileMode.OpenOrCreate, FileAccess.Write);
                BinaryWriter br = new BinaryWriter(fs);
                br.Write(photo);
                br.Flush();
                br.Close();
                fs.Close();
            }
            else
            {
                string name = Session["UserName"].ToString();
                FileStream fs = new FileStream(MapPath("~/PhotoData/" + name + ".jpg"), FileMode.OpenOrCreate, FileAccess.Write);
                BinaryWriter br = new BinaryWriter(fs);
                br.Write(photo);
                br.Flush();
                br.Close();
                fs.Close();
            }
            
            
        }
        catch (Exception Ex)
        {
           
        }
    }
}
