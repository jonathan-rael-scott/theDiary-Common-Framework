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
    public partial class RequestHeaders : UserControl
    {
        public RequestHeaders()
        {
            InitializeComponent();
        }

        private Dictionary<string, string> headerParameters = new Dictionary<string, string>();

        public IEnumerable<KeyValuePair<string,string>> Parameters
        {
            get
            {
                return this.headerParameters;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void UpdateValue_Click(object sender, EventArgs e)
        {
            this.AddParameter(this.ParameterName.Text, this.ParameterValue.Text);
        }

        public void RemoveParameter(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentOutOfRangeException("name", "The parameter name can not be empty or whitespace.");
 
            if (this.headerParameters.ContainsKey(name))
                this.headerParameters.Remove(name);
        }
        public void AddParameter(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentOutOfRangeException("name", "The parameter name can not be empty or whitespace.");

            if (string.IsNullOrEmpty(value))
                throw new ArgumentOutOfRangeException("value", "The parameter value can not be empty.");

            if (this.headerParameters.ContainsKey(name))
            {
                this.headerParameters[name] = value;
            }
            else
            {
                this.headerParameters.Add(name, value);
            }
        }

        private void RemoveValue_Click(object sender, EventArgs e)
        {
            this.RemoveParameter(this.ParameterName.Text);
        }
    }
}
