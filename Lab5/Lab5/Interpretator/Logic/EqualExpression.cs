using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    class EqualExpression : Expression
    {
        Expression leftExpression;
        Expression rightExpression;

        public EqualExpression(Expression left, Expression right)
        {
            leftExpression = left;
            rightExpression = right;
        }
        public Complex Interpret(Context context)
        {
            if (leftExpression.Interpret(context) == rightExpression.Interpret(context))
                return new Complex(1, 1);
            else
                return new Complex(-1, -1);
        }
    }
}
