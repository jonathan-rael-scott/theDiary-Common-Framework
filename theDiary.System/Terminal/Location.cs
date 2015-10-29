using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public struct Location
    {
        #region Constructors
        private Location(int left, int top)
        {
            if (left < 0)
                throw new ArgumentOutOfRangeException("left");

            if (top < 0)
                throw new ArgumentOutOfRangeException("top");

            this.left = left;
            this.top = top;
        }
        #endregion

        #region Private Declarations
        private int left;
        private int top;
        #endregion

        #region Public Properties
        public int Left
        {
            get
            {
                return this.left;
            }
            set
            {
                if (value >= 0 && value <= Console.WindowWidth)
                    this.left = value;
            }
        }

        public int Top
        {
            get
            {
                return this.top;
            }
            set
            {
                if (value >= 0 && value <= Console.WindowHeight)
                    this.top = value;
            }
        }
        #endregion

        #region Public Methods & Fuunctions
        public override string ToString()
        {
            return string.Format("Left={0}, Top={1}", this.Left, this.Top);
        }
        #endregion

        #region Public Static Properties
        public static Location CursorLocation
        {
            get
            {
                return System.Terminal.ConsoleApp.CursorLocation;
            }
        }

        public static Location WindowLocation
        {
            get
            {
                return System.Terminal.ConsoleApp.WindowLocation;
            }
        }
        #endregion

        #region Public Static Methods & Functions
        public static Location Create(int left, int top)
        {
            return new Location(left, top);
        }
        #endregion
    }
}
