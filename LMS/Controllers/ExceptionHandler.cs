using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LMS.Controllers
{
    internal class ExceptionHandler
    {
        public void AddExeption(Exception expt, string className,string functionName, DateTime time)
        {
            try
            {
                string programDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string fileName = "Log.txt";
                string filePath = Path.Combine(programDirectory, fileName);
                string Message = DateTime.Now + " => 'Class: " + className + " Method: "+ functionName + "' Erorr: \"" + expt.Message + "\"\n";
                File.AppendAllText(filePath, Message);
            }
            catch (Exception ex) { }
        }
    }
}
