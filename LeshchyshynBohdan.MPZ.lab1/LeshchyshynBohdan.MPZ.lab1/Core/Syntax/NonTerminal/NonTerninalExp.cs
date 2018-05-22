using System;
using System.IO;
using LeshchyshynBohdan.MPZ.lab1.Core.Syntax.Terminal;

namespace LeshchyshynBohdan.MPZ.lab1.Core.Syntax.NonTerminal
{
    public abstract class NonTerninalExp : IAbstractExpression
    {
        public abstract NonTerninalExp GetNext();
        public abstract void SetNext(NonTerninalExp exp);
        public abstract String Execute(Context context);
    }
    class ConsoleLogCommand : NonTerninalExp
    {
        private readonly TerminalExp _expression;
        private NonTerninalExp _next;
        public ConsoleLogCommand(TerminalExp exp){_expression = exp;}
        public override void SetNext(NonTerninalExp command){_next = command;}
        public override NonTerninalExp GetNext(){ return _next;}
        public override String Execute(Context context)
        {
            String str = _expression.Execute(context);
            context.ConsoleOutput.Add(str);
            context.OperatorsList.Add("ConsoleLogCommand - print string - " + str);
            return null;
        }
    }
    class CreateVariableCommand : NonTerninalExp
    {
        private NonTerninalExp _next;
        private readonly String _variableName;
        private readonly String _variableType;
        private readonly TerminalExp _variableValue;
        public CreateVariableCommand(string type, string varName, TerminalExp exp)
        {
            _variableType = type;
            _variableName = varName;
            _variableValue = exp;
        }
        public override void SetNext(NonTerninalExp command){_next = command;}
        public override NonTerninalExp GetNext(){return _next;}
        public override String Execute(Context context)
        {
            context.Variables.Add(_variableName, new Variable(_variableType, _variableValue.Execute(context)));
            context.OperatorsList.Add("CreateVariableCommand - create variable type:" + _variableType +
                "name: \"" + _variableName +
                "\"value: \"" + context.Variables[_variableName].Value + "\"");
            return null;
        }
    }
    class AssignmentCommand : NonTerninalExp
    {
        private readonly String _variableName;
        private readonly TerminalExp _expression;
        private NonTerninalExp _next;
        public AssignmentCommand(String variable, TerminalExp exp)
        {
            _variableName = variable;
            _expression = exp;
        }
        public override void SetNext(NonTerninalExp command){_next = command;}
        public override NonTerninalExp GetNext(){return _next;}
        public override String Execute(Context context)
        {
            Variable var = context.Variables[_variableName];
            String str = _expression.Execute(context);
            int e;
            if (!int.TryParse(str, out e) && (var.Type == "int"))
                throw new Exception("Присвоєння рядка числу");
            var.Value = str;
            context.Variables[_variableName] = var;

            context.OperatorsList.Add("AssignmentCommand - variable \"" + _variableName +
                "\" assignment value \"" + var.Value + "\"");
            return null;
        }
    }
    class ConditionCommand : NonTerninalExp
    {
        private readonly TerminalExp _expression;
        private NonTerninalExp _nextPositive;
        private NonTerninalExp _nextNegative;
        private bool _result = true;
        public ConditionCommand(TerminalExp exp){_expression = exp;}
        public void SetPositiveNext(NonTerninalExp command){_nextPositive = command;}
        public void SetNegativeNext(NonTerninalExp command){_nextNegative = command;}
        public NonTerninalExp GetPositiveNext(){return _nextPositive;}
        public NonTerninalExp GetNegativeNext(){return _nextNegative;}
        public override NonTerninalExp GetNext(){return _result ? _nextPositive : _nextNegative;}
        public override void SetNext(NonTerninalExp exp){}
        public override String Execute(Context context)
        {
            String str = _expression.Execute(context);
            context.OperatorsList.Add("ConditionCommand - return value - \"" + str +"\"");
            _result = _expression.Execute(context) == "true";
            return null;
        }
    }
    class CreateDirCommand : NonTerninalExp
    {
        private readonly TerminalExp _whereExp;
        private readonly TerminalExp _nameExp;
        private NonTerninalExp _next;
        public CreateDirCommand(TerminalExp whereExp, TerminalExp nameExp)
        {
            _whereExp = whereExp;
            _nameExp = nameExp;
        }
        public override void SetNext(NonTerninalExp command) { _next = command; }
        public override NonTerninalExp GetNext() { return _next; }
        public override String Execute(Context context)
        {
            String whereStr = _whereExp.Execute(context);
            String nameStr = _nameExp.Execute(context);
            Directory.CreateDirectory(@whereStr + nameStr);
            context.OperatorsList.Add("CreateDirCommand - create directory \"" + whereStr + nameStr + "\"");
            return null;
        }
    }
    class DeleteCommand : NonTerninalExp
    {
        private readonly TerminalExp _fileExp;
        private NonTerninalExp _next;
        public DeleteCommand(TerminalExp file) { _fileExp = file; }
        public override void SetNext(NonTerninalExp command) { _next = command; }
        public override NonTerninalExp GetNext() { return _next; }
        public override String Execute(Context context)
        {
            String fileStr = _fileExp.Execute(context);

            if (File.Exists(fileStr))
            {
                File.Delete(@fileStr);
                context.OperatorsList.Add("- Delete file - " + fileStr + "\n");
            }
            if (Directory.Exists(fileStr))
            {
                Directory.Delete(@fileStr, true);
                context.OperatorsList.Add("DeleteCommand - delete directory - \"" + fileStr + "\"");
            }
            return null;
        }
    }
    class ClearFileCommand : NonTerninalExp
    {
        private readonly TerminalExp _fileExp;
        private NonTerninalExp _next;
        public ClearFileCommand(TerminalExp file) { _fileExp = file; }
        public override void SetNext(NonTerninalExp command) { _next = command; }
        public override NonTerninalExp GetNext() { return _next; }
        public override String Execute(Context context)
        {
            String fileStr = _fileExp.Execute(context);

            if (File.Exists(fileStr))
            {
                File.WriteAllText(@fileStr, "");
                context.OperatorsList.Add("ClearFileCommand - clear file \"" + fileStr + "\"");
            }
            return null;
        }
    }
    class ReadAndLogCommand : NonTerninalExp
    {
        private readonly TerminalExp _fileExp;
        private NonTerninalExp _next;
        public ReadAndLogCommand(TerminalExp file) { _fileExp = file; }
        public override void SetNext(NonTerninalExp command) { _next = command; }
        public override NonTerninalExp GetNext() { return _next; }
        public override String Execute(Context context)
        {
            String fileStr = _fileExp.Execute(context);
            if (File.Exists(fileStr))
            {
                String textfile = File.ReadAllText(@fileStr);
                context.OperatorsList.Add("ReadAndLogCommand - read file \"" + fileStr + "\" and log on console");
                context.ConsoleOutput.Add("- Text in file - " + fileStr+"\n - " + textfile);
            }
            return null;
        }
    }
    class LogAllItemsCommand : NonTerninalExp
    {
        private readonly TerminalExp _pathExp;
        private NonTerninalExp _next;
        public LogAllItemsCommand(TerminalExp path) { _pathExp = path; }
        public override void SetNext(NonTerninalExp command) { _next = command; }
        public override NonTerninalExp GetNext() { return _next; }
        public override String Execute(Context context)
        {
            String pathStr = _pathExp.Execute(context);

            if (Directory.Exists(pathStr))
            {
                context.OperatorsList.Add("LogAllItemsCommand - read all elements from \""+ 
                    pathStr +"\" and log on console");
                var a = Directory.EnumerateFileSystemEntries(@pathStr);
                foreach (var file in a)
                    context.ConsoleOutput.Add("Element - " + file + "\n");
            }
            return null;
        }
    }
    class CreateTxtFileCommand : NonTerninalExp
    {
        private readonly TerminalExp _whereExp;
        private readonly TerminalExp _nameExp;
        private NonTerninalExp _next;
        public CreateTxtFileCommand(TerminalExp whereExp, TerminalExp nameExp)
        {
            _whereExp = whereExp;
            _nameExp = nameExp;
        }
        public override void SetNext(NonTerninalExp command) { _next = command; }
        public override NonTerninalExp GetNext() { return _next; }
        public override String Execute(Context context)
        {
            String whereStr = _whereExp.Execute(context);
            String nameStr = _nameExp.Execute(context);
            if (nameStr.Contains(".txt"))
            {
                FileStream fs = File.Create(@whereStr + nameStr);
                fs.Close();
                context.OperatorsList.Add("CreateTxtFileCommand - Create file \"" + whereStr + nameStr + "\"");
            }
            return null;
        }
    }
    class MoveCommand : NonTerninalExp
    {
        private readonly TerminalExp _fromExp;
        private readonly TerminalExp _toExp;
        private NonTerninalExp _next;
        public MoveCommand(TerminalExp fromExp, TerminalExp toExp)
        {
            _toExp = toExp;
            _fromExp = fromExp;
        }
        public override void SetNext(NonTerninalExp command) { _next = command; }
        public override NonTerninalExp GetNext() { return _next; }
        public override String Execute(Context context)
        {
            String fromStr = _fromExp.Execute(context);
            String toStr = _toExp.Execute(context);
            toStr += fromStr.Substring(fromStr.LastIndexOf("\\"));
            if (File.Exists(fromStr))
            {
                File.Move(@fromStr, @toStr);
                context.OperatorsList.Add("MoveCommand - move file \"" + fromStr + " to \n" + toStr + "\"");
            }
            if (Directory.Exists(fromStr))
            {
                Directory.Move(@fromStr,@toStr );
                context.OperatorsList.Add("MoveCommand - move dir \"" + fromStr + " to \n" + toStr + "\"");
            }
            return null;
        }
    }
    class RenameCommand : NonTerninalExp
    {
        private readonly TerminalExp _pathExp;
        private readonly TerminalExp _newName;
        private NonTerninalExp _next;
        public RenameCommand(TerminalExp pathExp, TerminalExp newName)
        {
            _pathExp = pathExp;
            _newName = newName;
        }
        public override void SetNext(NonTerninalExp command) { _next = command; }
        public override NonTerninalExp GetNext() { return _next; }
        public override String Execute(Context context)
        {
            String pathStr = _pathExp.Execute(context);
            String newNameStr = _newName.Execute(context);

            int i = pathStr.LastIndexOf("\\", StringComparison.Ordinal);
            String newStr = pathStr.Substring(0, i + 1) + newNameStr;
            if (File.Exists(pathStr))
            {
                File.Move(@pathStr, @newStr);
                context.OperatorsList.Add("RenameCommand - rename file \"" + pathStr + " to \n" + newStr + "\"");
            }
            if (Directory.Exists(pathStr))
            {
                Directory.Move(@pathStr, @newStr);
                context.OperatorsList.Add("RenameCommand - rename dir \"" + pathStr + " to \n" + newStr + "\"");
            }
            return null;
        }
    }
    class CopyCommand : NonTerninalExp
    {
        private readonly TerminalExp _fromExp;
        private readonly TerminalExp _toExp;
        private NonTerninalExp _next;
        public CopyCommand(TerminalExp fromExp, TerminalExp whereExp)
        {
            _toExp = whereExp;
            _fromExp = fromExp;
        }
        public override void SetNext(NonTerninalExp command) { _next = command; }
        public override NonTerninalExp GetNext() { return _next; }
        public override String Execute(Context context)
        {
            String fromStr = _fromExp.Execute(context);
            String toStr = _toExp.Execute(context);
            toStr += fromStr.Substring(fromStr.LastIndexOf("\\"));
            if (File.Exists(fromStr))
            {
                File.Copy(@fromStr, @toStr);
                context.OperatorsList.Add("CopyCommand - copy file \"" + fromStr + " to \n" + toStr + "\"");
            }
            if (Directory.Exists(fromStr))
            {
                CopyDir(fromStr, toStr);
                context.OperatorsList.Add("CopyCommand - copy dir \"" + fromStr + " to \n" + toStr + "\"");
            }
            return null;
        }
        private void CopyDir(String fromDir, String toDir)
        {
            Directory.CreateDirectory(toDir);
            foreach (string s1 in Directory.GetFiles(fromDir))
            {
                string s2 = toDir + "\\" + Path.GetFileName(s1);
                File.Copy(s1, s2);
            }
            foreach (string s in Directory.GetDirectories(fromDir))
            {
                CopyDir(s, toDir + "\\" + Path.GetFileName(s));
            }
        }
    }
    class FindCommand : NonTerninalExp
    {
        private readonly TerminalExp _whereExp;
        private readonly TerminalExp _whatExp;
        public FindCommand(TerminalExp whereExp, TerminalExp whatExp)
        {
            _whereExp = whereExp;
            _whatExp = whatExp;
        }

