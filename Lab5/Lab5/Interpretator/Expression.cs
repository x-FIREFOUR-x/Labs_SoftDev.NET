﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    interface Expression 
    {
        public Complex Interpret(Context context);
    }
}
