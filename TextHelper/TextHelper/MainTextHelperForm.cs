using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextHelper
{
    public partial class MainTextHelperForm : Form
    {
        private const UInt32 EM_SETTABSTOPS = 0x00CB;
        private const int unitsPerCharacter = 4;

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, ref IntPtr lParam);
        public MainTextHelperForm()
        {
            InitializeComponent();
            SetTextBoxTabStopLength(this.mainTextBox, 4);
        }

        public static void SetTextBoxTabStopLength(TextBox tb, int tabSizeInCharacters)
        {
            // 1 means all tab stops are the the same length
            // This means lParam must point to a single integer that contains the desired tab length
            const uint regularLength = 1;

            // A dialog unit is 1/4 of the average character width
            int length = tabSizeInCharacters * unitsPerCharacter;

            // Pass the length pointer by reference, essentially passing a pointer to the desired length
            IntPtr lengthPointer = new IntPtr(length);
            SendMessage(tb.Handle, EM_SETTABSTOPS, (IntPtr)regularLength, ref lengthPointer);
        }


        private void vbScriptQueryButton_Click(object sender, EventArgs e)
        {
            this.mainTextBox.Text = TextHelper.formatSQLtoVBS(this.mainTextBox.Text);
            this.mainTextBox.SelectAll();
            this.mainTextBox.Focus();
        }

        private void VBStoSQLButton_Click(object sender, EventArgs e)
        {
            this.mainTextBox.Text = TextHelper.formatVBStoSQL(this.mainTextBox.Text);
            this.mainTextBox.SelectAll();
            this.mainTextBox.Focus();
        }

        private void mainTextBox_TextChanged(object sender, EventArgs e)
        {
            //replace LF with CR+LF
            this.mainTextBox.Text = this.mainTextBox.Text.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n");
        }

        private void mainTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (sender != null)
                    ((TextBox)sender).SelectAll();
            }
        }
    }
}
