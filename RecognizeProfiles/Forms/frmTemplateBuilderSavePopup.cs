using RecognizeProfiles.Entities;
using RecognizeProfiles.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RecognizeProfiles.Forms
{
    public partial class frmTemplateBuilderSavePopup : Form
    {
        TemplateRepository _templateRepository = new TemplateRepository();
        private List<PositionModel> _lstPositionModel;
        public frmTemplateBuilderSavePopup(List<PositionModel> lstPositionModel)
        {
            InitializeComponent();
            _lstPositionModel = lstPositionModel;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            TemplateModel template = new TemplateModel();
            template.Name = txtName.Text;
            template.Positions = _lstPositionModel;
            _templateRepository.Add(template);
            this.Close();
        }
    }
}
