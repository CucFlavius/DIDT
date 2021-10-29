using DarkUI.Controls;
using DarkUI.Forms;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DIDT
{
    public partial class MainWindow : DarkForm
    {
        bool allowResizeAllCorners = true;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        int activeTab = 0;
        ResourceRepository repo;
        const string RESOURCE_REPOSITORY_NAME = "resource.repository";

        public MainWindow()
        {
            InitializeComponent();
            Initialize();
            Debug.Initialize(new Progress<string>(AppendLogText));
            DataTool.Initialize(new Progress<int>(SetProgressBarPercent));
        }

        private void AppendLogText(string text)
        {
            var listViewItem = new DarkListItem(text);
            this.logList.Items.Add(listViewItem);
            this.logList.SelectItem(this.logList.Items.Count - 1);
            this.logList.EnsureVisible();
        }

        public void Initialize()
        {
            this.comboBox_PatchListOSType.DataSource = Enum.GetValues(typeof(DataTool.OSType));
            this.comboBox_PatchListGameVersion.DataSource = Enum.GetValues(typeof(DataTool.GameVersion));
            this.logList
                .GetType()
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(this.logList, true, null);
            this.comboBox_PatchListOSType.SelectedIndex = 0;
            this.comboBox_PatchListGameVersion.SelectedIndex = 0;
        }

        public string GetPatchListPath()
        {
            return this.textBox_PatchListPath.Text;
        }

        public string GetOSTypeString()
        {
            var osTypeSelectedItem = comboBox_PatchListOSType.SelectedItem;
            if (osTypeSelectedItem == null) return "UnknownOS";
            return ((DataTool.OSType)(osTypeSelectedItem)).ToString();
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

        private void SetProgressBarPercent(int percent)
        {
            progressBar1.Value = percent;
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
                if (gameVersionStr.Contains("CN"))
                {
                    textBox_PatchListPath.Text = DataTool.updateDomainURLCN + @"pl/patchlist_" + osTypeStr.ToLower() + "_" + gameVersionStr;
                }
                else
                {
                    textBox_PatchListPath.Text = DataTool.updateDomainURL + @"pl/patchlist_" + osTypeStr.ToLower() + "_" + gameVersionStr;
                }
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            foreach (Control Control in this.panelTitleBar.Controls)
            {
                if (!(Control is Button)) //Change here depending on the Library you use for your contols
                {
                    Control.MouseDown += new MouseEventHandler(this.TitlebarDrag);
                }
            }
        }

        void TitlebarDrag(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (allowResizeAllCorners)
            {
                if (m.Msg == 0x84)
                {
                    const int resizeArea = 10;
                    Point cursorPosition = PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (cursorPosition.X >= ClientSize.Width - resizeArea && cursorPosition.Y >= ClientSize.Height - resizeArea)
                    {
                        m.Result = (IntPtr)17; //HTBOTTOMRIGHT
                        return;
                    }
                    else if (cursorPosition.X <= resizeArea && cursorPosition.Y >= ClientSize.Height - resizeArea)
                    {
                        m.Result = (IntPtr)16; //HTBOTTOMLEFT
                        return;
                    }
                    else if (cursorPosition.X <= resizeArea)
                    {
                        m.Result = (IntPtr)10; //HTLEFT
                        return;
                    }
                    else if (cursorPosition.X >= ClientSize.Width - resizeArea)
                    {
                        m.Result = (IntPtr)11; //HTRIGHT
                        return;
                    }
                    else if (cursorPosition.Y >= ClientSize.Height - resizeArea)
                    {
                        m.Result = (IntPtr)15; //HTBOTTOM
                        return;
                    }
                }
            }
            else
            {
                if (m.Msg == 0x84)
                {
                    const int resizeArea = 10;
                    Point cursorPosition = PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (cursorPosition.X >= ClientSize.Width - resizeArea && cursorPosition.Y >= ClientSize.Height - resizeArea)
                    {
                        m.Result = (IntPtr)17;
                        return;
                    }
                }
            }
            base.WndProc(ref m);
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            TitlebarDrag(sender, e);
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void buttonMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox_PatchListOSType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePatchListString();
        }

        private void comboBox_PatchListGameVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePatchListString();
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

        private void button_GetPatchList_Click(object sender, EventArgs e)
        {
            if (DataTool.running)
            {
                this.button_GetPatchList.Text = "Start";
                DataTool.running = false;
                DataTool.EndSession();
            }
            else
            {
                this.button_GetPatchList.Text = "Stop";
                DataTool.running = true;
                DataTool.BeginSession();
            }
        }

        void ChangeTab(int newTabIndex)
        {
            if (activeTab != newTabIndex)
            {
                switch (activeTab)
                {
                    case 0:
                        buttonTab0.BackColor = Color.FromArgb(37, 37, 38);
                        tab0.Hide();
                        break;
                    case 1:
                        buttonTab1.BackColor = Color.FromArgb(37, 37, 38);
                        tab1.Hide();
                        break;
                    default:
                        break;
                }

                switch (newTabIndex)
                {
                    case 0:
                        buttonTab0.BackColor = Color.FromArgb(45, 45, 48);
                        tab0.Show();
                        break;
                    case 1:
                        buttonTab1.BackColor = Color.FromArgb(45, 45, 48);
                        tab1.Show();
                        break;
                    default:
                        break;
                }

                activeTab = newTabIndex;
            }
        }

        private void buttonTab0_Click(object sender, EventArgs e)
        {
            ChangeTab(0);
        }

        private void buttonTab1_Click(object sender, EventArgs e)
        {
            ChangeTab(1);
        }

        void CreateResourceRepo()
        {
            string osTypeString = Program.window.GetOSTypeString();
            string gameVersionString = Program.window.GetGameVersionString();
            string dataPath = AppContext.BaseDirectory + @"\Data_" + gameVersionString + "_" + osTypeString + @"\";
            string resourceRepoPath = dataPath + "\\" + RESOURCE_REPOSITORY_NAME;
            repo = new ResourceRepository(resourceRepoPath, new Progress<int>(SetProgressBarPercent));
        }

        private void buttonSortFiles_Click(object sender, EventArgs e)
        {
            if (repo == null)
            {
                CreateResourceRepo();
            }

            if (repo.running)
            {
                this.buttonSortFiles.Text = "Start";
                repo.running = false;

                repo.StopWork();
            }
            else
            {
                this.buttonSortFiles.Text = "Stop";
                repo.running = true;

                string osTypeString = Program.window.GetOSTypeString();
                string gameVersionString = Program.window.GetGameVersionString();
                string dataPath = AppContext.BaseDirectory + @"\Data_" + gameVersionString + "_" + osTypeString + @"\";
                repo.SortFiles(dataPath);
            }
        }

        private void buttonDecompressFiles_Click(object sender, EventArgs e)
        {
            if (repo == null)
            {
                CreateResourceRepo();
            }

            if (repo.running)
            {
                this.buttonDecompressFiles.Text = "Start";
                repo.running = false;

                repo.StopWork();
            }
            else
            {
                this.buttonDecompressFiles.Text = "Stop";
                repo.running = true;

                repo.DecompressFiles();
            }
        }
    }
}
