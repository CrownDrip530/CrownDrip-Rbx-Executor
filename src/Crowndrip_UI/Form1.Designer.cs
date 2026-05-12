namespace CrownDripExecutor
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.attachButton = new System.Windows.Forms.Button();
            this.detachButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // attachButton
            //
            this.attachButton.Location = new System.Drawing.Point(75, 80);
            this.attachButton.Name = "attachButton";
            this.attachButton.Size = new System.Drawing.Size(150, 23);
            this.attachButton.TabIndex = 0;
            this.attachButton.Text = "Attach to Roblox";
            this.attachButton.UseVisualStyleBackColor = true;
            this.attachButton.Click += new System.EventHandler(this.AttachToRobloxClick);
            //
            // detachButton
            //
            this.detachButton.Location = new System.Drawing.Point(75, 120);
            this.detachButton.Name = "detachButton";
            this.detachButton.Size = new System.Drawing.Size(150, 23);
            this.detachButton.TabIndex = 1;
            this.detachButton.Text = "Detach from Roblox";
            this.detachButton.UseVisualStyleBackColor = true;
            this.detachButton.Click += new System.EventHandler(this.DetachFromRobloxClick);
            //
            // titleLabel
            //
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Helvetica", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(50, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(200, 27);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "CrownDrip Executor";
            //
            // MainForm
            //
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.detachButton);
            this.Controls.Add(this.attachButton);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CrownDrip Executor";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button attachButton;
        private System.Windows.Forms.Button detachButton;
        private System.Windows.Forms.Label titleLabel;
    }
}
