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
    public partial class frmTemplates : Form
    {
        TemplateRepository _templateRepository = new TemplateRepository();

        public delegate void GetFlagChang(bool flag);
        public GetFlagChang myFlagChange;

        public frmTemplates()
        {

            InitializeComponent();
            GetAll();
        }


        private int countList = 0;
        private string _templateTemp;

        private void _showListView(List<TemplateModel> listSoModel)
        {
            foreach (var item in listSoModel)
            {
                //Add items in the listview
                string[] arr = new string[4];

                ListViewItem itm = new ListViewItem();
                countList++;
                //Add first item
                arr[0] = item.Id;
                arr[1] = countList.ToString();
                arr[2] = item.Name;
                itm = new ListViewItem(arr);
                listView2.Items.Add(itm);
            }
        }

        private void GetAll()
        {
            try
            {
                countList = 0;
                listView2.Items.Clear();
                List<TemplateModel> listSoModel = _templateRepository.GetAll();
                _showListView(listSoModel);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error" + ex.ToString());
            }
        }

        private void Find()
        {
            try
            {
                listView2.Items.Clear();
                List<TemplateModel> listSoModel = _templateRepository.FindAll(txtName.Text);
                _showListView(listSoModel);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error" + ex.ToString());
            }

        }

        private void Edit()
        {
            try
            {

                TemplateModel _TemplateModel = new TemplateModel();
                _TemplateModel.Name = txtName.Text.Trim();
                _templateRepository.Update(_templateTemp, _TemplateModel);
                GetAll();
                myFlagChange(true);
                MessageBox.Show("Updated!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void Del()
        {
            try
            {
                _templateRepository.Delete(_templateTemp);
                myFlagChange(true);
                GetAll();

                MessageBox.Show("Deleted!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }

        private void DelAll()
        {
            if (DialogResult.Yes == MessageBox.Show("You want to delete all template?", "Messenge alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    Utilities.ResetAll(_templateRepository._nameFile);

                    TemplateModel _TemplateModel = new TemplateModel();
                    _templateRepository.Add(_TemplateModel);
                    GetAll();
                    myFlagChange(true);
                    MessageBox.Show("Deleted all tempaltes!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.ToString());
                }

            }
            else
            {

                MessageBox.Show("Canceled delete all templates!");
            }

        }

        private void bntFind_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void bntEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void bntDel_Click(object sender, EventArgs e)
        {
            Del();
        }

        private void bntDelAll_Click(object sender, EventArgs e)
        {
            DelAll();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection itemCollectionSong =
            this.listView2.SelectedItems;

            foreach (ListViewItem item in itemCollectionSong)
            {
                txtName.Text = item.SubItems[2].Text;
                _templateTemp = item.SubItems[0].Text;
            }
        }


    }
}
