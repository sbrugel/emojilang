using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Emojilang_IDE
{
    public partial class Form1 : Form
    {
        readonly string APPDATA_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Emojilang";
        string pythonDirectory, currentFile = "";
        public Form1(string openedFile = "")
        {
            if (!openedFile.Equals("")) // opening another file
            {

            } else // opening initially
            {
                if (!Directory.Exists(APPDATA_FOLDER))
                {
                    Directory.CreateDirectory(APPDATA_FOLDER);
                }
                if (!File.Exists(APPDATA_FOLDER + "\\python.txt"))
                {
                    string name = Interaction.InputBox("Enter the full path of the location of your Python executable. You can find this by running \'print(sys.executable)\' in a Python shell.");
                    File.WriteAllText(Path.Combine(APPDATA_FOLDER, "python.txt"), name);
                    pythonDirectory = name;
                    InitializeComponent();
                }
                else
                {
                    pythonDirectory = File.ReadLines(Path.Combine(APPDATA_FOLDER, "python.txt")).ElementAtOrDefault(0); // first line
                    InitializeComponent();
                }

                if (!currentFile.Equals(""))
                {
                    Text = "IntelliEmoji - " + currentFile;
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Emojilang File|*.emoji";
            saveFile.Title = "Save File";

            string code = ReplaceText();

            if (currentFile.Equals(""))
            {
                DialogResult result = saveFile.ShowDialog();
                if (result == DialogResult.OK)
                {
                    currentFile = saveFile.FileName;
                    Text = "IntelliEmoji - " + currentFile;
                } else
                {
                    return;
                }
            }

            File.WriteAllText(currentFile, code);

            File.WriteAllText(currentFile + ".py", code);

            string fileName = currentFile + ".py";

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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
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
