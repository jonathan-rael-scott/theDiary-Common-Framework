using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace theDiary.Tools.Development.HostFileManager
{
    public interface IEventAction
         : IEventAction<Control>
    {

    }

    public interface IEventAction<T>
        : IActionExecutor
    {
        void AttachAction(T target);
    }

    public class ViewAction
        : IEventAction<ListView>
    {
        public ViewAction(string actionName, string eventName, EventHandler execute)
            : base()
        {
            this.ActionName = actionName;
            this.EventName = eventName;
            this.Execute = execute;
        }

        public string ActionName { get; private set; }

        public string EventName { get; private set; }

        public EventHandler Execute { get; private set; }

        private IEnumerable<ParameterExpression> GenerateArgsExpressions(MethodInfo method)
        {
            foreach (var i in method.GetParameters())
                yield return Expression.Parameter(i.ParameterType, i.Name);
        }

        public void AttachAction(ListView target)
        {
            EventInfo @event = typeof(ListView).GetEvent(this.EventName);
            @event.AddEventHandler(target, (Delegate)this.Execute);
        }
    }
}
