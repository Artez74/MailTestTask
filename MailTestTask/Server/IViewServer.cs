using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    interface IViewServer
    {
        void ChangeBtnStartStop(bool state);
        void ShowErrorMessage(string errorMessage);
        void ShowEnterMessage(TransferMessage transferMessage);
        void PrintData(IEnumerable<PrintMessage> printMessages);
    }
}
