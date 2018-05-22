using System.Collections.Generic;
using System.Linq;
using LeshchyshynBohdan.MPZ.lab1.Core.Lexical;
using LeshchyshynBohdan.MPZ.lab1.Core.Syntax.NonTerminal;

namespace LeshchyshynBohdan.MPZ.lab1.Core.Syntax
{
    static class SyntaxAnalyser
    {
        private static readonly List<INonTerninalExpPattern> Patterns = new List<INonTerninalExpPattern>()
        {
            new FunctionsWithOneParameterCommandPattern(),
            new FunctionsWithTwoParametersCommandPattern(),
            new CreateVariablePattern(),
            new AssignmentCommandPattern(),
            new ConditionCommandPattern(),
            new MissCommandPattern(),
            new BracketsCommandPattern(),
            new ElseCommandPattern(),
            new WhileCommandPattern(),
            new EmptyEndCommandPattern()
        };
        public static NonTerninalExp Analyse(List<Token> tokens)
        {
            var p = Patterns.FirstOrDefault(
                a => a.Match(tokens));
            return p.CreateCommand(tokens);
        }
    }
}
