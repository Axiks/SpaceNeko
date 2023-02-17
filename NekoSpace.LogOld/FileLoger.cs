using NekoSpace.Log.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.Log
{
    public class FileLoger : ILog
    {
        private string pathToLogFile;

        public FileLoger(string pathToLogFile)
        {
            this.pathToLogFile = pathToLogFile;
        }

        public void Print(string text)
        {
            if (!IsFileExist())
            {
                CreateEmptyFile();
            }

            WriteTextToEnd(text);
        }

        private bool IsFileExist() {
            return File.Exists(pathToLogFile);
        }
        public void CreateEmptyFile() {
            File.WriteAllText(pathToLogFile, String.Empty);
        }
        public void WriteTextToEnd(string text) {
            File.AppendAllText(@pathToLogFile, text + Environment.NewLine);
        }
        public void WriteTextAndDateToEnd(string text)
        {
            var currentDate = DateTime.Now.ToString("dd-MM-YYYY h:mm:ss");
            File.AppendAllText(@pathToLogFile, currentDate + " | " + text + Environment.NewLine);
        }
    }
}
