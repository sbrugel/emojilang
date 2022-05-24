using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Emojilang_IDE
{
    public partial class Form1 : Form
    {
        string pythonDirectory = "";
        public Form1()
        {
            if (pythonDirectory == "")
            {
                MessageBox.Show("Please go into the code and copy your python.exe directory into the \'pythonDirectory\' variable. An improved way of getting this path will be implemented later.");
                return;
            }
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Emojilang File|*.emoji";
            saveFile.Title = "Save File";
            DialogResult result = saveFile.ShowDialog();

            string code = ReplaceText();
            if (result == DialogResult.OK)
            {
                File.WriteAllText(saveFile.FileName, code);
            }

            File.WriteAllText(saveFile.FileName + ".py", code);

            string fileName = saveFile.FileName + ".py";

            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(pythonDirectory, fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardError = true
            };
            textBox2.Text = "";
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            string error = p.StandardError.ReadToEnd();
            p.WaitForExit();

            if (output == "")
            {
                textBox2.BackColor = Color.PaleVioletRed;

                string betterError = error;

                betterError = betterError.Replace("def", "🏁");
                betterError = betterError.Replace("print", "🖨");
                betterError = betterError.Replace("if", "🤔");
                betterError = betterError.Replace("elif", "😕");
                betterError = betterError.Replace("else", "😔");
                betterError = betterError.Replace("=", "✔");
                betterError = betterError.Replace("not", "❌");
                betterError = betterError.Replace("return", "↩");
                betterError = betterError.Replace("True", "🙂");
                betterError = betterError.Replace("False", "😢");
                betterError = betterError.Replace(">", "▶");
                betterError = betterError.Replace("<", "◀");

                textBox2.Text = betterError;
            } else
            {
                textBox2.BackColor = Color.White;
                textBox2.Text = output;
            }

            File.Delete(fileName);
        }

        public string ReplaceText()
        {
            string code = textBox1.Text;

            code = code.Replace("🏁", "def");
            code = code.Replace("🖨", "print");
            code = code.Replace("🤔", "if");
            code = code.Replace("😕", "elif");
            code = code.Replace("😔", "else");
            code = code.Replace("✔", "=");
            code = code.Replace("❌", "not");
            code = code.Replace("↩", "return");
            code = code.Replace("🙂", "True");
            code = code.Replace("😢", "False");
            code = code.Replace("▶", ">");
            code = code.Replace("◀", "<");

            code = code.Replace("🕛", "0");
            code = code.Replace("🕐", "1");
            code = code.Replace("🕑", ">");
            code = code.Replace("🕒", "3");
            code = code.Replace("🕓", "4");
            code = code.Replace("🕔", "5");
            code = code.Replace("🕕", "6");
            code = code.Replace("🕖", "7");
            code = code.Replace("🕗", "8");
            code = code.Replace("🕘", "<");

            return code;
        }
    }
}
