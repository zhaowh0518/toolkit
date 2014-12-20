namespace ToolSolution.Tools.App
{
    partial class QQForm
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
            this.txtContent = new System.Windows.Forms.TextBox();
            this.btnFrep = new System.Windows.Forms.Button();
            this.txtParam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnReverse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtContent
            // 
            this.txtContent.HideSelection = false;
            this.txtContent.Location = new System.Drawing.Point(12, 49);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(769, 501);
            this.txtContent.TabIndex = 0;
            // 
            // btnFrep
            // 
            this.btnFrep.Location = new System.Drawing.Point(556, 10);
            this.btnFrep.Name = "btnFrep";
            this.btnFrep.Size = new System.Drawing.Size(75, 23);
            this.btnFrep.TabIndex = 1;
            this.btnFrep.Text = "聊天频率";
            this.btnFrep.UseVisualStyleBackColor = true;
            this.btnFrep.Click += new System.EventHandler(this.btnFrep_Click);
            // 
            // txtParam
            // 
            this.txtParam.Location = new System.Drawing.Point(427, 12);
            this.txtParam.Name = "txtParam";
            this.txtParam.Size = new System.Drawing.Size(98, 20);
            this.txtParam.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(378, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "参数：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "QQ聊天文件路径：";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(125, 12);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(234, 20);
            this.txtPath.TabIndex = 5;
            // 
            // btnReverse
            // 
            this.btnReverse.Location = new System.Drawing.Point(649, 9);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(90, 23);
            this.btnReverse.TabIndex = 6;
            this.btnReverse.Text = "逆向聊天记录";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // QQForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.btnReverse);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtParam);
            this.Controls.Add(this.btnFrep);
            this.Controls.Add(this.txtContent);
            this.Name = "QQForm";
            this.Text = "QQForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Button btnFrep;
        private System.Windows.Forms.TextBox txtParam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnReverse;
    }
}