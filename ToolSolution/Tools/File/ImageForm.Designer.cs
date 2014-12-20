namespace ToolSolution.Tools.File
{
    partial class ImageForm
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
            this.btnCompress = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCompressDest = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCompressSource = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.combQuality = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtHeight);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtWidth);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.combQuality);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnCompress);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCompressDest);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCompressSource);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 149);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图片压缩";
            // 
            // btnCompress
            // 
            this.btnCompress.Location = new System.Drawing.Point(335, 110);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(75, 21);
            this.btnCompress.TabIndex = 5;
            this.btnCompress.Text = "压缩";
            this.btnCompress.UseVisualStyleBackColor = true;
            this.btnCompress.Click += new System.EventHandler(this.btnCompress_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "目标地址：";
            // 
            // txtCompressDest
            // 
            this.txtCompressDest.Location = new System.Drawing.Point(75, 45);
            this.txtCompressDest.Name = "txtCompressDest";
            this.txtCompressDest.Size = new System.Drawing.Size(658, 21);
            this.txtCompressDest.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "源地址：";
            // 
            // txtCompressSource
            // 
            this.txtCompressSource.Location = new System.Drawing.Point(75, 21);
            this.txtCompressSource.Name = "txtCompressSource";
            this.txtCompressSource.Size = new System.Drawing.Size(658, 21);
            this.txtCompressSource.TabIndex = 1;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 183);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(760, 100);
            this.txtMessage.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "压缩质量：";
            // 
            // combQuality
            // 
            this.combQuality.FormattingEnabled = true;
            this.combQuality.Items.AddRange(new object[] {
            "高",
            "中",
            "低"});
            this.combQuality.Location = new System.Drawing.Point(75, 73);
            this.combQuality.Name = "combQuality";
            this.combQuality.Size = new System.Drawing.Size(121, 20);
            this.combQuality.TabIndex = 7;
            this.combQuality.Text = "中";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "宽：";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(311, 72);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(90, 21);
            this.txtWidth.TabIndex = 9;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(491, 72);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(90, 21);
            this.txtHeight.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(456, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "高：";
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 519);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.groupBox1);
            this.Name = "ImageForm";
            this.Text = "图片处理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCompressSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCompressDest;
        private System.Windows.Forms.Button btnCompress;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ComboBox combQuality;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label4;
    }
}