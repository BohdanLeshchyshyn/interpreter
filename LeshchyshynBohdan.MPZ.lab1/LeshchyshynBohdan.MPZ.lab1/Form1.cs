using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LeshchyshynBohdan.MPZ.lab1.Core;
using LeshchyshynBohdan.MPZ.lab1.Core.Lexical;
using LeshchyshynBohdan.MPZ.lab1.Core.Syntax;
using LeshchyshynBohdan.MPZ.lab1.Core.Syntax.NonTerminal;

namespace LeshchyshynBohdan.MPZ.lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InfoBox.Text = "ConsoleLog(\"text\") - виводить \'text\' в консоль;\n\n" +
                          "CreateDir(\"path\",\"name\") - створює папку \'name\' за шляхом \'path\';\n\n" +
                          "CreateTxtFile(\"path\",\"name.txt\") - створює текстовий файл \'name.txt\' за шляхом \'path\';\n\n" +
                          "Move(\"file\",\"path\") - переносить \'file\' за шляхом \'path\';\n\n" +
                          "Copy(\"file\",\"path\") - копіює \'file\' за шляхом \'path\';\n\n" +
                          "Find(\"path\",\"expression\") - шукає в \'path\' та його підпапках всі файли, що відповідають \'expression\' і виводить в консоль;\n\n" +
                          "Rename(\"full_path\",\"name\") - задає \'full_path\' нове ім'я \'name\';\n\n" +
                          "WriteToFile(\"file\",\"text\") - записує в \'file\' текст \'text\';\n\n" +
                          "AppendToFile(\"file\",\"text\") - додає в кінець файлу \'file\' текст \'text\';\n\n" +
                          "Delete(\"file\") - видалає \'file\';\n\n" +
                          "LogAllItems(\"path\") - виводить в консоль усі файли та папки що знаходяться в \'path\';\n\n" +
                          "ReadAndLog(\"file\") - виводить в консоль вміст файлу \'file\';\n\n" +
                          "ClearFile(\"file\") - очищає вміст файлу \'file\';\n\n";
        }

        private void label2_Click(object sender, EventArgs e){}
        private void label1_Click(object sender, EventArgs e){}
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var lexicalAnalyzer = new LexicalAnalyzer();
                var lexems = lexicalAnalyzer.Analyze(InputBox.Text);
                SyntaxBox.Text = lexicalAnalyzer.ToStr(lexems);


                NonTerninalExp com = SyntaxAnalyser.Analyse(lexems);
                List<String> operatorsList;
                List<String> consoleList;
                Interpreter.Interpret(com, out operatorsList, out consoleList);
                OperatorsBox.Lines = operatorsList.ToArray();
                ConsoleBox.Lines = consoleList.ToArray();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString(), "Exception", MessageBoxButtons.OK);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e){}
    }
}
