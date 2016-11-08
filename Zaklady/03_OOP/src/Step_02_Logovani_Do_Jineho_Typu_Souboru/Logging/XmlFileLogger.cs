using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace JezekT.SkoleniCS.Kalkulator.ConsoleApp.Logging
{
    public class XmlFileLogger
    {
        private const string LogsElementName = "Logs";
        private const string LogElementName = "Log";
        private const string DateTimeElementName = "DateTime";
        private const string LevelElementName = "Level";
        private const string MessageElementName = "Message";

        private readonly string _filePath;


        public void Log(LogLevel level, string message)
        {
            if (!File.Exists(_filePath))
            {
                CreateNewFileAndLog(level, message);
            }
            else
            {
                AddLogToExistingFile(level, message);
            }
        }


        public XmlFileLogger(string filePath)
        {
            _filePath = filePath;
        }


        private void CreateNewFileAndLog(LogLevel level, string message)
        {
            var xmlWriterSettings = new XmlWriterSettings { Indent = true, NewLineOnAttributes = true };
            using (var xmlWriter = XmlWriter.Create(_filePath, xmlWriterSettings))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement(LogsElementName);

                xmlWriter.WriteStartElement(LogElementName);
                xmlWriter.WriteElementString(DateTimeElementName, DateTime.Now.ToString(CultureInfo.CurrentCulture));
                xmlWriter.WriteElementString(LevelElementName, level.ToString());
                xmlWriter.WriteElementString(MessageElementName, message);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Flush();
                xmlWriter.Close();
            }
        }
        private void AddLogToExistingFile(LogLevel level, string message)
        {
            var xDocument = XDocument.Load(_filePath);
            var root = xDocument.Element(LogsElementName);
            if (root != null)
            {
                var rows = root.Descendants(LogElementName);
                var lastRow = rows.Last();
                lastRow.AddAfterSelf(
                    new XElement(LogElementName, new XElement(DateTimeElementName, DateTime.Now.ToString(CultureInfo.CurrentCulture)),
                                                 new XElement(LevelElementName, level.ToString()),
                                                 new XElement(MessageElementName, message)));
                xDocument.Save(_filePath);
            }
        }
    }
}
