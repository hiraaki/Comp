using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace Comp
{
    class LexAnalyser
    {
        private string codeFile { get; set; }

        public LexAnalyser(string path)
        {
            codeFile=path;
        }


        public static string OperatorCheck(string s, int startPosition, int endPosition)
        {
            string check = "";
            if (Math.Max(startPosition, endPosition) <= s.Length)
            {
                check = s.Substring(startPosition, endPosition - startPosition);
            }
            switch (check)
            {
                case "+":
                    return "<ADD>";                
                case "-":
                    return "<SUM>";
                case "*":
                    return "<MUL>";
                case "/":
                    return "<DIV>";
                case "%":
                    return "<MOD>";
                case "!":
                    return "<NOT";
                case "&&":
                    return "<LOP>";
                case "||":
                    return "<LOP>";
                case ">":
                    return "<ROP>";
                case "<":
                    return "<ROP>";
                case ">=":
                    return "<ROP>";
                case "<=":
                    return "<ROP>";
                case "!=":
                    return "<ROP>";
                case "==":
                    return "<ROP>";
                case "=":
                    return "<ATT>";
            }

            return "<ERROR>";
        }

        public static string ReservCheck(string s, int startPosition, int endPosition)
        {
            string check = "";
            
            if (Math.Max(startPosition, endPosition) <= s.Length)
                check = s.Substring(startPosition, endPosition - startPosition);
            switch (check)
            {
                case "ProgramVar":
                    return "<PROGRAMVAR>";
                case "if":
                    return "<IF>";
                case "else":
                    return "<ELSE>";
                case "for":
                    return "<FOR>";
                case "while":
                    return "<WHILE>";
                case "case":
                    return "<CASE>";
                case "switch":
                    return "<SWITCH>";
                case "break":
                    return "<BREAK>";
                case "int":
                    return "<INT>";
                case "real":
                    return "<REAL>";
                case "double":
                    return "<DOUBLE>";
                case "char":
                    return "<CHAR>";
                case "bool":
                    return "<BOOL>";
                case "true":
                    return "<TRUE>";
                case "false":
                    return "<FALSE>";
                case "ProgramBody":
                    return "<PROGRAMBODY>";
            }
            return ("<ID>");

        }


        public static string SpecialCheck(string s, int startPosition, int endPosition)
        {
            var check = "";
            if (Math.Max(startPosition, endPosition) <= s.Length)
                check = s.Substring(startPosition, endPosition - startPosition);
            switch (check)
            {
                case "{":
                    return "<OPBRACE>";
                case "}":
                    return "<CLBREACE>";
                case "(":
                    return "<OPPAR>";
                case ")":
                    return "<CLPAR>";
                case ";":
                    return "<ENDSTM>";
            }
            return ("<ERROR>");

        }

        public List<string> TokenGen()
        {
            var tokens = new List<Tuple<string, string>>();
            var y = 0;
            using (StreamReader sr = File.OpenText(codeFile))
            {
                var s = "";
                while (!sr.EndOfStream)
                {
                    s = sr.ReadLine();
                    var startPosition = 0;

                    var i = 0;
                    //s = Regex.Replace(s, @"\s+", string.Empty);
                    tokens.Add(new Tuple<string, string>($"<line {y}>", $"<line {y}>"));
                    y++;
                    STATE_0:
                    startPosition = i;
                    if (i == s.Length)
                    {
                        goto FINNISH;
                    }
                    if (char.IsLetter(s[i]))
                    {
                        goto STATE_1;
                    }
                    if (char.IsDigit(s[i]))
                    {
                        goto STATE_14;
                    }
                    if (char.IsWhiteSpace(s[i]))
                    {
                        i++;
                        goto STATE_0;
                    }

                    switch (s[i])
                    {
                        case '=':
                        case '<':
                        case '>':
                        case '!':
                            goto STATE_3;
                        case '+':
                            goto STATE_13;
                        case '-':
                            goto STATE_7;
                        case '/':
                            goto STATE_6;
                        case '*':
                            goto STATE_8;
                        case '&':
                            goto STATE_9;
                        case '|':
                            goto STATE_11;
                        case '"':
                            goto STATE_17;
                        case '(':
                            goto STATE_19;
                        case ')':
                            goto STATE_20;
                        case '{':
                            goto STATE_21;
                        case '}':
                            goto STATE_22;
                        case ';':
                            goto STATE_23;
                        case '%':
                            goto STATE_24;
                        default:
                            Console.WriteLine("Failing Character {0} on state 1", s[i]);
                            goto FAILED;
                    }
                    STATE_1:
                    i++;
                    if (i < s.Length && char.IsLetterOrDigit(s[i]))
                    {
                        goto STATE_1;
                    }
                    tokens.Add(new Tuple<string, string>(ReservCheck(s, startPosition, i),
                        s.Substring(startPosition, i - startPosition)));
                    goto STATE_0;
                    STATE_3:
                    i++;
                    if (s[i] == '=')
                        goto STATE_5;
                    goto STATE_4;
                    STATE_4: //Reconhece o token
                    tokens.Add(new Tuple<string, string>(OperatorCheck(s, startPosition, i),
                        s.Substring(startPosition, i - startPosition)));

                    goto STATE_0;
                    STATE_5:
                    i++;
                    tokens.Add(new Tuple<string, string>(OperatorCheck(s, startPosition, i),
                        s.Substring(startPosition, i - startPosition)));
                    goto STATE_0;
                    STATE_6:
                    i++;
                    tokens.Add(new Tuple<string, string>(OperatorCheck(s, startPosition, i),
                        s.Substring(startPosition, i - startPosition)));
                    goto STATE_0;
                    STATE_7:
                    i++;
                    if (char.IsDigit(s[i]))
                    {
                        goto STATE_14;
                    }
                    tokens.Add(new Tuple<string, string>(OperatorCheck(s, startPosition, i),
                        s.Substring(startPosition, i - startPosition)));
                    goto STATE_0;
                    STATE_8:
                    i++;
                    tokens.Add(new Tuple<string, string>(OperatorCheck(s, startPosition, i),
                        s.Substring(startPosition, i - startPosition)));
                    goto STATE_0;
                    STATE_9:
                    i++;
                    if (s[i] == '&')
                        goto STATE_10;
                    Console.WriteLine("Failing Character {0} on state 9", s[i]);
                    goto FAILED;
                    STATE_10:
                    i++;
                    tokens.Add(new Tuple<string, string>(OperatorCheck(s, startPosition, i),
                        s.Substring(startPosition, i - startPosition)));
                    goto STATE_0;
                    STATE_11:
                    i++;
                    if (s[i] == '|')
                        goto STATE_12;
                    Console.WriteLine("Failing Character {0} on state 12", s[i]);
                    goto FAILED;
                    STATE_12:
                    i++;
                    tokens.Add(new Tuple<string, string>(OperatorCheck(s, startPosition, i),
                        s.Substring(startPosition, i - startPosition)));
                    goto STATE_0;
                    STATE_13:
                    i++;
                    if (char.IsDigit(s[i]))
                        goto STATE_14;
                    if (s[i] == '=')
                        goto STATE_5;
                    goto STATE_4;
                    STATE_14:
                    i++;
                    if (i < s.Length && char.IsDigit(s[i]))
                        goto STATE_14;
                    if (i < s.Length && s[i] == '.')
                        goto STATE_15;
                    tokens.Add(new Tuple<string, string>("<number>",
                        s.Substring(startPosition, i - startPosition)));
                    goto STATE_0;
                    STATE_15:
                    i++;
                    if (char.IsDigit(s[i]))
                    {
                        goto STATE_16;
                    }
                    Console.WriteLine($"Failing Character {s[i]} on state 16");
                    goto FAILED;
                    STATE_16:
                    i++;
                    if (i < s.Length && char.IsDigit(s[i]))
                    {
                        goto STATE_16;
                    }
                    tokens.Add(new Tuple<string, string>("<number>",
                        s.Substring(startPosition, i - startPosition)));
                    goto STATE_0;
                    STATE_17:
                    i++;
                    if (i < s.Length && s[i] == '\\')
                    {
                        i += 2;
                        goto STATE_17;
                    }
                    if (i < s.Length && s[i] == '"')
                        goto STATE_18;
                    goto STATE_17;
                    STATE_18:
                    i++;
                    tokens.Add(new Tuple<string, string>("<string>",
                        s.Substring(startPosition, i - startPosition)));
                    goto STATE_0;
                    STATE_19:
                    i++;
                    tokens.Add(new Tuple<string, string>(SpecialCheck(s, startPosition, i),
                        s.Substring(startPosition, i - startPosition)));
                    goto STATE_0;
                    STATE_20:
                    i++;
                    tokens.Add(new Tuple<string, string>(SpecialCheck(s, startPosition, i),
                        s.Substring(startPosition, i - startPosition)));
                    goto STATE_0;
                    STATE_21:
                    i++;
                    tokens.Add(new Tuple<string, string>(SpecialCheck(s, startPosition, i),
                        s.Substring(startPosition, i - startPosition)));
                    goto STATE_0;
                    STATE_22:
                    i++;
                    tokens.Add(new Tuple<string, string>(SpecialCheck(s, startPosition, i),
                        s.Substring(startPosition, i - startPosition)));
                    goto STATE_0;
                    STATE_23:
                    i++;
                    tokens.Add(new Tuple<string, string>(SpecialCheck(s, startPosition, i),
                        s.Substring(startPosition, i - startPosition)));
                    goto STATE_0;
                    STATE_24:
                    i++;
                    tokens.Add(new Tuple<string, string>(OperatorCheck(s, startPosition, i),
                        s.Substring(startPosition, i - startPosition)));
                    goto STATE_0;
                    FAILED:
                    Console.WriteLine($"Caracter inesperado encontrado na linha {y}");
                    throw new Exception("Falha ao tentar resolver alguns simbolos");
                    FINNISH:
                    Console.Write("");
                }
            }
            return tokens.Select(x => x.Item1).ToArray().ToList();

        }

    }
        
       
    
}
