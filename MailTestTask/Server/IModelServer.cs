﻿using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    interface IModelServer
    {
        //ICollection<PrintMessage> GetMessages();
        void Save(TransferMessage transferMessage);
        IEnumerable<PrintMessage> GetData();
        
    }
}
