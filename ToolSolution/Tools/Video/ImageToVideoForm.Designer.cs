namespace ToolSolution.Tools.Video
{
    partial class ImageToVideoForm
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
            this.chbEnable = new System.Windows.Forms.CheckBox();
            this.chbQuicCreate = new System.Windows.Forms.CheckBox();
            this.chbReCreate = new System.Windows.Forms.CheckBox();
            this.chbAutoClear = new System.Windows.Forms.CheckBox();
            this.txtCoverBack = new System.Windows.Forms.TextBox();
            this.txtCover = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbSpeed = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbResolution = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTempPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtMusicPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFoldPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.cbFormat = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSourceVideo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTestMusic = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTestMusic);
            this.groupBox1.Controls.Add(this.chbEnable);
            this.groupBox1.Controls.Add(this.chbQuicCreate);
            this.groupBox1.Controls.Add(this.chbReCreate);
            this.groupBox1.Controls.Add(this.chbAutoClear);
            this.groupBox1.Controls.Add(this.txtCoverBack);
            this.groupBox1.Controls.Add(this.txtCover);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbSpeed);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbResolution);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtTempPath);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnCreate);
            this.groupBox1.Controls.Add(this.txtMusicPath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtOutputPath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtFoldPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 207);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图片文件夹转视频";
            // 
            // chbEnable
            // 
            this.chbEnable.AutoSize = true;
            this.chbEnable.Location = new System.Drawing.Point(686, 107);
            this.chbEnable.Name = "chbEnable";
            this.chbEnable.Size = new System.Drawing.Size(48, 16);
            this.chbEnable.TabIndex = 27;
            this.chbEnable.Text = "启用";
            this.chbEnable.UseVisualStyleBackColor = true;
            this.chbEnable.CheckedChanged += new System.EventHandler(this.chbEnable_CheckedChanged);
            // 
            // chbQuicCreate
            // 
            this.chbQuicCreate.AutoSize = true;
            this.chbQuicCreate.Enabled = false;
            this.chbQuicCreate.Location = new System.Drawing.Point(615, 25);
            this.chbQuicCreate.Name = "chbQuicCreate";
            this.chbQuicCreate.Size = new System.Drawing.Size(72, 16);
            this.chbQuicCreate.TabIndex = 25;
            this.chbQuicCreate.Text = "直接生成";
            this.chbQuicCreate.UseVisualStyleBackColor = true;
            // 
            // chbReCreate
            // 
            this.chbReCreate.AutoSize = true;
            this.chbReCreate.Location = new System.Drawing.Point(615, 82);
            this.chbReCreate.Name = "chbReCreate";
            this.chbReCreate.Size = new System.Drawing.Size(72, 16);
            this.chbReCreate.TabIndex = 24;
            this.chbReCreate.Text = "重新生成";
            this.chbReCreate.UseVisualStyleBackColor = true;
            // 
            // chbAutoClear
            // 
            this.chbAutoClear.AutoSize = true;
            this.chbAutoClear.Checked = true;
            this.chbAutoClear.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAutoClear.Location = new System.Drawing.Point(615, 107);
            this.chbAutoClear.Name = "chbAutoClear";
            this.chbAutoClear.Size = new System.Drawing.Size(72, 16);
            this.chbAutoClear.TabIndex = 22;
            this.chbAutoClear.Text = "自动清理";
            this.chbAutoClear.UseVisualStyleBackColor = true;
            // 
            // txtCoverBack
            // 
            this.txtCoverBack.Location = new System.Drawing.Point(393, 152);
            this.txtCoverBack.Name = "txtCoverBack";
            this.txtCoverBack.Size = new System.Drawing.Size(335, 21);
            this.txtCoverBack.TabIndex = 21;
            // 
            // txtCover
            // 
            this.txtCover.Location = new System.Drawing.Point(116, 152);
            this.txtCover.Name = "txtCover";
            this.txtCover.Size = new System.Drawing.Size(271, 21);
            this.txtCover.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 155);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "封面封底：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(418, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "秒";
            // 
            // cbSpeed
            // 
            this.cbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpeed.FormattingEnabled = true;
            this.cbSpeed.Items.AddRange(new object[] {
            "3",
            "6",
            "12"});
            this.cbSpeed.Location = new System.Drawing.Point(365, 179);
            this.cbSpeed.Name = "cbSpeed";
            this.cbSpeed.Size = new System.Drawing.Size(47, 20);
            this.cbSpeed.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(270, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "图片切换时间：";
            // 
            // cbResolution
            // 
            this.cbResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResolution.FormattingEnabled = true;
            this.cbResolution.Items.AddRange(new object[] {
            "iPhone4(1.5)",
            "Original(1.5)",
            "1024*768(1.3)",
            "iPad4(1.3)",
            "iPhone5s(1.7)",
            "1080P(1.7)"});
            this.cbResolution.Location = new System.Drawing.Point(116, 179);
            this.cbResolution.Name = "cbResolution";
            this.cbResolution.Size = new System.Drawing.Size(121, 20);
            this.cbResolution.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "视频分辨率：";
            // 
            // txtTempPath
            // 
            this.txtTempPath.Location = new System.Drawing.Point(116, 104);
            this.txtTempPath.Name = "txtTempPath";
            this.txtTempPath.ReadOnly = true;
            this.txtTempPath.Size = new System.Drawing.Size(490, 21);
            this.txtTempPath.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "工作目录：";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(116, 128);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(490, 21);
            this.txtTitle.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "视频名称：";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(495, 178);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 21);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.Text = "生成";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtMusicPath
            // 
            this.txtMusicPath.Location = new System.Drawing.Point(116, 54);
            this.txtMusicPath.Name = "txtMusicPath";
            this.txtMusicPath.Size = new System.Drawing.Size(490, 21);
            this.txtMusicPath.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "背景音乐地址：";
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(116, 80);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(490, 21);
            this.txtOutputPath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "视频输出目录:：";
            // 
            // txtFoldPath
            // 
            this.txtFoldPath.Location = new System.Drawing.Point(116, 23);
            this.txtFoldPath.Name = "txtFoldPath";
            this.txtFoldPath.Size = new System.Drawing.Size(490, 21);
            this.txtFoldPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "图片文件夹目录：";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 307);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage.Size = new System.Drawing.Size(760, 161);
            this.txtMessage.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 498);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(377, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "说明： 只支持jpg格式的图片，音乐或封面为空表示视频中不包含该项";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnConvert);
            this.groupBox2.Controls.Add(this.cbFormat);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtSourceVideo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 228);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 66);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "格式转换";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(597, 28);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 21);
            this.btnConvert.TabIndex = 28;
            this.btnConvert.Text = "转";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // cbFormat
            // 
            this.cbFormat.FormattingEnabled = true;
            this.cbFormat.Items.AddRange(new object[] {
            "mp4",
            "avi",
            "vcd"});
            this.cbFormat.Location = new System.Drawing.Point(495, 28);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(75, 20);
            this.cbFormat.TabIndex = 28;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(430, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 29;
            this.label12.Text = "目标格式：";
            // 
            // txtSourceVideo
            // 
            this.txtSourceVideo.Location = new System.Drawing.Point(80, 28);
            this.txtSourceVideo.Name = "txtSourceVideo";
            this.txtSourceVideo.Size = new System.Drawing.Size(332, 21);
            this.txtSourceVideo.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "源视频路径：";
            // 
            // btnTestMusic
            // 
            this.btnTestMusic.Location = new System.Drawing.Point(615, 52);
            this.btnTestMusic.Name = "btnTestMusic";
            this.btnTestMusic.Size = new System.Drawing.Size(75, 21);
            this.btnTestMusic.TabIndex = 28;
            this.btnTestMusic.Text = "合成测试";
            this.btnTestMusic.UseVisualStyleBackColor = true;
            this.btnTestMusic.Click += new System.EventHandler(this.btnTestMusic_Click);
            // 
            // ImageToVideoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 519);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtMessage);
            this.Name = "ImageToVideoForm";
            this.Text = "把图片集生成视频";
            this.Load += new System.EventHandler(this.ImageToVideoForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMusicPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFoldPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTempPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbResolution;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbSpeed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCover;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCoverBack;
        private System.Windows.Forms.CheckBox chbAutoClear;
        private System.Windows.Forms.CheckBox chbReCreate;
        private System.Windows.Forms.CheckBox chbQuicCreate;
        private System.Windows.Forms.CheckBox chbEnable;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbFormat;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSourceVideo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnTestMusic;
    }
}