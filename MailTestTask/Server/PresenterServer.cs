using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Transfer;

namespace Server
{
    class PresenterServer
    {
        private readonly IViewServer view;
        private readonly IModelServer model;
        bool blnStartStop;
        ServiceHost host;
        
        public PresenterServer(IViewServer view, IModelServer model)
        {
            this.view = view;
            this.model = model;
        }

        public void StartStopServer()
        {
            blnStartStop = !blnStartStop;
            if (blnStartStop)
            {
                host = new ServiceHost(typeof(TransferService));
                host.Open();
            }
            else
            {
                host.Close();
            }
            view.ChangeBtnStartStop(blnStartStop);
        }
    }
}
