using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CrownDripExecutor
{
    public class MainForm : Form
    {
        private Button attachButton;
        private Button detachButton;
        private Label titleLabel;

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

            titleLabel = new Label();
            titleLabel.Text = "CrownDrip Executor";
            titleLabel.Font = new System.Drawing.Font("Helvetica", 16, System.Drawing.FontStyle.Bold);
            titleLabel.AutoSize = true;
            titleLabel.Location = new System.Drawing.Point(50, 20);
            this.Controls.Add(titleLabel);

            attachButton = new Button();
            attachButton.Text = "Attach to Roblox";
            attachButton.Location = new System.Drawing.Point(75, 80);
            attachButton.Click += new EventHandler(AttachToRobloxClick);
            this.Controls.Add(attachButton);

            detachButton = new Button();
            detachButton.Text = "Detach from Roblox";
            detachButton.Location = new System.Drawing.Point(75, 120);
            detachButton.Click += new EventHandler(DetachFromRobloxClick);
            this.Controls.Add(detachButton);
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
