namespace Iterative.Tools.RunAs
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoMinimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.allowCustomRunAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authenticationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.largeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notificationContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ncMenuItemShow = new System.Windows.Forms.ToolStripMenuItem();
            this.ncMenuItemRunAsApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ncMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.imgListRunAsActions = new System.Windows.Forms.ImageList(this.components);
            this.runAsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.openContainingFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runAsListMediumIcons = new System.Windows.Forms.ImageList(this.components);
            this.runAsListSmallIcons = new System.Windows.Forms.ImageList(this.components);
            this.runAsListLargeIcons = new System.Windows.Forms.ImageList(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.currentStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolStripStatusLabel();
            this.runAsList = new System.Windows.Forms.ListView();
            this.chRunAsName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRunAsFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.runAsUserDetails1 = new Iterative.Tools.RunAs.Controls.RunAsUserDetails();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsExecuteRunAs = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsApplicationOpenFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsAddApplication = new System.Windows.Forms.ToolStripButton();
            this.tsDeleteApplication = new System.Windows.Forms.ToolStripButton();
            this.tsRefreshApplications = new System.Windows.Forms.ToolStripButton();
            this.tsExecuteRunAsOther = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.notificationContextMenu.SuspendLayout();
            this.runAsContextMenu.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(513, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.toolStripMenuItem4,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripMenuItem.Image")));
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem.Text = "&Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshApplications);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(110, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.exitToolStripMenuItem.Text = "E&xit...";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitApplication);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoMinimizeToolStripMenuItem,
            this.minimizeToTrayToolStripMenuItem,
            this.alwaysOnTopToolStripMenuItem,
            this.toolStripMenuItem1,
            this.allowCustomRunAsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.DropDownOpening += new System.EventHandler(this.editToolStripMenuItem_DropDownOpening);
            // 
            // autoMinimizeToolStripMenuItem
            // 
            this.autoMinimizeToolStripMenuItem.CheckOnClick = true;
            this.autoMinimizeToolStripMenuItem.Name = "autoMinimizeToolStripMenuItem";
            this.autoMinimizeToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.autoMinimizeToolStripMenuItem.Tag = "MinimizeAfterRun";
            this.autoMinimizeToolStripMenuItem.Text = "&Auto Minimize...";
            this.autoMinimizeToolStripMenuItem.Click += new System.EventHandler(this.SetConfigurationChanged);
            // 
            // minimizeToTrayToolStripMenuItem
            // 
            this.minimizeToTrayToolStripMenuItem.CheckOnClick = true;
            this.minimizeToTrayToolStripMenuItem.Name = "minimizeToTrayToolStripMenuItem";
            this.minimizeToTrayToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.minimizeToTrayToolStripMenuItem.Tag = "MinimizeToTray";
            this.minimizeToTrayToolStripMenuItem.Text = "&Minimize to Tray...";
            this.minimizeToTrayToolStripMenuItem.Click += new System.EventHandler(this.SetConfigurationChanged);
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.CheckOnClick = true;
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.alwaysOnTopToolStripMenuItem.Tag = "AlwaysOnTop";
            this.alwaysOnTopToolStripMenuItem.Text = "Always on &Top...";
            this.alwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.SetConfigurationChanged);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(192, 6);
            // 
            // allowCustomRunAsToolStripMenuItem
            // 
            this.allowCustomRunAsToolStripMenuItem.CheckOnClick = true;
            this.allowCustomRunAsToolStripMenuItem.Name = "allowCustomRunAsToolStripMenuItem";
            this.allowCustomRunAsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.allowCustomRunAsToolStripMenuItem.Tag = "AllowCustomApplicationRunAs";
            this.allowCustomRunAsToolStripMenuItem.Text = "Allow Custom RunAs...";
            this.allowCustomRunAsToolStripMenuItem.Click += new System.EventHandler(this.SetConfigurationChanged);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.authenticationDetailsToolStripMenuItem,
            this.statusbarToolStripMenuItem,
            this.toolStripMenuItem3,
            this.largeIconsToolStripMenuItem,
            this.mediumIconsToolStripMenuItem,
            this.smallIconsToolStripMenuItem,
            this.detailsToolStripMenuItem,
            this.listToolStripMenuItem,
            this.tilesToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            this.viewToolStripMenuItem.DropDownOpening += new System.EventHandler(this.viewToolStripMenuItem_DropDownOpening);
            // 
            // authenticationDetailsToolStripMenuItem
            // 
            this.authenticationDetailsToolStripMenuItem.CheckOnClick = true;
            this.authenticationDetailsToolStripMenuItem.Name = "authenticationDetailsToolStripMenuItem";
            this.authenticationDetailsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.authenticationDetailsToolStripMenuItem.Tag = "ViewAuthenticationDetails";
            this.authenticationDetailsToolStripMenuItem.Text = "&Authentication Details";
            this.authenticationDetailsToolStripMenuItem.Click += new System.EventHandler(this.SetConfigurationChanged);
            // 
            // statusbarToolStripMenuItem
            // 
            this.statusbarToolStripMenuItem.CheckOnClick = true;
            this.statusbarToolStripMenuItem.Name = "statusbarToolStripMenuItem";
            this.statusbarToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.statusbarToolStripMenuItem.Tag = "ShowStatusbar";
            this.statusbarToolStripMenuItem.Text = "Statusbar";
            this.statusbarToolStripMenuItem.Click += new System.EventHandler(this.SetConfigurationChanged);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(188, 6);
            // 
            // largeIconsToolStripMenuItem
            // 
            this.largeIconsToolStripMenuItem.CheckOnClick = true;
            this.largeIconsToolStripMenuItem.Name = "largeIconsToolStripMenuItem";
            this.largeIconsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.largeIconsToolStripMenuItem.Tag = Iterative.Tools.RunAs.RunAsView.LargeIcon;
            this.largeIconsToolStripMenuItem.Text = "&Large icons";
            this.largeIconsToolStripMenuItem.Click += new System.EventHandler(this.SetRunAsViewChanged);
            // 
            // mediumIconsToolStripMenuItem
            // 
            this.mediumIconsToolStripMenuItem.CheckOnClick = true;
            this.mediumIconsToolStripMenuItem.Name = "mediumIconsToolStripMenuItem";
            this.mediumIconsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.mediumIconsToolStripMenuItem.Tag = Iterative.Tools.RunAs.RunAsView.MediumIcon;
            this.mediumIconsToolStripMenuItem.Text = "&Medium icons";
            this.mediumIconsToolStripMenuItem.Click += new System.EventHandler(this.SetRunAsViewChanged);
            // 
            // smallIconsToolStripMenuItem
            // 
            this.smallIconsToolStripMenuItem.CheckOnClick = true;
            this.smallIconsToolStripMenuItem.Name = "smallIconsToolStripMenuItem";
            this.smallIconsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.smallIconsToolStripMenuItem.Tag = Iterative.Tools.RunAs.RunAsView.SmallIcon;
            this.smallIconsToolStripMenuItem.Text = "&Small icons";
            this.smallIconsToolStripMenuItem.Click += new System.EventHandler(this.SetRunAsViewChanged);
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.CheckOnClick = true;
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.detailsToolStripMenuItem.Tag = Iterative.Tools.RunAs.RunAsView.Details;
            this.detailsToolStripMenuItem.Text = "&Details";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.SetRunAsViewChanged);
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.CheckOnClick = true;
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.listToolStripMenuItem.Tag = Iterative.Tools.RunAs.RunAsView.List;
            this.listToolStripMenuItem.Text = "L&ist";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.SetRunAsViewChanged);
            // 
            // tilesToolStripMenuItem
            // 
            this.tilesToolStripMenuItem.CheckOnClick = true;
            this.tilesToolStripMenuItem.Name = "tilesToolStripMenuItem";
            this.tilesToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.tilesToolStripMenuItem.Tag = Iterative.Tools.RunAs.RunAsView.Tile;
            this.tilesToolStripMenuItem.Text = "&Tiles";
            this.tilesToolStripMenuItem.Click += new System.EventHandler(this.SetRunAsViewChanged);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.notificationContextMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Iterative RunAs";
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // notificationContextMenu
            // 
            this.notificationContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ncMenuItemShow,
            this.ncMenuItemRunAsApplications,
            this.toolStripSeparator1,
            this.ncMenuItemExit});
            this.notificationContextMenu.Name = "notificationContextMenu";
            this.notificationContextMenu.Size = new System.Drawing.Size(178, 76);
            // 
            // ncMenuItemShow
            // 
            this.ncMenuItemShow.Name = "ncMenuItemShow";
            this.ncMenuItemShow.Size = new System.Drawing.Size(177, 22);
            this.ncMenuItemShow.Text = "Open RunAs";
            this.ncMenuItemShow.Click += new System.EventHandler(this.ShowRunAsForm);
            // 
            // ncMenuItemRunAsApplications
            // 
            this.ncMenuItemRunAsApplications.Name = "ncMenuItemRunAsApplications";
            this.ncMenuItemRunAsApplications.Size = new System.Drawing.Size(177, 22);
            this.ncMenuItemRunAsApplications.Text = "RunAs Applications";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // ncMenuItemExit
            // 
            this.ncMenuItemExit.Name = "ncMenuItemExit";
            this.ncMenuItemExit.Size = new System.Drawing.Size(177, 22);
            this.ncMenuItemExit.Text = "E&xit";
            this.ncMenuItemExit.Click += new System.EventHandler(this.ExitApplication);
            // 
            // imgListRunAsActions
            // 
            this.imgListRunAsActions.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListRunAsActions.ImageStream")));
            this.imgListRunAsActions.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListRunAsActions.Images.SetKeyName(0, "add - 16x16.png");
            this.imgListRunAsActions.Images.SetKeyName(1, "delete - 16x16.png");
            // 
            // runAsContextMenu
            // 
            this.runAsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executeToolStripMenuItem,
            this.executeAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.openContainingFolderToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.runAsContextMenu.Name = "runAsContextMenu";
            this.runAsContextMenu.Size = new System.Drawing.Size(207, 98);
            this.runAsContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.runAsContextMenu_Opening);
            // 
            // executeToolStripMenuItem
            // 
            this.executeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("executeToolStripMenuItem.Image")));
            this.executeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.executeToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            this.executeToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.executeToolStripMenuItem.Text = "&Execute";
            this.executeToolStripMenuItem.Click += new System.EventHandler(this.ExecuteRunAs);
            // 
            // executeAsToolStripMenuItem
            // 
            this.executeAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("executeAsToolStripMenuItem.Image")));
            this.executeAsToolStripMenuItem.Name = "executeAsToolStripMenuItem";
            this.executeAsToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.executeAsToolStripMenuItem.Text = "Execute &As...";
            this.executeAsToolStripMenuItem.Click += new System.EventHandler(this.ExecuteRunAsAs);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(203, 6);
            // 
            // openContainingFolderToolStripMenuItem
            // 
            this.openContainingFolderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openContainingFolderToolStripMenuItem.Image")));
            this.openContainingFolderToolStripMenuItem.Name = "openContainingFolderToolStripMenuItem";
            this.openContainingFolderToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.openContainingFolderToolStripMenuItem.Text = "&Open containing folder...";
            this.openContainingFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenContainingFolder);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeToolStripMenuItem.Image")));
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.removeToolStripMenuItem.Text = "&Remove...";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveSelectedApplication);
            // 
            // runAsListMediumIcons
            // 
            this.runAsListMediumIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.runAsListMediumIcons.ImageSize = new System.Drawing.Size(32, 32);
            this.runAsListMediumIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // runAsListSmallIcons
            // 
            this.runAsListSmallIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.runAsListSmallIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.runAsListSmallIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // runAsListLargeIcons
            // 
            this.runAsListLargeIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.runAsListLargeIcons.ImageSize = new System.Drawing.Size(64, 64);
            this.runAsListLargeIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.runAsList);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.runAsUserDetails1);
            this.toolStripContainer1.ContentPanel.Padding = new System.Windows.Forms.Padding(10);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(513, 331);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(513, 380);
            this.toolStripContainer1.TabIndex = 15;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
            this.toolStripContainer1.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.currentStatus,
            this.toolTip});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(513, 24);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 19);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // currentStatus
            // 
            this.currentStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.currentStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.currentStatus.Name = "currentStatus";
            this.currentStatus.Size = new System.Drawing.Size(30, 19);
            this.currentStatus.Text = "Idle";
            // 
            // toolTip
            // 
            this.toolTip.Name = "toolTip";
            this.toolTip.Size = new System.Drawing.Size(45, 19);
            this.toolTip.Text = "Tooltip";
            // 
            // runAsList
            // 
            this.runAsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chRunAsName,
            this.chRunAsFile});
            this.runAsList.ContextMenuStrip = this.runAsContextMenu;
            this.runAsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.runAsList.LargeImageList = this.runAsListMediumIcons;
            this.runAsList.Location = new System.Drawing.Point(10, 86);
            this.runAsList.Name = "runAsList";
            this.runAsList.Size = new System.Drawing.Size(493, 235);
            this.runAsList.SmallImageList = this.runAsListSmallIcons;
            this.runAsList.TabIndex = 14;
            this.runAsList.UseCompatibleStateImageBehavior = false;
            this.runAsList.SelectedIndexChanged += new System.EventHandler(this.runAsList_SelectedIndexChanged);
            this.runAsList.DoubleClick += new System.EventHandler(this.ExecuteRunAs);
            // 
            // chRunAsName
            // 
            this.chRunAsName.Text = "Name";
            // 
            // chRunAsFile
            // 
            this.chRunAsFile.Text = "File";
            // 
            // runAsUserDetails1
            // 
            this.runAsUserDetails1.DataBind = false;
            this.runAsUserDetails1.Dock = System.Windows.Forms.DockStyle.Top;
            this.runAsUserDetails1.DomainName = "";
            this.runAsUserDetails1.Location = new System.Drawing.Point(10, 10);
            this.runAsUserDetails1.MaximumSize = new System.Drawing.Size(2048, 76);
            this.runAsUserDetails1.MinimumSize = new System.Drawing.Size(323, 76);
            this.runAsUserDetails1.Name = "runAsUserDetails1";
            this.runAsUserDetails1.Password = "";
            this.runAsUserDetails1.Size = new System.Drawing.Size(493, 76);
            this.runAsUserDetails1.TabIndex = 15;
            this.runAsUserDetails1.UserName = "";
            this.runAsUserDetails1.MouseEnter += new System.EventHandler(this.SetTooltip);
            this.runAsUserDetails1.MouseLeave += new System.EventHandler(this.ClearTooltip);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsExecuteRunAs});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(70, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // tsExecuteRunAs
            // 
            this.tsExecuteRunAs.AccessibleDescription = "Execute the selected Application.";
            this.tsExecuteRunAs.Enabled = false;
            this.tsExecuteRunAs.Image = ((System.Drawing.Image)(resources.GetObject("tsExecuteRunAs.Image")));
            this.tsExecuteRunAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsExecuteRunAs.Name = "tsExecuteRunAs";
            this.tsExecuteRunAs.Size = new System.Drawing.Size(67, 22);
            this.tsExecuteRunAs.Text = "&Execute";
            this.tsExecuteRunAs.Click += new System.EventHandler(this.ExecuteRunAs);
            this.tsExecuteRunAs.MouseEnter += new System.EventHandler(this.SetTooltip);
            this.tsExecuteRunAs.MouseLeave += new System.EventHandler(this.ClearTooltip);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsApplicationOpenFolder,
            this.toolStripSeparator2,
            this.tsAddApplication,
            this.tsDeleteApplication,
            this.tsRefreshApplications});
            this.toolStrip2.Location = new System.Drawing.Point(73, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(101, 25);
            this.toolStrip2.TabIndex = 1;
            // 
            // tsApplicationOpenFolder
            // 
            this.tsApplicationOpenFolder.AccessibleDescription = "Open the containing folder of the selected Application";
            this.tsApplicationOpenFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsApplicationOpenFolder.Image = ((System.Drawing.Image)(resources.GetObject("tsApplicationOpenFolder.Image")));
            this.tsApplicationOpenFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsApplicationOpenFolder.Name = "tsApplicationOpenFolder";
            this.tsApplicationOpenFolder.Size = new System.Drawing.Size(23, 22);
            this.tsApplicationOpenFolder.Text = "Open Containing Folder";
            this.tsApplicationOpenFolder.Click += new System.EventHandler(this.OpenContainingFolder);
            this.tsApplicationOpenFolder.MouseEnter += new System.EventHandler(this.SetTooltip);
            this.tsApplicationOpenFolder.MouseLeave += new System.EventHandler(this.ClearTooltip);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsAddApplication
            // 
            this.tsAddApplication.AccessibleDescription = "Register a new Application";
            this.tsAddApplication.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAddApplication.Image = ((System.Drawing.Image)(resources.GetObject("tsAddApplication.Image")));
            this.tsAddApplication.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAddApplication.Name = "tsAddApplication";
            this.tsAddApplication.Size = new System.Drawing.Size(23, 22);
            this.tsAddApplication.Text = "Add Application";
            this.tsAddApplication.ToolTipText = "Add an Application";
            this.tsAddApplication.Click += new System.EventHandler(this.AddRunAs);
            this.tsAddApplication.MouseEnter += new System.EventHandler(this.SetTooltip);
            this.tsAddApplication.MouseLeave += new System.EventHandler(this.ClearTooltip);
            // 
            // tsDeleteApplication
            // 
            this.tsDeleteApplication.AccessibleDescription = "Delete the selected Application";
            this.tsDeleteApplication.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDeleteApplication.Image = ((System.Drawing.Image)(resources.GetObject("tsDeleteApplication.Image")));
            this.tsDeleteApplication.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDeleteApplication.Name = "tsDeleteApplication";
            this.tsDeleteApplication.Size = new System.Drawing.Size(23, 22);
            this.tsDeleteApplication.Text = "Delete Application";
            this.tsDeleteApplication.ToolTipText = "Delete the selected Application";
            this.tsDeleteApplication.Click += new System.EventHandler(this.RemoveSelectedApplication);
            this.tsDeleteApplication.MouseEnter += new System.EventHandler(this.SetTooltip);
            this.tsDeleteApplication.MouseLeave += new System.EventHandler(this.ClearTooltip);
            // 
            // tsRefreshApplications
            // 
            this.tsRefreshApplications.AccessibleDescription = "Refresh the Registered Applications";
            this.tsRefreshApplications.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsRefreshApplications.Image = ((System.Drawing.Image)(resources.GetObject("tsRefreshApplications.Image")));
            this.tsRefreshApplications.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRefreshApplications.Name = "tsRefreshApplications";
            this.tsRefreshApplications.Size = new System.Drawing.Size(23, 22);
            this.tsRefreshApplications.Text = "&Refresh";
            this.tsRefreshApplications.ToolTipText = "Refresh the Registered Applications";
            this.tsRefreshApplications.Click += new System.EventHandler(this.RefreshApplications);
            this.tsRefreshApplications.MouseEnter += new System.EventHandler(this.SetTooltip);
            this.tsRefreshApplications.MouseLeave += new System.EventHandler(this.ClearTooltip);
            // 
            // tsExecuteRunAsOther
            // 
            this.tsExecuteRunAsOther.AccessibleDescription = "Execute the selected Application with other credentials.";
            this.tsExecuteRunAsOther.Name = "tsExecuteRunAsOther";
            this.tsExecuteRunAsOther.Size = new System.Drawing.Size(139, 22);
            this.tsExecuteRunAsOther.Text = "Execute &As...";
            this.tsExecuteRunAsOther.MouseEnter += new System.EventHandler(this.SetTooltip);
            this.tsExecuteRunAsOther.MouseLeave += new System.EventHandler(this.ClearTooltip);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 404);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iterative RunAs...";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.notificationContextMenu.ResumeLayout(false);
            this.runAsContextMenu.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoMinimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToTrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem allowCustomRunAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ImageList imgListRunAsActions;
        private System.Windows.Forms.ImageList runAsListMediumIcons;
        private System.Windows.Forms.ContextMenuStrip runAsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem executeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem openContainingFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ImageList runAsListSmallIcons;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tilesToolStripMenuItem;
        private System.Windows.Forms.ImageList runAsListLargeIcons;
        private System.Windows.Forms.ToolStripMenuItem statusbarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem authenticationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolTip;
        private System.Windows.Forms.ListView runAsList;
        private System.Windows.Forms.ColumnHeader chRunAsName;
        private System.Windows.Forms.ColumnHeader chRunAsFile;
        private Controls.RunAsUserDetails runAsUserDetails1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsExecuteRunAs;
        private System.Windows.Forms.ToolStripMenuItem tsExecuteRunAsOther;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsApplicationOpenFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsAddApplication;
        private System.Windows.Forms.ToolStripButton tsDeleteApplication;
        private System.Windows.Forms.ToolStripButton tsRefreshApplications;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel currentStatus;
        private System.Windows.Forms.ContextMenuStrip notificationContextMenu;
        private System.Windows.Forms.ToolStripMenuItem ncMenuItemShow;
        private System.Windows.Forms.ToolStripMenuItem ncMenuItemRunAsApplications;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ncMenuItemExit;
    }
}

