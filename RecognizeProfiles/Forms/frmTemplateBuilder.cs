using RecognizeProfiles.Entities;
using RecognizeProfiles.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RecognizeProfiles.Forms
{
    public partial class frmTemplateBuilder : Form
    {
        public delegate void GetFlagChang(bool flag);
        public GetFlagChang myFlagChange;

        public frmTemplateBuilder()
        {
            InitializeComponent();
            Init();
            pbxImage.Image = Image.FromFile("lena.jpg");
        }
        private Point RectStartPoint;
        private Rectangle Rect = new Rectangle();
        private Brush selectionBrush = new SolidBrush(Color.FromArgb(128, 72, 145, 220));
        private List<PositionModel> pstModel = new List<PositionModel>();
        private TemplateRepository _templateRepository = new TemplateRepository();
        private void Init()
        {
            LoadLanguages();
            LoadTemplates();
        }

        #region entities

        private void LoadLanguages()
        {
            ComboboxHelper.BindToCombobox(cbbChooseLanguage.ComboBox, Constants.LANGUAGES);
        }

        private void LoadTemplates()
        {
            List<TemplateModel> lstTemp = _templateRepository.GetAll();
            List<ComboboxItem> lstComboboxItems = new List<ComboboxItem>();
            foreach (var item in lstTemp)
            {
                lstComboboxItems.Add(new ComboboxItem() { Id = item.Id, Text = item.Name });
            }
            ComboboxHelper.BindToCombobox(cbbLstTemplate.ComboBox, lstComboboxItems);
        }
        //Template
        private void LoadTemplate() { 
          //cbbLstTemplate.

        } 
        #endregion

        #region Logic
        private Rectangle[] GetRects()
        {
            List<Rectangle> results = new List<Rectangle>();
            foreach (PositionModel positionModel in pstModel)
            {
                results.Add(positionModel.Rect);
            }
            return results.ToArray();
        }
        #endregion

        #region Event
        // Start Rectangle
        //
        private void pbxImage_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Determine the initial rectangle coordinates...
            RectStartPoint = e.Location;
            isBackflag = false;
            Invalidate();
        }

        // Draw Rectangle
        //
        private void pbxImage_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            Point tempEndPoint = e.Location;
            Rect.Location = new Point(
                Math.Min(RectStartPoint.X, tempEndPoint.X),
                Math.Min(RectStartPoint.Y, tempEndPoint.Y));
            Rect.Size = new Size(
                Math.Abs(RectStartPoint.X - tempEndPoint.X),
                Math.Abs(RectStartPoint.Y - tempEndPoint.Y));
            pbxImage.Invalidate();
        }

        // Draw Area
        //
        private void pbxImage_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Draw the rectangle...
            if (pbxImage.Image != null)
            {
                if (Rect != null && Rect.Width > 0 && Rect.Height > 0)
                {
                    Rectangle[] arrRect = GetRects();
                    if (arrRect.Length > 0)
                    {
                        e.Graphics.FillRectangles(selectionBrush, GetRects());
                    }
                    if (!isBackflag)
                        e.Graphics.FillRectangle(selectionBrush, Rect);
                }
            }
        }

        private void pbxImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Rect.Contains(e.Location))
                {
                    Debug.WriteLine("Right click");
                }
            }
        }
        #endregion

        #region Crud Event
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult result = odlOpenImage.ShowDialog();
            if (result == DialogResult.OK)
            {
                pstModel = new List<PositionModel>();
                pbxImage.Image = Image.FromFile(odlOpenImage.FileName);
            }
        }
        private bool _isChangeValue = false;
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            frmTemplateBuilderSavePopup frmTemplateBuilderSavePopup = new frmTemplateBuilderSavePopup(pstModel);
            frmTemplateBuilderSavePopup.ShowDialog();
            _isChangeValue = true;
        }
        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            PositionModel positionModel = new PositionModel();
            positionModel.HtmlName = "";
            positionModel.Rect = Rect;
            positionModel.LanguageCode = (string)cbbChooseLanguage.ComboBox.SelectedValue;
            pstModel.Add(positionModel);
        }
        #endregion

        bool isBackflag = false;
        private void btnBack_Click(object sender, EventArgs e)
        {
            isBackflag = true;
            if (pstModel.Count > 0)
            {
                pstModel.RemoveAt(pstModel.Count - 1);
                pbxImage.Refresh();
            }
            else
            {
                Rect = new Rectangle();
                pbxImage.Refresh();
            }
        }

        private void frmTemplateBuilder_FormClosing(object sender, FormClosingEventArgs e)
        {
            myFlagChange(_isChangeValue);
        }

    }
}
