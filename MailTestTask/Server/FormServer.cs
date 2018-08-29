using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transfer;

namespace Server
{
    public partial class FormServer : Form, IViewServer
    {
        PresenterServer presenter;
        ServiceHost host;
        //TransferService cs = new TransferService();
        public FormServer()
        {
            InitializeComponent();
            presenter = new PresenterServer(this, new ModelServer());
        }

        public void ChangeBtnStartStop(bool state)
        {
            if (state)
            {
                btnStartStop.Text = "Остановить";
                lstPrint.Items.Add("Сервер запущен");
            }
            else
            {
                btnStartStop.Text = "Запустить";
                lstPrint.Items.Add("Сервер остановлен.");
                lstPrint.Items.Add("");

            }
        }

            private void BtnClear_Click(object sender, EventArgs e)
        {
            lstPrint.Items.Clear();
        }

        private void BtnStartStop_Click(object sender, EventArgs e)
        {
            presenter.StartStopServer();
        }
    }
}
