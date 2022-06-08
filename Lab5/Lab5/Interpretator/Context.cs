using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    class Context
    {
        private Dictionary<string, Complex> variables;

        public Context()
        {
            variables = new Dictionary<string, Complex>();
        }

        public Complex GetVariable(string name)
        {
            return variables[name];
        }

        public void SetVariable(string name, Complex value)
        {
            if (variables.ContainsKey(name))
                variables[name] = value;
            else
                variables.Add(name, value);
        }
    }
}
