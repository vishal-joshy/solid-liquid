using LexicalAnalyzer;

namespace Stack
{
    public class RDParser
    {
        TokenGenerator generator;
        Token CurrentToken = null;
        Stack stack;

        public RDParser(string expString)
        {
            generator = new TokenGenerator(Lexer.Analyze(expString));
            stack = new Stack();
        }

        public double DoParse()
        {
            CurrentToken = generator.Yield();
            Expr();
            return stack.Pop();
        }

        public void Expr()
        {
            Term();
            if (CurrentToken.TokenType == TokenType.Plus || CurrentToken.TokenType == TokenType.Minus)
            {
                Token opToken = CurrentToken;
                CurrentToken = generator.Yield();
                Expr();
                double y = stack.Pop();
                double x = stack.Pop();
                if (opToken.TokenType == TokenType.Plus)
                {
                    stack.Push(x + y);
                }
                else
                {
                    stack.Push(x - y);
                }
            }
        }

        public void Term()
        {
            Factor();
            if (CurrentToken.TokenType == TokenType.Mult || CurrentToken.TokenType == TokenType.Div)
            {
                Token opToken = CurrentToken;
                CurrentToken = generator.Yield();
                Term();
                double y = stack.Pop();
                double x = stack.Pop();
                if (opToken.TokenType == TokenType.Mult)
                {
                    stack.Push(x * y);
                }
                else
                {
                    stack.Push(x / y);
                }
            }
        }

        public void Factor()
        {
            if (CurrentToken.TokenType == TokenType.Double)
            {
                Token t = CurrentToken;
                CurrentToken = generator.Yield();
                stack.Push(t.DoubleValue);
            }
            else
            {
                throw new Exception("Invalid token");
            }
        }
    }
}