        private NonTerninalExp _next;
        public override void SetNext(NonTerninalExp command) { _next = command; }
        public override NonTerninalExp GetNext() { return _next; }
        public override String Execute(Context context)
        {
            String whereStr = _whereExp.Execute(context);
            String whatStr = _whatExp.Execute(context);

            var files = Directory.EnumerateFileSystemEntries(@whereStr, @whatStr, SearchOption.AllDirectories);
            context.OperatorsList.Add("FindCommand - find - \"" + whatStr + "\" in \n" + whereStr + "\"");

            foreach (var str in files)
                context.ConsoleOutput.Add("File faund  \"" + str + "\"");
            return null;
        }
    }
    class WriteToFileCommand : NonTerninalExp
    {
        private readonly TerminalExp _fileExp;
        private readonly TerminalExp _textExp;
        private NonTerninalExp _next;
        public WriteToFileCommand(TerminalExp fileExp, TerminalExp textExp)
        {
            _fileExp = fileExp;
            _textExp = textExp;
        }
        public override void SetNext(NonTerninalExp command) { _next = command; }
        public override NonTerninalExp GetNext() { return _next; }
        public override String Execute(Context context)
        {
            String fileStr = _fileExp.Execute(context);
            String textStr = _textExp.Execute(context);

            if (File.Exists(fileStr))
            {
                File.WriteAllText(@fileStr, textStr);
                context.OperatorsList.Add("WriteToFileCommand - write to file \"" + fileStr + "\"");
            }
            return null;
        }
    }
    class AppendToFileCommand : NonTerninalExp
    {
        private readonly TerminalExp _fileExp;
        private readonly TerminalExp _textExp;
        private NonTerninalExp _next;
        public AppendToFileCommand(TerminalExp fileExp, TerminalExp textExp)
        {
            _fileExp = fileExp;
            _textExp = textExp;
        }
        public override void SetNext(NonTerninalExp command) { _next = command; }
        public override NonTerninalExp GetNext() { return _next; }
        public override String Execute(Context context)
        {
            String fileStr = _fileExp.Execute(context);
            String textStr = _textExp.Execute(context);

            if (File.Exists(fileStr))
            {
                File.AppendAllText(@fileStr, textStr + "\r\n");
                context.OperatorsList.Add("ConsoleLogCommand - write to file \"" + fileStr + "\"");
            }
            return null;
        }
    }
    class BracketsCommand : NonTerninalExp
    {
        private readonly NonTerninalExp _insideCommands;
        private NonTerninalExp _next;
        public BracketsCommand(NonTerninalExp insideCommands){_insideCommands = insideCommands;}
        public override void SetNext(NonTerninalExp next){_next = next;}
        public override NonTerninalExp GetNext(){return _next;}
        public override String Execute(Context context)
        {
            var c = _insideCommands;
            while (true)
            {
                if (c is EmptyEndCommand)
                    break;
                c.Execute(context);
                c = c.GetNext();
            }
            return null;
        }
    }
    class EmptyEndCommand : NonTerninalExp
    {
        public EmptyEndCommand(){}
        public override NonTerninalExp GetNext(){return null;}
        public override void SetNext(NonTerninalExp exp){}
        public override String Execute(Context context){return null;}
    }
}