public abstract class Expression
{
    public abstract Double Evaluate();
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

    public override Double Evaluate()
    {
        return exp;
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

    public override Double Evaluate()
    {
        Double lEval = exp1.Evaluate();
        Double rEval = exp2.Evaluate();
        switch (op)
        {
            case Operator.PLUS: return lEval + rEval;
            case Operator.SUB: return lEval - rEval;
            case Operator.MULT: return lEval * rEval;
            case Operator.DIV: return lEval / rEval;
            default: throw new Exception("Invalid binary expression");
        }
    }
}