using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for LogWriter
/// </summary>
public class LogWriter
{
    public LogWriter()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private string m_exePath = string.Empty;
    public LogWriter(string logMessage)
    {
        LogWrite(logMessage);
    }

    public void LogWrite(string logMessage)
    {
        m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        string folderPath = "~/App_Data/Logs";

        try
        {
            using (StreamWriter w = File.AppendText(folderPath + "\\" + "log.txt"))
            {
                Log(logMessage, w);
            }
        }
        catch (Exception ex)
        {
        }
    }

    public void Log(string logMessage, TextWriter txtWriter)
    {
        try
        {
            txtWriter.Write("\r\nLog Entry : ");
            txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            txtWriter.WriteLine("  :");
            txtWriter.WriteLine("  :{0}", logMessage);
            txtWriter.WriteLine("-------------------------------");
        }
        catch (Exception ex)
        {
        }
    }
}