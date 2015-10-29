using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iterative.Tools.RunAs
{
    public sealed class Configuration
        : System.ComponentModel.INotifyPropertyChanged, IRunAsDetails
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

        public bool AllowCustomApplicationRunAs
        {
            get
            {
                return ConfigurationHelper.ReadConfiguration("AllowCustomApplicationRunAs");
            }
            set
            {
                if (this.AllowCustomApplicationRunAs == value)
                    return;

                ConfigurationHelper.SaveConfiguration("AllowCustomApplicationRunAs", value);
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("AllowCustomApplicationRunAs"));
            }
        }

        public string DomainName
        {
            get
            {
                return ConfigurationHelper.ReadStringConfiguration("DomainName");
            }
            set
            {
                if (this.DomainName == value)
                    return;

                ConfigurationHelper.SaveConfiguration("DomainName", value);
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("DomainName"));
            }
        }

        public string UserName
        {
            get
            {
                return ConfigurationHelper.ReadStringConfiguration("UserName");
            }
            set
            {
                if (this.UserName == value)
                    return;

                ConfigurationHelper.SaveConfiguration("UserName", value);
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("UserName"));
            }
        }

        public string Password
        {
            get
            {
                return ConfigurationHelper.ReadStringConfiguration("Password");
            }
            set
            {
                if (this.Password == value)
                    return;

                ConfigurationHelper.SaveConfiguration("Password", value);
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Password"));
            }
        }

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

        public bool ViewAuthenticationDetails
        {
            get
            {
                return ConfigurationHelper.ReadConfiguration("ViewAuthenticationDetails");
            }
            set
            {
                if (this.ViewAuthenticationDetails == value)
                    return;
                ConfigurationHelper.SaveConfiguration("ViewAuthenticationDetails", value);
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("ViewAuthenticationDetails"));
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

        public RunAsView RunAsView
        {
            get
            {
                return (RunAsView)Enum.Parse(typeof(RunAsView), ConfigurationHelper.ReadStringConfiguration("RunAsView", RunAsView.MediumIcon.ToString()), true);
            }
            set
            {
                if (this.RunAsView == value)
                    return;
                ConfigurationHelper.SaveConfiguration("RunAsView", value.ToString());
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("RunAsView"));
            }
        }

        string IRunAsDetails.UserName
        {
            get
            {
                return this.UserName;
            }
        }

        string IRunAsDetails.Password
        {
            get
            {
                return this.Password;
            }
        }

        string IRunAsDetails.DomainName
        {
            get
            {
                return this.DomainName;
            }
        }
    }
}
