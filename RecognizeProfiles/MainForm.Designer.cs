namespace MousePos.ViewForms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.imageBoxInput = new Emgu.CV.UI.ImageBox();
            this.imageBoxOutputROI = new Emgu.CV.UI.ImageBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPostionXY = new System.Windows.Forms.Label();
            this.imageBoxROI = new Emgu.CV.UI.ImageBox();
            this.btnAddPosition = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxOutputROI)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxROI)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.04729F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.95271F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 283F));
            this.tableLayoutPanel1.Controls.Add(this.imageBoxInput, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.imageBoxOutputROI, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.imageBoxROI, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddPosition, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(855, 362);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // imageBoxInput
            // 
            this.imageBoxInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBoxInput.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBoxInput.Location = new System.Drawing.Point(3, 3);
            this.imageBoxInput.Name = "imageBoxInput";
            this.imageBoxInput.Size = new System.Drawing.Size(354, 300);
            this.imageBoxInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBoxInput.TabIndex = 4;
            this.imageBoxInput.TabStop = false;
            this.imageBoxInput.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.imageBoxInput.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDoubleClick);
            this.imageBoxInput.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.imageBoxInput.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.imageBoxInput.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // imageBoxOutputROI
            // 
            this.imageBoxOutputROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBoxOutputROI.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBoxOutputROI.Location = new System.Drawing.Point(363, 3);
            this.imageBoxOutputROI.Name = "imageBoxOutputROI";
            this.imageBoxOutputROI.Size = new System.Drawing.Size(205, 300);
            this.imageBoxOutputROI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBoxOutputROI.TabIndex = 2;
            this.imageBoxOutputROI.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 97.79005F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.209945F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelPostionXY, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 309);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(354, 50);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "1) Select Region Of Interest with Mouse";
            // 
            // labelPostionXY
            // 
            this.labelPostionXY.AutoSize = true;
            this.labelPostionXY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPostionXY.Location = new System.Drawing.Point(3, 25);
            this.labelPostionXY.Name = "labelPostionXY";
            this.labelPostionXY.Size = new System.Drawing.Size(114, 13);
            this.labelPostionXY.TabIndex = 4;
            this.labelPostionXY.Text = "Last Position: X:0   Y:0";
            // 
            // imageBoxROI
            // 
            this.imageBoxROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBoxROI.Location = new System.Drawing.Point(574, 3);
            this.imageBoxROI.Name = "imageBoxROI";
            this.imageBoxROI.Size = new System.Drawing.Size(278, 300);
            this.imageBoxROI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBoxROI.TabIndex = 2;
            this.imageBoxROI.TabStop = false;
            // 
            // btnAddPosition
            // 
            this.btnAddPosition.Location = new System.Drawing.Point(363, 309);
            this.btnAddPosition.Name = "btnAddPosition";
            this.btnAddPosition.Size = new System.Drawing.Size(75, 23);
            this.btnAddPosition.TabIndex = 6;
            this.btnAddPosition.Text = "Add Position";
            this.btnAddPosition.UseVisualStyleBackColor = true;
            this.btnAddPosition.Click += new System.EventHandler(this.btnAddPosition_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 362);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Image Real Coordinates by Richard J. Algarve";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxOutputROI)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxROI)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Emgu.CV.UI.ImageBox imageBoxOutputROI;
        private Emgu.CV.UI.ImageBox imageBoxInput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPostionXY;
        private Emgu.CV.UI.ImageBox imageBoxROI;
        private System.Windows.Forms.Button btnAddPosition;
    }
}

