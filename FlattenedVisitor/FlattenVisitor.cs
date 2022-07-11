namespace FlattenedVisitor
{
    public enum ExprKind { Operator, Value };

    public class Item
    {
        public Operator op;
        public double Value;
        public ExprKind kind;

        public Item()
        {
            op = Operator.Illegal;
        }

        public bool SetValue(double val)
        {
            kind = ExprKind.Value;
            Value = val;
            return true;
        }

        public bool SetOperator(Operator _op)
        {
            kind = ExprKind.Operator;
            op = _op;
            return true;
        }
    }
}