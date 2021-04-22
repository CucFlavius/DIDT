
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
            this.components = new System.ComponentModel.Container();
            this.button_GetPatchList = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBox_PatchListPath = new System.Windows.Forms.TextBox();
            this.comboBox_PatchListOSType = new System.Windows.Forms.ComboBox();
            this.comboBox_PatchListGameVersion = new System.Windows.Forms.ComboBox();
            this.checkBox_PatchListCustom = new System.Windows.Forms.CheckBox();
            this.listView_Log = new System.Windows.Forms.ListView();
            this.Log = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // button_GetPatchList
            // 
            this.button_GetPatchList.Location = new System.Drawing.Point(12, 12);
            this.button_GetPatchList.Name = "button_GetPatchList";
            this.button_GetPatchList.Size = new System.Drawing.Size(118, 51);
            this.button_GetPatchList.TabIndex = 0;
            this.button_GetPatchList.Text = "Go";
            this.button_GetPatchList.UseVisualStyleBackColor = true;
            this.button_GetPatchList.Click += new System.EventHandler(this.button_GetPatchList_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 70);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(760, 21);
            this.progressBar1.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBox_PatchListPath
            // 
            this.textBox_PatchListPath.Enabled = false;
            this.textBox_PatchListPath.Location = new System.Drawing.Point(136, 41);
            this.textBox_PatchListPath.Name = "textBox_PatchListPath";
            this.textBox_PatchListPath.ReadOnly = true;
            this.textBox_PatchListPath.Size = new System.Drawing.Size(436, 23);
            this.textBox_PatchListPath.TabIndex = 4;
            // 
            // comboBox_PatchListOSType
            // 
            this.comboBox_PatchListOSType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_PatchListOSType.FormattingEnabled = true;
            this.comboBox_PatchListOSType.Location = new System.Drawing.Point(392, 12);
            this.comboBox_PatchListOSType.Name = "comboBox_PatchListOSType";
            this.comboBox_PatchListOSType.Size = new System.Drawing.Size(106, 23);
            this.comboBox_PatchListOSType.TabIndex = 6;
            this.comboBox_PatchListOSType.SelectedIndexChanged += new System.EventHandler(this.comboBox_PatchListOSType_SelectedIndexChanged);
            // 
            // comboBox_PatchListGameVersion
            // 
            this.comboBox_PatchListGameVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_PatchListGameVersion.FormattingEnabled = true;
            this.comboBox_PatchListGameVersion.Location = new System.Drawing.Point(136, 12);
            this.comboBox_PatchListGameVersion.Name = "comboBox_PatchListGameVersion";
            this.comboBox_PatchListGameVersion.Size = new System.Drawing.Size(250, 23);
            this.comboBox_PatchListGameVersion.TabIndex = 7;
            this.comboBox_PatchListGameVersion.SelectedIndexChanged += new System.EventHandler(this.comboBox_PatchListGameVersion_SelectedIndexChanged);
            // 
            // checkBox_PatchListCustom
            // 
            this.checkBox_PatchListCustom.AutoSize = true;
            this.checkBox_PatchListCustom.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBox_PatchListCustom.Location = new System.Drawing.Point(504, 14);
            this.checkBox_PatchListCustom.Name = "checkBox_PatchListCustom";
            this.checkBox_PatchListCustom.Size = new System.Drawing.Size(68, 19);
            this.checkBox_PatchListCustom.TabIndex = 8;
            this.checkBox_PatchListCustom.Text = "Custom";
            this.checkBox_PatchListCustom.UseVisualStyleBackColor = true;
            this.checkBox_PatchListCustom.CheckedChanged += new System.EventHandler(this.checkBox_PatchListCustom_CheckedChanged);
            // 
            // listView_Log
            // 
            this.listView_Log.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.listView_Log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView_Log.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Log});
            this.listView_Log.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.listView_Log.HideSelection = false;
            this.listView_Log.Location = new System.Drawing.Point(12, 97);
            this.listView_Log.Name = "listView_Log";
            this.listView_Log.Size = new System.Drawing.Size(760, 452);
            this.listView_Log.TabIndex = 9;
            this.listView_Log.UseCompatibleStateImageBehavior = false;
            this.listView_Log.View = System.Windows.Forms.View.Details;
            // 
            // Log
            // 
            this.Log.Text = "Log";
            this.Log.Width = 755;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.listView_Log);
            this.Controls.Add(this.checkBox_PatchListCustom);
            this.Controls.Add(this.comboBox_PatchListGameVersion);
            this.Controls.Add(this.comboBox_PatchListOSType);
            this.Controls.Add(this.textBox_PatchListPath);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button_GetPatchList);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainWindow";
            this.Text = "Diablo Immortal Data Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_GetPatchList;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBox_PatchListPath;
        private System.Windows.Forms.ComboBox comboBox_PatchListOSType;
        private System.Windows.Forms.ComboBox comboBox_PatchListGameVersion;
        private System.Windows.Forms.CheckBox checkBox_PatchListCustom;
        private System.Windows.Forms.ListView listView_Log;
        private System.Windows.Forms.ColumnHeader Log;
    }
}

