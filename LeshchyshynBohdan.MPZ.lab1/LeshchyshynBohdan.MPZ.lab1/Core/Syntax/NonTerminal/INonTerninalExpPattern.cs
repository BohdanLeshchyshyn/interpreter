using System;
using System.Collections.Generic;
using System.Linq;
using LeshchyshynBohdan.MPZ.lab1.Core.Lexical;
using LeshchyshynBohdan.MPZ.lab1.Core.Syntax.Terminal;

namespace LeshchyshynBohdan.MPZ.lab1.Core.Syntax.NonTerminal
{
    interface INonTerninalExpPattern
    {
        bool Match(List<Token> tokens);
        NonTerninalExp CreateCommand(List<Token> tokens);
    }
    class CreateVariablePattern : INonTerninalExpPattern
    {
        public bool Match(List<Token> tokens)
        {
            return tokens[0].TokenType == TokenType.Int ||
                   tokens[0].TokenType == TokenType.String;
        }
        public NonTerninalExp CreateCommand(List<Token> tokens)
        {

            List<String> variableNamesList = new List<String>();
            String type = tokens[0].TokenType == TokenType.Int ? "int" : "string";
            variableNamesList.Add(tokens[1].Value);
            int indexEndVariables = 1;

            for (var i = 1; tokens[i + 1].TokenType == TokenType.Comma; i += 2)
            {
                variableNamesList.Add(tokens[i + 2].Value);
                indexEndVariables = i + 2;
            }

            TerminalExp exp;

            if (tokens[indexEndVariables + 1].TokenType == TokenType.Assignment)
                exp = TerminalExpressionAnalyser.Analyse(tokens.GetRange(indexEndVariables + 2, 1));
            else if (type == "int")
                exp = new NumericConstExp(0);
            else
                exp = new StringConstExp("");

            List<CreateVariableCommand> listCreatesCommand = new List<CreateVariableCommand>();

            foreach (var name in variableNamesList)
                listCreatesCommand.Add(new CreateVariableCommand(type, name, exp));

            for (int i = 0; i < listCreatesCommand.Count - 1; i++)
                listCreatesCommand[i].SetNext(listCreatesCommand[i + 1]);

            var semicolonIndex = tokens.FindIndex(a => a.TokenType == TokenType.Semicolon);

            listCreatesCommand[listCreatesCommand.Count - 1].SetNext(
                SyntaxAnalyser.Analyse(tokens.GetRange
                (semicolonIndex, tokens.Count - semicolonIndex)));

            return listCreatesCommand[0];
        }
    }
    class AssignmentCommandPattern : INonTerninalExpPattern
    {
        public bool Match(List<Token> tokens)
        {
            return
                tokens[0].TokenType == TokenType.Var &&
                tokens[1].TokenType == TokenType.Assignment;
        }
        public NonTerninalExp CreateCommand(List<Token> tokens)
        {
            var semicolonIndex = tokens.FindIndex(a => a.TokenType == TokenType.Semicolon);
            var exp = TerminalExpressionAnalyser.Analyse(tokens.GetRange(2, semicolonIndex - 1));
            var command = new AssignmentCommand(tokens[0].Value, exp);
            command.SetNext(SyntaxAnalyser.Analyse(tokens.GetRange(semicolonIndex,
                tokens.Count - semicolonIndex)));
            return command;
        }
    }
    class ConditionCommandPattern : INonTerninalExpPattern
    {
        public bool Match(List<Token> tokens)
        {
            return
                tokens[0].TokenType == TokenType.If &&
                tokens[1].TokenType == TokenType.OpenParenthesis;
        }
        public NonTerninalExp CreateCommand(List<Token> tokens)
        {
            var closeParenthesisIndex = TokenHelper.GetIndexPairParanthesis(tokens, 1);

            var exp = TerminalExpressionAnalyser.Analyse(tokens.GetRange(2, closeParenthesisIndex - 2));
            var command = new ConditionCommand(exp);

            var closeBracketIndex = TokenHelper.GetIndexPairBracket(tokens, closeParenthesisIndex + 1);
            command.SetPositiveNext(SyntaxAnalyser.Analyse(tokens.GetRange(closeParenthesisIndex + 1,
                tokens.Count - closeParenthesisIndex - 1)));
            if (tokens[closeBracketIndex + 1].TokenType == TokenType.Else)
            {
                if (tokens[closeBracketIndex + 2].TokenType != TokenType.If)
                {
                    ConditionCommand com = new ConditionCommand(new StringConstExp("true"));
                    com.SetPositiveNext(SyntaxAnalyser.Analyse(tokens.GetRange(closeBracketIndex + 2,
                        tokens.Count - closeBracketIndex - 2)));
                    com.SetNegativeNext(com.GetPositiveNext().GetNext());
                    command.SetNegativeNext(com);
                }
                else
                    command.SetNegativeNext(SyntaxAnalyser.Analyse(tokens.GetRange(closeBracketIndex + 2,
                        tokens.Count - closeBracketIndex - 2)));
            }
            else
            {
                command.SetNegativeNext(SyntaxAnalyser.Analyse(tokens.GetRange(closeBracketIndex + 1,
                    tokens.Count - closeBracketIndex - 1)));
            }
            return command;
        }
    }
    class ElseCommandPattern : INonTerninalExpPattern
    {
        public bool Match(List<Token> tokens)
        {
            return tokens[0].TokenType == TokenType.Else;
        }
        public NonTerninalExp CreateCommand(List<Token> tokens)
        {
            if (tokens[1].TokenType == TokenType.If)
            {
                NonTerninalExp com = new ConditionCommandPattern().CreateCommand(tokens.GetRange(
                    1, tokens.Count - 1));
                while (com is ConditionCommand)
                    com = ((ConditionCommand)com).GetNegativeNext();
                return com;
            }
            else
            {
                ConditionCommand com = new ConditionCommand(new StringConstExp("false"));
                com.SetPositiveNext(SyntaxAnalyser.Analyse(tokens.GetRange(1,
                tokens.Count - 1)));
                com.SetNegativeNext(com.GetPositiveNext().GetNext());
                return com;

            }
        }
    }
    class WhileCommandPattern : INonTerninalExpPattern
    {
        public bool Match(List<Token> tokens)
        {
            return tokens[0].TokenType == TokenType.While &&
                tokens[1].TokenType == TokenType.OpenParenthesis;
        }
        public NonTerninalExp CreateCommand(List<Token> tokens)
        {
            var closeParenthesisIndex = TokenHelper.GetIndexPairParanthesis(tokens, 1);

            var exp = TerminalExpressionAnalyser.Analyse(tokens.GetRange(2, closeParenthesisIndex - 2));
            var command = new ConditionCommand(exp);

            var closeBracketsIndex = TokenHelper.GetIndexPairBracket(tokens, closeParenthesisIndex + 1);
            BracketsCommand insideCom = (BracketsCommand)SyntaxAnalyser.Analyse(tokens.GetRange(
                closeParenthesisIndex + 1, tokens.Count - closeParenthesisIndex - 1));
            insideCom.SetNext(command);

            command.SetPositiveNext(insideCom);
            command.SetNegativeNext(SyntaxAnalyser.Analyse(tokens.GetRange(
                closeBracketsIndex + 1, tokens.Count - closeBracketsIndex - 1)));

            return command;
        }
    }
    class FunctionsWithOneParameterCommandPattern : INonTerninalExpPattern
    {
        public bool Match(List<Token> tokens)
        {
            return tokens[0].TokenType == TokenType.ConsoleLog ||
                tokens[0].TokenType == TokenType.Delete ||
                tokens[0].TokenType == TokenType.LogAllItems ||
                tokens[0].TokenType == TokenType.ReadAndLog ||
                tokens[0].TokenType == TokenType.ClearFile;
        }
        public NonTerninalExp CreateCommand(List<Token> tokens)
        {
            var closeParenthesisIndex = TokenHelper.GetIndexPairParanthesis(tokens, 1);
            var exp = TerminalExpressionAnalyser.Analyse(tokens.GetRange(2, closeParenthesisIndex - 2));

            NonTerninalExp command;
            switch (tokens[0].TokenType)
            {
                case TokenType.ConsoleLog: command = new ConsoleLogCommand(exp); break;
                case TokenType.Delete: command = new DeleteCommand(exp); break;
                case TokenType.LogAllItems: command =  new LogAllItemsCommand(exp); break;
                case TokenType.ReadAndLog: command =  new ReadAndLogCommand(exp); break;
                case TokenType.ClearFile: command =  new ClearFileCommand(exp); break;
                default: command = new ConsoleLogCommand(exp); break;
            }

            command.SetNext(SyntaxAnalyser.Analyse(tokens.GetRange(closeParenthesisIndex + 1,
                tokens.Count - closeParenthesisIndex - 1)));
            return command;
        }
    }
    class FunctionsWithTwoParametersCommandPattern : INonTerninalExpPattern
    {
        public bool Match(List<Token> tokens)
        {
            return tokens[0].TokenType == TokenType.CreateDir ||
                   tokens[0].TokenType == TokenType.CreateTxtFile ||
                   tokens[0].TokenType == TokenType.Move ||
                   tokens[0].TokenType == TokenType.Copy ||
                   tokens[0].TokenType == TokenType.Find ||
                   tokens[0].TokenType == TokenType.Rename ||
                   tokens[0].TokenType == TokenType.WriteToFile ||
                   tokens[0].TokenType == TokenType.AppendToFile;
        }
        public NonTerninalExp CreateCommand(List<Token> tokens)
        {
            var closeParenthesisIndex = TokenHelper.GetIndexPairParanthesis(tokens, 1);
            var comma = tokens.IndexOf(tokens.First(token => token.TokenType == TokenType.Comma));

            var firstParam = TerminalExpressionAnalyser.Analyse(tokens.GetRange(2, comma - 2));
            var secondParam = TerminalExpressionAnalyser.Analyse(tokens.GetRange(comma + 1,
                closeParenthesisIndex - comma - 1));
            NonTerninalExp command;
            switch (tokens[0].TokenType)
            {
                case TokenType.CreateDir: command = new CreateDirCommand(firstParam, secondParam);break;
                case TokenType.CreateTxtFile: command = new CreateTxtFileCommand(firstParam, secondParam);break;
                case TokenType.Move: command = new MoveCommand(firstParam, secondParam);break;
                case TokenType.Copy: command = new CopyCommand(firstParam, secondParam);break;
                case TokenType.Find: command = new FindCommand(firstParam, secondParam); break;
                case TokenType.Rename: command = new RenameCommand(firstParam, secondParam);break;
                case TokenType.WriteToFile: command = new WriteToFileCommand(firstParam, secondParam); break;
                case TokenType.AppendToFile: command = new AppendToFileCommand(firstParam, secondParam); break;
                default:command = new CreateDirCommand(firstParam, secondParam);break;
            }
            command.SetNext(SyntaxAnalyser.Analyse(tokens.GetRange(closeParenthesisIndex + 1,
                        tokens.Count - closeParenthesisIndex - 1)));
            return command;
        }
    }
    class MissCommandPattern : INonTerninalExpPattern
    {
        public bool Match(List<Token> tokens){return tokens[0].TokenType == TokenType.Semicolon;}
        public NonTerninalExp CreateCommand(List<Token> tokens)
        {
            if (tokens.Count == 1) return null;
            return SyntaxAnalyser.Analyse(tokens.GetRange(1, tokens.Count - 1));
        }
    }
    class BracketsCommandPattern : INonTerninalExpPattern
    {
        public bool Match(List<Token> tokens)
        {
            return tokens[0].TokenType == TokenType.OpenBracket;
        }

        public NonTerninalExp CreateCommand(List<Token> tokens)
        {
            var closeBracketIndex = TokenHelper.GetIndexPairBracket(tokens, 0);
            List<Token> tok = tokens.GetRange(1, closeBracketIndex - 1);
            tok.Add(new Token{ TokenType = TokenType.EmptyEndCommand, Value = "end" });
            BracketsCommand com = new BracketsCommand(SyntaxAnalyser.Analyse(tok));
            com.SetNext(SyntaxAnalyser.Analyse(tokens.GetRange(
                closeBracketIndex + 1, tokens.Count - closeBracketIndex - 1)));
            return com;
        }
    }
    class EmptyEndCommandPattern : INonTerninalExpPattern
    {
        public bool Match(List<Token> tokens){return tokens[0].TokenType == TokenType.EmptyEndCommand;}
        public NonTerninalExp CreateCommand(List<Token> tokens){return new EmptyEndCommand();}
    }
}