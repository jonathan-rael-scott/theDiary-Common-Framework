using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Iterative.Tools.RunAs
{
    public partial class MainForm : Form
    {
        #region Constructors
        public MainForm()
        {
            InitializeComponent();
            this.lastWindowState = this.WindowState;
            this.SelectedItemChanged += Form1_SelectedItemChanged;
            
        }
        #endregion

        #region Event Declarations
        public event EventHandler WindowStateChanged;

        public event EventHandler SelectedItemChanged;
        #endregion

        #region Private Declarations
        private FormWindowState lastWindowState;
        
        private IRunAs selectedItem;
        #endregion

        #region Public Properties
        public IRunAs SelectedItem
        {
            get
            {
                return this.selectedItem;
            }
            private set
            {
                this.selectedItem = value;
                this.SelectedItemChanged(this, new EventArgs());
            }
        }
        #endregion

        #region Event Handler Methods & Functions
        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
                e.Cancel = MessageBox.Show(this, "Are you sure want to Exit?", "Exit RunAs", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes;
        }

        void Instance_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "AlwaysOnTop":
                    this.TopMost = Configuration.Instance.AlwaysOnTop;
                    break;
                case "AllowCustomApplicationRunAs":
                    this.RefreshApplications(sender, e);
                    break;
                case "RunAsView":
                    this.runAsList.BeginUpdate();
                    this.runAsList.LargeImageList = (Configuration.Instance.RunAsView == RunAsView.LargeIcon) ? this.runAsListLargeIcons : this.runAsListMediumIcons;
                    System.Windows.Forms.View view = (Configuration.Instance.RunAsView == RunAsView.MediumIcon) ? System.Windows.Forms.View.LargeIcon : (System.Windows.Forms.View)(int)Configuration.Instance.RunAsView;
                    this.runAsList.View = view;
                    this.runAsList.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
                    this.runAsList.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
                    this.runAsList.EndUpdate();
                    break;
                case "ShowStatusbar":
                    this.statusStrip1.Visible = Configuration.Instance.ShowStatusbar;
                    break;
                case "ViewAuthenticationDetails":
                    this.runAsUserDetails1.Visible = Configuration.Instance.ViewAuthenticationDetails;
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormClosing += Form1_FormClosing;
            Configuration.Instance.PropertyChanged += Instance_PropertyChanged;
            this.runAsUserDetails1.DataBindings.Add("DomainName", Configuration.Instance, "DomainName", false, DataSourceUpdateMode.OnPropertyChanged);
            this.runAsUserDetails1.DataBindings.Add("UserName", Configuration.Instance, "UserName", false, DataSourceUpdateMode.OnPropertyChanged);
            this.runAsUserDetails1.DataBindings.Add("Password", Configuration.Instance, "Password", false, DataSourceUpdateMode.OnPropertyChanged);
            
            foreach (var property in typeof(Configuration).GetProperties())
                this.Instance_PropertyChanged(this, new PropertyChangedEventArgs(property.Name));

            this.Form1_SelectedItemChanged(sender, e);
        }

        

        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            foreach (ToolStripItem a in ((ToolStripMenuItem)sender).DropDownItems)
            {
                if (!(a is ToolStripMenuItem))
                    continue;

                string name = ((ToolStripMenuItem)a).Tag as string;
                ((ToolStripMenuItem)a).Checked = (bool)typeof(Configuration).GetProperty(name).GetValue(Configuration.Instance, null);
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                this.ShowRunAsForm(sender, e);
        }
        #endregion

        #region Private Methods & Functions
        private void ShowTooltip(object sender, EventArgs e)
        {
            this.toolTip.Text = ((Control)sender).AccessibleDescription;
        }

        private void HideTooltip(object sender, EventArgs e)
        {
            this.toolTip.Text = string.Empty;
        }

        private void SetConfigurationChanged(object sender, EventArgs e)
        {
            string configurationName = ((ToolStripMenuItem)sender).Tag as string;
            typeof(Configuration).GetProperty(configurationName).SetValue(Configuration.Instance, ((ToolStripMenuItem)sender).Checked, null);
        }

        private void SetRunAsViewChanged(object sender, EventArgs e)
        {
            RunAsView view = (RunAsView)((ToolStripMenuItem)sender).Tag;
            typeof(Configuration).GetProperty("RunAsView").SetValue(Configuration.Instance, view, null);
        }

        private int RegisterIcon(Icon appIcon = null)
        {
            if (appIcon == null)
            {
                this.runAsListLargeIcons.Images.Clear();
                this.runAsListMediumIcons.Images.Clear();
                this.runAsListSmallIcons.Images.Clear();
                this.runAsListLargeIcons.Images.Add(Properties.Resources.SelectApplication_Large);
                this.runAsListMediumIcons.Images.Add(Properties.Resources.SelectApplication_Medium);
                this.runAsListSmallIcons.Images.Add(Properties.Resources.SelectApplication_Small);
            }
            else
            {
                this.runAsListLargeIcons.Images.Add(appIcon);
                this.runAsListMediumIcons.Images.Add(appIcon);
                this.runAsListSmallIcons.Images.Add(appIcon);
            }

            return this.runAsListSmallIcons.Images.Count - 1;
        }

        private RunAsItem CreateRunAsItem(IRunAs application)
        {
            Type applicationType = application.GetType();
            int applicationRunAsType = (applicationType == typeof(RegisteredRunAs)) ? 0 : (applicationType == typeof(SelectApplicationRunAs)) ? 2 : 1;

            int imageIndex = 0;
            if (applicationRunAsType == 0)
                imageIndex = this.RegisterIcon(Icon.ExtractAssociatedIcon(application.Path));

            RunAsItem item = new RunAsItem(application, imageIndex, this.ExecuteRunAs);
            if (applicationRunAsType == 2)
                ((SelectApplicationRunAs)application).ExecuteHandler = this.ShowAddApplicationDialog;

            return item;
        }

        private void RefreshRunAsApplications()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(this.RefreshRunAsApplications), null);
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            this.SetCurrentStatus("Refreshing Applications...");
            this.SelectedItem = null;
            this.tsRefreshApplications.Enabled = false;
            this.ncMenuItemRunAsApplications.DropDownItems.Clear();

            this.runAsList.BeginUpdate();
            this.runAsList.Items.Clear();
            this.RegisterIcon();

            foreach (var application in RunAsHelper.GetAvailableRunAsApplications())
            {
                RunAsItem item = this.CreateRunAsItem(application);
                this.runAsList.Items.Add(item);
                this.ncMenuItemRunAsApplications.DropDownItems.Add(item);
            }
            this.runAsList.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.runAsList.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.runAsList.EndUpdate();
            this.tsRefreshApplications.Enabled = true;
            this.SetCurrentStatus();
            this.Cursor = Cursors.Default;
        }

        private void ExecuteRunAs(IRunAs runAs, IRunAsDetails runAsDetails)
        {
            if (runAs == null)
                return;
            System.Threading.ThreadPool.QueueUserWorkItem(a =>
            {
                this.SetCurrentStatus(string.Format("Starting {0}...", runAs.DisplayName));
                var originalProcess = System.Diagnostics.Process.GetProcesses().Where(currentProcess => currentProcess.ProcessName.Equals(runAs.Path));
                if (runAs is IRunAsOther)
                {
                    ((IRunAsOther)runAs).Execute(runAsDetails);
                }
                else
                {
                    runAs.Execute();
                }
                while (System.Diagnostics.Process.GetProcesses().FirstOrDefault(newProcess => newProcess.ProcessName.Equals(System.IO.Path.GetFileNameWithoutExtension(runAs.Path)) && !originalProcess.Contains(newProcess)) == null)
                    System.Threading.Thread.Sleep(250);

                System.Threading.Thread.Sleep(1500);
                if (runAs is RegisteredRunAs && Configuration.Instance.MinimizeAfterRun)
                    this.Invoke(new Action(delegate { this.WindowState = FormWindowState.Minimized; }), null);
                this.SetTooltip(string.Empty);
            });

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

            this.toolTip.Text = tooltipText;
            this.Invalidate();
        }

        private void ShowAddApplicationDialog(bool doExecute = true)
        {
            this.OpenFormDialog<DialogForm>(new DialogForm(new Controls.AddApplication()), addApp =>
            {
                if (addApp.DialogResult != System.Windows.Forms.DialogResult.OK)
                {
                    this.SetTooltip();
                    return;
                }

                IRunAs runAs = (addApp.DialogControl as Controls.AddApplication).SelectedApplication;
                IRegisteredRunAs registeredRunAs = runAs as IRegisteredRunAs;
                if (registeredRunAs != null)
                    this.RefreshApplications(this, new EventArgs());

                if (doExecute)
                    this.ExecuteRunAs(runAs, null);

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
        #endregion

        #region Protected Methods & Functions
        protected override void OnClientSizeChanged(EventArgs e)
        {
            if (this.WindowState != this.lastWindowState)
            {
                this.lastWindowState = this.WindowState;
                this.OnWindowStateChanged(this, e);
            }
            base.OnClientSizeChanged(e);
        }

        protected void OnWindowStateChanged(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case FormWindowState.Minimized:
                    if (Configuration.Instance.MinimizeToTray)
                    {
                        this.notifyIcon1.Visible = true;
                        this.ShowInTaskbar = false;
                    }
                    else
                    {
                        this.notifyIcon1.Visible = false;
                        this.ShowInTaskbar = true;
                    }
                    break;
                default:
                    this.notifyIcon1.Visible = false;
                    this.ShowInTaskbar = true;
                    break;
            }
        }
        #endregion

        #region Private Event Handler Methods & Functions
        private void Form1_SelectedItemChanged(object sender, EventArgs e)
        {
            this.tsExecuteRunAs.Enabled = (this.SelectedItem != null);
            this.tsDeleteApplication.Enabled = (this.SelectedItem is IRegisteredRunAs);
            this.tsApplicationOpenFolder.Enabled = (this.SelectedItem is IRegisteredRunAs);
        }

        private void runAsContextMenu_Opening(object sender, CancelEventArgs e)
        {
            this.executeToolStripMenuItem.Enabled = this.SelectedItem != null;
            this.executeAsToolStripMenuItem.Enabled = this.SelectedItem != null && this.SelectedItem is RegisteredRunAs;
            this.removeToolStripMenuItem.Enabled = this.SelectedItem != null && this.SelectedItem is RegisteredRunAs;
            this.openContainingFolderToolStripMenuItem.Enabled = this.removeToolStripMenuItem.Enabled;
        }

        private void viewToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            this.authenticationDetailsToolStripMenuItem.Checked = Configuration.Instance.ViewAuthenticationDetails;
            this.statusbarToolStripMenuItem.Checked = Configuration.Instance.ShowStatusbar;
            this.largeIconsToolStripMenuItem.Checked = (Configuration.Instance.RunAsView == RunAsView.LargeIcon);
            this.mediumIconsToolStripMenuItem.Checked = (Configuration.Instance.RunAsView == RunAsView.MediumIcon);
            this.smallIconsToolStripMenuItem.Checked = (Configuration.Instance.RunAsView == RunAsView.SmallIcon);
            this.tilesToolStripMenuItem.Checked = (Configuration.Instance.RunAsView == RunAsView.Tile);
            this.listToolStripMenuItem.Checked = (Configuration.Instance.RunAsView == RunAsView.List);
            this.detailsToolStripMenuItem.Checked = (Configuration.Instance.RunAsView == RunAsView.Details);
        }
        
        private void runAsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedItem = this.runAsList.SelectedIndices.Count == 0 ? null : (IRunAs) this.runAsList.Items[this.runAsList.SelectedIndices[0]].Tag;
        }
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenFormDialog<AboutBox>(new AboutBox());
        }

        private void AddRunAs(object sender, EventArgs e)
        {
            this.ShowAddApplicationDialog(false);
        }

        private void ExecuteRunAs(object sender, EventArgs e)
        {
            if (sender is ToolStripItem)
                this.SelectedItem = (IRunAs)((ToolStripItem)sender).Tag;

            if (this.SelectedItem == null)
                return;

            this.ExecuteRunAs(this.SelectedItem, Configuration.Instance);
        }

        private void ExecuteRunAsAs(object sender, EventArgs e)
        {
            this.OpenFormDialog<DialogForm>(new DialogForm(new Controls.RunAsUserDetails()), runAsDetails =>
            {
                DialogResult addAppResult = runAsDetails.ShowDialog(this);
                if (addAppResult == System.Windows.Forms.DialogResult.OK)
                {
                    this.ExecuteRunAs(this.SelectedItem, runAsDetails.DialogControl as IRunAsDetails);
                }
            });
        }

        private void OpenContainingFolder(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(System.IO.Path.GetDirectoryName(this.SelectedItem.Path));
        }        

        private void RemoveSelectedApplication(object sender, EventArgs e)
        {
            if (this.SelectedItem is SelectApplicationRunAs
                        || MessageBox.Show(this, string.Format("Are you sure you want to remove the '{0}' application?", this.SelectedItem), "Delete Application", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;

            ((RegisteredRunAs)this.SelectedItem).Delete();
            this.RefreshApplications(sender, e);
        }

        private void RefreshApplications(object sender, EventArgs e)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(a => this.RefreshRunAsApplications());
        }

        private void SetTooltip(object sender, EventArgs e)
        {
            if (sender is Control)
            {
                this.SetTooltip(((Control)sender).AccessibleDescription);
            }
            else if (sender is ToolStripItem)
            {
                this.SetTooltip(((ToolStripItem)sender).AccessibleDescription);
            }
        }

        private void ClearTooltip(object sender, EventArgs e)
        {
            this.SetTooltip();
        }

        private void ShowRunAsForm(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon1.Visible = false;
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.ShowRunAsForm(sender, e);

            this.Close();
        }
        #endregion

        
    }
}
