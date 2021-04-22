using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIDT
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            DataTool.Initialize(this);
        }

        public void AppendLogText(string text)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendLogText), new object[] { text });
                return;
            }

            string[] row = { text };
            var listViewItem = new ListViewItem(row);
            this.listView_Log.Items.Add(listViewItem);
            this.listView_Log.Items[this.listView_Log.Items.Count - 1].EnsureVisible();
        }

        public void BeginLogUpdate()
        {
            this.listView_Log.BeginUpdate();
        }

        public void EndLogUpdate()
        {
            this.listView_Log.EndUpdate();
        }

        public void Initialize()
        {
            this.comboBox_PatchListOSType.DataSource = Enum.GetValues(typeof(DataTool.OSType));
            this.comboBox_PatchListGameVersion.DataSource = Enum.GetValues(typeof(DataTool.GameVersion));
            this.listView_Log
                .GetType()
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(this.listView_Log, true, null);
        }

        public string GetPatchListPath()
        {
            return this.textBox_PatchListPath.Text;
        }

        public string GetOSTypeString()
        {
            var osTypeSelectedItem = comboBox_PatchListOSType.SelectedItem;
            if (osTypeSelectedItem == null) return "UnknownOS";

            return ((DataTool.OSType)osTypeSelectedItem).ToString();
        }

        public string GetGameVersionString()
        {

            var gameVersionSelectedItem = comboBox_PatchListGameVersion.SelectedItem;
            if (gameVersionSelectedItem == null) return "UnknownVersion";
            DataTool.GameVersion gameVersion = (DataTool.GameVersion)gameVersionSelectedItem;

            if (DataTool.gameVersionLinkStrings.TryGetValue(gameVersion, out string gameVersionStr))
            {
                return gameVersionStr;
            }

            return "UnknownVersion";
        }

        public void SetProgressBarPercent(int percent)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(SetProgressBarPercent), new object[] { percent });
                return;
            }

            progressBar1.Value = percent;
        }

        private void button_GetPatchList_Click(object sender, EventArgs e)
        {
            DataTool.BeginSession();
        }

        private void comboBox_PatchListOSType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePatchListString();
        }


        private void comboBox_PatchListGameVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePatchListString();
        }

        void UpdatePatchListString()
        {
            var osTypeSelectedItem = comboBox_PatchListOSType.SelectedItem;
            if (osTypeSelectedItem == null) return;
            string osTypeStr = ((DataTool.OSType)osTypeSelectedItem).ToString();

            var gameVersionSelectedItem = comboBox_PatchListGameVersion.SelectedItem;
            if (gameVersionSelectedItem == null) return;
            DataTool.GameVersion gameVersion = (DataTool.GameVersion)gameVersionSelectedItem;

            if (DataTool.gameVersionLinkStrings.TryGetValue(gameVersion, out string gameVersionStr))
            {
                string urlStr = DataTool.updateDomainURL + @"pl/patchlist_" + osTypeStr.ToLower() + "_" + gameVersionStr;
                textBox_PatchListPath.Text = urlStr;
            }
        }

        private void checkBox_PatchListCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_PatchListCustom.Checked)
            {
                comboBox_PatchListOSType.Enabled = false;
                comboBox_PatchListGameVersion.Enabled = false;
                textBox_PatchListPath.Enabled = true;
                textBox_PatchListPath.ReadOnly = false;
            }
            else
            {
                comboBox_PatchListOSType.Enabled = true;
                comboBox_PatchListGameVersion.Enabled = true;
                textBox_PatchListPath.Enabled = false;
                textBox_PatchListPath.ReadOnly = true;
                UpdatePatchListString();
            }
        }
    }
}
