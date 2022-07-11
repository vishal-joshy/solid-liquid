namespace FlattenedVisitor
{
    public interface IVisitor
    {
        public double visit(NumericConstant nConst);
        public double visit(BinaryExpression bExp);
    }

    public class FlattenVisitor : IVisitor
    {
        List<Item> list = null;

        public FlattenVisitor()
        {
            list = new List<Item>();
        }

        public List<Item> FlattenedExpression() => list;

        public Item MakeList(double number)
        {
            Item result = new Item();
            result.SetValue(number);
            return result;
        }

        public Item MakeList(Operator op)
        {
            Item result = new Item();
            result.SetOperator(op);
            return result;
        }

        public double visit(NumericConstant num)
        {
            list.Add(MakeList(num.GetNumber()));
            return 0;
        }

        public double visit(BinaryExpression bExp)
        {
            bExp.GetLExp().accept(this);
            bExp.GetRExp().accept(this);
            list.Add(MakeList(bExp.GetOperator()));
            return Double.NaN;
        }
    }
}