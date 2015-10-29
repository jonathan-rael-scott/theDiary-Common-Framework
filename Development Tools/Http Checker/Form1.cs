using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace theDiary.Tools.Development.HttpChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            var post = System.Net.Http.HttpMethod.Post;
            
        }

        private HttpContent CreateContent()
        {
            return new System.Net.Http.StringContent("");
        }
    }
}
