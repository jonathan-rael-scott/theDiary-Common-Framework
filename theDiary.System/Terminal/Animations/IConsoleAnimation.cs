using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Terminal.Animations
{
    public interface IConsoleAnimation
    {
        int CurrentStep { get; }

        Location Location { get; }

        void Step();
    }
}
