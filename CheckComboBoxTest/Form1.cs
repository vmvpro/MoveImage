using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace CheckComboBox {
    public partial class Form1 : Form {
        private string[] coloursArr = { "Red", "Green", "Black", "White", "Orange", "Yellow", "Blue", "Maroon", "Pink", "Purple" };
        // ,"A very long string exceeding the dropdown width and forcing a scrollbar to appear to make the content viewable"};

        public Form1() {
            InitializeComponent();
            // Manually add handler for when an item check state has been modified.
			CheckedComboBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccb_ItemCheck);
        }

        private void Form1_Load(object sender, EventArgs e) {
            for (int i = 0; i < coloursArr.Length; i++) {
                CheckedComboBoxItem item = new CheckedComboBoxItem(coloursArr[i], i);
				CheckedComboBox1.Items.Add(item);
            }
            // If more then 5 items, add a scroll bar to the dropdown.
			CheckedComboBox1.MaxDropDownItems = 5;
            // Make the "Name" property the one to display, rather than the ToString() representation.
			CheckedComboBox1.DisplayMember = "Name";
			CheckedComboBox1.ValueSeparator = "; ";
            // Check the first 2 items.
			CheckedComboBox1.SetItemChecked(0, true);
			CheckedComboBox1.SetItemChecked(1, true);
            //ccb.SetItemCheckState(1, CheckState.Indeterminate);
        }

        private void ccb_DropDownClosed(object sender, EventArgs e) {
            txtOut.AppendText("DropdownClosed\r\n");
			txtOut.AppendText(string.Format("value changed: {0}\r\n", CheckedComboBox1.ValueChanged));
			txtOut.AppendText(string.Format("value: {0}\r\n", CheckedComboBox1.Text));
            // Display all checked items.
            StringBuilder sb = new StringBuilder("Items checked: ");
			foreach (CheckedComboBoxItem item in CheckedComboBox1.CheckedItems)
			{
				sb.Append(item.Name).Append(CheckedComboBox1.ValueSeparator);
            }
			sb.Remove(sb.Length - CheckedComboBox1.ValueSeparator.Length, CheckedComboBox1.ValueSeparator.Length);
            txtOut.AppendText(sb.ToString());
            txtOut.AppendText("\r\n");
			//MessageBox.Show(CheckedComboBox1.Text);

        }

        private void ccb_ItemCheck(object sender, ItemCheckEventArgs e) {
			CheckedComboBoxItem item = CheckedComboBox1.Items[e.Index] as CheckedComboBoxItem;
            txtOut.AppendText(string.Format("Item '{0}' is about to be {1}\r\n", item.Name, e.NewValue.ToString()));
        }        
    }
}