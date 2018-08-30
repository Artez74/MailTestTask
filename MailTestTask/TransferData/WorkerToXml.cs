using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Data
{
    public class WorkerToXml : IWorker
    {
        protected object sync = new object();
        protected readonly string fileName;
        public WorkerToXml(string fileName)
        {
            this.fileName = fileName;
        }

        public virtual IEnumerable<PrintMessage>  GetData()
        {
            //получаем сообщения для печати
            XDocument xdoc;
            lock (sync)
            {
                xdoc = XDocument.Load(fileName);
            }
                var items = from xe in xdoc.Element("Messages").Elements("Message")

                            select new PrintMessage
                            {
                                Message = xe.Attribute("text").Value,
                                ip = xe.Element("ip").Value,
                                Date = Convert.ToDateTime(xe.Element("DateTime").Value)
                            };
            return items;
        }

        protected XElement CheckExistFile()
        {
                if (File.Exists(fileName))
                {
                    var xdoc = XDocument.Load(fileName);
                    var root = xdoc.Element("Messages");
                    File.Delete(fileName);
                    return root;
                }            
            return new XElement("Messages");
        }

        public virtual void Save(object[] message)
        {
            //сохраняем полученные сообщения
            lock (sync)
            {

                if (!(message is TransferMessage[] mes))
                    throw new Exception("Неверный тип. Неоходим TransferMessage");
                if (mes == null)
                    return;

                var xdoc = new XDocument();
                XElement root = CheckExistFile();

                foreach (var item in mes)
                {
                    root.Add(new XElement("Message",
                        new XAttribute("text", item.Message),
                        new XElement("ip", item.ip),
                        new XElement("DateTime", DateTime.Now.ToString())));
                }
                xdoc.Add(root);
                xdoc.Save(fileName);
            }
        }

        public virtual void Update(object[] message)
        {
        }
    }
}
