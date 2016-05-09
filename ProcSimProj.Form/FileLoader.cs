using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcSimProj.Form;

namespace AndreisMathsExpressionEvaluator.HistoryManager
{
    public static class HistoryLoader
    {
        public static void Load(MainForm form)
        {
            var fileLocation = Application.StartupPath + ConstantsClass._fileName;
            if (File.Exists(fileLocation))
            {
                form.HistoryTextBox.Text = File.ReadAllText(fileLocation);
            }
            form.HistoryTextBox.SelectionStart = form.HistoryTextBox.Text.Length;
            form.HistoryTextBox.ScrollToCaret();
        }
    }
}
