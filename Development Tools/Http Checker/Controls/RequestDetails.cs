using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace theDiary.Tools.Development.HttpChecker.Controls
{
    public partial class RequestDetails : UserControl
    {
        public RequestDetails()
        {
            InitializeComponent();
        }

        private System.Text.RegularExpressions.RegExPattern intFinderPattern = "(\\d+)";

        private void timeOutTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (this.timeOutTrackBar.Value == 0)
            {
                this.timeOut.Text = string.Empty;
            }
            else
            {
                this.timeOut.Text = string.Format("{0} seconds", this.timeOutTrackBar.Value);
            }
        }

        public string DestinationUrl
        {
            get
            {
                return this.destinationUrl.Text;
            }
            set
            {
                this.destinationUrl.Text = value;
            }
        }

        public TimeSpan TimeOut
        {
            get
            {
                int seconds = 0;
                System.Text.RegularExpressions.Match timeOutResult;
                if (this.intFinderPattern.TryMatch(this.timeOut.Text, out timeOutResult)
                    && int.TryParse(timeOutResult.Value, out seconds))
                    return new TimeSpan(0, 0, seconds);
                return new TimeSpan();
            }
            set
            {
                this.timeOutTrackBar.Value = (int) value.TotalSeconds;
            }
        }
    }
}
