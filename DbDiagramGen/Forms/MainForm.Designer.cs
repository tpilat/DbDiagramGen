
namespace DbDiagramGen.Forms
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
			this.CreateDbModelButton = new System.Windows.Forms.Button();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.FilePathTextBox = new System.Windows.Forms.TextBox();
			this.ButtonBrowse = new System.Windows.Forms.Button();
			this.FilePathLabel = new System.Windows.Forms.Label();
			this.MainPanel = new System.Windows.Forms.Panel();
			this.LoadButton = new System.Windows.Forms.Button();
			this.UseAutoRoutingLineStyleCheckBox = new System.Windows.Forms.CheckBox();
			this.MainPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// CreateDbModelButton
			// 
			this.CreateDbModelButton.Location = new System.Drawing.Point(418, 79);
			this.CreateDbModelButton.Name = "CreateDbModelButton";
			this.CreateDbModelButton.Size = new System.Drawing.Size(117, 39);
			this.CreateDbModelButton.TabIndex = 0;
			this.CreateDbModelButton.Text = "Create db model";
			this.CreateDbModelButton.UseVisualStyleBackColor = true;
			this.CreateDbModelButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// OpenFileDialog
			// 
			this.OpenFileDialog.FileName = "Open IRIS Export";
			// 
			// FilePathTextBox
			// 
			this.FilePathTextBox.Location = new System.Drawing.Point(20, 41);
			this.FilePathTextBox.Name = "FilePathTextBox";
			this.FilePathTextBox.Size = new System.Drawing.Size(418, 20);
			this.FilePathTextBox.TabIndex = 1;
			// 
			// ButtonBrowse
			// 
			this.ButtonBrowse.Location = new System.Drawing.Point(460, 38);
			this.ButtonBrowse.Name = "ButtonBrowse";
			this.ButtonBrowse.Size = new System.Drawing.Size(75, 25);
			this.ButtonBrowse.TabIndex = 2;
			this.ButtonBrowse.Text = "Browse";
			this.ButtonBrowse.UseVisualStyleBackColor = true;
			this.ButtonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
			// 
			// FilePathLabel
			// 
			this.FilePathLabel.AutoSize = true;
			this.FilePathLabel.Location = new System.Drawing.Point(17, 21);
			this.FilePathLabel.Name = "FilePathLabel";
			this.FilePathLabel.Size = new System.Drawing.Size(132, 13);
			this.FilePathLabel.TabIndex = 3;
			this.FilePathLabel.Text = "JSON db settings file path:";
			// 
			// MainPanel
			// 
			this.MainPanel.Controls.Add(this.LoadButton);
			this.MainPanel.Controls.Add(this.UseAutoRoutingLineStyleCheckBox);
			this.MainPanel.Controls.Add(this.ButtonBrowse);
			this.MainPanel.Controls.Add(this.FilePathLabel);
			this.MainPanel.Controls.Add(this.CreateDbModelButton);
			this.MainPanel.Controls.Add(this.FilePathTextBox);
			this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPanel.Location = new System.Drawing.Point(0, 0);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(558, 139);
			this.MainPanel.TabIndex = 4;
			// 
			// LoadButton
			// 
			this.LoadButton.Location = new System.Drawing.Point(246, 79);
			this.LoadButton.Name = "LoadButton";
			this.LoadButton.Size = new System.Drawing.Size(166, 39);
			this.LoadButton.TabIndex = 10;
			this.LoadButton.Text = "DEBUG: Load EA Repository";
			this.LoadButton.UseVisualStyleBackColor = true;
			this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
			// 
			// UseAutoRoutingLineStyleCheckBox
			// 
			this.UseAutoRoutingLineStyleCheckBox.AutoSize = true;
			this.UseAutoRoutingLineStyleCheckBox.Location = new System.Drawing.Point(20, 91);
			this.UseAutoRoutingLineStyleCheckBox.Name = "UseAutoRoutingLineStyleCheckBox";
			this.UseAutoRoutingLineStyleCheckBox.Size = new System.Drawing.Size(147, 17);
			this.UseAutoRoutingLineStyleCheckBox.TabIndex = 9;
			this.UseAutoRoutingLineStyleCheckBox.Text = "Use auto-routing line style";
			this.UseAutoRoutingLineStyleCheckBox.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(558, 139);
			this.Controls.Add(this.MainPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Generate db diagram based on json settings";
			this.MainPanel.ResumeLayout(false);
			this.MainPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button CreateDbModelButton;
		private System.Windows.Forms.OpenFileDialog OpenFileDialog;
		private System.Windows.Forms.TextBox FilePathTextBox;
		private System.Windows.Forms.Button ButtonBrowse;
		private System.Windows.Forms.Label FilePathLabel;
		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.CheckBox UseAutoRoutingLineStyleCheckBox;
		private System.Windows.Forms.Button LoadButton;
	}
}