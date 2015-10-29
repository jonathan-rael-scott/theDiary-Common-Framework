using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace theDiary.Tools.Development.HostFileManager.Controls
{
    public partial class IPAddressControl 
        : UserControl
    {
        public IPAddressControl()
        {
            InitializeComponent();
            EventHandler textChangedHandler = (s,e)=>{
                if (this.IPAddressChanged != null)
                    this.IPAddressChanged(this, e);
            };
            this.part1.TextChanged += textChangedHandler;
            this.part2.TextChanged += textChangedHandler;
            this.part3.TextChanged += textChangedHandler;
            this.part4.TextChanged += textChangedHandler;
        }

        public bool IsEmpty
        {
            get
            {
                return this.Value == IPAddress.None;
            }
        }

        public IPAddress Value
        {
            get
            {
                return new IPAddress(this.Parts);
            }
            set
            {
                byte[] values =value.GetAddressBytes();
                this.Part1 = values[0];
                this.Part2 = values[1];
                this.Part3 = values[2];
                this.Part4 = values[3];
            }
        }

        public byte[] Parts
        {
            get
            {
                return new byte[] { this.Part1, this.Part2, this.Part3, this.Part4 };
            }
        }

        public byte Part1
        {
            get
            {
                byte value = 0;
                byte.TryParse(this.part1.Text, out value);
                return value;
            }
            set
            {
                this.part1.Text = value.ToString();
            }
        }

        public byte Part2
        {
            get
            {
                byte value = 0;
                byte.TryParse(this.part2.Text, out value);
                return value;
            }
            set
            {
                this.part2.Text = value.ToString();
            }
        }

        public byte Part3
        {
            get
            {
                byte value = 0;
                byte.TryParse(this.part3.Text, out value);
                return value;
            }
            set
            {
                this.part3.Text = value.ToString();
            }
        }

        public byte Part4
        {
            get
            {
                byte value = 0;
                byte.TryParse(this.part4.Text, out value);
                return value;
            }
            set
            {
                this.part4.Text = value.ToString();
            }
        }

        private void ValidateValue(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) &&
                        !char.IsControl(e.KeyChar);
        }

        public event EventHandler IPAddressChanged;
    }
}
