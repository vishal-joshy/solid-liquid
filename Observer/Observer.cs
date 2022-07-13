using FlattenedVisitor;

namespace Observer
{
  public class Observ{
    public static double Eval(IObservable<Item> source){
        Stack<double> EvalStack = new Stack<double>();
        IDisposable subscription = source.Subscribe(x => {
            if (x.kind == ExprKind.Value)
                {
                    EvalStack.Push(x.Value);
                }
                else
                {
                    switch(x.op){
                        case Operator.PLUS: EvalStack.Push(EvalStack.Pop() + EvalStack.Pop());break;
                        case Operator.SUB: EvalStack.Push(EvalStack.Pop() - EvalStack.Pop());break;
                        case Operator.MULT: EvalStack.Push(EvalStack.Pop() * EvalStack.Pop());break;
                        case Operator.DIV: EvalStack.Push(EvalStack.Pop() / EvalStack.Pop());break;
                    }
                }
        });
        return EvalStack.Pop();
    }
  }
}