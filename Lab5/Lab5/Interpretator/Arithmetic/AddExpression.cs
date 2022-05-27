using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    class AddExpression : Expression
    {
        Expression leftExpression;
        Expression rightExpression;

        public AddExpression(Expression left, Expression right)
        {
            leftExpression = left;
            rightExpression = right;
        }
        public Complex Interpret(Context context)
        {
            return leftExpression.Interpret(context) + rightExpression.Interpret(context); 
        }
    }
}
