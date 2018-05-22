using System;
using System.Collections.Generic;
using LeshchyshynBohdan.MPZ.lab1.Core.Lexical;

namespace LeshchyshynBohdan.MPZ.lab1.Core.Syntax.Terminal
{
    public interface ITerminalExpPattern
    {
        bool Match(List<Token> tokens);
        TerminalExp CreateExpression(List<Token> tokens);
    }
    public class StringConstExpressionPattern : ITerminalExpPattern
    {
        public bool Match(List<Token> tokens){return tokens[0].TokenType == TokenType.StringConst;}
        public TerminalExp CreateExpression(List<Token> tokens){return new StringConstExp(tokens[0].Value);}
    }
    public class NumericConstExpressionPattern : ITerminalExpPattern
    {
        public bool Match(List<Token> tokens) { return tokens[0].TokenType == TokenType.NumericConst; }
        public TerminalExp CreateExpression(List<Token> tokens)
        {
            return new NumericConstExp(Convert.ToInt32(tokens[0].Value));
        }
    }
    public class СomparisonExpressionPattern : ITerminalExpPattern
    {
        public bool Match(List<Token> tokens)
        {
            foreach (var token in tokens)
            {
                if ((token.TokenType == TokenType.Equal) ||
                    (token.TokenType == TokenType.More) ||
                    (token.TokenType == TokenType.Less) ||
                    (token.TokenType == TokenType.UpEqual) ||
                    (token.TokenType == TokenType.DownEqual))
                    return true;
            }
            return false;
        }
        public TerminalExp CreateExpression(List<Token> tokens)
        {
            int index = 0;
            foreach (var token in tokens)
            {
                if ((token.TokenType == TokenType.Equal) ||
                    (token.TokenType == TokenType.More) ||
                    (token.TokenType == TokenType.Less) ||
                    (token.TokenType == TokenType.UpEqual) ||
                    (token.TokenType == TokenType.DownEqual))
                {
                    index = tokens.IndexOf(token);
                    break;
                }
            }

            TerminalExp exp1 = TerminalExpressionAnalyser.Analyse(tokens.GetRange(0, index));
            TerminalExp exp2 = TerminalExpressionAnalyser.Analyse(tokens.GetRange(
                index + 1, tokens.Count - index - 1));
            if (exp1 is StringConstExp && exp2 is StringConstExp && tokens[index].TokenType == TokenType.Equal)
                return new EqualsExp(exp1, exp2);
                switch (tokens[index].TokenType)
                {
                    case TokenType.Equal:
                        return new EqualsExp(exp1, exp2);
                    case TokenType.More:
                        return new MoreExp(exp1, exp2);
                    case TokenType.Less:
                        return new LessExp(exp1, exp2);
                    case TokenType.UpEqual:
                        return new UpEqualExp(exp1, exp2);
                    case TokenType.DownEqual:
                        return new DownEqualExp(exp1, exp2);
                }
            return null;
        }
    }
    public class MathematicExpressionPattern : ITerminalExpPattern
    {
        public bool Match(List<Token> tokens)
        {
            foreach (var token in tokens)
            {
                if ((token.TokenType == TokenType.Plus) ||
                    (token.TokenType == TokenType.Minus) ||
                    (token.TokenType == TokenType.Multiple) ||
                    (token.TokenType == TokenType.Divide))
                    return true;
            }
            return false;
        }
        public TerminalExp CreateExpression(List<Token> tokens)
        {
            int index = 0;
            foreach (var token in tokens)
                if (token.TokenType == TokenType.Minus)
                {
                    index = tokens.IndexOf(token);
                    break;
                }
            foreach (var token in tokens)
                if (token.TokenType == TokenType.Plus)
                {
                    index = tokens.IndexOf(token);
                    break;
                }
            foreach (var token in tokens)
                if (token.TokenType == TokenType.Divide)
                {
                    index = tokens.IndexOf(token);
                    break;
                }
            foreach (var token in tokens)
                if (token.TokenType == TokenType.Multiple)
                {
                    index = tokens.IndexOf(token);
                    break;
                }
            
            TerminalExp exp1 = TerminalExpressionAnalyser.Analyse(tokens.GetRange(0, index));
            TerminalExp exp2 = TerminalExpressionAnalyser.Analyse(tokens.GetRange(
                index + 1, tokens.Count - index - 1));

                switch (tokens[index].TokenType)
                {
                    case TokenType.Multiple:
                        return new MultipleExp(exp1, exp2);
                    case TokenType.Divide:
                        return new DivideExp(exp1, exp2);
                    case TokenType.Plus:
                        return new PlusExp(exp1, exp2);
                    case TokenType.Minus:
                        return new MinusExp(exp1, exp2);
                }
            return null;
        }
    }
    public class ParenthesisExpressionPattern : ITerminalExpPattern
    {
        public bool Match(List<Token> tokens){return tokens[0].TokenType == TokenType.OpenParenthesis;}
        public TerminalExp CreateExpression(List<Token> tokens)
        {
            var closeParanthesisIndex = TokenHelper.GetIndexPairParanthesis(tokens, 0);
            List<Token> tok = tokens.GetRange(1, closeParanthesisIndex - 1);
            TerminalExp expression = new ParanhesisExp(TerminalExpressionAnalyser.Analyse(tok));
            return expression;
        }
    }
    public class VariableExpressionPattern : ITerminalExpPattern
    {
        public bool Match(List<Token> tokens){return tokens[0].TokenType == TokenType.Var;}
        public TerminalExp CreateExpression(List<Token> tokens){return new VariableExp(tokens[0].Value);}
    }
}