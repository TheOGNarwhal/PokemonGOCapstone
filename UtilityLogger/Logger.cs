using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Logger
{
    public class ErrorLogger
    {
        public void errorlogger(Exception errorToWrite)
        {
            string message = string.Format("Time{0}", DateTime.Now.ToString(""));
            message += Environment.NewLine;
            message += "-----------------------------------";
            message += Environment.NewLine;
            message += string.Format("message{0}", errorToWrite.Message);
            message += Environment.NewLine;
            message += string.Format("Stack Trace {0}", errorToWrite.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source{0}", errorToWrite.Source);
            message += Environment.NewLine;
            message += string.Format("Targetsite{0}", errorToWrite.TargetSite.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------";
            message += Environment.NewLine;
            //
            using (StreamWriter _writer = new StreamWriter("C:\\Users\\admin2\\downloads\\PokemonErrorLogs.txt", true))
            {
                _writer.WriteLine(message);
            }
        }
    }
}
