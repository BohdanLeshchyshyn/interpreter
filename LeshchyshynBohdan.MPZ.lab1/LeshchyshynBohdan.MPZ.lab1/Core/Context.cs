using System;
using System.Collections.Generic;

namespace LeshchyshynBohdan.MPZ.lab1.Core
{
    public class Context
    {
        public Dictionary<String, Variable> Variables = new Dictionary<String, Variable>();
        public List<String> OperatorsList = new List<String>();
        public List<String> ConsoleOutput = new List<String>();
        public void Clean() {Variables.Clear();}
    }
    public struct Variable
    {
        public String Type;
        public String Value;
        public Variable(String type, String value)
        {
            Type = type;
            Value = value;
        }
    }
}
