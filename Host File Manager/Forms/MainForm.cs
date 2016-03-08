using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace theDiary.Tools.Development.HostFileManager
{
    public partial class MainForm
        : Form, ISelectedItemContainer<HostEntry>
    {
        public MainForm()
        {
            InitializeComponent();
            this.lastWindowState = this.WindowState;
            HostsFileHelper.IsDirtyHandler += (s, e) =>
            {
                if (Configuration.Instance.AutoSave)
                {
                    HostsFileHelper.SaveHostEntries();
                }
                else
                {
                    this.entriesAreDirty.Text = HostsFileHelper.IsDirty ? "Dirty" : string.Empty;
                }
            };

            this.FormClosing += (sender, e) =>
            {
                if (Configuration.Instance.ConfirmWhenExiting && (e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.ApplicationExitCall))
                    e.Cancel = MessageBox.Show(this, "Are you sure want to Exit?", "Exit Host File Manager", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes;
                if (!e.Cancel && HostsFileHelper.IsDirty && MessageBox.Show(this, "Do you want to save the host file entries?", "Save changes?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    HostsFileHelper.SaveHostEntries();
            };

            this.Load += (sender, e) =>
            {
                Configuration.Instance.PropertyChanged += this.Instance_PropertyChanged;

                foreach (var property in typeof(Configuration).GetProperties())
                    this.Instance_PropertyChanged(this, new PropertyChangedEventArgs(property.Name));
            };
            this.exitToolStripMenuItem.Click += (s, e) => Application.Exit();

            


            this.InitializeListViewActions();
            this.InitializeToolstripActions();
            this.InitializeMenuActions();



            this.Load += (s, e) =>
            {

            };
            this.Shown += (s, e) =>
            {
                this.actions.Process<ToolstripButtonAction<HostEntry>, ToolStrip>();
                this.actions.Process<ToolstripButtonStateAction<HostEntry>, ToolStrip>();
                this.actions.Process<MenuItemAction>();
                this.actions.Process<ViewAction>();
                this.RefreshHostEntries();
            };
        }

        #region Private Declarations
        private FormWindowState lastWindowState;
        private ActionContainer actions = new ActionContainer();
        #endregion

        #region Event Declarations
        public event EventHandler WindowStateChanged;

        public event SelectedItemChangedEventHandler<HostEntry> SelectedItemChanged;
        #endregion

        private void InitializeMenuActions()
        {
            this.actions.Add(new MenuItemAction("File", "Refresh", (s, e) => this.RefreshHostEntries()));
            this.actions.Add(new MenuItemAction("File", "Options", (s, e) =>
            {
                this.OpenFormDialog<DialogForm>(new DialogForm(new Controls.OptionsControl()));
            }, new 
            {
                Image = Resources._16x16.Configure,
            }
            ));

            this.actions.RegisterProcessor<MenuItemAction>(action =>
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                action.SetControl(item);
                if (string.IsNullOrWhiteSpace(action.ParentPath))
                {
                    menuStrip1.Items.Add(item);
                }
                else
                {
                    ToolStripMenuItem parent = action.GetParent(menuStrip1);
                    parent.DropDownItems.Insert(0, item);
                }
            });
        }
        private void InitializeListViewActions()
        {
            if (ElevatedApplication.IsElevated)
                this.actions.Add(new ViewAction("ViewDoubleClick", "DoubleClick", (s, e) =>
                {
                    if (this.SelectedItem.IsNotNull())
                        this.EditHostEntry(this.SelectedItem);
                }));
            this.actions.RegisterProcessor<ViewAction>(action => action.AttachAction(this.hostEntryList));
        }

        private void InitializeToolstripActions()
        {


            this.actions.Add(new ToolstripButtonAction<HostEntry>("Host Entry", "AddHostEntry", this.AddHostEntry, new {
                ImageKey = "NewHost",
                ToolTipText = "Add a new Host entry.",
                Text = "Add"
            }));
            this.actions.Add(new ToolstripButtonAction<HostEntry>("Host Entry", "EditHostEntry",
                this.EditHostEntry, new {
                    ImageKey = "EditHost",
                    Text = "Edit",
                    Enabled = new Func<bool>(() => this.SelectedItem.IsNotNull()),
                    Visible = new Func<bool>(() => this.SelectedItem.IsNotNull())
                    }));

            this.actions.Add(new ToolstripButtonAction<HostEntry>("Host Entry", "DeleteHostEntry",
                this.DeleteHostEntry, new
                {
                    ImageKey = "DeleteHost",
                    Text = "Delete",
                    Visible = new Func<bool>(() => this.SelectedItem.IsNotNull()),
                    Enabled = new Func<bool>(() => this.SelectedItem.IsNotNull()),
                }));
            this.actions.Add(new ToolstripButtonAction<HostEntry>("Host Entry", "DisableHostEntry",
                this.EnableDisableHostEntry, new
                {
                    ImageKey = new Func<string>(() => this.SelectedItem.IsNull() || this.SelectedItem.Enabled ? "DisableHost" : "EnableHost"),
                    Text = new Func<string>(() => this.SelectedItem.IsNull() || this.SelectedItem.Enabled ? "Disable" : "Enable"),

                }));

            this.actions.Add(new ToolstripButtonAction<HostEntry>("Common", "Refresh", (s, e) => this.RefreshHostEntries(), new
            {
                ImageKey = "Refresh",
                Text = "Refresh",
                ToolTipText = "Reloads all entries in the 'Hosts' file.",
            }));
            if (ElevatedApplication.IsElevated)
                this.actions.Add(new ToolstripButtonStateAction<HostEntry>("Common", "Save", new ActionStateEventHandler<HostEntry>((s, e) => HostsFileHelper.SaveHostEntries()), new
                {
                    Enabled = new Func<bool>(() => HostsFileHelper.IsDirty),
                    ToolTipText = "Save the changes."
                }
                ));
            this.actions.Add(new ToolstripButtonAction<HostEntry>("Common", "Search", SearchHostEntries, new
            {
                ImageKey = "Search",
                Text = "Search"
            }));

            // Register Processors
            this.actions.RegisterProcessor<ToolstripButtonAction<HostEntry>, ToolStrip>(new Action<ToolstripButtonAction<HostEntry>, ToolStrip>((action, toolstripGroup) =>
            {
                var tsButton = new ToolStripButton();
                action.SetControl(tsButton);
                toolstripGroup.Items.Add(tsButton);
                IClientControlStateAction stateAction = action as IClientControlStateAction;
                if (stateAction != null)
                {
                    this.SelectedItemChanged += (s, e) =>
                    {
                        //stateAction.SetState(this.SelectedItem);
                        stateAction.SetControl(tsButton, this.SelectedItem);
                    };
                }
            }),
            groupBy =>
            {
                string groupName = string.IsNullOrWhiteSpace(groupBy) ? "group_Common" : groupBy.Trim();
                ToolStrip toolstripGroup = this.toolStripContainer1.TopToolStripPanel.Controls.Find(groupName, false).FirstOrDefault() as ToolStrip;
                if (toolstripGroup == null)
                {
                    toolstripGroup = new ToolStrip();
                    toolstripGroup.Name = groupName;
                    toolstripGroup.Text = groupBy;
                    toolstripGroup.ImageList = toolstripGroup.ImageList.CreateImageList(typeof(Resources._16x16), new Size(16,16));
                    toolstripGroup.Left = 0;
                    toolstripGroup.Top = 0;
                    this.toolStripContainer1.TopToolStripPanel.Controls.Add(toolstripGroup);
                }
                return toolstripGroup;
            });

            this.actions.RegisterProcessor<ToolstripButtonStateAction<HostEntry>, ToolStrip>(new Action<ToolstripButtonStateAction<HostEntry>, ToolStrip>((action, toolstripGroup) =>
            {
                var tsButton = new ToolStripButton();
                ((IClientControlStateAction<HostEntry, ToolStripButton>) action).SetControl(tsButton);
                toolstripGroup.Items.Add(tsButton);
                IClientControlStateAction stateAction = action as IClientControlStateAction;
                if (stateAction != null)
                {
                    this.SelectedItemChanged += (s, e) =>
                    {
                        stateAction.SetState(this.SelectedItem);
                        stateAction.SetControl(tsButton, this.SelectedItem);
                    };
                }
            }),
            groupBy =>
            {
                string groupName = string.IsNullOrWhiteSpace(groupBy) ? "group_Common" : groupBy.Trim();
                ToolStrip toolstripGroup = this.toolStripContainer1.TopToolStripPanel.Controls.Find(groupName, false).FirstOrDefault() as ToolStrip;
                if (toolstripGroup == null)
                {
                    toolstripGroup = new ToolStrip();
                    toolstripGroup.Name = groupName;
                    toolstripGroup.Text = groupBy;
                    toolstripGroup.ImageList = this.hostEntrySmallIcons;
                    toolstripGroup.Left = 0;
                    toolstripGroup.Top = 0;
                    this.toolStripContainer1.TopToolStripPanel.Controls.Add(toolstripGroup);
                }
                return toolstripGroup;
            });
        }
        #region Public Read-Only Properties
        public HostEntry SelectedItem
        {
            get
            {
                return this.hostEntryList.SelectedIndices.Count == 0
                    ? null
                    : (HostEntry) this.hostEntryList.Items[this.hostEntryList.SelectedIndices[0]].Tag;
            }
        }
        #endregion

        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            foreach (ToolStripItem a in ((ToolStripMenuItem) sender).DropDownItems)
            {
                if (!(a is ToolStripMenuItem))
                    continue;

                string name = ((ToolStripMenuItem) a).Tag as string;
                PropertyInfo p ;
                if (typeof(Configuration).TryGetProperty(name, out p))
                    ((ToolStripMenuItem) a).Checked = p.GetValue(Configuration.Instance, null).As<bool>();
            }
        }

        private void viewToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            this.statusbarToolStripMenuItem.Checked = Configuration.Instance.ShowStatusbar;
            this.largeIconsToolStripMenuItem.Checked = (Configuration.Instance.CurrentItemsView == ListItemsView.LargeIcon);
            this.mediumIconsToolStripMenuItem.Checked = (Configuration.Instance.CurrentItemsView == ListItemsView.MediumIcon);
            this.smallIconsToolStripMenuItem.Checked = (Configuration.Instance.CurrentItemsView == ListItemsView.SmallIcon);
            this.tilesToolStripMenuItem.Checked = (Configuration.Instance.CurrentItemsView == ListItemsView.Tile);
            this.listToolStripMenuItem.Checked = (Configuration.Instance.CurrentItemsView == ListItemsView.List);
            this.detailsToolStripMenuItem.Checked = (Configuration.Instance.CurrentItemsView == ListItemsView.Details);
        }

        public void SearchHostEntries(object sender, EventArgs e)
        {
        }

        private void EnableDisableHostEntry(object sender, EventArgs e)//ActionEventArgs<HostEntry> e)
        {
            this.SelectedItem.Toggle();
            this.RefreshHostEntry(this.SelectedItem, this.hostEntryList.SelectedItems[0]);
            HostsFileHelper.SetEntry(this.SelectedItem);
        }

        private void AddHostEntry(object sender, EventArgs e)
        {
            this.OpenFormDialog<DialogForm>(new DialogForm(new Controls.HostEntryControl()), addApp =>
            {

                if (addApp.DialogResult != System.Windows.Forms.DialogResult.OK)
                {
                    this.SetTooltip();
                    return;
                }
                Task.Run(() => this.RefreshHostEntries());
            });
        }

        private void DeleteHostEntry(object sender, EventArgs e)
        {
            HostsFileHelper.RemoveEntry(this.SelectedItem);
            Task.Run(() => this.RefreshHostEntries());
        }

        private void EditHostEntry(object sender, EventArgs e)//ActionEventArgs<HostEntry> e)
        {
            //e.State = this.SelectedItem;
            this.EditHostEntry(this.SelectedItem);
            this.RefreshHostEntry(this.SelectedItem, this.hostEntryList.SelectedItems[0]);
        }

        private void Instance_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "AlwaysOnTop":
                    this.TopMost = Configuration.Instance.AlwaysOnTop;
                    break;
                case "CurrentItemsView":
                    this.hostEntryList.BeginUpdate();
                    this.hostEntryList.LargeImageList = (Configuration.Instance.CurrentItemsView == ListItemsView.LargeIcon) ? this.hostEntryLargeIcons : this.hostEntryMediumIcons;
                    System.Windows.Forms.View view = (Configuration.Instance.CurrentItemsView == ListItemsView.MediumIcon) ? System.Windows.Forms.View.LargeIcon : (System.Windows.Forms.View) (int) Configuration.Instance.CurrentItemsView;
                    this.hostEntryList.View = view;
                    this.hostEntryList.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
                    this.hostEntryList.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
                    this.hostEntryList.EndUpdate();
                    break;
                case "CurrentToolstripView":
                    ToolStripItemDisplayStyle displayStyle = ToolStripItemDisplayStyle.Text;
                    System.Drawing.Size size = default(System.Drawing.Size);
                    ToolstripView value = Configuration.Instance.CurrentToolstripView;
                    if (value == ToolstripView.TextOnly)
                    {
                        displayStyle = ToolStripItemDisplayStyle.Text;
                    }
                    else if (value.HasFlag(ToolstripView.Text | ToolstripView.SmallIcons))
                    {
                        displayStyle = ToolStripItemDisplayStyle.ImageAndText;
                        this.toolStripActions.ImageList = hostEntrySmallIcons;
                    }
                    else if (value.HasFlag(ToolstripView.Text | ToolstripView.MediumIcons))
                    {
                        displayStyle = ToolStripItemDisplayStyle.ImageAndText;
                        this.toolStripActions.ImageList = hostEntryMediumIcons;
                    }
                    else if (value.HasFlag(ToolstripView.Text | ToolstripView.LargeIcons))
                    {
                        displayStyle = ToolStripItemDisplayStyle.ImageAndText;
                        size = new Size(48, 48);
                        this.toolStripActions.ImageList = hostEntryLargeIcons;
                    }
                    break;
                case "ShowStatusbar":
                    this.statusStrip1.Visible = Configuration.Instance.ShowStatusbar;
                    break;
            }
        }

        private void RefreshHostEntries()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(this.RefreshHostEntries), null);
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            this.SetCurrentStatus("Refreshing...");

            this.hostEntryList.BeginUpdate();
            this.hostEntryList.Items.Clear();
            var entries = HostsFileHelper.GetHostEntries();
            foreach (var entry in entries)
            {
                ListViewItem item = this.RefreshHostEntry(entry);
                this.hostEntryList.Items.Add(item);
            }
            this.entryCount.Text = string.Format("{0} Entries", entries.Count());
            this.disabledEntryCount.Text = string.Format("{0} Entries", entries.Where(entry => !entry.Enabled).Count());
            this.hostEntryList.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.hostEntryList.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.hostEntryList.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.hostEntryList.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.hostEntryList.EndUpdate();
            this.SetCurrentStatus();
            this.Cursor = Cursors.Default;

        }

        private ListViewItem RefreshHostEntry(HostEntry hostEntry, ListViewItem item = null)
        {
            if (item == null)
                item = new ListViewItem();
            if (item.SubItems.Count < 4)
                while (item.SubItems.Count < 4)
                    item.SubItems.Add(new ListViewItem.ListViewSubItem());
            item.Text = hostEntry.IPAddress.ToString();
            item.SubItems[1].Text = hostEntry.Destination;
            item.SubItems[2].Text = hostEntry.Enabled ? "Enabled" : "Disabled";
            item.SubItems[3].Text = hostEntry.Description;
            item.Tag = hostEntry;
            item.ImageIndex = hostEntry.Enabled ? 1 : 0;

            return item;
        }

        private void SetCurrentStatus(string currentStatusFormat, params object[] args)
        {
            this.SetCurrentStatus(string.Format(currentStatusFormat, args));
        }

        private void SetCurrentStatus(string currentStatus = "Idle")
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(this.SetTooltip), currentStatus);
                return;
            }

            if (string.IsNullOrWhiteSpace(currentStatus))
                currentStatus = "Idle";

            this.currentStatus.Text = currentStatus;
            this.Invalidate();

        }

        private void SetTooltip(string tooltipText = "")
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(this.SetTooltip), tooltipText);
                return;
            }
            this.Invalidate();
        }

        private void SetTooltip(string tooltipFormat, params object[] args)
        {
            this.SetTooltip(string.Format(tooltipFormat, args));
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {

        }

        private void EditHostEntry(HostEntry hostEntry)
        {
            this.OpenFormDialog<DialogForm>(new DialogForm(new Controls.HostEntryControl(hostEntry)), addApp =>
            {
                if (addApp.DialogResult != System.Windows.Forms.DialogResult.OK)
                {
                    this.SetTooltip();
                    return;
                }
                Task.Run(() => this.RefreshHostEntries());
            });
        }

        private void OpenFormDialog<T>(T dialogForm, Action<T> dialogAction = null)
            where T : Form
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<T, Action<T>>(this.OpenFormDialog), dialogForm, dialogAction);
                return;
            }

            this.SetCurrentStatus("Opening {0}...", dialogForm.Text);
            dialogForm.ShowDialog(this);
            if (dialogForm.DialogResult == System.Windows.Forms.DialogResult.OK && dialogAction != null)
                dialogAction(dialogForm);
            dialogForm.Dispose();
            this.SetCurrentStatus();
        }
        private void SelectedHostEntryChanged(object sender, EventArgs e)
        {
            HostEntry item = this.hostEntryList.SelectedIndices.Count == 0 ? null : (HostEntry) this.hostEntryList.Items[this.hostEntryList.SelectedIndices[0]].Tag;
            if (this.SelectedItemChanged != null)
                this.SelectedItemChanged(this, new ItemEventArgs<HostEntry>(item));
        }

        private void ListItemsViewChanged(object sender, EventArgs e)
        {
            ListItemsView view = (ListItemsView) Enum.Parse(typeof(ListItemsView), (string) ((ToolStripMenuItem) sender).Tag);
            typeof(Configuration).GetProperty("CurrentItemsView").SetValue(Configuration.Instance, view, null);
        }
        private void SetConfigurationChanged(object sender, EventArgs e)
        {
            string configurationName = ((ToolStripMenuItem) sender).Tag as string;
            typeof(Configuration).GetProperty(configurationName).SetValue(Configuration.Instance, ((ToolStripMenuItem) sender).Checked, null);
        }
        private void toolStripContextMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ToolstripViewChanged(object sender, EventArgs e)
        {
            ToolstripView view = (ToolstripView) Enum.Parse(typeof(ToolstripView), (string) ((ToolStripMenuItem) sender).Tag);
            typeof(Configuration).GetProperty("CurrentToolstripView").SetValue(Configuration.Instance, view, null);
        }

        private void viewContextMenu_Opening(object sender, CancelEventArgs e)
        {
            foreach (var a in this.hostEntryList.Columns.Cast<ColumnHeader>())
            {
                if (this.groupByToolStripMenuItem.DropDownItems.ContainsKey(a.Text))
                    continue;
                var item = new ToolStripMenuItem(a.Text);
                item.Click += (s, e2) =>
                {
                    this.hostEntryList.Groups.Clear();
                    foreach (var he in this.hostEntryList.Items.Cast<ListViewItem>())
                    {
                        //                        (he.Tag as HostEntry).
                    }
                    var groupBy = new ListViewGroup(a.Text, HorizontalAlignment.Left);
                    //this.hostEntryList.Groups.Add();
                };
                this.groupByToolStripMenuItem.DropDownItems.Add(item);
            }

            IEnumerable<ToolStripItem> items = this.viewToolStripMenuItem.DropDownItems.Cast<ToolStripItem>().Skip(2);
            viewContextMenu.Items.AddRange(items.ToArray());
        }
    }
}
