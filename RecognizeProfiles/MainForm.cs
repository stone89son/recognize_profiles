using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;
using RecognizeProfiles;

namespace MousePos.ViewForms
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
    public partial class MainForm : Form
    {
        private Image<Bgr, byte> imgEntrada;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            imgEntrada = new Image<Bgr, byte>("lena.jpg");
            imageBoxOutputROI.Image = imageBoxInput.Image = imgEntrada;
        }

        #region EVENTOS PICTURE BOX | DEFINIÇÃO DE ROI
        private Point RectStartPoint;
        private Rectangle Rect = new Rectangle();
        private Rectangle RealImageRect = new Rectangle();
        private Brush selectionBrush = new SolidBrush(Color.FromArgb(128, 64, 64, 64));
        private int thickness = 3;

        /// <summary>
        /// Start Rectangle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Determine the initial rectangle coordinates...
            RectStartPoint = e.Location;
            Invalidate();
        }

        /// <summary>
        /// Draw Rectangle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            #region SETS COORDINATES AT INPUT IMAGE BOX
            int X0, Y0;
            Utilities.ConvertCoordinates(imageBoxInput, out X0, out Y0, e.X, e.Y);
            labelPostionXY.Text = "Last Position: X:" + X0 + "  Y:" + Y0;

            //Coordinates at input picture box
            if (e.Button != MouseButtons.Left)
                return;
            Point tempEndPoint = e.Location;
            Rect.Location = new Point(
                Math.Min(RectStartPoint.X, tempEndPoint.X),
                Math.Min(RectStartPoint.Y, tempEndPoint.Y));
            Rect.Size = new Size(
                Math.Abs(RectStartPoint.X - tempEndPoint.X),
                Math.Abs(RectStartPoint.Y - tempEndPoint.Y));
            #endregion

            #region SETS COORDINATES AT REAL IMAGE
            //Coordinates at real image - Create ROI
            Utilities.ConvertCoordinates(imageBoxInput, out X0, out Y0, RectStartPoint.X, RectStartPoint.Y);
            int X1, Y1;
            Utilities.ConvertCoordinates(imageBoxInput, out X1, out Y1, tempEndPoint.X, tempEndPoint.Y);
            RealImageRect.Location = new Point(
                Math.Min(X0, X1),
                Math.Min(Y0, Y1));
            RealImageRect.Size = new Size(
                Math.Abs(X0 - X1),
                Math.Abs(Y0 - Y1));

            imgEntrada = new Image<Bgr, byte>("lena.jpg");
            imgEntrada.Draw(RealImageRect, new Bgr(Color.Red), thickness);
            imageBoxOutputROI.Image = imgEntrada;
            #endregion

            ((PictureBox)sender).Invalidate();
        }

        /// <summary>
        /// Desenha retângulo
        /// </summary>
        /// http://stackoverflow.com/questions/11088154/graphics-fillrectangle-except-specified-area-net-gdi
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Draw the rectangle...
            if (imageBoxInput.Image != null)
            {
                if (Rect != null && Rect.Width > 0 && Rect.Height > 0)
                {
                    //Seleciona a ROI
                    e.Graphics.SetClip(Rect, System.Drawing.Drawing2D.CombineMode.Exclude);
                    e.Graphics.FillRectangle(selectionBrush, new Rectangle(0, 0, ((PictureBox)sender).Width, ((PictureBox)sender).Height));
                    e.Graphics.FillRectangle(selectionBrush, Rect);
                }
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            //Define ROI. Valida altura e largura para evitar index range exception.
            if (RealImageRect.Width > 0 && RealImageRect.Height > 0)
            {
                imgEntrada.ROI = RealImageRect;
                imageBoxROI.Image = imgEntrada;
            }

        }

        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Rect = new Rectangle();
            ((PictureBox)sender).Invalidate();
        }

        #endregion

        private void btnAddPosition_Click(object sender, EventArgs e)
        {

        }


    }
}
