﻿namespace SetBrightness
{
    partial class TabForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.autoStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useContrastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotKeyWinAltBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rescanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homepageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadingTipLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Location = new System.Drawing.Point(1, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(380, 136);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoStartToolStripMenuItem,
            this.useContrastToolStripMenuItem,
            this.hotKeyWinAltBToolStripMenuItem,
            this.rescanToolStripMenuItem,
            this.homepageToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(205, 158);
            this.contextMenuStrip.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.contextMenuStrip_Closing);
            // 
            // autoStartToolStripMenuItem
            // 
            this.autoStartToolStripMenuItem.CheckOnClick = true;
            this.autoStartToolStripMenuItem.Name = "autoStartToolStripMenuItem";
            this.autoStartToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.autoStartToolStripMenuItem.Text = "开机启动";
            this.autoStartToolStripMenuItem.Click += new System.EventHandler(this.autoStartToolStripMenuItem_Click);
            this.autoStartToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.autoStartToolStripMenuItem_MouseDown);
            // 
            // useContrastToolStripMenuItem
            // 
            this.useContrastToolStripMenuItem.CheckOnClick = true;
            this.useContrastToolStripMenuItem.Name = "useContrastToolStripMenuItem";
            this.useContrastToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.useContrastToolStripMenuItem.Text = "启用对比度";
            this.useContrastToolStripMenuItem.Click += new System.EventHandler(this.useContrastToolStripMenuItem_Click);
            this.useContrastToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.useContrastToolStripMenuItem_MouseDown);
            // 
            // hotKeyWinAltBToolStripMenuItem
            // 
            this.hotKeyWinAltBToolStripMenuItem.CheckOnClick = true;
            this.hotKeyWinAltBToolStripMenuItem.Name = "hotKeyWinAltBToolStripMenuItem";
            this.hotKeyWinAltBToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.hotKeyWinAltBToolStripMenuItem.Text = "快捷键（Win+Ctrl+B）";
            this.hotKeyWinAltBToolStripMenuItem.Click += new System.EventHandler(this.hotKeyWinAltBToolStripMenuItem_Click);
            this.hotKeyWinAltBToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.hotKeyWinAltBToolStripMenuItem_MouseDown);
            // 
            // rescanToolStripMenuItem
            // 
            this.rescanToolStripMenuItem.Name = "rescanToolStripMenuItem";
            this.rescanToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.rescanToolStripMenuItem.Text = "重新检测屏幕";
            this.rescanToolStripMenuItem.Click += new System.EventHandler(this.rescanToolStripMenuItem_Click);
            // 
            // homepageToolStripMenuItem
            // 
            this.homepageToolStripMenuItem.Name = "homepageToolStripMenuItem";
            this.homepageToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.homepageToolStripMenuItem.Text = "项目主页";
            this.homepageToolStripMenuItem.Click += new System.EventHandler(this.homepageToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.quitToolStripMenuItem.Text = "退出";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // loadingTipLabel
            // 
            this.loadingTipLabel.AutoSize = true;
            this.loadingTipLabel.BackColor = System.Drawing.Color.White;
            this.loadingTipLabel.Location = new System.Drawing.Point(160, 35);
            this.loadingTipLabel.Name = "loadingTipLabel";
            this.loadingTipLabel.Size = new System.Drawing.Size(54, 17);
            this.loadingTipLabel.TabIndex = 1;
            this.loadingTipLabel.Text = "加载中…";
            // 
            // TabForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 137);
            this.Controls.Add(this.loadingTipLabel);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TabForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.TabForm_Deactivate);
            this.VisibleChanged += new System.EventHandler(this.TabForm_VisibleChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TabForm_KeyPress);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem autoStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useContrastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rescanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Label loadingTipLabel;
        private System.Windows.Forms.ToolStripMenuItem hotKeyWinAltBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homepageToolStripMenuItem;
    }
}