using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RecognizeProfiles.Entities
{
    public class ComboboxHelper
    {
        public static void BindToCombobox(ComboBox cbb, List<ComboboxItem> lstDataCombobox)
        {
            cbb.DataSource = null;
            cbb.ValueMember = "Id";
            cbb.DisplayMember = "Text";
            cbb.DataSource = lstDataCombobox;
            cbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cbb.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbb.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        //public static void BindToToolStripCombobox(ToolStripComboBox cbb, List<ComboboxItem> lstDataCombobox)
        //{
        //    cbb.DataSource = null;
        //    cbb.ValueMember = "Id";
        //    cbb.DisplayMember = "Text";
        //    cbb.DataSource = lstDataCombobox;
        //    cbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
        //    cbb.AutoCompleteMode = AutoCompleteMode.Suggest;
        //    cbb.AutoCompleteSource = AutoCompleteSource.ListItems;
        //}
        public static void BindItemToCombobox(ComboBox cbb, List<ComboboxItem> lstDataCombobox)
        {
            foreach (var dataCombobox in lstDataCombobox)
            {
                cbb.Items.Add(dataCombobox.Text);
            }

            cbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cbb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection autoStr = new AutoCompleteStringCollection();
            foreach (var dataCombobox in lstDataCombobox)
            {
                autoStr.Add(dataCombobox.Text);
            }
            cbb.AutoCompleteCustomSource = autoStr;
        }

        public static void SetSelectByItem(ComboBox cbb, string text = "")
        {
            if (text != null && !string.IsNullOrWhiteSpace(text))
            {
                ComboBox.ObjectCollection lstComboboxItem = cbb.Items;
                foreach (string comboboxItem in lstComboboxItem)
                {
                    if (string.Equals(comboboxItem, text))
                    {
                        cbb.SelectedItem = text;
                        break;
                    }
                }
            }
            else { if (cbb.Items.Count > 0) cbb.SelectedIndex = 0; };
        }

    }
}
 