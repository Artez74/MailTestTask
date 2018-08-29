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
using Data;
using Transfer;

namespace Server
{
    public partial class FormServer : Form, IViewServer
    {
        PresenterServer presenter;
       public FormServer()
        {
            InitializeComponent();
            presenter = new PresenterServer(this, new ModelServer(new WorkerToXml("Base.xml")));
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

        public void ShowEnterMessage(TransferMessage transferMessage)
        {
            lstPrint.Items.Add((new PrintMessage() { Date = DateTime.Now, ip = transferMessage.ip, Message = transferMessage.Message }).ToString());
        }

        public void ShowErrorMessage(string errorMessage)
        {
            MessageBox.Show(errorMessage);
        }

        public void PrintData(IEnumerable<PrintMessage> printMessages)
        {
            lstPrint.Items.Add("");
            lstPrint.Items.Add("Печать данных...");
            foreach (var item in printMessages)
            {
                lstPrint.Items.Add(item);
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

        private void PrintMainMenuItem_Click(object sender, EventArgs e)
        {
            presenter.PrintData();
        }
    }
}
