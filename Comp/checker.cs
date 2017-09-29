using System;

namespace Comp
{
    class Checker
    {
        public static string Operator(string s, int startPosition, int endPosition)
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

        public static string Reserved(string s, int startPosition, int endPosition)
        {
            string check = "";

            if (Math.Max(startPosition, endPosition) <= s.Length)
                check = s.Substring(startPosition, endPosition - startPosition);
            switch (check)
            {

                case "print":
                    return "<OUT>";
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
                case "double":
                    return "<DOUBLE>";
                case "string":
                    return "<STRING>";
                case "bool":
                    return "<BOOL>";
                case "true":
                    return "<TRUE>";
                case "false":
                    return "<FALSE>";
                case "ProgramBody":
                    return "<PROGRAMBODY>";
            }
            return ("<ID>" + "<" + check + ">");

        }


        public static string Special(string s, int startPosition, int endPosition)
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
    }
}