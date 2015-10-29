using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theDiary.Tools.Development.HttpChecker.Controls
{
    public class RequestGroupTreeNode
        : System.Windows.Forms.TreeNode, 
        IRequestGroup
    {
        public RequestGroupTreeNode()
            : base()
        {
        }

        public RequestGroupTreeNode(IRequestGroup requestGroup)
            : base(requestGroup.ItemName)
        {
            requestGroup.CopyInterface<IRequestGroup, RequestGroupTreeNode>(this);
        }

        private IRequestGroup requestGroup;
        
        IEnumerable<IRequestItem> IRequestGroup.Children
        {
            get
            {
                return base.Nodes.Cast<IRequestItem>();
            }
        }

        IRequestItem IRequestItem.Parent
        {
            get
            {
                return base.Parent as IRequestItem;
            }
            set
            {
            }
        }

        string IRequestItem.ItemName
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }
    }
}
