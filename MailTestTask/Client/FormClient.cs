using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FormClient : Form, IViewClient
    {
        private readonly PresenterClient presenterClient;
        public FormClient()
        {
            InitializeComponent();
            presenterClient = new PresenterClient(this, new ModelClient(new WorkerToXmlClient("ClientBase.xml")));
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (tbMessage.Text.Length == 0)
                return;
            var res = presenterClient.SendMessage(tbMessage.Text);
            tbMessage.Text = "";
        }

        public void ShowErrorMessage(string errorMessage)
        {
            MessageBox.Show(errorMessage);
        }

        public void ShowEnterMessage(string Message)
        {
            MessageBox.Show(Message);
        }

        private void timerSendMessage_Tick(object sender, EventArgs e)
        {
            var res = presenterClient.SendUnsendMessage();
        }

        private void FormClient_Load(object sender, EventArgs e)
        {
            timerSendMessage.Enabled = true;
        }
    }
}
