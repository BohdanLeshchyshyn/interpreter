using System;

namespace LeshchyshynBohdan.MPZ.lab1.Core.Lexical
{
    public class Token
    {
        public String Value;
        public TokenType TokenType;
    }
    public enum TokenType
    {
        Undefined, StringConst,
        Dot, Semicolon, Comma, OpenBracket, CloseBracket, OpenParenthesis, CloseParenthesis,
        Equal, More, Less, UpEqual, DownEqual, Assignment, Plus, Minus, Multiple, Divide,
        If, Else, While, Int, String,
        ConsoleLog, Delete, LogAllItems, ReadAndLog, ClearFile,
        CreateDir, CreateTxtFile, Move, Copy, Find, Rename, WriteToFile, AppendToFile,
        NumericConst, Var,
        EmptyEndCommand
    }
}