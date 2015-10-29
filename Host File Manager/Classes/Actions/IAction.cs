﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theDiary.Tools.Development.HostFileManager
{
    public static class ActionExentions
    {
        public static void ExecuteAction(this IClientAction action, params dynamic[] args)
        {
            action.Execute(action, new ActionEventArgs(action));
        }

        public static void ExecuteAction<TDelegate>(this IClientAction<TDelegate> action, params dynamic[] args)
        {
            (action.Execute as Delegate).DynamicInvoke(args);
        }
    }
    public interface IActionExecutor
    {
        string ActionName { get; }
    }

    public interface IClientAction
        : IActionExecutor
    {
        ActionEventHandler Execute { get; }
    }

    public interface IClientAction<TDelegate>
        : IActionExecutor
    {
        TDelegate Execute { get; }
    }
    public interface IClientActionGroup
        : IClientAction
    {
        string GroupName { get; }
    }

    public interface IClientActionGroup<T>
        : IClientActionGroup
    {
        
    }

    public interface IClientControlAction<TControl>
        where TControl : Component
    {
        void SetControl(TControl control);
    }

    public interface IClientStateAction<T>
        : IClientAction
    {
        T State { get; }

        void SetState(T state);
    }

    public interface IClientControlStateAction
        : IClientAction
    {
        void SetState(object state);
        void SetControl(object control, object state);
    }

    public interface IClientControlStateAction<TState, TControl>
        : IClientControlStateAction, 
        IClientControlAction<TControl>,
        IClientStateAction<TState>
        where TControl : Component
    {
        new void SetControl(TControl control, TState state);
    }
}