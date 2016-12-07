namespace AccountingApplication.usercontrol
{
    partial class ComputeAnswerFuza
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
            this.cbbjd = new System.Windows.Forms.ComboBox();
            this.txtKuaijikemu = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.btnOpenKuaiji = new System.Windows.Forms.Button();
            this.lblTimuxuhao = new System.Windows.Forms.Label();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnremove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbbjd
            // 
            this.cbbjd.FormattingEnabled = true;
            this.cbbjd.Items.AddRange(new object[] {
            "借",
            "贷"});
            this.cbbjd.Location = new System.Drawing.Point(60, 3);
            this.cbbjd.Name = "cbbjd";
            this.cbbjd.Size = new System.Drawing.Size(54, 20);
            this.cbbjd.TabIndex = 0;
            // 
            // txtKuaijikemu
            // 
            this.txtKuaijikemu.Location = new System.Drawing.Point(130, 3);
            this.txtKuaijikemu.Name = "txtKuaijikemu";
            this.txtKuaijikemu.ReadOnly = true;
            this.txtKuaijikemu.Size = new System.Drawing.Size(160, 21);
            this.txtKuaijikemu.TabIndex = 1;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(397, 3);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(202, 21);
            this.txtNumber.TabIndex = 2;
            this.txtNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // btnOpenKuaiji
            // 
            this.btnOpenKuaiji.Location = new System.Drawing.Point(306, 1);
            this.btnOpenKuaiji.Name = "btnOpenKuaiji";
            this.btnOpenKuaiji.Size = new System.Drawing.Size(75, 23);
            this.btnOpenKuaiji.TabIndex = 3;
            this.btnOpenKuaiji.Text = "。。。";
            this.btnOpenKuaiji.UseVisualStyleBackColor = true;
            this.btnOpenKuaiji.Click += new System.EventHandler(this.btnOpenKuaiji_Click);
            // 
            // lblTimuxuhao
            // 
            this.lblTimuxuhao.AutoSize = true;
            this.lblTimuxuhao.Location = new System.Drawing.Point(3, 6);
            this.lblTimuxuhao.Name = "lblTimuxuhao";
            this.lblTimuxuhao.Size = new System.Drawing.Size(0, 12);
            this.lblTimuxuhao.TabIndex = 4;
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(617, 1);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(30, 23);
            this.btnadd.TabIndex = 5;
            this.btnadd.Text = "+";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnremove
            // 
            this.btnremove.Location = new System.Drawing.Point(670, 1);
            this.btnremove.Name = "btnremove";
            this.btnremove.Size = new System.Drawing.Size(30, 23);
            this.btnremove.TabIndex = 6;
            this.btnremove.Text = "-";
            this.btnremove.UseVisualStyleBackColor = true;
            this.btnremove.Click += new System.EventHandler(this.btnremove_Click);
            // 
            // ComputeAnswerFuza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnremove);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.lblTimuxuhao);
            this.Controls.Add(this.btnOpenKuaiji);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.txtKuaijikemu);
            this.Controls.Add(this.cbbjd);
            this.Name = "ComputeAnswerFuza";
            this.Size = new System.Drawing.Size(719, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenKuaiji;
        public System.Windows.Forms.ComboBox cbbjd;
        public System.Windows.Forms.TextBox txtKuaijikemu;
        public System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Button btnadd;
        public System.Windows.Forms.Label lblTimuxuhao;
        public System.Windows.Forms.Button btnremove;
    }
}
