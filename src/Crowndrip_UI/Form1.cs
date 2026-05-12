using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CrownDripExecutor
{
    public partial class MainForm : Form  // Added "partial"
    {
        [DllImport("wearedevs_exploit_api.dll")]
        private static extern void AttachToRoblox();

        [DllImport("wearedevs_exploit_api.dll")]
        private static extern void DetachFromRoblox();

        public MainForm()
        {
            this.Text = "CrownDrip Executor";
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon("icon.ico"); 
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(300, 200);
            
            // Add this line to call the designer initialization
            InitializeComponent();
        }

        private void AttachToRobloxClick(object sender, EventArgs e)
        {
            AttachToRoblox();
            MessageBox.Show("Attached to Roblox!");
            attachButton.BackColor = System.Drawing.Color.Green;
        }

        private void DetachFromRobloxClick(object sender, EventArgs e)
        {
            DetachFromRoblox();
            MessageBox.Show("Detached from Roblox!");
            attachButton.BackColor = System.Drawing.SystemColors.Control;
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
