using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceDemo
{
    public partial class Form1 : Form
    {
        MessageService messageService = new MessageService();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSpeak_Click(object sender, EventArgs e)
        {
            var name = tbName.Text;
            var newMessage = messageService.ReturnMessage(name);
            MessageBox.Show(newMessage);
        }
    }
}
