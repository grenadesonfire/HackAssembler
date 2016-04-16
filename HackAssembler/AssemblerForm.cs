using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HackAssembler
{
    public partial class AssemblerForm : Form
    {
        Assembler assembler;
        public AssemblerForm()
        {
            InitializeComponent();
            assembler = new Assembler();
        }

        private void LoadAssemblyButton_Click(object sender, EventArgs e)
        {
            /*
            Assembler assembler = new Assembler();
            Console.WriteLine("Enter the name of the assembly:");
            FileInfo inputAssembly = new FileInfo( 
                @"D:\Programming\nand2Tetris\projects\06\add\Add.asm");//Console.ReadLine();
            string fileName = inputAssembly.FullName;
            assembler.LoadFile(fileName);
            assembler.ProcessLines();
            assembler.Assemble();
            string outputFileName = Path.Combine(inputAssembly.DirectoryName, fileName.Substring(0,fileName.Length-4) + ".hack");
            File.WriteAllLines(outputFileName, assembler.OutputAssembly());
            */
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                assembler.LoadFile(ofd.FileName);
                AssemblyTextBox.Lines = assembler.GetAssemblyFile();
            }
        }

        private void AssembleButton_Click(object sender, EventArgs e)
        {
            //assembler.ProcessLines();
            assembler.Assemble();
            MachineCodeTextBox.Lines = assembler.OutputAssembly().ToArray();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            assembler.SaveAssembly();
        }
    }
}
