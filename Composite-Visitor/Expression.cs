namespace CompositeVisitor
{
    public abstract class Expression
    {
        public abstract Double accept(IVisitor v);
    }

    public enum Operator
    {
        PLUS, SUB, MULT, DIV
    }

    public class NumericConstant : Expression
    {
        Double exp;

        public NumericConstant(Double e)
        {
            exp = e;
        }

        public double GetNumber() => exp;

        public override Double accept(IVisitor v)
        {
            return v.visit(this);
        }
    }

    public class BinaryExpression : Expression
    {
        Expression exp1, exp2;
        Operator op;

        public BinaryExpression(Operator o, Expression e1, Expression e2)
        {
            op = o;
            exp1 = e1;
            exp2 = e2;
        }

        public Expression GetLExp() => exp1;
        public Expression GetRExp() => exp2;
        public Operator GetOperator() => op;

        public override Double accept(IVisitor v)
        {
            return v.visit(this);
        }
    }
}