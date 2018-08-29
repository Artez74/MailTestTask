using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Data
{
    public class WorkerToXml : IWorker
    {
        private readonly string fileName;
        public WorkerToXml(string fileName)
        {
            this.fileName = fileName;
        }

        public IEnumerable<PrintMessage> GetData()
        {
                XDocument xdoc = XDocument.Load(fileName);
                var items = from xe in xdoc.Element("Messages").Elements("Message")

                            select new PrintMessage
                            {
                                Message = xe.Attribute("text").Value,
                                ip = xe.Element("ip").Value,
                                Date = Convert.ToDateTime(xe.Element("DateTime").Value)
                            };
            return items;
        }

        public void Save(TransferMessage message)
        {
            XDocument xdoc;
            XElement root;
            try
            {
                if (!File.Exists(fileName))
                {
                    root = new XElement("Messages");
                    //xdoc.Save(_fileName);
                }
                else
                {
                    xdoc = XDocument.Load(fileName);
                    root = xdoc.Element("Messages");
                    File.Delete(fileName);
                }

                xdoc = new XDocument();


                root.Add(new XElement("Message",
                    new XAttribute("text", message.Message),
                    new XElement("ip", message.ip),
                    new XElement("DateTime", DateTime.Now.ToString())));
                xdoc.Add(root);
                xdoc.Save(fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
