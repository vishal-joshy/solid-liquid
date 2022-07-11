namespace FlattenedVisitor
{
    // Add Method to Expression and List<Item>
    // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods

    public static class Extensions
    {
        public static List<Item> FlattenExpressionToList(this Expression exp)
        {
            FlattenVisitor fv = new FlattenVisitor();
            exp.accept(fv);
            return fv.FlattenedExpression();
        }

        public static double Evaluate(this List<Item> list)
        {
            Stack<double> EvalStack = new Stack<double>();

            foreach (Item i in list)
            {
                if (i.kind == ExprKind.Value)
                {
                    EvalStack.Push(i.Value);
                }
                else
                {
                    switch(i.op){
                        case Operator.PLUS: EvalStack.Push(EvalStack.Pop() + EvalStack.Pop());break;
                        case Operator.SUB: EvalStack.Push(EvalStack.Pop() - EvalStack.Pop());break;
                        case Operator.MULT: EvalStack.Push(EvalStack.Pop() * EvalStack.Pop());break;
                        case Operator.DIV: EvalStack.Push(EvalStack.Pop() / EvalStack.Pop());break;
                    }
                }
            }
            return EvalStack.Pop();
        }
    }
}