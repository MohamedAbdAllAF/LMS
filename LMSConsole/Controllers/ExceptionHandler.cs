using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LMSConsole.Controllers
{
    internal class ExceptionHandler
    {
        public void AddExeption(Exception expt,string Classname,DateTime time) 
        {
            try
            {
                string programDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string fileName = "Log.txt";
                string filePath = Path.Combine(programDirectory, fileName);
                string Message = DateTime.Now+" => Class: "+Classname+ " Erorr: \"" + expt.Message+ "\"\n";
                File.AppendAllText(filePath, Message);
            }
            catch (Exception ex) { }
        }
    }
}
