using LexicalAnalyzer;

namespace SExpr
{
    public class SExpression
    {
        List<Token> tokenList = new List<Token>();

        public SExpression(string expString)
        {
            this.tokenList = Lexer.Analyze(expString);
        }

        public double Evaluate()
        {
            Stack<Token> atomStack = new Stack<Token>();
            Stack<double> evalStack = new Stack<double>();

            foreach (Token tok in tokenList)
            {
                if (tok.TokenType != TokenType.CPAREN)
                {
                    atomStack.Push(tok);
                }
                else
                {
                    Token atom = atomStack.Pop();
                    double result = 0;
                    while (atom.TokenType != TokenType.OPAREN)
                    {
                        if (atom.TokenType == TokenType.Double) //populate eval stack with operands
                        {
                            evalStack.Push(atom.DoubleValue);
                        }
                        else
                        {
                            result = operateOnStack(atom.TokenType, evalStack);
                        }
                        atom = atomStack.Pop();
                    }
                    atomStack.Push(new Token(TokenType.Double, result));
                }
            }
            return atomStack.Pop().DoubleValue;
        }

        private double operateOnStack(TokenType op, Stack<double> evalStack)
        {
            double result = 0;
            if (evalStack.Count == 1) //Only one operand unary op
            {
                result = evalStack.Pop();
                if (op == TokenType.Minus)
                {
                    result = -result;
                }
            }
            if (evalStack.Count > 1) // more than 1 operand binary op on eval stack
            {
                result = evalStack.Pop();
                while (evalStack.Count > 0)
                {
                    switch (op)
                    {
                        case TokenType.Plus: result = result + evalStack.Pop(); break;
                        case TokenType.Mult: result = result * evalStack.Pop(); break;
                        case TokenType.Minus: result = result - evalStack.Pop(); break;
                        case TokenType.Div: result = result / evalStack.Pop(); break;
                        default: throw new Exception("invalid op");
                    }
                }
            }
            return result;
        }
    }
}