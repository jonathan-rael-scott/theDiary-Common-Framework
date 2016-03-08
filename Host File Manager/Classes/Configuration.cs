using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theDiary.Tools.Development.HostFileManager
{
    public sealed class Configuration
        : Singleton<Configuration>, System.ComponentModel.INotifyPropertyChanged

    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public  Configuration()
            : base()
        {
        }


        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public bool MinimizeToTaskbar
        {
            get
            {
                return ConfigurationHelper.ReadConfiguration("MinimizeToTaskbar");
            }
            set
            {
                if (this.MinimizeToTaskbar == value)
                    return;

                ConfigurationHelper.SaveConfiguration("MinimizeToTaskbar", value);
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("MinimizeToTaskbar"));
            }
        }

        public bool AlwaysOnTop
        {
            get
            {
                return ConfigurationHelper.ReadConfiguration("AlwaysOnTop");
            }
            set
            {
                if (this.AlwaysOnTop == value)
                    return;
                ConfigurationHelper.SaveConfiguration("AlwaysOnTop", value);
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("AlwaysOnTop"));
            }
        }

        public bool ShowStatusbar
        {
            get
            {
                return ConfigurationHelper.ReadConfiguration("ShowStatusbar");
            }
            set
            {
                if (this.ShowStatusbar == value)
                    return;
                ConfigurationHelper.SaveConfiguration("ShowStatusbar", value);
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("ShowStatusbar"));
            }
        }

        public ListItemsView CurrentItemsView
        {
            get
            {
                return (ListItemsView)Enum.Parse(typeof(ListItemsView), ConfigurationHelper.ReadStringConfiguration("CurrentItemsView", ListItemsView.MediumIcon.ToString()), true);
            }
            set
            {
                if (this.CurrentItemsView == value)
                    return;
                ConfigurationHelper.SaveConfiguration("CurrentItemsView", value.ToString());
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("CurrentItemsView"));
            }
        }
        public bool ConfirmWhenExiting
        {
            get
            {
                return ConfigurationHelper.ReadConfiguration("ConfirmWhenExiting");
            }
            set
            {
                if (this.ShowStatusbar == value)
                    return;
                ConfigurationHelper.SaveConfiguration("ConfirmWhenExiting", value);
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("ConfirmWhenExiting"));
            }
        }

        public bool AutoSave
        {
            get
            {
                return ConfigurationHelper.ReadConfiguration("AutoSave");
            }
            set
            {
                if (this.ShowStatusbar == value)
                    return;
                ConfigurationHelper.SaveConfiguration("AutoSave", value);
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("AutoSave"));
            }
        }

        public ToolstripView CurrentToolstripView
        {
            get
            {
                return ConfigurationHelper.ReadConfiguration<ToolstripView, byte>("CurrentToolstripView", (byte) (ToolstripView.SmallIcons));
            }
            set
            {
                if (this.CurrentToolstripView == value)
                    return;
                ConfigurationHelper.SaveConfiguration("CurrentToolstripView", value.ToString());
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("CurrentToolstripView"));
            }
        }
    }
}
