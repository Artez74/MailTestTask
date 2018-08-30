using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data
{
    public class WorkerToXmlClient : WorkerToXml
    {
        public WorkerToXmlClient(string fileName) : base(fileName)
        {
        }

        public override IEnumerable<PrintMessage> GetData()
        {
            //получаем не отправленные данные
            String host = System.Net.Dns.GetHostName();
            XDocument xdoc;
            lock (sync)
            {
                xdoc = XDocument.Load(fileName);
            }
            var items = from xe in xdoc.Element("Messages").Elements("Message")
                            where xe.Element("IsTransfer").Value == "false"
                            select new PrintMessage
                            {
                                Message = xe.Attribute("text").Value
                            };
            return items;            
        }

        public override void Save(object[] message)
        {
            //сохраняем сообщения
            if (!(message is ClientMessage[] mes))
                throw new Exception("Неверный тип. Неоходим TransferMessage");
            if (mes == null)
                return;

            lock (sync)
            {
                var xdoc = new XDocument();
                XElement root = CheckExistFile();

                foreach (var item in mes)
                {
                    root.Add(new XElement("Message",
                        new XAttribute("text", item.Message),
                        new XElement("IsTransfer", item.IsTransfer),
                        new XElement("DateTime", DateTime.Now.ToString())));
                }
                xdoc.Add(root);
                xdoc.Save(fileName);
            }
        }

        public override void Update(object[] message)
        {
            //обновляем если удалось отправить
            lock (sync)
            {
                var xdoc = new XDocument();
                XElement root = CheckExistFile();
                foreach (var item in root.Elements("Message").ToList())
                {
                    if (item.Element("IsTransfer").Value == "false")
                    {
                        item.Element("IsTransfer").Value = "true";
                    }
                }
                xdoc.Add(root);
                xdoc.Save(fileName);
            }
        }
    }
}
