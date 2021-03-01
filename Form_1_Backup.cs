using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bens_Test01
{
    

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Bens_Knopf_Test();

        }

        public int i = 0;
        public Form2 myNewForm = new Form2();
        public void Bens_Knopf_Test()
        {
            
            if (i == 0)
            {
                myNewForm.Show();
                i++;
            }
            else
            {
                Button MyButton = new Button();
                MyButton.Text = "Submit";
                myNewForm.Controls.Add(MyButton);
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Bens_Knopf_Test();

        }
    }
}
