using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theDiary.Tools.Development.HostFileManager
{
    public sealed class Configuration
        : Singleton<Configuration>, System.ComponentModel.INotifyPropertyChanged

    {
        private Configuration()
            : base()
        {
        }

        private static readonly Configuration configuration = new Configuration();

        internal static Configuration Instance
        {
            get
            {
                return configuration;
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public bool MinimizeAfterRun
        {
            get
            {
                return ConfigurationHelper.ReadConfiguration("MinimizeAfterRun");
            }
            set
            {
                if (this.MinimizeAfterRun == value)
                    return;

                ConfigurationHelper.SaveConfiguration("MinimizeAfterRun", value);
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("MinimizeAfterRun"));
            }
        }

        public bool MinimizeToTray
        {
            get
            {
                return ConfigurationHelper.ReadConfiguration("MinimizeToTray");
            }
            set
            {
                if (this.MinimizeToTray == value)
                    return;

                ConfigurationHelper.SaveConfiguration("MinimizeToTray", value);
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("MinimizeToTray"));
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
