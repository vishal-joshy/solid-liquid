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
        Expression returnValue = Factor();
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