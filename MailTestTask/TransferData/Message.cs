using System;

namespace Data
{
    public class TransferMessage
    {
        public string Message { get; set; }
        public string ip { get; set; }
    }

    public class PrintMessage : TransferMessage
    {
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return string.Format($"{ Date.ToString()}       |    {ip}     |     {Message}" );
        }
    }

    public class ClientMessage
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public bool IsTransfer { get; set; }
    }
}
