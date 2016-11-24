namespace RecognizeProfiles.Forms
{
    partial class frmTemplates
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
            this.listView2 = new System.Windows.Forms.ListView();
            this.clIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bntFind = new System.Windows.Forms.Button();
            this.bntDelAll = new System.Windows.Forms.Button();
            this.bntEdit = new System.Windows.Forms.Button();
            this.bntDel = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clId,
            this.clIndex,
            this.clName});
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(12, 70);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(418, 549);
            this.listView2.TabIndex = 26;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // clIndex
            // 
            this.clIndex.DisplayIndex = 0;
            this.clIndex.Text = "#";
            this.clIndex.Width = 40;
            // 
            // clName
            // 
            this.clName.DisplayIndex = 1;
            this.clName.Text = "Name";
            this.clName.Width = 370;
            // 
            // bntFind
            // 
            this.bntFind.Location = new System.Drawing.Point(15, 35);
            this.bntFind.Name = "bntFind";
            this.bntFind.Size = new System.Drawing.Size(47, 27);
            this.bntFind.TabIndex = 23;
            this.bntFind.Text = "Find";
            this.bntFind.UseVisualStyleBackColor = true;
            this.bntFind.Click += new System.EventHandler(this.bntFind_Click);
            // 
            // bntDelAll
            // 
            this.bntDelAll.Location = new System.Drawing.Point(196, 34);
            this.bntDelAll.Name = "bntDelAll";
            this.bntDelAll.Size = new System.Drawing.Size(88, 27);
            this.bntDelAll.TabIndex = 22;
            this.bntDelAll.Text = "Delete All";
            this.bntDelAll.UseVisualStyleBackColor = true;
            this.bntDelAll.Click += new System.EventHandler(this.bntDelAll_Click);
            // 
            // bntEdit
            // 
            this.bntEdit.Location = new System.Drawing.Point(71, 35);
            this.bntEdit.Name = "bntEdit";
            this.bntEdit.Size = new System.Drawing.Size(52, 27);
            this.bntEdit.TabIndex = 21;
            this.bntEdit.Text = "Edit";
            this.bntEdit.UseVisualStyleBackColor = true;
            this.bntEdit.Click += new System.EventHandler(this.bntEdit_Click);
            // 
            // bntDel
            // 
            this.bntDel.Location = new System.Drawing.Point(132, 35);
            this.bntDel.Name = "bntDel";
            this.bntDel.Size = new System.Drawing.Size(47, 27);
            this.bntDel.TabIndex = 20;
            this.bntDel.Text = "Delete";
            this.bntDel.UseVisualStyleBackColor = true;
            this.bntDel.Click += new System.EventHandler(this.bntDel_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(99, 8);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(331, 20);
            this.txtName.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Name Template";
            // 
            // clId
            // 
            this.clId.DisplayIndex = 2;
            this.clId.Width = 0;
            // 
            // frmTemplates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 621);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.bntFind);
            this.Controls.Add(this.bntDelAll);
            this.Controls.Add(this.bntEdit);
            this.Controls.Add(this.bntDel);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "frmTemplates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Template";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader clIndex;
        private System.Windows.Forms.ColumnHeader clName;
        private System.Windows.Forms.Button bntFind;
        private System.Windows.Forms.Button bntDelAll;
        private System.Windows.Forms.Button bntEdit;
        private System.Windows.Forms.Button bntDel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader clId;
    }
}