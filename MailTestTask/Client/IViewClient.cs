using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    interface IViewClient
    {
        void ShowErrorMessage(string errorMessage);
        void ShowEnterMessage(string Message);
    }
}
