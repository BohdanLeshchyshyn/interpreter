using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LeshchyshynBohdan.MPZ.lab1.Core.Lexical
{
    public class LexicalAnalyzer
    {
        public List<Token> Analyze(String program)
        {
            program = Regex.Replace(program, @"\t|\n|\r", "");
            var list = GetStringConsts(program);
            list = GetSeparators(list);
            list = GetOperators(list);
            list = GetFunctions(list);
            list = GetVarsAndConsts(list);
            list = RemoveEmptyTokens(list);
            return list;
        }
        public List<Token> GetStringConsts(String program)
        {
            if (program.Trim() == "")
            {
                return new List<Token>();
            }
            var firstIndex = program.IndexOf('"');
            if (firstIndex == -1)
            {
                return new List<Token>() { new Token() { TokenType = TokenType.Undefined, Value = program } };
            }
            var secondIndex = program.IndexOf('"', firstIndex + 1);
            if (secondIndex == -1)
            {
                throw new Exception("Error S001: Quote is missing!");
            }
            var result = new List<Token>();
            if (firstIndex > 0)
            {
                result.Add(new Token()
                {
                    TokenType = TokenType.Undefined,
                    Value = program.Substring(0, firstIndex)
                });
                result.Add(new Token()
                {
                    TokenType = TokenType.StringConst,
                    Value = program.Substring(firstIndex + 1, secondIndex - firstIndex - 1)
                });
                result.AddRange(this.GetStringConsts(program.Substring(secondIndex + 1, program.Length - secondIndex - 1)));
            }
            else
            {
                throw new Exception("Error S002: Quote is in incorrect position!");
            }

            return result;
        }
        public List<Token> GetSeparators(List<Token> list)
        {
            var dividers = new List<Divider>()
            {
                new Divider()
                {
                    TokenType = TokenType.Dot,
                    Value = ".",
                    Length = 1
                },
                new Divider()
                {
                    TokenType = TokenType.Semicolon,
                    Value = ";",
                    Length = 1
                },
                new Divider()
                {
                    TokenType = TokenType.Comma,
                    Value = ",",
                    Length = 1
                },
                new Divider()
                {
                    TokenType = TokenType.OpenBracket,
                    Value = "{",
                    Length = 1
                },
                new Divider()
                {
                    TokenType = TokenType.CloseBracket,
                    Value = "}",
                    Length = 1
                },
                new Divider()
                {
                    TokenType = TokenType.OpenParenthesis,
                    Value = "(",
                    Length = 1
                },
                new Divider()
                {
                    TokenType = TokenType.CloseParenthesis,
                    Value = ")",
                    Length = 1
                },
            };
            return this.DivideByMany(list, dividers);
        }
        public List<Token> GetOperators(List<Token> list)
        {
            var dividers = new List<Divider>()
            {
                new Divider()
                {
                    TokenType = TokenType.If,
                    Value = "if",
                    Length = 2
                },
                new Divider()
                {
                    TokenType = TokenType.Else,
                    Value = "else",
                    Length = 4
                },
                new Divider()
                {
                    TokenType = TokenType.While,
                    Value = "while",
                    Length = 5
                },
                new Divider()
                {
                    TokenType = TokenType.Equal,
                    Value = "==",
                    Length = 2
                },
                new Divider()
                {
                    TokenType = TokenType.UpEqual,
                    Value = ">=",
                    Length = 2
                },
                new Divider()
                {
                    TokenType = TokenType.DownEqual,
                    Value = "<=",
                    Length = 2
                },
                new Divider()
                {
                    TokenType = TokenType.More,
                    Value = ">",
                    Length = 1
                },
                new Divider()
                {
                    TokenType = TokenType.Less,
                    Value = "<",
                    Length = 1
                },
                new Divider()
                {
                    TokenType = TokenType.Assignment,
                    Value = "=",
                    Length = 1
                },
                new Divider()
                {
                    TokenType = TokenType.Plus,
                    Value = "+",
                    Length = 1
                },
                new Divider()
                {
                    TokenType = TokenType.Minus,
                    Value = "-",
                    Length = 1
                },
                new Divider()
                {
                    TokenType = TokenType.Multiple,
                    Value = "*",
                    Length = 1
                },
                new Divider()
                {
                    TokenType = TokenType.Divide,
                    Value = "/",
                    Length = 1
                },
                new Divider()
                {
                    TokenType = TokenType.Int,
                    Value = "int",
                    Length = 3
                },
                new Divider()
                {
                    TokenType = TokenType.String,
                    Value = "string",
                    Length = 6
                }
            };
            return this.DivideByMany(list, dividers);
        }
        public List<Token> GetFunctions(List<Token> list)
        {
            var dividers = new List<Divider>()
            {
                new Divider()
                {
                    TokenType = TokenType.ConsoleLog,
                    Value = "ConsoleLog",
                    Length = 10
                },
                new Divider()
                {
                    TokenType = TokenType.Delete,
                    Value = "Delete",
                    Length = 6
                },
                new Divider()
                {
                    TokenType = TokenType.LogAllItems,
                    Value = "LogAllItems",
                    Length = 11
                },
                new Divider()
                {
                    TokenType = TokenType.ReadAndLog,
                    Value = "ReadAndLog",
                    Length = 10
                },
                new Divider()
                {
                    TokenType = TokenType.ClearFile,
                    Value = "ClearFile",
                    Length = 9
                },
                new Divider()
                {
                    TokenType = TokenType.CreateDir,
                    Value = "CreateDir",
                    Length = 9
                },
                new Divider()
                {
                    TokenType = TokenType.CreateTxtFile,
                    Value = "CreateTxtFile",
                    Length = 13
                },
                new Divider()
                {
                    TokenType = TokenType.Move,
                    Value = "Move",
                    Length = 4
                },
                new Divider()
                {
                    TokenType = TokenType.Copy,
                    Value = "Copy",
                    Length = 4
                },
                new Divider()
                {
                    TokenType = TokenType.Find,
                    Value = "Find",
                    Length = 4
                },
                new Divider()
                {
                    TokenType = TokenType.Rename,
                    Value = "Rename",
                    Length = 6
                },
                new Divider()
                {
                    TokenType = TokenType.WriteToFile,
                    Value = "WriteToFile",
                    Length = 11
                },
                new Divider()
                {
                    TokenType = TokenType.AppendToFile,
                    Value = "AppendToFile",
                    Length = 12
                }
            };
            return DivideByMany(list, dividers);
        }
        public List<Token> GetVarsAndConsts(List<Token> list)
        {
            var result = new List<Token>();
            foreach (var token in list)
            {
                if (token.TokenType == TokenType.Undefined && token.Value.Trim() != "")
                {
                    var tokenValue = token.Value.Trim();
                    double output = 0;
                    if (Double.TryParse(tokenValue, out output))
                    {
                        result.Add(new Token()
                        {
                            TokenType = TokenType.NumericConst,
                            Value = Convert.ToString(output)
                        });
                    }
                    else
                    {
                        result.Add(new Token()
                        {
                            TokenType = TokenType.Var,
                            Value = tokenValue
                        });
                    }
                }
                else
                {
                    result.Add(token);
                }
            }
            return result;
        }
        public List<Token> DivideByOne(Token token, Divider divider)
        {
            var result = new List<Token>();
            var tokenValue = token.Value;
            var dividerIndex = tokenValue.IndexOf(divider.Value);
            if (dividerIndex == -1)
            {
                if (result.Count == 0)
                {
                    return new List<Token>() { token };
                }
                return result;
            }
            if (dividerIndex > 0)
            {
                result.Add(new Token()
                {
                    TokenType = TokenType.Undefined,
                    Value = tokenValue.Substring(0, dividerIndex)
                });
            }
            result.Add(new Token()
            {
                TokenType = divider.TokenType,
                Value = tokenValue.Substring(dividerIndex, divider.Length)
            });
            result.AddRange(this.DivideByOne(new Token()
            {
                TokenType = TokenType.Undefined,
                Value = tokenValue.Substring(dividerIndex + divider.Length)
            },
            divider));
            return result;
        }
        public List<Token> DivideByMany(List<Token> list, List<Divider> dividers)
        {
            var result = new List<Token>();
            var tmpList = list;
            foreach (var divider in dividers)
            {
                foreach (var token in tmpList)
                {
                    if (token.TokenType == TokenType.Undefined)
                    {
                        result.AddRange(this.DivideByOne(token, divider));
                    }
                    else
                    {
                        result.Add(token);
                    }
                }
                tmpList = result;
                result = new List<Token>();
            }
            return tmpList;
        }
        public List<Token> RemoveEmptyTokens(List<Token> list)
        {
            var result = new List<Token>();
            foreach (var token in list)
            {
                if (token.TokenType != TokenType.Undefined)
                    result.Add(token);
            }
            result.Add(new Token() { Value = "end", TokenType = TokenType.EmptyEndCommand });
            return result;
        }
        public String ToStr(List<Token> list)
        {
            String result = "";
            foreach (var token in list)
            {
                result += "TokType: " + token.TokenType + "\nTokValue: \"" + token.Value + "\"\n\n";
            }
            return result;
        }
    }
}
