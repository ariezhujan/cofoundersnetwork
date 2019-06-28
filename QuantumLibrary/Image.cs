using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

namespace QuantumLibrary
{
    /// <summary>
    /// Summary description for Image
    /// </summary>
    public class Image
    {
        public static string extension_JPG = "jpg";
        public static string extension_JPEG = "jpeg";
        public static string extension_PNG = "png";
        public static string extension_SVG = "svg";
        public static string extension_GIF = "gif";
        public static string extension_TIFF = "tiff";
        public static string saveLocation_Temp = Data.ReadSetting("imageDiskLocation");
        public static string saveLocation_Perm = saveLocation_Temp + "thumb\\";

        public int imageID { get; private set; }

        public string ImageURL_Original { get; private set; } = "";
        public string ImageURL_Original_Extension { get; private set; } = "";
        public int ImageURL_Original_Width { get; private set; } = 0;
        public int ImageURL_Original_Height { get; private set; } = 0;

        public string ImageURL_Thumb { get; private set; } = "";
        public string ImageInDrive_Original { get; private set; } = "";
        public string ImageInDrive_Thumb { get; private set; } = "";

        public Image(int imageID, string ImageURL_Original, string ImageURL_Thumb)
        {
            this.imageID = imageID;
            this.ImageURL_Original = ImageURL_Original;
            this.ImageURL_Thumb = ImageURL_Thumb;

            this.ImageURL_Original_Extension = ImageURL_Original.Substring(ImageURL_Original.LastIndexOf(".")+1, ImageURL_Original.Length-(ImageURL_Original.LastIndexOf(".")+1)).ToLower().Trim();
        }

