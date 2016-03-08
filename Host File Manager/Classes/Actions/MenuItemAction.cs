using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace theDiary.Tools.Development.HostFileManager
{
    public class MenuItemAction
        : ClientActionBase, IClientControlAction<System.Windows.Forms.ToolStripMenuItem>
    {
        public MenuItemAction(string actionName, ActionEventHandler executeHandler, dynamic additional = null)
            : this(null, actionName, null, executeHandler)
        {
            this.Text = actionName;
            this.Additional = additional;
        }

        public MenuItemAction(string parentPath, string actionName, ActionEventHandler executeHandler, dynamic additional = null)
            : this(parentPath, actionName, null, executeHandler)
        {
            this.Text = actionName;
            this.ParentPath = parentPath;
            this.Additional = additional;
        }

        public MenuItemAction(string parentPath, string actionName, string text, ActionEventHandler executeHandler, dynamic additional = null)
            : base(actionName, executeHandler)
        {
            this.ParentPath = parentPath ?? string.Empty;
            this.Text = text ?? actionName;
            this.Additional = additional;
        }
        
        public string Text { get; private set; }

        public string ParentPath { get; private set; }

        
        private System.Windows.Forms.ToolStripMenuItem GetParent(System.Windows.Forms.ToolStripMenuItem container, IEnumerable<string> parents)
        {
            System.Windows.Forms.ToolStripMenuItem returnValue = null;
            string parentName = parents.FirstOrDefault();
            if (parentName == null)
                return returnValue;

            foreach (System.Windows.Forms.ToolStripItem item in container.DropDownItems)
            {
                System.Windows.Forms.ToolStripMenuItem menuItem = item as System.Windows.Forms.ToolStripMenuItem;
                if (menuItem == null
                    || !menuItem.Text.Replace("&", string.Empty).Equals(parentName.Replace("\\", string.Empty).Replace("&", string.Empty), StringComparison.OrdinalIgnoreCase))
                    continue;

                returnValue = this.GetParent(menuItem, parents.Skip(1));
                if (returnValue != null)
                {
                    if (returnValue.OwnerItem == null)
                        container.DropDownItems.Add(returnValue);

                    return returnValue;
                }
            }
            if (returnValue == null)
                returnValue = new System.Windows.Forms.ToolStripMenuItem(parentName);

            return returnValue;
        }
        public System.Windows.Forms.ToolStripMenuItem GetParent(System.Windows.Forms.MenuStrip container)
        {
            System.Windows.Forms.ToolStripMenuItem returnValue = null;
            string[] parents;
            if (string.IsNullOrWhiteSpace(this.ParentPath)
                || ((parents = this.ParentPath.Split('\\')).Count() == 0))
                return returnValue;

            string parentName = parents.FirstOrDefault();
            foreach (System.Windows.Forms.ToolStripItem item in container.Items)
            {
                System.Windows.Forms.ToolStripMenuItem menuItem = item as System.Windows.Forms.ToolStripMenuItem;
                if (menuItem == null
                    || !menuItem.Text.Replace("&", string.Empty).Equals(parentName.Replace("\\", string.Empty).Replace("&", string.Empty), StringComparison.OrdinalIgnoreCase))
                    continue;

                if (parents.Count() == 1)
                {
                    returnValue = menuItem;
                    break;
                }
                else
                {
                    returnValue = this.GetParent(menuItem, parents.Skip(1));
                    if (returnValue != null)
                    {
                        if (returnValue.OwnerItem == null)
                            container.Items.Add(returnValue);

                        break;
                    }
                }
            }
            return returnValue;
        }

        public void SetControl(System.Windows.Forms.ToolStripMenuItem control)
        {
            control.Text = this.Text;
            control.Click += (s, e) => this.Execute(s, new ActionEventArgs(this));

            this.SetFromAdditional(control);
        }
    }
}
