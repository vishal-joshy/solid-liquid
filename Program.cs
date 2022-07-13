using FlattenedVisitor;
using System.Reactive;
using System.Reactive.Linq;
using Observer;

public class Program
{
    public static void Main(String[] args)
    {

        RDParser parser = new RDParser("1+2*3+2");
        Expression exp = parser.DoParse();

        // //FlattenedVisitor
        // List<Item> itemList = exp.FlattenExpressionToList();
        // Console.Write(itemList.Evaluate());

        // // Observer
        // List<Item> itemList = exp.FlattenExpressionToList();
        // IObservable<Item> source = itemList.ToObservable();
        // Console.Write(Observ.Eval(source));


    }
}
