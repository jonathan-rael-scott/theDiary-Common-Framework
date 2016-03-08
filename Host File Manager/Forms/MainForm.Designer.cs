namespace theDiary.Tools.Development.HostFileManager
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.currentStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.entriesAreDirty = new System.Windows.Forms.ToolStripStatusLabel();
            this.entryCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.disabledEntryCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoMinimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.hostEntryMediumIcons = new System.Windows.Forms.ImageList(this.components);
            this.hostEntrySmallIcons = new System.Windows.Forms.ImageList(this.components);
            this.hostEntryLargeIcons = new System.Windows.Forms.ImageList(this.components);
            this.toolStripContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.largeIconsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumIconsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.iconsTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.hostEntryList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripActions = new System.Windows.Forms.ToolStrip();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStripContextMenu.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.viewContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentStatus,
            this.entriesAreDirty,
            this.entryCount,
            this.disabledEntryCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 282);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(635, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // currentStatus
            // 
            this.currentStatus.Name = "currentStatus";
            this.currentStatus.Size = new System.Drawing.Size(518, 17);
            this.currentStatus.Spring = true;
            this.currentStatus.Text = "toolStripStatusLabel1";
            this.currentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // entriesAreDirty
            // 
            this.entriesAreDirty.Name = "entriesAreDirty";
            this.entriesAreDirty.Size = new System.Drawing.Size(0, 17);
            // 
            // entryCount
            // 
            this.entryCount.Name = "entryCount";
            this.entryCount.Size = new System.Drawing.Size(51, 17);
            this.entryCount.Text = "0 Entries";
            // 
            // disabledEntryCount
            // 
            this.disabledEntryCount.Name = "disabledEntryCount";
            this.disabledEntryCount.Size = new System.Drawing.Size(51, 17);
            this.disabledEntryCount.Text = "0 Entries";
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
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(635, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem4,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(98, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit...";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoMinimizeToolStripMenuItem,
            this.minimizeToTrayToolStripMenuItem,
            this.alwaysOnTopToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.DropDownOpening += new System.EventHandler(this.editToolStripMenuItem_DropDownOpening);
            // 
            // autoMinimizeToolStripMenuItem
            // 
            this.autoMinimizeToolStripMenuItem.CheckOnClick = true;
            this.autoMinimizeToolStripMenuItem.Name = "autoMinimizeToolStripMenuItem";
            this.autoMinimizeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.autoMinimizeToolStripMenuItem.Tag = "MinimizeAfterRun";
            this.autoMinimizeToolStripMenuItem.Text = "&Auto Minimize...";
            this.autoMinimizeToolStripMenuItem.Click += new System.EventHandler(this.SetConfigurationChanged);
            // 
            // minimizeToTrayToolStripMenuItem
            // 
            this.minimizeToTrayToolStripMenuItem.CheckOnClick = true;
            this.minimizeToTrayToolStripMenuItem.Name = "minimizeToTrayToolStripMenuItem";
            this.minimizeToTrayToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.minimizeToTrayToolStripMenuItem.Tag = "MinimizeToTaskbar";
            this.minimizeToTrayToolStripMenuItem.Text = "&Minimize to Tray...";
            this.minimizeToTrayToolStripMenuItem.Click += new System.EventHandler(this.SetConfigurationChanged);
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.CheckOnClick = true;
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.alwaysOnTopToolStripMenuItem.Tag = "AlwaysOnTop";
            this.alwaysOnTopToolStripMenuItem.Text = "Always on &Top...";
            this.alwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.SetConfigurationChanged);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            // statusbarToolStripMenuItem
            // 
            this.statusbarToolStripMenuItem.CheckOnClick = true;
            this.statusbarToolStripMenuItem.Name = "statusbarToolStripMenuItem";
            this.statusbarToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.statusbarToolStripMenuItem.Tag = "ShowStatusbar";
            this.statusbarToolStripMenuItem.Text = "Statusbar";
            this.statusbarToolStripMenuItem.Click += new System.EventHandler(this.SetConfigurationChanged);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(147, 6);
            // 
            // largeIconsToolStripMenuItem
            // 
            this.largeIconsToolStripMenuItem.CheckOnClick = true;
            this.largeIconsToolStripMenuItem.Name = "largeIconsToolStripMenuItem";
            this.largeIconsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.largeIconsToolStripMenuItem.Tag = "LargeIcon";
            this.largeIconsToolStripMenuItem.Text = "&Large icons";
            this.largeIconsToolStripMenuItem.Click += new System.EventHandler(this.ListItemsViewChanged);
            // 
            // mediumIconsToolStripMenuItem
            // 
            this.mediumIconsToolStripMenuItem.CheckOnClick = true;
            this.mediumIconsToolStripMenuItem.Name = "mediumIconsToolStripMenuItem";
            this.mediumIconsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.mediumIconsToolStripMenuItem.Tag = "MediumIcon";
            this.mediumIconsToolStripMenuItem.Text = "&Medium icons";
            this.mediumIconsToolStripMenuItem.Click += new System.EventHandler(this.ListItemsViewChanged);
            // 
            // smallIconsToolStripMenuItem
            // 
            this.smallIconsToolStripMenuItem.CheckOnClick = true;
            this.smallIconsToolStripMenuItem.Name = "smallIconsToolStripMenuItem";
            this.smallIconsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.smallIconsToolStripMenuItem.Tag = "SmallIcon";
            this.smallIconsToolStripMenuItem.Text = "&Small icons";
            this.smallIconsToolStripMenuItem.Click += new System.EventHandler(this.ListItemsViewChanged);
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.CheckOnClick = true;
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.detailsToolStripMenuItem.Tag = "Details";
            this.detailsToolStripMenuItem.Text = "&Details";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.ListItemsViewChanged);
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.CheckOnClick = true;
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.listToolStripMenuItem.Tag = "List";
            this.listToolStripMenuItem.Text = "L&ist";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.ListItemsViewChanged);
            // 
            // tilesToolStripMenuItem
            // 
            this.tilesToolStripMenuItem.CheckOnClick = true;
            this.tilesToolStripMenuItem.Name = "tilesToolStripMenuItem";
            this.tilesToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.tilesToolStripMenuItem.Tag = "Tile";
            this.tilesToolStripMenuItem.Text = "&Tiles";
            this.tilesToolStripMenuItem.Click += new System.EventHandler(this.ListItemsViewChanged);
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
            // 
            // hostEntryMediumIcons
            // 
            this.hostEntryMediumIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("hostEntryMediumIcons.ImageStream")));
            this.hostEntryMediumIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.hostEntryMediumIcons.Images.SetKeyName(0, "Disabled_Medium.png");
            this.hostEntryMediumIcons.Images.SetKeyName(1, "Enabled_Medium.png");
            this.hostEntryMediumIcons.Images.SetKeyName(2, "Add_Medium.png");
            this.hostEntryMediumIcons.Images.SetKeyName(3, "Edit_Medium.png");
            this.hostEntryMediumIcons.Images.SetKeyName(4, "Delete_Medium.png");
            this.hostEntryMediumIcons.Images.SetKeyName(5, "Disable_Medium.png");
            this.hostEntryMediumIcons.Images.SetKeyName(6, "Enable_Medium.png");
            this.hostEntryMediumIcons.Images.SetKeyName(7, "Find_Medium.png");
            this.hostEntryMediumIcons.Images.SetKeyName(8, "Refresh_Medium.png");
            this.hostEntryMediumIcons.Images.SetKeyName(9, "Save_Medium.png");
            // 
            // hostEntrySmallIcons
            // 
            this.hostEntrySmallIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("hostEntrySmallIcons.ImageStream")));
            this.hostEntrySmallIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.hostEntrySmallIcons.Images.SetKeyName(0, "Disabled_Small.png");
            this.hostEntrySmallIcons.Images.SetKeyName(1, "Enabled_Small.png");
            this.hostEntrySmallIcons.Images.SetKeyName(2, "Add_Small.png");
            this.hostEntrySmallIcons.Images.SetKeyName(3, "Edit_Small.png");
            this.hostEntrySmallIcons.Images.SetKeyName(4, "Delete_Small.png");
            this.hostEntrySmallIcons.Images.SetKeyName(5, "Disable_Small.png");
            this.hostEntrySmallIcons.Images.SetKeyName(6, "Enable_Small.png");
            this.hostEntrySmallIcons.Images.SetKeyName(7, "Find_Small.png");
            this.hostEntrySmallIcons.Images.SetKeyName(8, "Refresh_Small.png");
            this.hostEntrySmallIcons.Images.SetKeyName(9, "Save_Small.png");
            // 
            // hostEntryLargeIcons
            // 
            this.hostEntryLargeIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.hostEntryLargeIcons.ImageSize = new System.Drawing.Size(48, 48);
            this.hostEntryLargeIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStripContextMenu
            // 
            this.toolStripContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeIconsToolStripMenuItem1,
            this.mediumIconsToolStripMenuItem1,
            this.smallIconsToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.iconsTextToolStripMenuItem,
            this.textOnlyToolStripMenuItem});
            this.toolStripContextMenu.Name = "toolStripContextMenu";
            this.toolStripContextMenu.Size = new System.Drawing.Size(151, 120);
            this.toolStripContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.toolStripContextMenu_Opening);
            // 
            // largeIconsToolStripMenuItem1
            // 
            this.largeIconsToolStripMenuItem1.Name = "largeIconsToolStripMenuItem1";
            this.largeIconsToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.largeIconsToolStripMenuItem1.Text = "&Large Icons";
            // 
            // mediumIconsToolStripMenuItem1
            // 
            this.mediumIconsToolStripMenuItem1.Name = "mediumIconsToolStripMenuItem1";
            this.mediumIconsToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.mediumIconsToolStripMenuItem1.Text = "&Medium Icons";
            // 
            // smallIconsToolStripMenuItem1
            // 
            this.smallIconsToolStripMenuItem1.Name = "smallIconsToolStripMenuItem1";
            this.smallIconsToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.smallIconsToolStripMenuItem1.Text = "&Small Icons";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(147, 6);
            // 
            // iconsTextToolStripMenuItem
            // 
            this.iconsTextToolStripMenuItem.Name = "iconsTextToolStripMenuItem";
            this.iconsTextToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.iconsTextToolStripMenuItem.Text = "&Icons && Text";
            // 
            // textOnlyToolStripMenuItem
            // 
            this.textOnlyToolStripMenuItem.Name = "textOnlyToolStripMenuItem";
            this.textOnlyToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.textOnlyToolStripMenuItem.Text = "&Text Only";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.hostEntryList);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(635, 258);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(635, 258);
            this.toolStripContainer1.TabIndex = 12;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.ContextMenuStrip = this.toolStripContextMenu;
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripActions);
            // 
            // hostEntryList
            // 
            this.hostEntryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.hostEntryList.ContextMenuStrip = this.viewContextMenu;
            this.hostEntryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hostEntryList.LargeImageList = this.hostEntryMediumIcons;
            this.hostEntryList.Location = new System.Drawing.Point(0, 0);
            this.hostEntryList.Name = "hostEntryList";
            this.hostEntryList.Size = new System.Drawing.Size(635, 258);
            this.hostEntryList.SmallImageList = this.hostEntrySmallIcons;
            this.hostEntryList.TabIndex = 10;
            this.hostEntryList.UseCompatibleStateImageBehavior = false;
            this.hostEntryList.View = System.Windows.Forms.View.Details;
            this.hostEntryList.SelectedIndexChanged += new System.EventHandler(this.SelectedHostEntryChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP Address";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Destination";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Enabled";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Description";
            // 
            // viewContextMenu
            // 
            this.viewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.groupByToolStripMenuItem,
            this.toolStripMenuItem2});
            this.viewContextMenu.Name = "contextMenuStrip1";
            this.viewContextMenu.Size = new System.Drawing.Size(133, 32);
            this.viewContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.viewContextMenu_Opening);
            // 
            // groupByToolStripMenuItem
            // 
            this.groupByToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noneToolStripMenuItem,
            this.toolStripMenuItem5});
            this.groupByToolStripMenuItem.Name = "groupByToolStripMenuItem";
            this.groupByToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.groupByToolStripMenuItem.Text = "Group By...";
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.noneToolStripMenuItem.Text = "&None";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(100, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(129, 6);
            // 
            // toolStripActions
            // 
            this.toolStripActions.ContextMenuStrip = this.toolStripContextMenu;
            this.toolStripActions.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripActions.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripActions.Location = new System.Drawing.Point(4, 0);
            this.toolStripActions.Name = "toolStripActions";
            this.toolStripActions.Size = new System.Drawing.Size(1, 0);
            this.toolStripActions.TabIndex = 11;
            this.toolStripActions.Text = "toolStrip1";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "&Save As...";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 304);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Host File Manager";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContextMenu.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.viewContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoMinimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToTrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusbarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem largeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel currentStatus;
        private System.Windows.Forms.ImageList hostEntrySmallIcons;
        private System.Windows.Forms.ImageList hostEntryMediumIcons;
        private System.Windows.Forms.ImageList hostEntryLargeIcons;
        private System.Windows.Forms.ContextMenuStrip toolStripContextMenu;
        private System.Windows.Forms.ToolStripMenuItem largeIconsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mediumIconsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem smallIconsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem iconsTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ListView hostEntryList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStrip toolStripActions;
        private System.Windows.Forms.ToolStripStatusLabel entriesAreDirty;
        private System.Windows.Forms.ContextMenuStrip viewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem groupByToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripStatusLabel entryCount;
        private System.Windows.Forms.ToolStripStatusLabel disabledEntryCount;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    }
}

