using System.Collections.Generic;

namespace LeshchyshynBohdan.MPZ.lab1.Core.Lexical
{
    static class TokenHelper
    {
        public static int GetIndexPairParanthesis(List<Token> tokens, int index)
        {
            int i = 0;

            foreach (var token in tokens)
            {
                if (tokens.IndexOf(token) >= index)
                {
                    if (token.TokenType == TokenType.OpenParenthesis) i++;
                    else if (token.TokenType == TokenType.CloseParenthesis) i--;

                    if (i == 0) return tokens.IndexOf(token);
                }
            }
            return tokens.FindIndex(a => a.TokenType == TokenType.CloseParenthesis);
        }
        public static int GetIndexPairBracket(List<Token> tokens, int index)
        {
            int i = 0;

            foreach (var token in tokens)
            {
                if (tokens.IndexOf(token) >= index)
                {
                    if (token.TokenType == TokenType.OpenBracket) i++;
                    else if (token.TokenType == TokenType.CloseBracket) i--;

                    if (i == 0) return tokens.IndexOf(token);
                }
            }
            return tokens.FindIndex(a => a.TokenType == TokenType.CloseBracket);
        }
    }
}
