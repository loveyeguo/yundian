namespace AccountingApplication
{
    partial class Formdxt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formdxt));
            this.paneldxt = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // paneldxt
            // 
            this.paneldxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paneldxt.Location = new System.Drawing.Point(0, 0);
            this.paneldxt.Name = "paneldxt";
            this.paneldxt.Size = new System.Drawing.Size(879, 393);
            this.paneldxt.TabIndex = 0;
            // 
            // Formdxt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(879, 393);
            this.Controls.Add(this.paneldxt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Formdxt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "单选题";
            this.Load += new System.EventHandler(this.Formdxt_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel paneldxt;

    }
}