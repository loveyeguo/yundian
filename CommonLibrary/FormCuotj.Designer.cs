namespace CommonLibrary
{
    partial class FormCuotj
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCuotj));
            this.label_pd = new System.Windows.Forms.Label();
            this.label_duox = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_dx = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_pd
            // 
            this.label_pd.AutoSize = true;
            this.label_pd.BackColor = System.Drawing.Color.Transparent;
            this.label_pd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(110)))), ((int)(((byte)(161)))));
            this.label_pd.Location = new System.Drawing.Point(528, 143);
            this.label_pd.Name = "label_pd";
            this.label_pd.Size = new System.Drawing.Size(11, 12);
            this.label_pd.TabIndex = 19;
            this.label_pd.Text = "1";
            // 
            // label_duox
            // 
            this.label_duox.AutoSize = true;
            this.label_duox.BackColor = System.Drawing.Color.Transparent;
            this.label_duox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(110)))), ((int)(((byte)(161)))));
            this.label_duox.Location = new System.Drawing.Point(283, 143);
            this.label_duox.Name = "label_duox";
            this.label_duox.Size = new System.Drawing.Size(11, 12);
            this.label_duox.TabIndex = 18;
            this.label_duox.Text = "1";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.label_pd);
            this.panel1.Controls.Add(this.label_duox);
            this.panel1.Controls.Add(this.label_dx);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(41, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 234);
            this.panel1.TabIndex = 4;
            // 
            // label_dx
            // 
            this.label_dx.AutoSize = true;
            this.label_dx.BackColor = System.Drawing.Color.Transparent;
            this.label_dx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(110)))), ((int)(((byte)(161)))));
            this.label_dx.Location = new System.Drawing.Point(43, 143);
            this.label_dx.Name = "label_dx";
            this.label_dx.Size = new System.Drawing.Size(11, 12);
            this.label_dx.TabIndex = 17;
            this.label_dx.Text = "1";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel4.Location = new System.Drawing.Point(483, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(162, 228);
            this.panel4.TabIndex = 16;
            this.panel4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Location = new System.Drawing.Point(240, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(170, 231);
            this.panel3.TabIndex = 16;
            this.panel3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(162, 228);
            this.panel2.TabIndex = 15;
            this.panel2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseClick);
            // 
            // FormCuotj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(744, 305);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormCuotj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "错题集";
            this.Load += new System.EventHandler(this.FormCuotj_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_pd;
        private System.Windows.Forms.Label label_duox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_dx;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;

    }
}