namespace AccountingApplication.usercontrol
{
    partial class ComputeAnswerJiandan
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
            this.lblTimuxuhao = new System.Windows.Forms.Label();
            this.txtJiandan = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTimuxuhao
            // 
            this.lblTimuxuhao.AutoSize = true;
            this.lblTimuxuhao.Location = new System.Drawing.Point(11, 7);
            this.lblTimuxuhao.Name = "lblTimuxuhao";
            this.lblTimuxuhao.Size = new System.Drawing.Size(0, 12);
            this.lblTimuxuhao.TabIndex = 11;
            // 
            // txtJiandan
            // 
            this.txtJiandan.Location = new System.Drawing.Point(162, 4);
            this.txtJiandan.Name = "txtJiandan";
            this.txtJiandan.Size = new System.Drawing.Size(440, 21);
            this.txtJiandan.TabIndex = 12;
            this.txtJiandan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJiandan_KeyPress);
            // 
            // ComputeAnswerJiandan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtJiandan);
            this.Controls.Add(this.lblTimuxuhao);
            this.Name = "ComputeAnswerJiandan";
            this.Size = new System.Drawing.Size(719, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblTimuxuhao;
        public System.Windows.Forms.TextBox txtJiandan;

    }
}
