namespace CompositeVisitor
{
    public interface IVisitor
    {
        public double visit(NumericConstant nConst);
        public double visit(BinaryExpression bExp);
    }

    public class StackEvaluator : IVisitor
    {
        private Stack<Double> evalStack = new Stack<double>();

        public StackEvaluator()
        {
            evalStack.Clear();
        }

        public double visit(NumericConstant nConst)
        {
            evalStack.Push(nConst.GetNumber());
            return 0;
        }
        public double visit(BinaryExpression bExp)
        {
            bExp.GetLExp().accept(this);
            bExp.GetRExp().accept(this);

            switch (bExp.GetOperator())
            {
                case Operator.PLUS: evalStack.Push(evalStack.Pop() + evalStack.Pop()); break;
                case Operator.SUB: evalStack.Push(evalStack.Pop() - evalStack.Pop()); break;
                case Operator.MULT: evalStack.Push(evalStack.Pop() * evalStack.Pop()); break;
                case Operator.DIV: evalStack.Push(evalStack.Pop() / evalStack.Pop()); break;
            }
            return double.NaN;
        }
    }

    public class TreeEvaluator : IVisitor
    {
        public double visit(NumericConstant num)
        {
            return num.GetNumber();
        }
        public double visit(BinaryExpression bExp)
        {
            double lEval = bExp.GetLExp().accept(this);
            double rEval = bExp.GetRExp().accept(this);

            switch (bExp.GetOperator())
            {
                case Operator.PLUS: return lEval + rEval;
                case Operator.SUB: return lEval - rEval;
                case Operator.MULT: return lEval * rEval;
                case Operator.DIV: return lEval / rEval;
                default : return Double.NaN;
            }
        }
    }

}