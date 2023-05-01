using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualXmlDiff
{
    public partial class OrderAlphabeticallyForm : Form
    {
        public OrderAlphabeticallyForm()
        {
            InitializeComponent();
            enableDisable();
        }

        private void browseFolderButton_Click(object sender, EventArgs e)
        {
            var folderBrowsDialog = new FolderBrowserDialog();
            folderBrowsDialog.ShowDialog();
            sourceFolderTextBox.Text = folderBrowsDialog.SelectedPath;
        }
        private void enableDisable()
        {
            this.okButton.Enabled = System.IO.Directory.Exists(this.sourceFolderTextBox.Text);
        }

        private void sourceFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            this.enableDisable();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            XmlTools.orderXmlFilesAlphabetically(this.sourceFolderTextBox.Text);
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Finished!");
        }
    }
}
