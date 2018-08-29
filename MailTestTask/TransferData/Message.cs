using System;

namespace Data
{
    public struct TransferMessage
    {
        public string Message { get; set; }
        public string ip { get; set; }
    }

    public struct PrintMessage
    {
        public string Message { get; set; }
        public string ip { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return string.Format(@"{0} | {1} | {2}", Date.ToString(), ip, Message);
        }
    }
}
