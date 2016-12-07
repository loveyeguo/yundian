namespace AccountingApplication.usercontrol
{
    partial class pd
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pd));
            this.btnjiexi = new System.Windows.Forms.Button();
            this.btnrandom = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.rbtfalse = new System.Windows.Forms.RadioButton();
            this.rbttrue = new System.Windows.Forms.RadioButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lbltm = new System.Windows.Forms.Label();
            this.btnsc = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel9.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnjiexi
            // 
            this.btnjiexi.Image = ((System.Drawing.Image)(resources.GetObject("btnjiexi.Image")));
            this.btnjiexi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnjiexi.Location = new System.Drawing.Point(22, 12);
            this.btnjiexi.Name = "btnjiexi";
            this.btnjiexi.Size = new System.Drawing.Size(101, 23);
            this.btnjiexi.TabIndex = 0;
            this.btnjiexi.Text = "解析";
            this.btnjiexi.UseVisualStyleBackColor = true;
            this.btnjiexi.Click += new System.EventHandler(this.btnjiexi_Click);
            // 
            // btnrandom
            // 
            this.btnrandom.Image = ((System.Drawing.Image)(resources.GetObject("btnrandom.Image")));
            this.btnrandom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrandom.Location = new System.Drawing.Point(246, 12);
            this.btnrandom.Name = "btnrandom";
            this.btnrandom.Size = new System.Drawing.Size(101, 23);
            this.btnrandom.TabIndex = 83;
            this.btnrandom.Text = "下一题";
            this.btnrandom.UseVisualStyleBackColor = true;
            this.btnrandom.Click += new System.EventHandler(this.btnrandom_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(29, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 74;
            this.label6.Text = "选择答案";
            // 
            // rbtfalse
            // 
            this.rbtfalse.AutoSize = true;
            this.rbtfalse.BackColor = System.Drawing.Color.Transparent;
            this.rbtfalse.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtfalse.Location = new System.Drawing.Point(204, 220);
            this.rbtfalse.Name = "rbtfalse";
            this.rbtfalse.Size = new System.Drawing.Size(58, 20);
            this.rbtfalse.TabIndex = 71;
            this.rbtfalse.TabStop = true;
            this.rbtfalse.Text = "错误";
            this.rbtfalse.UseVisualStyleBackColor = false;
            // 
            // rbttrue
            // 
            this.rbttrue.AutoSize = true;
            this.rbttrue.BackColor = System.Drawing.Color.Transparent;
            this.rbttrue.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbttrue.Location = new System.Drawing.Point(132, 220);
            this.rbttrue.Name = "rbttrue";
            this.rbttrue.Size = new System.Drawing.Size(58, 20);
            this.rbttrue.TabIndex = 70;
            this.rbttrue.TabStop = true;
            this.rbttrue.Text = "正确";
            this.rbttrue.UseVisualStyleBackColor = false;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.panel9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel9.BackgroundImage")));
            this.panel9.Controls.Add(this.lbltm);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(895, 44);
            this.panel9.TabIndex = 120;
            // 
            // lbltm
            // 
            this.lbltm.AutoSize = true;
            this.lbltm.BackColor = System.Drawing.Color.Transparent;
            this.lbltm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbltm.ForeColor = System.Drawing.Color.White;
            this.lbltm.Location = new System.Drawing.Point(40, 14);
            this.lbltm.Name = "lbltm";
            this.lbltm.Size = new System.Drawing.Size(112, 16);
            this.lbltm.TabIndex = 69;
            this.lbltm.Text = "第1题(共0题）";
            // 
            // btnsc
            // 
            this.btnsc.Image = ((System.Drawing.Image)(resources.GetObject("btnsc.Image")));
            this.btnsc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsc.Location = new System.Drawing.Point(358, 12);
            this.btnsc.Name = "btnsc";
            this.btnsc.Size = new System.Drawing.Size(101, 23);
            this.btnsc.TabIndex = 121;
            this.btnsc.Text = "收藏";
            this.btnsc.UseVisualStyleBackColor = true;
            this.btnsc.Click += new System.EventHandler(this.btnsc_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrev.Location = new System.Drawing.Point(134, 12);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(101, 23);
            this.btnPrev.TabIndex = 122;
            this.btnPrev.Text = "上一题";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.btnPrev);
            this.panel1.Controls.Add(this.btnrandom);
            this.panel1.Controls.Add(this.btnsc);
            this.panel1.Controls.Add(this.btnjiexi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 383);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 48);
            this.panel1.TabIndex = 125;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(22, 50);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(847, 112);
            this.webBrowser1.TabIndex = 126;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // pd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rbtfalse);
            this.Controls.Add(this.rbttrue);
            this.Name = "pd";
            this.Size = new System.Drawing.Size(895, 431);
            this.Load += new System.EventHandler(this.pd_Load);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnjiexi;
        public System.Windows.Forms.Button btnrandom;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.RadioButton rbtfalse;
        public System.Windows.Forms.RadioButton rbttrue;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lbltm;
        public System.Windows.Forms.Button btnsc;
        public System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}
