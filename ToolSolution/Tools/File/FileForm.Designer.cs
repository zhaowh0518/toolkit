namespace ToolSolution.Tools.File
{
    partial class FileForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReplaceChar = new System.Windows.Forms.TextBox();
            this.txtReplaceToChar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReplace = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReplace);
            this.groupBox1.Controls.Add(this.txtReplaceToChar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtReplaceChar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文件名替换";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "文件路径：";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(83, 12);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(689, 21);
            this.txtFilePath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "要替换的字符：";
            // 
            // txtReplaceChar
            // 
            this.txtReplaceChar.Location = new System.Drawing.Point(92, 23);
            this.txtReplaceChar.Name = "txtReplaceChar";
            this.txtReplaceChar.Size = new System.Drawing.Size(180, 21);
            this.txtReplaceChar.TabIndex = 1;
            // 
            // txtReplaceToChar
            // 
            this.txtReplaceToChar.Location = new System.Drawing.Point(383, 23);
            this.txtReplaceToChar.Name = "txtReplaceToChar";
            this.txtReplaceToChar.Size = new System.Drawing.Size(180, 21);
            this.txtReplaceToChar.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(297, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "替换后的字符：";
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(625, 21);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(75, 23);
            this.btnReplace.TabIndex = 4;
            this.btnReplace.Text = "替换";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // FileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FileForm";
            this.Text = "文件处理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.TextBox txtReplaceToChar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReplaceChar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilePath;
    }
}