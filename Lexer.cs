namespace LexicalAnalyzer
{
    public enum TokenType
    {
        Plus,
        Minus,
        Mult,
        Div,
        Double,
        NULL,
        OPAREN,
        CPAREN
    }

    public class Token
    {
        public TokenType TokenType;
        public double DoubleValue;

        public Token(TokenType tok, double value)
        {
            TokenType = tok;
            DoubleValue = value;
        }

        public Token(TokenType tok)
        {
            TokenType = tok;
        }
    }

    public class Lexer
    {
        public static List<Token> Analyze(string data)
        {
            List<Token> Tokens = new List<Token>();
            for (int i = 0; i < data.Length; i++)
            {
                switch (data[i])
                {
                    case ' ': break;
                    case '+': Tokens.Add(new Token(TokenType.Plus)); break;
                    case '-': Tokens.Add(new Token(TokenType.Minus)); break;
                    case '*': Tokens.Add(new Token(TokenType.Mult)); break;
                    case '/': Tokens.Add(new Token(TokenType.Div)); break;
                    case '(':Tokens.Add(new Token(TokenType.OPAREN));break;
                    case ')':Tokens.Add(new Token(TokenType.CPAREN));break;
                    default:
                        if (isNumber(data[i]))
                        {
                            string tempNumber = "" + data[i];
                            i++;
                            while (i < data.Length && isNumber(data[i]))
                            {
                                tempNumber = tempNumber + data[i];
                                i++;
                            }
                            i--;
                            Tokens.Add(new Token(TokenType.Double, Convert.ToDouble(tempNumber)));
                            break;
                        }
                        throw new Exception("Invalid token");
                }
            }
            return Tokens;
        }

        public static bool isNumber(char inp)
        {
            if (int.TryParse(inp.ToString(), out int n))
            {
                return true;
            }
            return false;
        }
    }
}