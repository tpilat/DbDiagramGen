using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using Microsoft.XmlDiffPatch;


namespace VisualXmlDiff
{
    /// <summary>
    /// Summary description for VisualXmlDiff.
    /// This class draws the main form and then does comparison of two files.
    /// </summary>
    public class VisualXmlDiff : System.Windows.Forms.Form
    {
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnuFile;
        private System.Windows.Forms.MenuItem mnuOptions;
        private System.Windows.Forms.MenuItem menuItem14;
        private System.Windows.Forms.Button compareButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox originalDirectoryTextBox;
        private System.Windows.Forms.TextBox compareDirectoryTextBox;
        private IContainer components;
        public string filename1 = string.Empty;
        public string filename2 = string.Empty;
        private string compareOverviewFile { get; set; }

        XmlDiffOptions diffOptions = new XmlDiffOptions();
        bool compareFragments = false;
        bool ignoreRefTypeDifferences = false;
        XmlDiffAlgorithm algorithm = XmlDiffAlgorithm.Auto;

        public System.Windows.Forms.MenuItem icoOpt;
        private System.Windows.Forms.MenuItem ipiOpt;
        private System.Windows.Forms.MenuItem icOpt;
        private System.Windows.Forms.MenuItem ixdOpt;
        private System.Windows.Forms.MenuItem iwsOpt;
        private System.Windows.Forms.MenuItem idtdOpt;
        private System.Windows.Forms.MenuItem inOpt;
        private System.Windows.Forms.MenuItem ipOpt;
        private System.Windows.Forms.MenuItem fOpt;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem algAuto;
        private System.Windows.Forms.MenuItem algFast;
        private System.Windows.Forms.MenuItem algOptions;
        private TextBox resultsPathTextBox;
        private Button resultsPathButton;
        private ProgressBar progressBar;
        private Label progressLabel;
        private TextBox logTextBox;
        private Button closeButton;
        private Button viewDetailsButton;
        private MenuItem toolsMenu;
        private MenuItem orderAlphabeticallyMenuItem;
        private MenuItem ignoreRefTypeMenuItem;
        private System.Windows.Forms.MenuItem algPrecise;