        public void DownloadImage()
        {
            //only download images of the type
            if (this.ImageURL_Original_Extension == Image.extension_JPEG || this.ImageURL_Original_Extension == Image.extension_JPG || this.ImageURL_Original_Extension == Image.extension_PNG || this.ImageURL_Original_Extension == Image.extension_SVG || this.ImageURL_Original_Extension == Image.extension_GIF || this.ImageURL_Original_Extension == Image.extension_TIFF)
            {
                this.ImageInDrive_Original = Data.DownloadImage(this, saveLocation_Temp);
            }

            //attempt to gather the height and width of the image
            try
            {
                if (System.IO.File.Exists(this.ImageInDrive_Original))
                {
                    System.Drawing.Image img = System.Drawing.Image.FromFile(this.ImageInDrive_Original);
                    this.ImageURL_Original_Height = img.Height;
                    this.ImageURL_Original_Width = img.Width;
                    img.Dispose();
                }
            } catch (Exception ex){
                if (ex.Message == "Out of memory.")
                {
                    DeleteOriginal(); //delete image
                }
                else
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Deleted the image from the database
        /// </summary>
        public void Delete()
        {
            File.DeleteImage(this.imageID);
        }

        public void DeleteOriginal()
        {
            try
            {
                if (System.IO.File.Exists(this.ImageInDrive_Original))
                { System.IO.File.Delete(this.ImageInDrive_Original); }
            }
            catch (Exception ex) { }
            this.ImageInDrive_Original = "";
        }

        public void Update()
        {
            File.UpdateImage(this.ImageURL_Original, this.ImageURL_Thumb, this.imageID);
        }

        public void CreateIconImage(int resizeHeight, int resizeWidth)
        {
            //only create icon images for jpg and png images
            if (this.ImageURL_Original_Extension != Image.extension_JPEG && this.ImageURL_Original_Extension != Image.extension_JPG && this.ImageURL_Original_Extension != Image.extension_PNG && this.ImageURL_Original_Extension != Image.extension_GIF)
            { return; }

            System.Drawing.Image image = System.Drawing.Image.FromFile(this.ImageInDrive_Original);
            int srcWidth = image.Width;
            int srcHeight = image.Height;

            Decimal sizeRatio = ((Decimal)srcHeight / srcWidth);
            int thumbHeight = 0, thumbWidth = 0;
            if (resizeHeight != 0 && resizeWidth != 0)
            {
                throw new Exception("Cannot create thumb and maintain ratio with both height and width specified.");
            }
            else if (resizeHeight != 0)
            {
                thumbHeight = resizeHeight;
                thumbWidth = Decimal.ToInt32(thumbHeight / sizeRatio);
            }
            else if (resizeWidth != 0)
            {
                thumbWidth = resizeWidth;
                thumbHeight = Decimal.ToInt32(thumbWidth * sizeRatio);
            }

            Bitmap bmp = new Bitmap(thumbWidth, thumbHeight);
            System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);

            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            System.Drawing.Rectangle rectDestination = new System.Drawing.Rectangle(0, 0, thumbWidth, thumbHeight);
            gr.DrawImage(image, rectDestination, 0, 0, srcWidth, srcHeight, GraphicsUnit.Pixel);

            this.ImageInDrive_Thumb = this.ImageInDrive_Original.Replace(saveLocation_Temp, saveLocation_Perm);
            bmp.Save(this.ImageInDrive_Thumb, System.Drawing.Imaging.ImageFormat.Jpeg);

            bmp.Dispose();
            image.Dispose();

            //create url to thumb
            this.ImageURL_Thumb = this.ImageInDrive_Thumb.Replace(saveLocation_Perm, "");
        }

        /// <summary>
        /// Passed relative location of file to make thumb of, returns the relative location of a thumb
        /// </summary>
        /// <param name="locationRelative"></param>
        /// <returns></returns>
        //public string CreateIconImage(string locationRelative, bool deleteOriginal)
        //{
        //    return CreateIconImage(locationRelative, deleteOriginal, 160, 0);
        //}
        //public string CreateIconImage(string locationRelative, bool deleteOriginal, int resizeHeight, int resizeWidth)
        //{
        //    string locationPhysical = File.LocationPhysical(locationRelative);
        //    try
        //    {
        //        locationRelative = locationRelative.Insert(locationRelative.LastIndexOf("."), "thumb_w" + resizeWidth + "h" + resizeHeight).Replace(" ", "").Replace("$", "").Replace("%", "").Replace("#", "").Replace("@", "").Replace("&", "");

        //        //if the file name does not end in jpg, add jpg
        //        if (!locationRelative.ToLower().EndsWith(".jpg"))
        //        {
        //            locationRelative = locationRelative + ".jpg";
        //        }

        //        //check if already exists
        //        if (System.IO.File.Exists(File.LocationPhysical(locationRelative)))
        //        {
        //            return locationRelative;
        //        }


        //        //int resizeWidth = 160;

        //        System.Drawing.Image image = System.Drawing.Image.FromFile(locationPhysical);
        //        int srcWidth = image.Width;
        //        int srcHeight = image.Height;

        //        Decimal sizeRatio = ((Decimal)srcHeight / srcWidth);
        //        int thumbHeight = 0, thumbWidth = 0;
        //        if (resizeHeight != 0 && resizeWidth != 0)
        //        {
        //            throw new Exception("Cannot create thumb and maintain ratio with both height and width specified.");
        //        }
        //        else if (resizeHeight != 0)
        //        {
        //            thumbHeight = resizeHeight; 
        //            resizeWidth = Decimal.ToInt32(sizeRatio * resizeWidth);
        //        }
        //        else if (resizeWidth != 0)
        //        {
        //            thumbWidth = resizeWidth;
        //            thumbHeight = Decimal.ToInt32(sizeRatio / thumbHeight);           
        //        }

        //        Bitmap bmp = new Bitmap(resizeWidth, thumbHeight);
        //        System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);

        //        gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //        gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        //        gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        //        System.Drawing.Rectangle rectDestination = new System.Drawing.Rectangle(0, 0, thumbWidth, thumbHeight);
        //        gr.DrawImage(image, rectDestination, 0, 0, srcWidth, srcHeight, GraphicsUnit.Pixel);

        //        bmp.Save(File.LocationPhysical(locationRelative), System.Drawing.Imaging.ImageFormat.Jpeg);

        //        bmp.Dispose();
        //        image.Dispose();

        //        //delete the screenshot
        //        if (deleteOriginal)
        //        {
        //            System.IO.File.Delete(locationPhysical);
        //        }

        //        //return the relative location of the icon file
        //        return locationRelative;
        //    }
        //    catch (Exception ex)
        //    {
        //        Event.SaveEvent("Image.CreateIconImage locationRelative: " + locationRelative + " - error: " + ex.Message.ToString(), Event.Type_System_AutoIconCreation_Failed);
        //    }

        //    return "";
        //}
    }
}