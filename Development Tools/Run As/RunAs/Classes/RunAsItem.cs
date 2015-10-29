using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Iterative.Tools.RunAs
{
    internal sealed class RunAsItem
    {
        internal RunAsItem(IRunAs application, int imageIndex, EventHandler handler)
            : base()
        {
            this.Application = application;
            this.ImageIndex = imageIndex;
            this.Handler = handler;
        }

        public EventHandler Handler { get; private set; }
        public string DisplayName
        {
            get
            {
                return this.Application.DisplayName;
            }
        }

        public string Path
        {
            get
            {
                return this.Application.Path;
            }
        }
        public int ImageIndex { get; private set; }

        public IRunAs Application { get; private set; }

        public static implicit operator ListViewItem(RunAsItem application)
        {
            ListViewItem item = new ListViewItem()
            {
                Text = application.DisplayName,
                ImageIndex = application.ImageIndex,
                Tag = application.Application,
            };

            item.SubItems.Add(application.Path);

            return item;
        }

        public static implicit operator ToolStripItem(RunAsItem application)
        {
            ToolStripLabel runAsLabel = new ToolStripLabel()
            {
                Text = application.DisplayName,
                Tag = application.Application,
            };

            runAsLabel.Click += application.Handler;
            return runAsLabel;
        }
    }
}
