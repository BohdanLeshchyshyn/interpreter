using System;
using System.Collections.Generic;
using LeshchyshynBohdan.MPZ.lab1.Core.Syntax.NonTerminal;

namespace LeshchyshynBohdan.MPZ.lab1.Core
{
    public static class Interpreter
    {
        public static void Interpret(NonTerninalExp head,
                                                out List<String> operatorList,
                                                out List<String> consoleList)
        {
            var context = new Context();
            var c = head;
            while (true)
            {
                if (c is EmptyEndCommand)
                    break;
                c.Execute(context);
                c = c.GetNext();
            }
            operatorList = context.OperatorsList;
            consoleList = context.ConsoleOutput;
        }
    }
}