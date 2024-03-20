﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Roan.Tools
{
    public static class Modifiers
    {
        public static int CalculateModifier(int stat)
        {
            switch (stat)
            {
                case < 5:
                    return -1;
                case < 10:
                    return 0;
                case < 15:
                    return 1;
                default:
                    return 2;
            }
        }
    }
}
