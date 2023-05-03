using Envelope.Database.Internal;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DbDiagramGen.Forms
{
	public partial class MainForm : Form
	{
		private readonly EA.Repository _repository;

		public MainForm(EA.Repository repository)
		{
			_repository = repository;
			InitializeComponent();
			Text = $"Generate db diagram based on json settings - v{GetType().Assembly?.GetName()?.Version}";
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			FilePathTextBox.Text = FilePathTextBox.Text.Trim();

			if (string.IsNullOrWhiteSpace(FilePathTextBox.Text))
			{
				var infoForm = new InfoForm("Enter JSON db settings file path.");
				infoForm.ShowDialog(this);
				return;
			}

			if (!File.Exists(FilePathTextBox.Text))
			{
				var infoForm = new InfoForm("JSON db settings file does not exists.");
				infoForm.ShowDialog(this);
				return;
			}

			var json = File.ReadAllText(FilePathTextBox.Text, new UTF8Encoding(false));
			var _config = Envelope.Database.Config.Model.LoadFromJson(json);
			var databaseModelFactory = new DatabaseModelFactory();
			var isOK = databaseModelFactory.TryCreate(_config, out var model, true);

			var generator = new DbGenerator(
				model,
				_repository,
				new DbGenertorConfig
				{
					UseAutoRoutingLineStyle = UseAutoRoutingLineStyleCheckBox.Checked
				});
			var genErrors = generator.Generate();

			if (string.IsNullOrWhiteSpace(genErrors))
			{
				var infoForm = new InfoForm("OK");
				infoForm.ShowDialog(this);
			}
			else
			{
				var infoForm = new InfoForm(genErrors);
				infoForm.ShowDialog(this);
			}
		}

		private void ButtonBrowse_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				//openFileDialog.InitialDirectory = "c:\\";
				openFileDialog.Filter = "DB model (*.json)|*.json";
				openFileDialog.FilterIndex = 2;
				openFileDialog.RestoreDirectory = true;

				if (openFileDialog.ShowDialog() == DialogResult.OK)
					FilePathTextBox.Text = openFileDialog.FileName;
			}
		}

		private void LoadButton_Click(object sender, EventArgs e)
		{
			var eaRepo = new EAModel.EARepository(_repository);
			eaRepo.Build();
			return;
		}
	}
}
