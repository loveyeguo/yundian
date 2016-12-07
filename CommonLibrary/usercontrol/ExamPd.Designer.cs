namespace AccountingApplication.usercontrol
{
    partial class ExamPd
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
            this.button1 = new System.Windows.Forms.Button();
            this.rbtfalse = new System.Windows.Forms.RadioButton();
            this.rbttrue = new System.Windows.Forms.RadioButton();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(20, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 93;
            this.button1.Text = "选择答案";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // rbtfalse
            // 
            this.rbtfalse.AutoSize = true;
            this.rbtfalse.BackColor = System.Drawing.Color.Transparent;
            this.rbtfalse.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtfalse.Location = new System.Drawing.Point(174, 250);
            this.rbtfalse.Name = "rbtfalse";
            this.rbtfalse.Size = new System.Drawing.Size(58, 20);
            this.rbtfalse.TabIndex = 88;
            this.rbtfalse.TabStop = true;
            this.rbtfalse.Text = "错误";
            this.rbtfalse.UseVisualStyleBackColor = false;
            // 
            // rbttrue
            // 
            this.rbttrue.AutoSize = true;
            this.rbttrue.BackColor = System.Drawing.Color.Transparent;
            this.rbttrue.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbttrue.Location = new System.Drawing.Point(112, 250);
            this.rbttrue.Name = "rbttrue";
            this.rbttrue.Size = new System.Drawing.Size(58, 20);
            this.rbttrue.TabIndex = 87;
            this.rbttrue.TabStop = true;
            this.rbttrue.Text = "正确";
            this.rbttrue.UseVisualStyleBackColor = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(20, 23);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(695, 125);
            this.webBrowser1.TabIndex = 94;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // ExamPd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rbtfalse);
            this.Controls.Add(this.rbttrue);
            this.Name = "ExamPd";
            this.Size = new System.Drawing.Size(743, 383);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RadioButton rbtfalse;
        public System.Windows.Forms.RadioButton rbttrue;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}
