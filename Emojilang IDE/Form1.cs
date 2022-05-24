using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Emojilang_IDE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Emojilang File|*.emoji";
            saveFile.Title = "Save File";
            DialogResult result = saveFile.ShowDialog();

            string code = replaceText();
            if (result == DialogResult.OK)
            {
                File.WriteAllText(saveFile.FileName, code);
            }

            File.WriteAllText(saveFile.FileName + ".py", code);

            string fileName = saveFile.FileName + ".py";

            Process p = new Process();
            p.StartInfo = new ProcessStartInfo("C:\\Program Files (x86)\\Microsoft Visual Studio\\Shared\\Python37_64\\python.exe", fileName)
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
                textBox2.Text = error;
            } else
            {
                textBox2.Text = output;
            }

            File.Delete(fileName);
        }

        public string replaceText()
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
