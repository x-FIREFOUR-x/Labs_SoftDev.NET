using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    class TerminalExpression : Expression
    {
        string name;

        public TerminalExpression(string name)
        {
            this.name = name;
        }
        public Complex Interpret(Context context)
        {
            return context.GetVariable(name);
        }
    }
}
