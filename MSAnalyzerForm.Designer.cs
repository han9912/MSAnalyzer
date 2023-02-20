
namespace MSAAnalyzer
{
    partial class MSAnalyzerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MSAnalyzerForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tb_FolderDir = new System.Windows.Forms.TextBox();
            this.btn_SelectFolder = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_ClearLog = new System.Windows.Forms.Button();
            this.lsb_Msg = new System.Windows.Forms.ListBox();
            this.pn_Control = new System.Windows.Forms.Panel();
            this.cb_Template = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_TemplatePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_OpenReportPath_Click = new System.Windows.Forms.Button();
            this.pn_Control.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Log根目录:";
            // 
            // tb_FolderDir
            // 
            this.tb_FolderDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_FolderDir.Location = new System.Drawing.Point(108, 15);
            this.tb_FolderDir.Name = "tb_FolderDir";
            this.tb_FolderDir.ReadOnly = true;
            this.tb_FolderDir.Size = new System.Drawing.Size(567, 23);
            this.tb_FolderDir.TabIndex = 4;
            this.tb_FolderDir.TextChanged += new System.EventHandler(this.Tb_FolderDir_TextChanged);
            // 
            // btn_SelectFolder
            // 
            this.btn_SelectFolder.Location = new System.Drawing.Point(695, 15);
            this.btn_SelectFolder.Name = "btn_SelectFolder";
            this.btn_SelectFolder.Size = new System.Drawing.Size(48, 23);
            this.btn_SelectFolder.TabIndex = 5;
            this.btn_SelectFolder.Text = "选择";
            this.btn_SelectFolder.UseVisualStyleBackColor = true;
            this.btn_SelectFolder.Click += new System.EventHandler(this.Btn_SelectFolder_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Start.Location = new System.Drawing.Point(732, 491);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(64, 26);
            this.btn_Start.TabIndex = 6;
            this.btn_Start.Text = "开始";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // btn_ClearLog
            // 
            this.btn_ClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ClearLog.Location = new System.Drawing.Point(802, 209);
            this.btn_ClearLog.Name = "btn_ClearLog";
            this.btn_ClearLog.Size = new System.Drawing.Size(64, 26);
            this.btn_ClearLog.TabIndex = 8;
            this.btn_ClearLog.Text = "清空Log";
            this.btn_ClearLog.UseVisualStyleBackColor = true;
            this.btn_ClearLog.Click += new System.EventHandler(this.Btn_ClearLog_Click);
            // 
            // lsb_Msg
            // 
            this.lsb_Msg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsb_Msg.BackColor = System.Drawing.SystemColors.Control;
            this.lsb_Msg.FormattingEnabled = true;
            this.lsb_Msg.ItemHeight = 17;
            this.lsb_Msg.Location = new System.Drawing.Point(2, 238);
            this.lsb_Msg.Margin = new System.Windows.Forms.Padding(0);
            this.lsb_Msg.Name = "lsb_Msg";
            this.lsb_Msg.Size = new System.Drawing.Size(864, 242);
            this.lsb_Msg.TabIndex = 7;
            // 
            // pn_Control
            // 
            this.pn_Control.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pn_Control.Controls.Add(this.cb_Template);
            this.pn_Control.Controls.Add(this.button2);
            this.pn_Control.Controls.Add(this.label4);
            this.pn_Control.Controls.Add(this.tb_TemplatePath);
            this.pn_Control.Controls.Add(this.label2);
            this.pn_Control.Controls.Add(this.tb_FolderDir);
            this.pn_Control.Controls.Add(this.btn_SelectFolder);
            this.pn_Control.Controls.Add(this.label1);
            this.pn_Control.Location = new System.Drawing.Point(2, 42);
            this.pn_Control.Margin = new System.Windows.Forms.Padding(0);
            this.pn_Control.Name = "pn_Control";
            this.pn_Control.Size = new System.Drawing.Size(864, 154);
            this.pn_Control.TabIndex = 9;
            // 
            // cb_Template
            // 
            this.cb_Template.AutoSize = true;
            this.cb_Template.Checked = true;
            this.cb_Template.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Template.Location = new System.Drawing.Point(750, 68);
            this.cb_Template.Name = "cb_Template";
            this.cb_Template.Size = new System.Drawing.Size(75, 21);
            this.cb_Template.TabIndex = 11;
            this.cb_Template.Text = "应用模板";
            this.cb_Template.UseVisualStyleBackColor = true;
            this.cb_Template.CheckedChanged += new System.EventHandler(this.Cb_Template_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(695, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "选择";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Btn_SelectTemplate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "报告模板目录:";
            // 
            // tb_TemplatePath
            // 
            this.tb_TemplatePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_TemplatePath.Location = new System.Drawing.Point(108, 66);
            this.tb_TemplatePath.Name = "tb_TemplatePath";
            this.tb_TemplatePath.ReadOnly = true;
            this.tb_TemplatePath.Size = new System.Drawing.Size(567, 23);
            this.tb_TemplatePath.TabIndex = 8;
            this.tb_TemplatePath.TextChanged += new System.EventHandler(this.Tb_TemplatePath_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(116, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "路径选择到SN命名文件夹的上一级路径";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(317, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 26);
            this.label3.TabIndex = 10;
            this.label3.Text = "测试结果值抓取统计工具";
            // 
            // btn_OpenReportPath_Click
            // 
            this.btn_OpenReportPath_Click.Enabled = false;
            this.btn_OpenReportPath_Click.Location = new System.Drawing.Point(802, 491);
            this.btn_OpenReportPath_Click.Name = "btn_OpenReportPath_Click";
            this.btn_OpenReportPath_Click.Size = new System.Drawing.Size(64, 26);
            this.btn_OpenReportPath_Click.TabIndex = 11;
            this.btn_OpenReportPath_Click.Text = "查看结果";
            this.btn_OpenReportPath_Click.UseVisualStyleBackColor = true;
            this.btn_OpenReportPath_Click.Click += new System.EventHandler(this.Btn_OpenReportPath_Click);
            // 
            // DataCaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 529);
            this.Controls.Add(this.btn_OpenReportPath_Click);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pn_Control);
            this.Controls.Add(this.btn_ClearLog);
            this.Controls.Add(this.lsb_Msg);
            this.Controls.Add(this.btn_Start);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DataCaptureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogDataCapture";
            this.Load += new System.EventHandler(this.DataCaptureForm_Load);
            this.pn_Control.ResumeLayout(false);
            this.pn_Control.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_FolderDir;
        private System.Windows.Forms.Button btn_SelectFolder;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_ClearLog;
        private System.Windows.Forms.ListBox lsb_Msg;
        private System.Windows.Forms.Panel pn_Control;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_OpenReportPath_Click;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_TemplatePath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox cb_Template;
    }
}

