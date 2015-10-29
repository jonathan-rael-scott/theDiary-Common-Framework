using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Terminal.Animations
{
    public class ConsoleSpiner
            : IConsoleAnimation
    {
        #region Constructors
        public ConsoleSpiner()
            : this(Location.CursorLocation)
        {
        }

        public ConsoleSpiner(int left, int top)
            : this(Location.Create(left, top))
        {
        }

        public ConsoleSpiner(Location location)
            : base()
        {
            this.CurrentStep = 0;
            this.Location = location;
        }
        #endregion

        #region Public Read-Only Properties
        public int CurrentStep { get; private set; }

        public Location Location { get; private set; }
        #endregion

        #region Public Methods & Functions
        public void Step()
        {
            Location cursorLocation = Location.CursorLocation;
            this.CurrentStep++;
            ConsoleApp.SetCursorPosition(this.Location);
            switch (this.CurrentStep % 4)
            {
                case 0: ConsoleApp.Write("/");
                    break;
                case 1: ConsoleApp.Write("-");
                    break;
                case 2: ConsoleApp.Write("\\");
                    break;
                case 3: ConsoleApp.Write("|");
                    break;
            }
            ConsoleApp.SetCursorPosition(cursorLocation);
        }
        #endregion
    }
}
