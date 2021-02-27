using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ben_py_gui_builder;

namespace ben_py_gui_builder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();




        }



        public void create_btn()

        {
            Console.WriteLine("Button Click");

            button1.Visible = true;


            Console.WriteLine("Finished");

        }



        public void create_radbtn()

        {
            Console.WriteLine("RadButton Click");
        }

        public void create_label()

        {
            Console.WriteLine("label Click");
        }


        public void create_entry()

        {
            Console.WriteLine("entry Click");
        }
        
        public void create_frame()

        {
            Console.WriteLine("frame Click");
        }

        public void create_checkbox()

        {
            Console.WriteLine("checkbox Click");
        }


        public void create_hscale()

        {
            Console.WriteLine("hscale Click");
        }

        public void create_vscale()

        {
            Console.WriteLine("vscale Click");
        }

        

        public void create_progressbar()

        {
            Console.WriteLine("progressbar Click");
        }

        public void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
