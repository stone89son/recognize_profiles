using DevExpress.XtraEditors.Controls;
using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using RecognizeProfiles.Entities;
using RecognizeProfiles.Forms;
using RecognizeProfiles.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RecognizeProfiles
{
    public partial class frmMain : Form
    {
        private TemplateRepository _templateRepository = new TemplateRepository();
        private Tesseract _jpnOrc;
        private Tesseract _engOrc;
        private TemplateModel _templateModel;
        public frmMain()
        {
            InitializeComponent();
            Init();

        }

        private void Init()
        {
            LoadTemplates();
            _jpnOrc = new Tesseract(@"", "jpn", Tesseract.OcrEngineMode.OEM_TESSERACT_ONLY);
            _engOrc = new Tesseract(@"", "eng", Tesseract.OcrEngineMode.OEM_TESSERACT_ONLY);
        }
        #region Templates
        private void LoadTemplates()
        {
            List<TemplateModel> lstTemp = _templateRepository.GetAll();
            List<ComboboxItem> lstComboboxItems = new List<ComboboxItem>();
            foreach (var item in lstTemp)
            {
                lstComboboxItems.Add(new ComboboxItem() { Id = item.Id, Text = item.Name });
            }
            ComboboxHelper.BindToCombobox(cbbChooseTemplates, lstComboboxItems);
        }
        private void LoadTemplateByCombobox()
        {
            if (cbbChooseTemplates.Items.Count == 0) return;
            string idTempate = (string)cbbChooseTemplates.SelectedValue;
            _templateModel = _templateRepository.Find(idTempate);
        }
        #endregion
        private void LoadImage(string[] lstImage)
        {
            devImageList.ImageList = imlImages;
            for (int i = 0, len = lstImage.Length; i < len; i++)
            {
                var item = lstImage[i];
                Image img = Image.FromFile(item);
                imlImages.Images.Add(img);
                ImageListBoxItem itemListImage = new ImageListBoxItem(item, i);
                devImageList.Items.Add(itemListImage);

            }
        }

        private string ProcessingImage(string imgPath)
        {
            List<PositionModel> lstPostion = _templateModel.Positions;
            Image<Bgr, Byte> image = new Image<Bgr, byte>(imgPath);
            StringBuilder strBuilder = new StringBuilder();
            int index = 0;
            using (Image<Gray, byte> gray = image.Convert<Gray, Byte>())
            {
                //Image<Gray, Byte> cropImage = gray.Clone();
                foreach (PositionModel positionModel in lstPostion)
                {
                    //image.Draw(positionModel.Rect, new Bgr() { Blue = 0, Green = 0, Red = 255 }, 1);
                    //if (index != 3) return string.Empty; ;
                    //cropImage.ROI = positionModel.Rect;
                    Image<Gray, Byte> cropImageRoi = gray.Copy(positionModel.Rect);

                    string text = string.Empty;
                    switch (positionModel.LanguageCode)
                    {
                        case "eng":
                            _engOrc.Recognize(cropImageRoi);
                            text = _engOrc.GetText();
                            break;
                        case "jpn":
                            _jpnOrc.Recognize(cropImageRoi);
                            text = _jpnOrc.GetText();
                            break;
                    }
                    strBuilder.AppendLine(text);
                }
                index++;
            }
            imbTest.Image = image;
            return strBuilder.ToString();
        }
        private void Recognize()
        {
            string[] lstItem = ofdOpenImages.FileNames;
            LoadTemplateByCombobox();
            StringBuilder strBuilder = new StringBuilder();
            foreach (var item in lstItem)
            {
                string textImage = ProcessingImage(item);
                strBuilder.AppendLine(textImage);
                strBuilder.AppendLine("_______________________________________");
            }
            rtbResult.Text = strBuilder.ToString();
        }

        private void btnRecognize_Click(object sender, EventArgs e)
        {
            Recognize();
        }

     
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ofdOpenImagesResult = ofdOpenImages.ShowDialog();
            if (ofdOpenImagesResult == DialogResult.OK)
            {
                string[] lstPathFile = ofdOpenImages.FileNames;
                LoadImage(lstPathFile);
            }
        }

        private void menuItemTemplateBuilder_Click(object sender, EventArgs e)
        {
            frmTemplateBuilder frmTemplateBuilder = new frmTemplateBuilder();
            frmTemplateBuilder.myFlagChange += new frmTemplateBuilder.GetFlagChang(event_ReloadTemplate);
            frmTemplateBuilder.ShowDialog();
        }

        private void menuItemTemplateManager_Click(object sender, EventArgs e)
        {
            frmTemplates template = new frmTemplates();
            template.myFlagChange += new frmTemplates.GetFlagChang(event_ReloadTemplate);
            template.ShowDialog();
        }

        private void event_ReloadTemplate(bool flag)
        {
            if (flag)
            {
                LoadTemplates();
            }
        }

        private void rtbResult_TextChanged(object sender, EventArgs e)
        {
            //LoadTemplateByCombobox();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Image<Bgr, Byte> cropImage = new Image<Bgr, Byte>(imageBox1.Image.Bitmap);
            Image<Gray, Byte> grayImage = cropImage.Convert<Gray, Byte>();
            _engOrc.Recognize(grayImage);
            string text = _engOrc.GetText();
        }


    }
}
