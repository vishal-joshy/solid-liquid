using LexicalAnalyzer;

namespace FlattenedVisitor
{
    public class RDParser
    {
        TokenGenerator generator;
        Token CurrentToken = null;

        public RDParser(string expString)
        {
            generator = new TokenGenerator(Lexer.Analyze(expString));
        }

        public Expression DoParse()
        {
            CurrentToken = generator.Yield();
            return Expr();
        }

        public Expression Expr()
        {
            Expression returnValue = Term();
            if (CurrentToken.TokenType == TokenType.Plus || CurrentToken.TokenType == TokenType.Minus)
            {
                Token opToken = CurrentToken;
                CurrentToken = generator.Yield();
                Expression exp = Expr();
                if (opToken.TokenType == TokenType.Plus)
                {
                    return new BinaryExpression(Operator.PLUS, returnValue, exp);
                }
                else
                {
                    return new BinaryExpression(Operator.SUB, returnValue, exp);
                }
            }
            return returnValue;
        }

        public Expression Term()
        {
            Expression returnValue = Factor();
            if (CurrentToken.TokenType == TokenType.Mult || CurrentToken.TokenType == TokenType.Div)
            {
                Token opToken = CurrentToken;
                CurrentToken = generator.Yield();
                Expression exp = Term();
                if (opToken.TokenType == TokenType.Mult)
                {
                    return new BinaryExpression(Operator.MULT, returnValue, exp);
                }
                else
                {
                    return new BinaryExpression(Operator.DIV, returnValue, exp);
                }
            }
            return returnValue;
        }


        public Expression Factor()
        {
            if (CurrentToken.TokenType == TokenType.Double)
            {
                Token t = CurrentToken;
                CurrentToken = generator.Yield();
                return new NumericConstant(t.DoubleValue);
            }
            else
            {
                throw new Exception("Invalid token");
            }
        }
    }
}