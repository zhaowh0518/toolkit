namespace ToolSolution.Tools.File
{
    partial class FileListForm
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
            this.tvFileList = new System.Windows.Forms.TreeView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tvFileList
            // 
            this.tvFileList.Location = new System.Drawing.Point(17, 59);
            this.tvFileList.Name = "tvFileList";
            this.tvFileList.Size = new System.Drawing.Size(755, 538);
            this.tvFileList.TabIndex = 0;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(697, 11);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 25);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "加载目录";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(109, 13);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(558, 20);
            this.txtDir.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "文件所在目录：";
            // 
            // FileListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 609);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.tvFileList);
            this.Name = "FileListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "文件列表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvFileList;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Label label1;
    }
}