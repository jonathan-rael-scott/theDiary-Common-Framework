using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theDiary.Tools.Development.HostFileManager
{
    public sealed class ActionContainer
        : IList<IActionExecutor>
    {
        #region Constructors
        public ActionContainer()
        {
            this.actions = new Dictionary<string, IActionExecutor>();
            this.actionProcessors = new Dictionary<Type, Delegate>();
        }
        #endregion

        #region Private Declarations
        private Dictionary<string, IActionExecutor> actions;
        private Dictionary<Type, Delegate> actionProcessors;
        #endregion

        #region Public Properties
        public int Count
        {
            get
            {
                return this.actions.Count;
            }
        }

        IActionExecutor IList<IActionExecutor>.this[int index]
        {
            get
            {
                int curIndex = 0;
                foreach (var val in this.actions.Keys)
                {
                    if (curIndex < index)
                    {
                        curIndex++;
                    }
                    else
                    {
                        return this.actions[val];
                    }
                }
                return null;
            }
            set
            {
                int curIndex = 0;
                foreach (var val in this.actions.Keys)
                {
                    if (curIndex < index)
                    {
                        curIndex++;
                    }
                    else
                    {
                        this.actions[val] = value;
                    }
                }
            }
        }

        public IActionExecutor this[string actionName]
        {
            get
            {
                return this.actions[actionName];
            }
        }
        #endregion
        public void Add(IActionExecutor item)
        {
            this.actions.Add(this.GetActionName(item.GetType(), item.ActionName), item);
        }

        public T Add<T>(T action)
            where T : IActionExecutor
        {
            if (action == null)
                throw new ArgumentNullException("action");

            this.actions.Add(this.GetActionName(typeof(T), action.ActionName), action);
            return action;
        }

        public T Add<T>(string actionName, ActionEventHandler executeHandler)
            where T : IActionExecutor
        {
            if (string.IsNullOrWhiteSpace(actionName))
                throw new ArgumentNullException("actionName");

            if (executeHandler == null)
                throw new ArgumentNullException("executeHandler");

            T action = (T)System.Activator.CreateInstance(typeof(T), new object[] { actionName, executeHandler });
            this.actions.Add(this.GetActionName(typeof(T), actionName), action);

            return action;
        }

        
        
        public void Clear()
        {
            this.actions.Clear();
        }

        public bool Contains(IActionExecutor item)
        {
            return this.actions.ContainsKey(item.ActionName);
        }

        void ICollection<IActionExecutor>.CopyTo(IActionExecutor[] array, int arrayIndex)
        {

        }

        public int IndexOf(IActionExecutor action)
        {
            int index = 0;
            foreach (var val in this.actions.Keys)
            {
                if (val.Equals(action.ActionName))
                    return index;
                index++;
            }
            return -1;
        }

        bool ICollection<IActionExecutor>.IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool Remove(IActionExecutor item)
        {
            return this.actions.Remove(item.ActionName);
        }

        public IEnumerator<IActionExecutor> GetEnumerator()
        {
            return this.actions.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.actions.Values.GetEnumerator();
        }

        void IList<IActionExecutor>.Insert(int index, IActionExecutor item)
        {
        }

        void IList<IActionExecutor>.RemoveAt(int index)
        {
        }

        public IEnumerable<T> Select<T>()
            where T : IActionExecutor
        {
            return this.actions.Values.Where(action => action is T).Cast<T>();
        }

        public void Process<T>(Action<T> processDelegate)
            where T : IActionExecutor
        {
            foreach (T action in this.Select<T>())
                processDelegate(action);
        }

        public void RegisterProcessor<T>(Action<T> processDelegate)
            where T : IActionExecutor
        {
            if (!this.actionProcessors.ContainsKey(typeof(T)))
                this.actionProcessors.Add(typeof(T), processDelegate);
        }
        
        public void RegisterProcessor<T>(Delegate processDelegate)
            where T : IActionExecutor
        {
            if (!this.actionProcessors.ContainsKey(typeof(T)))
                this.actionProcessors.Add(typeof(T), processDelegate);
        }

        public void RegisterProcessor<T, TGroupBy>(Delegate processDelegate, Func<string, TGroupBy> groupByDelegate)
            where T : IClientActionGroup
        {
            if (!this.actionProcessors.ContainsKey(typeof(IClientActionGroup<T>)))
                this.actionProcessors.Add(typeof(IClientActionGroup<T>), groupByDelegate);

            if (!this.actionProcessors.ContainsKey(typeof(T)))
                this.actionProcessors.Add(typeof(T), processDelegate);
        }
        public void Process<T, TGroupBy>()
                where T : IClientActionGroup
        {
            this.Process<T, TGroupBy>(null);
        }
        public void Process<T, TGroupBy>(object[] args, params object[] groupByArgs)
            where T : IClientActionGroup
        {
            IEnumerable<string> groups = this.Select<IClientActionGroup>().OrderBy(groupBy => groupBy.GroupName).Select(groupBy => groupBy.GroupName).Distinct();
            foreach (string groupIdentifier in groups)
            {
                object groupByValue = this.actionProcessors[typeof(IClientActionGroup<T>)].DynamicInvoke(this.CreateDelegateArgs(groupByArgs, groupIdentifier));
                IEnumerable<T> groupActions = this.Select<T>().Where(action=>action.GroupName.Equals(groupIdentifier));
                foreach (T action in groupActions)
                    this.actionProcessors[typeof(T)].DynamicInvoke(this.CreateDelegateArgs(args, action, groupByValue));
            }
        }

        public void Process<T>(params object[] args)
            where T : IActionExecutor
        {
            if (!this.actionProcessors.ContainsKey(typeof(T)))
                throw new InvalidOperationException("No action processor found.");
            foreach (T action in this.Select<T>())
                this.actionProcessors[typeof(T)].DynamicInvoke(this.CreateDelegateArgs(args, action));
        }

        public void Process<T>(Action<T, object[]> processDelegate, params object[] args)
            where T : IActionExecutor
        {
            this.RegisterProcessor<T>(processDelegate);
            this.Process<T>(args);
        }

        private string GetActionName(Type type, string actionName)
        {
            return string.Format("{0}_{1}", type.Name, actionName);
        }

        private object[] CreateDelegateArgs(object[] secondaryArgs, params object[] primaryArgs)
        {
            List<object> returnValue = new List<object>();
            if (primaryArgs != null)
                returnValue.AddRange(primaryArgs.Where(arg=>arg != null));
            if (secondaryArgs != null)
                returnValue.AddRange(secondaryArgs);

            return returnValue.ToArray();
        }
    }
}
