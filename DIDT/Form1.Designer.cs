
using System;

namespace DIDT
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.titleBar = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonMaximize = new System.Windows.Forms.Button();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.titleText = new DarkUI.Controls.DarkLabel();
            this.tabButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonTab0 = new System.Windows.Forms.Button();
            this.buttonTab1 = new System.Windows.Forms.Button();
            this.tabHolder = new System.Windows.Forms.Panel();
            this.tab1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDecompressFiles = new DarkUI.Controls.DarkButton();
            this.darkLabel3 = new DarkUI.Controls.DarkLabel();
            this.buttonSortFiles = new DarkUI.Controls.DarkButton();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.tab0 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new DarkUI.Controls.DarkLabel();
            this.button_GetPatchList = new DarkUI.Controls.DarkButton();
            this.textBox_PatchListPath = new DarkUI.Controls.DarkTextBox();
            this.checkBox_PatchListCustom = new DarkUI.Controls.DarkCheckBox();
            this.comboBox_PatchListGameVersion = new DarkUI.Controls.DarkComboBox();
            this.comboBox_PatchListOSType = new DarkUI.Controls.DarkComboBox();
            this.logPanel = new System.Windows.Forms.TableLayoutPanel();
            this.log = new System.Windows.Forms.TableLayoutPanel();
            this.logList = new DarkUI.Controls.DarkListView();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panelMain.SuspendLayout();
            this.titleBar.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.tabButtons.SuspendLayout();
            this.tabHolder.SuspendLayout();
            this.tab1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tab0.SuspendLayout();
            this.panel2.SuspendLayout();
            this.logPanel.SuspendLayout();
            this.log.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.titleBar, 0, 0);
            this.panelMain.Controls.Add(this.tabButtons, 0, 1);
            this.panelMain.Controls.Add(this.tabHolder, 0, 2);
            this.panelMain.Controls.Add(this.logPanel, 0, 3);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(2, 2);
            this.panelMain.Margin = new System.Windows.Forms.Padding(0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 4;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Size = new System.Drawing.Size(1027, 567);
            this.panelMain.TabIndex = 11;
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.titleBar.ColumnCount = 2;
            this.titleBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.titleBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.titleBar.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.titleBar.Controls.Add(this.panelTitleBar, 0, 0);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Margin = new System.Windows.Forms.Padding(0);
            this.titleBar.Name = "titleBar";
            this.titleBar.RowCount = 1;
            this.titleBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.titleBar.Size = new System.Drawing.Size(1027, 30);
            this.titleBar.TabIndex = 11;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonClose);
            this.flowLayoutPanel1.Controls.Add(this.buttonMaximize);
            this.flowLayoutPanel1.Controls.Add(this.buttonMinimize);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(937, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(90, 30);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonClose
            // 
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonClose.Location = new System.Drawing.Point(60, 0);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(30, 30);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonMaximize
            // 
            this.buttonMaximize.FlatAppearance.BorderSize = 0;
            this.buttonMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaximize.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonMaximize.Location = new System.Drawing.Point(30, 0);
            this.buttonMaximize.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMaximize.Name = "buttonMaximize";
            this.buttonMaximize.Size = new System.Drawing.Size(30, 30);
            this.buttonMaximize.TabIndex = 5;
            this.buttonMaximize.Text = "□";
            this.buttonMaximize.UseVisualStyleBackColor = false;
            this.buttonMaximize.Click += new System.EventHandler(this.buttonMaximize_Click);
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.FlatAppearance.BorderSize = 0;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonMinimize.Location = new System.Drawing.Point(0, 0);
            this.buttonMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(30, 30);
            this.buttonMinimize.TabIndex = 4;
            this.buttonMinimize.Text = "_";
            this.buttonMinimize.UseVisualStyleBackColor = false;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.Controls.Add(this.titleText);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Margin = new System.Windows.Forms.Padding(0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Padding = new System.Windows.Forms.Padding(9);
            this.panelTitleBar.Size = new System.Drawing.Size(937, 30);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // titleText
            // 
            this.titleText.AutoSize = true;
            this.titleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.titleText.Location = new System.Drawing.Point(9, 9);
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(180, 15);
            this.titleText.TabIndex = 0;
            this.titleText.Text = "DIDT - Diablo Immortal Data Tool";
            // 
            // tabButtons
            // 
            this.tabButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabButtons.Controls.Add(this.buttonTab0);
            this.tabButtons.Controls.Add(this.buttonTab1);
            this.tabButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabButtons.Location = new System.Drawing.Point(0, 30);
            this.tabButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tabButtons.Name = "tabButtons";
            this.tabButtons.Padding = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.tabButtons.Size = new System.Drawing.Size(1027, 30);
            this.tabButtons.TabIndex = 12;
            // 
            // buttonTab0
            // 
            this.buttonTab0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.buttonTab0.FlatAppearance.BorderSize = 0;
            this.buttonTab0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTab0.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonTab0.Location = new System.Drawing.Point(8, 3);
            this.buttonTab0.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTab0.Name = "buttonTab0";
            this.buttonTab0.Size = new System.Drawing.Size(80, 30);
            this.buttonTab0.TabIndex = 5;
            this.buttonTab0.Text = "Download";
            this.buttonTab0.UseVisualStyleBackColor = false;
            this.buttonTab0.Click += new System.EventHandler(this.buttonTab0_Click);
            // 
            // buttonTab1
            // 
            this.buttonTab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.buttonTab1.FlatAppearance.BorderSize = 0;
            this.buttonTab1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTab1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonTab1.Location = new System.Drawing.Point(88, 3);
            this.buttonTab1.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTab1.Name = "buttonTab1";
            this.buttonTab1.Size = new System.Drawing.Size(80, 30);
            this.buttonTab1.TabIndex = 6;
            this.buttonTab1.Text = "Extra";
            this.buttonTab1.UseVisualStyleBackColor = false;
            this.buttonTab1.Click += new System.EventHandler(this.buttonTab1_Click);
            // 
            // tabHolder
            // 
            this.tabHolder.Controls.Add(this.tab1);
            this.tabHolder.Controls.Add(this.tab0);
            this.tabHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabHolder.Location = new System.Drawing.Point(4, 60);
            this.tabHolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.tabHolder.Name = "tabHolder";
            this.tabHolder.Size = new System.Drawing.Size(1019, 116);
            this.tabHolder.TabIndex = 13;
            // 
            // tab1
            // 
            this.tab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tab1.ColumnCount = 1;
            this.tab1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tab1.Controls.Add(this.panel1, 0, 0);
            this.tab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab1.Location = new System.Drawing.Point(0, 0);
            this.tab1.Margin = new System.Windows.Forms.Padding(0);
            this.tab1.Name = "tab1";
            this.tab1.RowCount = 1;
            this.tab1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tab1.Size = new System.Drawing.Size(1019, 116);
            this.tab1.TabIndex = 13;
            this.tab1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panel1.Controls.Add(this.buttonDecompressFiles);
            this.panel1.Controls.Add(this.darkLabel3);
            this.panel1.Controls.Add(this.buttonSortFiles);
            this.panel1.Controls.Add(this.darkLabel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1013, 114);
            this.panel1.TabIndex = 14;
            // 
            // buttonDecompressFiles
            // 
            this.buttonDecompressFiles.Location = new System.Drawing.Point(3, 71);
            this.buttonDecompressFiles.Name = "buttonDecompressFiles";
            this.buttonDecompressFiles.Padding = new System.Windows.Forms.Padding(5);
            this.buttonDecompressFiles.Size = new System.Drawing.Size(79, 24);
            this.buttonDecompressFiles.TabIndex = 16;
            this.buttonDecompressFiles.Text = "Start";
            this.buttonDecompressFiles.Click += new System.EventHandler(this.buttonDecompressFiles_Click);
            // 
            // darkLabel3
            // 
            this.darkLabel3.AutoSize = true;
            this.darkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel3.Location = new System.Drawing.Point(3, 53);
            this.darkLabel3.Name = "darkLabel3";
            this.darkLabel3.Size = new System.Drawing.Size(567, 15);
            this.darkLabel3.TabIndex = 15;
            this.darkLabel3.Text = "2. Decompress all files (that are compressed with LZ4, except textures which are " +
    "compressed per mip level)";
            // 
            // buttonSortFiles
            // 
            this.buttonSortFiles.Location = new System.Drawing.Point(3, 21);
            this.buttonSortFiles.Name = "buttonSortFiles";
            this.buttonSortFiles.Padding = new System.Windows.Forms.Padding(5);
            this.buttonSortFiles.Size = new System.Drawing.Size(79, 24);
            this.buttonSortFiles.TabIndex = 13;
            this.buttonSortFiles.Text = "Start";
            this.buttonSortFiles.Click += new System.EventHandler(this.buttonSortFiles_Click);
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(2, 3);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(329, 15);
            this.darkLabel2.TabIndex = 14;
            this.darkLabel2.Text = "1. Sort and rename the files based on resource.repository info";
            // 
            // tab0
            // 
            this.tab0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tab0.ColumnCount = 1;
            this.tab0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tab0.Controls.Add(this.panel2, 0, 0);
            this.tab0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab0.Location = new System.Drawing.Point(0, 0);
            this.tab0.Margin = new System.Windows.Forms.Padding(0);
            this.tab0.Name = "tab0";
            this.tab0.RowCount = 1;
            this.tab0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tab0.Size = new System.Drawing.Size(1019, 116);
            this.tab0.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button_GetPatchList);
            this.panel2.Controls.Add(this.textBox_PatchListPath);
            this.panel2.Controls.Add(this.checkBox_PatchListCustom);
            this.panel2.Controls.Add(this.comboBox_PatchListGameVersion);
            this.panel2.Controls.Add(this.comboBox_PatchListOSType);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1013, 110);
            this.panel2.TabIndex = 13;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(589, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Download the data from the server and assemble it into the same file structure as" +
    " it exists on the mobile device";
            // 
            // button_GetPatchList
            // 
            this.button_GetPatchList.Location = new System.Drawing.Point(2, 18);
            this.button_GetPatchList.Name = "button_GetPatchList";
            this.button_GetPatchList.Padding = new System.Windows.Forms.Padding(5);
            this.button_GetPatchList.Size = new System.Drawing.Size(80, 53);
            this.button_GetPatchList.TabIndex = 13;
            this.button_GetPatchList.Text = "Start";
            this.button_GetPatchList.Click += new System.EventHandler(this.button_GetPatchList_Click);
            // 
            // textBox_PatchListPath
            // 
            this.textBox_PatchListPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.textBox_PatchListPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PatchListPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.textBox_PatchListPath.Location = new System.Drawing.Point(88, 48);
            this.textBox_PatchListPath.Name = "textBox_PatchListPath";
            this.textBox_PatchListPath.ReadOnly = true;
            this.textBox_PatchListPath.Size = new System.Drawing.Size(337, 23);
            this.textBox_PatchListPath.TabIndex = 12;
            // 
            // checkBox_PatchListCustom
            // 
            this.checkBox_PatchListCustom.AutoSize = true;
            this.checkBox_PatchListCustom.Location = new System.Drawing.Point(431, 49);
            this.checkBox_PatchListCustom.Name = "checkBox_PatchListCustom";
            this.checkBox_PatchListCustom.Size = new System.Drawing.Size(68, 19);
            this.checkBox_PatchListCustom.TabIndex = 11;
            this.checkBox_PatchListCustom.Text = "Custom";
            this.checkBox_PatchListCustom.CheckedChanged += new System.EventHandler(this.checkBox_PatchListCustom_CheckedChanged);
            // 
            // comboBox_PatchListGameVersion
            // 
            this.comboBox_PatchListGameVersion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBox_PatchListGameVersion.FormattingEnabled = true;
            this.comboBox_PatchListGameVersion.Location = new System.Drawing.Point(88, 18);
            this.comboBox_PatchListGameVersion.Name = "comboBox_PatchListGameVersion";
            this.comboBox_PatchListGameVersion.Size = new System.Drawing.Size(210, 24);
            this.comboBox_PatchListGameVersion.TabIndex = 10;
            this.comboBox_PatchListGameVersion.SelectedIndexChanged += new System.EventHandler(this.comboBox_PatchListGameVersion_SelectedIndexChanged);
            // 
            // comboBox_PatchListOSType
            // 
            this.comboBox_PatchListOSType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBox_PatchListOSType.FormattingEnabled = true;
            this.comboBox_PatchListOSType.Location = new System.Drawing.Point(304, 18);
            this.comboBox_PatchListOSType.Name = "comboBox_PatchListOSType";
            this.comboBox_PatchListOSType.Size = new System.Drawing.Size(121, 24);
            this.comboBox_PatchListOSType.TabIndex = 9;
            this.comboBox_PatchListOSType.SelectedIndexChanged += new System.EventHandler(this.comboBox_PatchListOSType_SelectedIndexChanged);
            // 
            // logPanel
            // 
            this.logPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.logPanel.ColumnCount = 1;
            this.logPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.logPanel.Controls.Add(this.log, 0, 1);
            this.logPanel.Controls.Add(this.progressBar1, 0, 0);
            this.logPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logPanel.Location = new System.Drawing.Point(3, 183);
            this.logPanel.Name = "logPanel";
            this.logPanel.RowCount = 2;
            this.logPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.logPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.logPanel.Size = new System.Drawing.Size(1021, 381);
            this.logPanel.TabIndex = 14;
            // 
            // log
            // 
            this.log.ColumnCount = 1;
            this.log.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.log.Controls.Add(this.logList, 0, 1);
            this.log.Controls.Add(this.darkLabel1, 0, 0);
            this.log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.log.Location = new System.Drawing.Point(0, 15);
            this.log.Margin = new System.Windows.Forms.Padding(0);
            this.log.Name = "log";
            this.log.RowCount = 2;
            this.log.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.log.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.log.Size = new System.Drawing.Size(1021, 366);
            this.log.TabIndex = 15;
            // 
            // logList
            // 
            this.logList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logList.Location = new System.Drawing.Point(0, 20);
            this.logList.Margin = new System.Windows.Forms.Padding(0);
            this.logList.Name = "logList";
            this.logList.Size = new System.Drawing.Size(1021, 346);
            this.logList.TabIndex = 11;
            this.logList.Text = "darkListView1";
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(3, 0);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(1015, 20);
            this.darkLabel1.TabIndex = 12;
            this.darkLabel1.Text = "Log";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(3, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1015, 9);
            this.progressBar1.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1031, 571);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(8000, 6000);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(80, 80);
            this.Name = "MainWindow";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "Diablo Immortal Data Tool";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.panelMain.ResumeLayout(false);
            this.titleBar.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.tabButtons.ResumeLayout(false);
            this.tabHolder.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tab0.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.logPanel.ResumeLayout(false);
            this.log.ResumeLayout(false);
            this.log.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.TableLayoutPanel titleBar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelTitleBar;
        private DarkUI.Controls.DarkLabel titleText;
        private System.Windows.Forms.FlowLayoutPanel tabButtons;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.Button buttonMaximize;
        private System.Windows.Forms.Button buttonTab0;
        private System.Windows.Forms.Button buttonTab1;
        private System.Windows.Forms.Panel tabHolder;
        private System.Windows.Forms.TableLayoutPanel tab0;
        private System.Windows.Forms.Panel panel2;
        private DarkUI.Controls.DarkComboBox comboBox_PatchListOSType;
        private DarkUI.Controls.DarkComboBox comboBox_PatchListGameVersion;
        private DarkUI.Controls.DarkCheckBox checkBox_PatchListCustom;
        private DarkUI.Controls.DarkTextBox textBox_PatchListPath;
        private DarkUI.Controls.DarkButton button_GetPatchList;
        private DarkUI.Controls.DarkLabel label1;
        private System.Windows.Forms.TableLayoutPanel tab1;
        private System.Windows.Forms.Panel panel1;
        private DarkUI.Controls.DarkButton buttonDecompressFiles;
        private DarkUI.Controls.DarkLabel darkLabel3;
        private DarkUI.Controls.DarkButton buttonSortFiles;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private System.Windows.Forms.TableLayoutPanel logPanel;
        private System.Windows.Forms.TableLayoutPanel log;
        private DarkUI.Controls.DarkListView logList;
        private DarkUI.Controls.DarkLabel darkLabel1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

