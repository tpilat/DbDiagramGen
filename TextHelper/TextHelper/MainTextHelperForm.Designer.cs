namespace TextHelper
{
    partial class MainTextHelperForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTextHelperForm));
            this.mainTextBox = new System.Windows.Forms.TextBox();
            this.vbScriptQueryButton = new System.Windows.Forms.Button();
            this.VBStoSQLButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainTextBox
            // 
            this.mainTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTextBox.Location = new System.Drawing.Point(12, 41);
            this.mainTextBox.MaxLength = 999999;
            this.mainTextBox.Multiline = true;
            this.mainTextBox.Name = "mainTextBox";
            this.mainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mainTextBox.Size = new System.Drawing.Size(981, 666);
            this.mainTextBox.TabIndex = 0;
            this.mainTextBox.WordWrap = false;
            this.mainTextBox.TextChanged += new System.EventHandler(this.mainTextBox_TextChanged);
            this.mainTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainTextBox_KeyDown);
            // 
            // vbScriptQueryButton
            // 
            this.vbScriptQueryButton.Location = new System.Drawing.Point(12, 12);
            this.vbScriptQueryButton.Name = "vbScriptQueryButton";
            this.vbScriptQueryButton.Size = new System.Drawing.Size(93, 23);
            this.vbScriptQueryButton.TabIndex = 1;
            this.vbScriptQueryButton.Text = "SQL -> VBS";
            this.vbScriptQueryButton.UseVisualStyleBackColor = true;
            this.vbScriptQueryButton.Click += new System.EventHandler(this.vbScriptQueryButton_Click);
            // 
            // VBStoSQLButton
            // 
            this.VBStoSQLButton.Location = new System.Drawing.Point(111, 12);
            this.VBStoSQLButton.Name = "VBStoSQLButton";
            this.VBStoSQLButton.Size = new System.Drawing.Size(93, 23);
            this.VBStoSQLButton.TabIndex = 1;
            this.VBStoSQLButton.Text = "VBS -> SQL";
            this.VBStoSQLButton.UseVisualStyleBackColor = true;
            this.VBStoSQLButton.Click += new System.EventHandler(this.VBStoSQLButton_Click);
            // 
            // MainTextHelperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 719);
            this.Controls.Add(this.VBStoSQLButton);
            this.Controls.Add(this.vbScriptQueryButton);
            this.Controls.Add(this.mainTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(200, 50);
            this.Name = "MainTextHelperForm";
            this.Text = "TextHelper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox mainTextBox;
        private System.Windows.Forms.Button vbScriptQueryButton;
        private System.Windows.Forms.Button VBStoSQLButton;
    }
}

