using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace theDiary.Tools.Development.HostFileManager
{
    public abstract class ClientActionBase
        : IClientAction
    {
        #region Constructors
        protected ClientActionBase(string actionName)
        {
            if (string.IsNullOrWhiteSpace(actionName))
                throw new ArgumentNullException("actionName");

            this.ActionName = actionName;
        }

        protected ClientActionBase(string actionName, ActionEventHandler executeHandler)
        {
            if (string.IsNullOrWhiteSpace(actionName))
                throw new ArgumentNullException("actionName");

            if (executeHandler == null)
                throw new ArgumentNullException("executeHandler");

            this.ActionName = actionName;
            this.Execute = executeHandler;
        }
        #endregion
        
        public ActionEventHandler Execute { get; private set; }

        public string ActionName { get; private set;
        }

        protected internal dynamic Additional { get; set; }

        protected internal bool HasAdditional

        {
            get
            {
                return this.Additional != null;
            }
        }

        
    }
    
    public abstract class ClientActionGroupBase<T>
        : ClientActionGroupBase, 
        IClientActionGroup<T>
    {
        #region Constructors
        protected ClientActionGroupBase(string actionName)
            : base(actionName)
        {
            this.GroupName = string.Empty;
        }

        protected ClientActionGroupBase(string actionName, ActionEventHandler executeHandler)
            : base(actionName, executeHandler)
        {
            this.GroupName = string.Empty;
        }
        protected ClientActionGroupBase(string groupName, string actionName)
            : base(groupName, actionName)
        {
            this.GroupName = string.IsNullOrWhiteSpace(groupName) ? string.Empty : groupName;
        }
        protected ClientActionGroupBase(string groupName, string actionName, ActionEventHandler executeHandler)
            : base(groupName, actionName, executeHandler)
        {
        }
        #endregion
    }

    public abstract class ClientActionGroupBase
        : ClientActionBase,
        IClientActionGroup
    {
        #region Constructors
        protected ClientActionGroupBase(string actionName)
            : base(actionName)
        {
            this.GroupName = string.Empty;
        }

        protected ClientActionGroupBase(string actionName, ActionEventHandler executeHandler)
            : base(actionName, executeHandler)
        {
            this.GroupName = string.Empty;
        }

        protected ClientActionGroupBase(string groupName, string actionName)
            : base(actionName)
        {
            this.GroupName = string.IsNullOrWhiteSpace(groupName) ? string.Empty : groupName;
        }
        
        protected ClientActionGroupBase(string groupName, string actionName, ActionEventHandler executeHandler)
            : base(actionName, executeHandler)
        {
            this.GroupName = string.IsNullOrWhiteSpace(groupName) ? string.Empty : groupName;
        }
        #endregion

        #region Public Properties
        public string GroupName { get; protected set; }
        #endregion
    }
}
