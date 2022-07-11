using LexicalAnalyzer;

public class TokenGenerator
{
    private List<Token> tokens;
    private int index = 0;

    public TokenGenerator(List<Token> tokList)
    {
        tokens = tokList;
    }

    public Token Yield()
    {
        if (HasMore())
        {
            Token result = tokens[index];
            index = index + 1;
            return result;
        }
        else
        {
            return new Token(TokenType.NULL);
        }
    }
    private bool HasMore()
    {
        return index < tokens.Count;
    }
}