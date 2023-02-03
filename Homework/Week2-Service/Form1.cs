using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week2_Service
{
    public partial class Form1 : Form
    {
        
        MessageService messageService = new MessageService();

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_calculate_Click(object sender, EventArgs e)
        {

            var num1 = tb_number1.Text;
            var num2 = tb_number2.Text;

            var newMessage = messageService.ReturnCalculationMessage(num1, num2);

            MessageBox.Show(newMessage);
        }
    }
}
