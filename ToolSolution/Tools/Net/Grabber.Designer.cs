namespace ToolSolution.Tools.Net
{
    partial class Grabber
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
            this.txtOppFilter = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtContentLength = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbReplaceHtml = new System.Windows.Forms.CheckBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbEncoding = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEndID = new System.Windows.Forms.TextBox();
            this.txtStartID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtListUrl = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtListUrl);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtOppFilter);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtContentLength);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbReplaceHtml);
            this.groupBox1.Controls.Add(this.txtFilter);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbbEncoding);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtEndID);
            this.groupBox1.Controls.Add(this.txtStartID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnGo);
            this.groupBox1.Controls.Add(this.txtOutput);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUrl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 264);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "遍历ID";
            // 
            // txtOppFilter
            // 
            this.txtOppFilter.Location = new System.Drawing.Point(488, 106);
            this.txtOppFilter.Name = "txtOppFilter";
            this.txtOppFilter.Size = new System.Drawing.Size(260, 21);
            this.txtOppFilter.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(394, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 25;
            this.label8.Text = "内容不包括：";
            // 
            // txtContentLength
            // 
            this.txtContentLength.Location = new System.Drawing.Point(358, 169);
            this.txtContentLength.Name = "txtContentLength";
            this.txtContentLength.Size = new System.Drawing.Size(146, 21);
            this.txtContentLength.TabIndex = 24;
            this.txtContentLength.Text = "300";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(237, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "内容长度大于：";
            // 
            // cbReplaceHtml
            // 
            this.cbReplaceHtml.AutoSize = true;
            this.cbReplaceHtml.Checked = true;
            this.cbReplaceHtml.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbReplaceHtml.Location = new System.Drawing.Point(544, 174);
            this.cbReplaceHtml.Name = "cbReplaceHtml";
            this.cbReplaceHtml.Size = new System.Drawing.Size(72, 16);
            this.cbReplaceHtml.TabIndex = 22;
            this.cbReplaceHtml.Text = "处理HTML";
            this.cbReplaceHtml.UseVisualStyleBackColor = true;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(76, 106);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(271, 21);
            this.txtFilter.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "内容包括：";
            // 
            // cbbEncoding
            // 
            this.cbbEncoding.FormattingEnabled = true;
            this.cbbEncoding.Items.AddRange(new object[] {
            "utf-8",
            "gb2312"});
            this.cbbEncoding.Location = new System.Drawing.Point(76, 169);
            this.cbbEncoding.Name = "cbbEncoding";
            this.cbbEncoding.Size = new System.Drawing.Size(121, 20);
            this.cbbEncoding.TabIndex = 19;
            this.cbbEncoding.Text = "utf-8";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "数据编码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "到：";
            // 
            // txtEndID
            // 
            this.txtEndID.Location = new System.Drawing.Point(342, 79);
            this.txtEndID.Name = "txtEndID";
            this.txtEndID.Size = new System.Drawing.Size(226, 21);
            this.txtEndID.TabIndex = 16;
            this.txtEndID.Text = "1";
            // 
            // txtStartID
            // 
            this.txtStartID.Location = new System.Drawing.Point(76, 79);
            this.txtStartID.Name = "txtStartID";
            this.txtStartID.Size = new System.Drawing.Size(197, 21);
            this.txtStartID.TabIndex = 15;
            this.txtStartID.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "ID区间：";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(76, 136);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(672, 21);
            this.txtOutput.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "输出目录：";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(76, 50);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(672, 21);
            this.txtUrl.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "明细地址：";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 294);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(760, 245);
            this.txtMessage.TabIndex = 18;
            // 
            // txtListUrl
            // 
            this.txtListUrl.Location = new System.Drawing.Point(76, 23);
            this.txtListUrl.Name = "txtListUrl";
            this.txtListUrl.Size = new System.Drawing.Size(672, 21);
            this.txtListUrl.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 27;
            this.label9.Text = "列表地址：";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(299, 209);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 13;
            this.btnGo.Text = "抓取";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // Grabber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.groupBox1);
            this.Name = "Grabber";
            this.Text = "抓取网页数据";
            this.Load += new System.EventHandler(this.Grabber_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEndID;
        private System.Windows.Forms.TextBox txtStartID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ComboBox cbbEncoding;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbReplaceHtml;
        private System.Windows.Forms.TextBox txtContentLength;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOppFilter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtListUrl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnGo;
    }
}