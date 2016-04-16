using System;
using System.Collections.Generic;

namespace HackAssembler
{
    class Token
    {
        public Token_Type tokenType;
        string original = "";
        public string convertedValue = "";
        private int lineNumber;

        public Token(string line)
        {
            original = line;
            if(line.Length == 0)
            {
                tokenType = Token_Type.EMPTYLINE;
            }
            else if (line.Length >=2 && 
                line.Substring(0, 2).Equals(
                    Assembler_Constants.LINE_COMMENT))
            {
                tokenType = Token_Type.COMMENT;
            }
            else if(line.Contains(Assembler_Constants.CONSTANT))
            {
                tokenType = Token_Type.CONSTANT;
                convertedValue = "0"+DecimalToBinary(
                    line.Substring(1,line.Length-1),15);
            }
            else if(line.Length > 2 && line[0] == '(')
            {
                tokenType = Token_Type.LABEL;
                convertedValue = line.Replace("(", "").Replace(")", "");
            }
            else
            {
                //tokenType = Token_Type.OTHER;
                tokenType = Token_Type.CTYPE;
                convertedValue = ConvertCType(line);
            }
        }

        public Token(string line, int lineNumber, out bool wasStmt) : this(line)
        {
            this.lineNumber = lineNumber;
            if(this.tokenType == Token_Type.CONSTANT || this.tokenType == Token_Type.CTYPE)
            {
                wasStmt = true;
            }
            else
            {
                wasStmt = false;
            }
        }

        private static string ConvertCType(string line)
        {
            line = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0];
            bool hasDest = line.Contains("=");
            bool hasJump = line.Contains(";");
            string dest = "";
            string comp = "";
            string jump = "";
            if (hasDest)
            {
                dest = line.Substring(0,line.IndexOf('='));
                line = line.Substring(line.IndexOf('=')+1, line.Length - dest.Length-1);
            }
            if (hasJump)
            {
                comp = line.Substring(0, line.IndexOf(';'));
                jump = line.Substring(line.IndexOf(';') + 1, line.Length - comp.Length - 1);
            }
            else
            {
                comp = line;
            }
            return "111"+ConvertComp(comp)+ConvertDest(dest)+ConvertJump(jump);
        }
        private static string ConvertJump(string jump)
        {
            switch (jump)
            {
                case "JGT":
                    return "001";
                case "JEQ":
                    return "010";
                case "JGE":
                    return "011";
                case "JLT":
                    return "100";
                case "JNE":
                    return "101";
                case "JLE":
                    return "110";
                case "JMP":
                    return "111";
                default:
                    return "000";
            }
        }

        internal Token Reprocess(Dictionary<string, int> _symbolTable)
        {
            string search = original.Split(new string[] { "@", " "},StringSplitOptions.RemoveEmptyEntries)[0];
            if (convertedValue != "0")
                return this;
            try {
                int val = _symbolTable[search];
                return new Token("@" + val);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Couldn't parse constant");
                return new Token("@0");
            }
        }

        private static string ConvertDest(string dest)
        {
            string ret = "";
            ret += dest.Contains("A") ? "1" : "0";
            ret += dest.Contains("D") ? "1" : "0";
            ret += dest.Contains("M") ? "1" : "0";
            return ret;
        }
        private static string ConvertComp(string comp)
        {
            string ret = "";
            if (comp.Contains("M")) ret = "1";
            else ret = "0";
            comp = comp.Split(' ')[0];
            switch (comp)
            {
                case "0":
                    ret += "101010";
                    break;
                case "1":
                    ret += "111111";
                    break;
                case "-1":
                    ret += "111010";
                    break;
                case "D":
                    ret += "001100";
                    break;
                case "M":
                case "A":
                    ret += "110000";
                    break;
                case "!D":
                    ret += "001101";
                    break;
                case "!A":
                case "!M":
                    ret += "110001";
                    break;
                case "-D":
                    ret += "001111";
                    break;
                case "-A":
                case "-M":
                    ret += "110011";
                    break;
                case "D+1":
                    ret += "011111";
                    break;
                case "A+1":
                case "M+1":
                    ret += "110111";
                    break;
                case "D-1":
                    ret += "001110";
                    break;
                case "A-1":
                case "M-1":
                    ret += "110010";
                    break;
                case "D+A":
                case "D+M":
                    ret += "000010";
                    break;
                case "D-A":
                case "D-M":
                    ret += "010011";
                    break;
                case "A-D":
                case "M-D":
                    ret += "000111";
                    break;
                case "D&A":
                case "D&M":
                    ret += "000000";
                    break;
                case "D|A":
                case "D|M":
                    ret += "010101";
                    break;
            }
            return ret;
        }
        public static string DecimalToBinary(string value, int length)
        {
            int val = -1;

            if (!int.TryParse(value,out val))
            {
                return "";
            }
            string bin = Convert.ToString(val,2);
            while (bin.Length != length) bin = "0" + bin;
            return bin;
        }
    }
}