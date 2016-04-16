// Decompiled with JetBrains decompiler
// Type: HackAssembler.Assembler
// Assembly: HackAssembler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 412D4B62-7ED3-49E4-8529-24D43793E67D
// Assembly location: C:\Users\nicky\Desktop\something.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HackAssembler
{
    internal class Assembler
    {
        private string assembly_file_name = "";
        private FileInfo inputAssembly;
        private List<string> assemblyLines;
        private List<Token> tokenPreProcess;
        private List<Token> tokenPostProcess;
        private Dictionary<string, int> _symbolTable;

        public Assembler()
        {
            this.assemblyLines = new List<string>();
            this.tokenPreProcess = new List<Token>();
            this.tokenPostProcess = new List<Token>();
            this.GenerateSymbolTable();
        }

        public Assembler(string fileName)
        {
            this.LoadFile(fileName);
        }

        private void GenerateSymbolTable()
        {
            this._symbolTable = new Dictionary<string, int>()
            {
                {"SP",      0x0000},
                {"LCL",     0x0001},
                {"ARG",     0x0002},
                {"THIS",    0x0003},
                {"THAT",    0x0004},
                {"R0",      0x0000},
                {"R1",      0x0001},
                {"R2",      0x0002},
                {"R3",      0x0003},
                {"R4",      0x0004},
                {"R5",      0x0005},
                {"R6",      0x0006},
                {"R7",      0x0007},
                {"R8",      0x0008},
                {"R9",      0x0009},
                {"R10",     0x000a},
                {"R11",     0x000b},
                {"R12",     0x000c},
                {"R13",     0x000d},
                {"R14",     0x000e},
                {"R15",     0x000f},
                {"SCREEN",  0x4000},
                {"KBD",     0x6000}
            };
        }

        internal void SaveAssembly()
        {
            if (!string.IsNullOrEmpty(assembly_file_name))
            {
                string outputFileName = Path.Combine(
                    inputAssembly.DirectoryName, 
                    assembly_file_name.Substring(0, assembly_file_name.Length - 4) + ".hack");
                File.WriteAllLines(outputFileName, OutputAssembly());
            }
        }

        public void LoadFile()
        {
            inputAssembly = new FileInfo(assembly_file_name);
            assemblyLines = new List<string>(File.ReadAllLines(this.assembly_file_name));
        }

        internal void ProcessLines()
        {
            tokenPreProcess = new List<Token>();
        }

        public void LoadFile(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException();
            this.assembly_file_name = fileName;
            this.LoadFile();
        }

        public bool Pass_1()
        {
            this.tokenPreProcess = new List<Token>();
            try
            {
                int lineNumber = 0;
                foreach (string assemblyLine in this.assemblyLines)
                {
                    bool wasStmt = false;
                    tokenPreProcess.Add(new Token(assemblyLine, lineNumber, out wasStmt));
                    if (wasStmt)
                        ++lineNumber;
                    else if (tokenPreProcess[tokenPreProcess.Count - 1].tokenType == Token_Type.LABEL)
                    {
                        _symbolTable.Add(tokenPreProcess[tokenPreProcess.Count - 1].convertedValue, lineNumber);
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Pass_2()
        {
            this.tokenPostProcess = new List<Token>();
            try
            {
                foreach (Token token in this.tokenPreProcess)
                {
                    switch (token.tokenType)
                    {
                        case Token_Type.CTYPE:
                            this.tokenPostProcess.Add(token);
                            break;
                        case Token_Type.CONSTANT:
                            this.tokenPostProcess.Add(token.Reprocess(_symbolTable));
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public void Assemble()
        {
            if (!this.Pass_1())
            {
                Console.WriteLine("Created symbol table and finished first pass.");
            }
            if (!this.Pass_2())
            {
                Console.WriteLine("Assembly completed.");
            }
        }

        public List<string> OutputAssembly()
        {
            List<string> stringList = new List<string>();
            foreach (Token token in this.tokenPostProcess)
                stringList.Add(token.convertedValue);
            return stringList;
        }

        public string[] GetAssemblyFile()
        {
            return this.assemblyLines.ToArray();
        }
    }
}
