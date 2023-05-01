using System.Windows.Forms;

namespace DbDiagramGen.Forms
{
	public partial class InfoForm : Form
	{
		public InfoForm(string text)
		{
			InitializeComponent();
			RichTextBox.Text = text;
		}
	}
}
