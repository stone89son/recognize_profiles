﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RecognizeProfiles
{
    /// <summary>
    /// Example ROI mouse selector
    /// </summary>
    /// <auhtor>
    /// Richard J. Algarve
    /// </auhtor>
    /// <location>
    /// City: Pederneiras, State: São Paulo, Country: Brasil
    /// </location>
    public class Utilities
    {
        /// <summary>
        /// Convert the coordinates for the image's SizeMode.
        /// </summary>
        /// http://csharphelper.com/blog/2014/10/select-parts-of-a-scaled-image-picturebox-different-sizemode-values-c/
        /// <param name="pic"></param>
        /// <param name="X0">out X coordinate</param>
        /// <param name="Y0">out Y coordinate</param>
        /// <param name="x">atual coordinate</param>
        /// <param name="y">atual coordinate</param>
        public static void ConvertCoordinates(PictureBox pic,
            out int X0, out int Y0, int x, int y)
        {
            int pic_hgt = pic.ClientSize.Height;
            int pic_wid = pic.ClientSize.Width;
            int img_hgt = pic.Image.Height;
            int img_wid = pic.Image.Width;

            X0 = x;
            Y0 = y;
            switch (pic.SizeMode)
            {
                case PictureBoxSizeMode.AutoSize:
                case PictureBoxSizeMode.Normal:
                    // These are okay. Leave them alone.
                    break;
                case PictureBoxSizeMode.CenterImage:
                    X0 = x - (pic_wid - img_wid) / 2;
                    Y0 = y - (pic_hgt - img_hgt) / 2;
                    break;
                case PictureBoxSizeMode.StretchImage:
                    X0 = (int)(img_wid * x / (float)pic_wid);
                    Y0 = (int)(img_hgt * y / (float)pic_hgt);
                    break;
                case PictureBoxSizeMode.Zoom:
                    float pic_aspect = pic_wid / (float)pic_hgt;
                    float img_aspect = img_wid / (float)img_wid;
                    if (pic_aspect > img_aspect)
                    {
                        // The PictureBox is wider/shorter than the image.
                        Y0 = (int)(img_hgt * y / (float)pic_hgt);

                        // The image fills the height of the PictureBox.
                        // Get its width.
                        float scaled_width = img_wid * pic_hgt / img_hgt;
                        float dx = (pic_wid - scaled_width) / 2;
                        X0 = (int)((x - dx) * img_hgt / (float)pic_hgt);
                    }
                    else
                    {
                        // The PictureBox is taller/thinner than the image.
                        X0 = (int)(img_wid * x / (float)pic_wid);

                        // The image fills the height of the PictureBox.
                        // Get its height.
                        float scaled_height = img_hgt * pic_wid / img_wid;
                        float dy = (pic_hgt - scaled_height) / 2;
                        Y0 = (int)((y - dy) * img_wid / pic_wid);
                    }
                    break;
            }
        }

        public static void ExportXmlTemp(string _pathFileTemp, DataTable dt)
        {
            dt.WriteXml(_pathFileTemp);
        }

        public static void ResetAll(string fileConfig)
        {
            DataTable dtFileLog = new DataTable();
            dtFileLog.TableName = "Entity";
            ExportXmlTemp(fileConfig, dtFileLog);
        }

    }
}
