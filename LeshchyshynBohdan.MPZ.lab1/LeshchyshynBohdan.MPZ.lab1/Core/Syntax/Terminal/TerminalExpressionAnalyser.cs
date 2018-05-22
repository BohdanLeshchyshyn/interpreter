using System.Collections.Generic;
using System.Linq;
using LeshchyshynBohdan.MPZ.lab1.Core.Lexical;

namespace LeshchyshynBohdan.MPZ.lab1.Core.Syntax.Terminal
{
    public static class TerminalExpressionAnalyser
    {
        private static readonly List<ITerminalExpPattern> Patterns = new List<ITerminalExpPattern>()
        {
            new ParenthesisExpressionPattern(),
            new MathematicExpressionPattern(),
            new СomparisonExpressionPattern(),
            new NumericConstExpressionPattern(),
            new StringConstExpressionPattern(),
            new VariableExpressionPattern()
        };
        public static TerminalExp Analyse(List<Token> tokens)
        {
            var p = Patterns.FirstOrDefault(
                a => a.Match(tokens));
            return p.CreateExpression(tokens);
        }
    }
}