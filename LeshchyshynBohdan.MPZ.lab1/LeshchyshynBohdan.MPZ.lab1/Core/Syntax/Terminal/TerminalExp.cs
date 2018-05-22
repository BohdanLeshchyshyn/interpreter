using System;

namespace LeshchyshynBohdan.MPZ.lab1.Core.Syntax.Terminal
{
    public abstract class TerminalExp : IAbstractExpression
    {
        public abstract String Execute(Context context);
    }
    public class StringConstExp : TerminalExp
    {
        private readonly String _value;
        public StringConstExp(String value) { _value = value; }
        public override String Execute(Context context) { return _value; }
    }
    public class NumericConstExp : TerminalExp
    {
        private readonly String _value;
        public NumericConstExp(int value) { _value = Convert.ToString(value); }
        public override String Execute(Context context) { return _value; }
    }
    public class VariableExp : TerminalExp
    {
        private readonly string _variableName;
        public String GetVarName() { return _variableName;}
        public VariableExp(string name){_variableName = name;}
        public override String Execute(Context context) { return context.Variables[_variableName].Value; }
    }
    public class PlusExp : TerminalExp
    {
        private readonly TerminalExp _exp1;
        private readonly TerminalExp _exp2;
        public PlusExp(TerminalExp exp1, TerminalExp exp2)
        {
            _exp1 = exp1;
            _exp2 = exp2;
        }
        public override String Execute(Context context)
        {
            int e1, e2;
            String str1 = _exp1.Execute(context);
            String str2 = _exp2.Execute(context);

            if (int.TryParse(str1, out e1) && int.TryParse(str2, out e2))
                return Convert.ToString(e1 + e2);
            return str1 + str2;
        }
    }
    public class MinusExp : TerminalExp
    {
        private readonly TerminalExp _exp1;
        private readonly TerminalExp _exp2;
        public MinusExp(TerminalExp exp1, TerminalExp exp2)
        {
            _exp1 = exp1;
            _exp2 = exp2;
        }
        public override String Execute(Context context)
        {
            int e1, e2;
            String str1 = _exp1.Execute(context);
            String str2 = _exp2.Execute(context);

            if (int.TryParse(str1, out e1) && int.TryParse(str2, out e2))
                return Convert.ToString(e1 - e2);
            throw new Exception("Віднімання рядків");
        }
    }
    public class MultipleExp : TerminalExp
    {
        private readonly TerminalExp _exp1;
        private readonly TerminalExp _exp2;
        public MultipleExp(TerminalExp exp1, TerminalExp exp2)
        {
            _exp1 = exp1;
            _exp2 = exp2;
        }
        public override String Execute(Context context)
        {
            int e1, e2;
            String str1 = _exp1.Execute(context);
            String str2 = _exp2.Execute(context);

            if (int.TryParse(str1, out e1) && int.TryParse(str2, out e2))
                return Convert.ToString(e1 * e2);
            throw new Exception("Множення рядків");
        }
    }
    public class DivideExp : TerminalExp
    {
        private readonly TerminalExp _exp1;
        private readonly TerminalExp _exp2;
        public DivideExp(TerminalExp exp1, TerminalExp exp2)
        {
            _exp1 = exp1;
            _exp2 = exp2;
        }
        public override String Execute(Context context)
        {
            int e1, e2;
            String str1 = _exp1.Execute(context);
            String str2 = _exp2.Execute(context);

            if (int.TryParse(str1, out e1) && int.TryParse(str2, out e2))
                return Convert.ToString(e1 * e2);
            throw new Exception("Ділення рядків");
        }
    }
    public class EqualsExp : TerminalExp
    {
        private readonly TerminalExp _exp1;
        private readonly TerminalExp _exp2;
        public EqualsExp(TerminalExp exp1, TerminalExp exp2)
        {
            _exp1 = exp1;
            _exp2 = exp2;
        }
        public override String Execute(Context context)
        {
            int e1, e2;
            String str1 = _exp1.Execute(context);
            String str2 = _exp2.Execute(context);

            if (int.TryParse(str1, out e1) && int.TryParse(str2, out e2))
                return e1 == e2 ? "true" : "false";
            return str1 == str2 ? "true" : "false";
        }
    }
    public class MoreExp : TerminalExp
    {
        private readonly TerminalExp _exp1;
        private readonly TerminalExp _exp2;
        public MoreExp(TerminalExp exp1, TerminalExp exp2)
        {
            _exp1 = exp1;
            _exp2 = exp2;
        }
        public override String Execute(Context context)
        {
            int e1, e2;
            String str1 = _exp1.Execute(context);
            String str2 = _exp2.Execute(context);

            if (int.TryParse(str1, out e1) && int.TryParse(str2, out e2))
                return e1 > e2 ? "true" : "false";
            return "false";
        }
    }
    public class LessExp : TerminalExp
    {
        private readonly TerminalExp _exp1;
        private readonly TerminalExp _exp2;
        public LessExp(TerminalExp exp1, TerminalExp exp2)
        {
            _exp1 = exp1;
            _exp2 = exp2;
        }
        public override String Execute(Context context)
        {
            int e1, e2;
            String str1 = _exp1.Execute(context);
            String str2 = _exp2.Execute(context);

            if (int.TryParse(str1, out e1) && int.TryParse(str2, out e2))
                return e1 < e2 ? "true" : "false";
            return "false";
        }
    }
    public class UpEqualExp : TerminalExp
    {
        private readonly TerminalExp _exp1;
        private readonly TerminalExp _exp2;
        public UpEqualExp(TerminalExp exp1, TerminalExp exp2)
        {
            _exp1 = exp1;
            _exp2 = exp2;
        }
        public override String Execute(Context context)
        {
            int e1, e2;
            String str1 = _exp1.Execute(context);
            String str2 = _exp2.Execute(context);

            if (int.TryParse(str1, out e1) && int.TryParse(str2, out e2))
                return e1 >= e2 ? "true" : "false";
            return "false";
        }
    }
    public class DownEqualExp : TerminalExp
    {
        private readonly TerminalExp _exp1;
        private readonly TerminalExp _exp2;
        public DownEqualExp(TerminalExp exp1, TerminalExp exp2)
        {
            _exp1 = exp1;
            _exp2 = exp2;
        }
        public override String Execute(Context context)
        {
            int e1, e2;
            String str1 = _exp1.Execute(context);
            String str2 = _exp2.Execute(context);

            if (int.TryParse(str1, out e1) && int.TryParse(str2, out e2))
                return e1 <= e2 ? "true" : "false";
            return "false";
        }
    }
    public class ParanhesisExp : TerminalExp
    {
        private readonly TerminalExp _exp;
        public ParanhesisExp(TerminalExp exp){_exp = exp;}
        public override String Execute(Context context) { return _exp.Execute(context);}
    }
}