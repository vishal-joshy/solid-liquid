using LexicalAnalyzer;

namespace SExpression
{
    public static class SExpParser
    {
        public static double Evaluate(string expString)
        {
            List<Token> tokenList = new List<Token>();
            tokenList = Lexer.Analyze(expString);

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
                        if (atom.TokenType == TokenType.Double)
                        {
                            evalStack.Push(atom.DoubleValue);
                        }
                        else
                        {
                            result = evalStack.Pop();
                            while (evalStack.Count > 0)
                            {
                                switch (atom.TokenType)
                                {
                                    case TokenType.Plus: result = result + evalStack.Pop(); break;
                                    case TokenType.Mult: result = result * evalStack.Pop(); break;
                                    case TokenType.Minus: result = result - evalStack.Pop(); break;
                                    case TokenType.Div: result = result / evalStack.Pop(); break;
                                    default: throw new Exception("invalid op");
                                }
                            }
                        }
                        atom = atomStack.Pop();
                    }
                    atomStack.Push(new Token(TokenType.Double, result));
                }
            }
            return atomStack.Pop().DoubleValue;
        }
    }
}