        public VisualXmlDiff()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private static void ShowUsage()
        {
            Console.WriteLine("xmldiffview [filename1] [filename2]");
        }
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            if (args.Length > 0)
            {
                if (args.Length != 2)
                {
                    ShowUsage();
                    return;
                }
                VisualXmlDiff vxd = new VisualXmlDiff();
                vxd.filename1 = args[0];
                vxd.filename2 = args[1];
                Application.Run(vxd);
            }
            else
            {
                VisualXmlDiff vxd = new VisualXmlDiff();
                Application.Run(vxd);
            }
        }
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mnuFile = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.mnuOptions = new System.Windows.Forms.MenuItem();
            this.icoOpt = new System.Windows.Forms.MenuItem();
            this.ipiOpt = new System.Windows.Forms.MenuItem();
            this.icOpt = new System.Windows.Forms.MenuItem();
            this.ixdOpt = new System.Windows.Forms.MenuItem();
            this.iwsOpt = new System.Windows.Forms.MenuItem();
            this.idtdOpt = new System.Windows.Forms.MenuItem();
            this.inOpt = new System.Windows.Forms.MenuItem();
            this.ipOpt = new System.Windows.Forms.MenuItem();
            this.fOpt = new System.Windows.Forms.MenuItem();
            this.algOptions = new System.Windows.Forms.MenuItem();
            this.algAuto = new System.Windows.Forms.MenuItem();
            this.algPrecise = new System.Windows.Forms.MenuItem();
            this.algFast = new System.Windows.Forms.MenuItem();
            this.toolsMenu = new System.Windows.Forms.MenuItem();
            this.orderAlphabeticallyMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.compareButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.originalDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.compareDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.resultsPathTextBox = new System.Windows.Forms.TextBox();
            this.resultsPathButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.viewDetailsButton = new System.Windows.Forms.Button();
            this.ignoreRefTypeMenuItem = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFile,
            this.mnuOptions,
            this.toolsMenu,
            this.menuItem1});
            // 
            // mnuFile
            // 
            this.mnuFile.Index = 0;
            this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem14});
            this.mnuFile.Text = "File";
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 0;
            this.menuItem14.Text = "Exit";
            this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
            // 
            // mnuOptions
            // 
            this.mnuOptions.Index = 1;
            this.mnuOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.icoOpt,
            this.ipiOpt,
            this.icOpt,
            this.ixdOpt,
            this.iwsOpt,
            this.idtdOpt,
            this.inOpt,
            this.ipOpt,
            this.fOpt,
            this.ignoreRefTypeMenuItem,
            this.algOptions});
            this.mnuOptions.Text = "Diff Options";
            // 
            // icoOpt
            // 
            this.icoOpt.Checked = true;
            this.icoOpt.Index = 0;
            this.icoOpt.Text = "Ignore Child Order";
            this.icoOpt.Click += new System.EventHandler(this.diffOptions_Click);
            // 
            // ipiOpt
            // 
            this.ipiOpt.Index = 1;
            this.ipiOpt.Text = "Ignore Processing Instructions";
            this.ipiOpt.Click += new System.EventHandler(this.diffOptions_Click);
            // 
            // icOpt
            // 
            this.icOpt.Checked = true;
            this.icOpt.Index = 2;
            this.icOpt.Text = "Ignore Comments";
            this.icOpt.Click += new System.EventHandler(this.diffOptions_Click);
            // 
            // ixdOpt
            // 
            this.ixdOpt.Checked = true;
            this.ixdOpt.Index = 3;
            this.ixdOpt.Text = "Ignore Xml Declaration";
            this.ixdOpt.Click += new System.EventHandler(this.diffOptions_Click);
            // 
            // iwsOpt
            // 
            this.iwsOpt.Checked = true;
            this.iwsOpt.Index = 4;
            this.iwsOpt.Text = "Ignore Whitespaces";
            this.iwsOpt.Click += new System.EventHandler(this.diffOptions_Click);
            // 
            // idtdOpt
            // 
            this.idtdOpt.Checked = true;
            this.idtdOpt.Index = 5;
            this.idtdOpt.Text = "Ignore Document Type Declaration (DTD)";
            this.idtdOpt.Click += new System.EventHandler(this.diffOptions_Click);
            // 
            // inOpt
            // 
            this.inOpt.Index = 6;
            this.inOpt.Text = "Ignore Namespaces";
            this.inOpt.Click += new System.EventHandler(this.diffOptions_Click);
            // 
            // ipOpt
            // 
            this.ipOpt.Checked = true;
            this.ipOpt.Index = 7;
            this.ipOpt.Text = "Ignore Prefixes";
            this.ipOpt.Click += new System.EventHandler(this.diffOptions_Click);
            // 
            // fOpt
            // 
            this.fOpt.Index = 8;
            this.fOpt.Text = "Compare Fragments";
            this.fOpt.Click += new System.EventHandler(this.diffOptions_Click);
            // 
            // algOptions
            // 
            this.algOptions.Index = 10;
            this.algOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.algAuto,
            this.algPrecise,
            this.algFast});
            this.algOptions.Text = "Algorithm";
            // 
            // algAuto
            // 
            this.algAuto.Checked = true;
            this.algAuto.Index = 0;
            this.algAuto.RadioCheck = true;
            this.algAuto.Text = "Auto";
            this.algAuto.Click += new System.EventHandler(this.algOptions_Click);
            // 
            // algPrecise
            // 
            this.algPrecise.Index = 1;
            this.algPrecise.RadioCheck = true;
            this.algPrecise.Text = "Greedy";
            this.algPrecise.Click += new System.EventHandler(this.algOptions_Click);
            // 
            // algFast
            // 
            this.algFast.Index = 2;
            this.algFast.RadioCheck = true;
            this.algFast.Text = "Fast";
            this.algFast.Click += new System.EventHandler(this.algOptions_Click);
            // 
            // toolsMenu
            // 
            this.toolsMenu.Index = 2;
            this.toolsMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.orderAlphabeticallyMenuItem});
            this.toolsMenu.Text = "Tools";
            // 
            // orderAlphabeticallyMenuItem
            // 
            this.orderAlphabeticallyMenuItem.Index = 0;
            this.orderAlphabeticallyMenuItem.Text = "Order Alphabetically...";
            this.orderAlphabeticallyMenuItem.Click += new System.EventHandler(this.orderAlphabeticallyMenuItem_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2});
            this.menuItem1.Text = "Help";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "About";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // compareButton
            // 
            this.compareButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.compareButton.Location = new System.Drawing.Point(261, 311);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(73, 23);
            this.compareButton.TabIndex = 6;
            this.compareButton.Text = "Compare";
            this.compareButton.Click += new System.EventHandler(this.Compare_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 24);
            this.button2.TabIndex = 5;
            this.button2.Text = "Compare With ...";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 24);
            this.button1.TabIndex = 4;
            this.button1.Text = "Original ...";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // originalDirectoryTextBox
            // 
            this.originalDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.originalDirectoryTextBox.Location = new System.Drawing.Point(120, 8);
            this.originalDirectoryTextBox.Name = "originalDirectoryTextBox";
            this.originalDirectoryTextBox.Size = new System.Drawing.Size(299, 20);
            this.originalDirectoryTextBox.TabIndex = 8;
            // 
            // compareDirectoryTextBox
            // 
            this.compareDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.compareDirectoryTextBox.Location = new System.Drawing.Point(120, 40);
            this.compareDirectoryTextBox.Name = "compareDirectoryTextBox";
            this.compareDirectoryTextBox.Size = new System.Drawing.Size(299, 20);
            this.compareDirectoryTextBox.TabIndex = 9;
            // 
            // resultsPathTextBox
            // 
            this.resultsPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsPathTextBox.Location = new System.Drawing.Point(120, 70);
            this.resultsPathTextBox.Name = "resultsPathTextBox";
            this.resultsPathTextBox.Size = new System.Drawing.Size(299, 20);
            this.resultsPathTextBox.TabIndex = 11;
            // 
            // resultsPathButton
            // 
            this.resultsPathButton.Location = new System.Drawing.Point(8, 70);
            this.resultsPathButton.Name = "resultsPathButton";
            this.resultsPathButton.Size = new System.Drawing.Size(104, 24);
            this.resultsPathButton.TabIndex = 10;
            this.resultsPathButton.Text = "Results to ...";
            this.resultsPathButton.Click += new System.EventHandler(this.resultsPathButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.ForeColor = System.Drawing.Color.LightGreen;
            this.progressBar.Location = new System.Drawing.Point(8, 100);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(411, 23);
            this.progressBar.Step = 3;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 12;
            // 
            // progressLabel
            // 
            this.progressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(12, 316);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(0, 13);
            this.progressLabel.TabIndex = 13;
            // 
            // logTextBox
            // 
            this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTextBox.Location = new System.Drawing.Point(8, 131);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(411, 170);
            this.logTextBox.TabIndex = 14;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(340, 311);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 15;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // viewDetailsButton
            // 
            this.viewDetailsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.viewDetailsButton.Enabled = false;
            this.viewDetailsButton.Location = new System.Drawing.Point(180, 311);
            this.viewDetailsButton.Name = "viewDetailsButton";
            this.viewDetailsButton.Size = new System.Drawing.Size(75, 23);
            this.viewDetailsButton.TabIndex = 16;
            this.viewDetailsButton.Text = "Details";
            this.viewDetailsButton.UseVisualStyleBackColor = true;
            this.viewDetailsButton.Click += new System.EventHandler(this.viewDetailsButton_Click);
            // 
            // ignoreRefTypeMenuItem
            // 
            this.ignoreRefTypeMenuItem.Index = 9;
            this.ignoreRefTypeMenuItem.Text = "Ignore Ref/Type differences";
            this.ignoreRefTypeMenuItem.Click += new System.EventHandler(this.diffOptions_Click);
            // 
            // VisualXmlDiff
            // 
            this.AcceptButton = this.compareButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(427, 341);
            this.Controls.Add(this.viewDetailsButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.resultsPathTextBox);
            this.Controls.Add(this.resultsPathButton);
            this.Controls.Add(this.compareDirectoryTextBox);
            this.Controls.Add(this.originalDirectoryTextBox);
            this.Controls.Add(this.compareButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Menu = this.mainMenu1;
            this.Name = "VisualXmlDiff";
            this.Text = "XSD Comparer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void menuItem14_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var ofd1 = new FolderBrowserDialog();
            ofd1.ShowDialog();
            originalDirectoryTextBox.Text = ofd1.SelectedPath;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            var ofd1 = new FolderBrowserDialog();
            ofd1.ShowDialog();
            compareDirectoryTextBox.Text = ofd1.SelectedPath;
        }


        /// <summary>
        /// This method basically is invoked when user clicks the 
        /// Compare button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Compare_Click(object sender, System.EventArgs e)
        {
            
            
            //Check if file 1 is safe and valid.
            if (originalDirectoryTextBox.Text == null || originalDirectoryTextBox.Text == string.Empty)
            {
                MessageBox.Show("Original folder not selected, please select");
                return;
            }

            if (!Directory.Exists(originalDirectoryTextBox.Text))
            {
                MessageBox.Show("Original folder1 doesn't exist, please select another file");
                return;
            }

            //Check if file 2 is safe and valid.
            if (compareDirectoryTextBox.Text == null || compareDirectoryTextBox.Text == string.Empty)
            {
                MessageBox.Show("Compare folder not selected, please select");
                return;
            }

            if (!Directory.Exists(compareDirectoryTextBox.Text))
            {
                MessageBox.Show("Compare folder doesn't exist, please select another file");
                return;
            }

            //Check if file 2 is safe and valid.
            if (resultsPathTextBox.Text == null || resultsPathTextBox.Text == string.Empty)
            {
                MessageBox.Show("Results folder not selected, please select");
                return;
            }

            if (!Directory.Exists(resultsPathTextBox.Text))
            {
                MessageBox.Show("Results folder doesn't exist, please select another file");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            this.progressLabel.Text = string.Empty;
            this.progressBar.Value = progressBar.Minimum;
            this.logTextBox.Clear();
            try
            {
                //compare the directories
                this.compareOverviewFile = DoCompare(originalDirectoryTextBox.Text, compareDirectoryTextBox.Text, resultsPathTextBox.Text);
                this.logTextBox.AppendText("Finished!");
            }
            catch (Exception err)
            {
                this.logTextBox.AppendText(err.Message);
            }
            this.viewDetailsButton.Enabled = File.Exists(compareOverviewFile);
            //set progressbar at maximum
            this.progressBar.Value = this.progressBar.Maximum;
            Cursor.Current = Cursors.Default;
        }

        public string DoCompare(string folder1, string folder2, string resultsPath)
        {
            SetDiffOptions();
            var comparer = new XmlComparer();
            comparer.onLogProgress += new EventHandler(this.onLogProgress);
            return comparer.doCompare(folder1, folder2, resultsPath, diffOptions, compareFragments, ignoreRefTypeDifferences, algorithm);
        }

        private void onLogProgress(object sender, EventArgs e)
        {
            //reset if at maximum
            if (progressBar.Value == progressBar.Maximum)
                progressBar.Value = progressBar.Minimum;
            this.progressBar.PerformStep();
            this.logTextBox.AppendText(sender.ToString() + Environment.NewLine);
            //this.logTextBox.Refresh();
        }

        /// <summary>
        /// This method reads the diff options set on the 
        /// menu and configures the XmlDiffOptions object.
        /// </summary>
        private void SetDiffOptions()
        {
            //Reset to None and refresh the options from the menuoptions
            //else eventually all options may get set and the menu changes will
            // not be reflected.
            diffOptions = XmlDiffOptions.None;


            //Read the options settings and OR the XmlDiffOptions enumeration.
            if (ipiOpt.Checked)
                diffOptions = diffOptions | XmlDiffOptions.IgnorePI;

            if (icoOpt.Checked)
                diffOptions = diffOptions | XmlDiffOptions.IgnoreChildOrder;

            if (icOpt.Checked)
                diffOptions = diffOptions | XmlDiffOptions.IgnoreComments;

            if (idtdOpt.Checked)
                diffOptions = diffOptions | XmlDiffOptions.IgnoreDtd;

            if (inOpt.Checked)
                diffOptions = diffOptions | XmlDiffOptions.IgnoreNamespaces;

            if (ipOpt.Checked)
                diffOptions = diffOptions | XmlDiffOptions.IgnorePrefixes;

            if (iwsOpt.Checked)
                diffOptions = diffOptions | XmlDiffOptions.IgnoreWhitespace;

            if (ixdOpt.Checked)
                diffOptions = diffOptions | XmlDiffOptions.IgnoreXmlDecl;

            if (fOpt.Checked)
                compareFragments = true;
            if (ignoreRefTypeMenuItem.Checked)
                ignoreRefTypeDifferences = true;
            //algorithm
            if (algFast.Checked) algorithm = XmlDiffAlgorithm.Fast;
            else if (algPrecise.Checked) algorithm = XmlDiffAlgorithm.Precise;
        }

        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            //MessageBox.Show("Microsoft Corp.\n" + "Copyright 2004");
        }

        //Handler for Diff Options for Ignore Settings.
        private void diffOptions_Click(object sender, System.EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            item.Checked = !item.Checked;
        }

        //Handler for Diff Options for Algorithm setting.
        private void algOptions_Click(object sender, System.EventArgs e)
        {
            System.Windows.Forms.Menu.MenuItemCollection items = algOptions.MenuItems;
            foreach (MenuItem i in items)
                i.Checked = false;
            MenuItem item = (MenuItem)sender;
            item.Checked = true;
        }

        private void resultsPathButton_Click(object sender, EventArgs e)
        {
            var ofd1 = new FolderBrowserDialog();
            ofd1.ShowDialog();
            resultsPathTextBox.Text = ofd1.SelectedPath;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void viewDetailsButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start( this.compareOverviewFile);
        }

        private void orderAlphabeticallyMenuItem_Click(object sender, EventArgs e)
        {
            new OrderAlphabeticallyForm().ShowDialog();
        }

    }
}
