﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theDiary.Tools.Development.HostFileManager
{
    [Flags]
    public enum ToolstripView
        : byte
    {
        TextOnly = 0,

        Text = 1,

        SmallIcons = 2,

        MediumIcons = 4,

        LargeIcons = 8,
    }
}
