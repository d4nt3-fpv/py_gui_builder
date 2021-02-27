using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ben_py_gui_builder;

namespace ben_py_gui_builder
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        



        private void button1_Click(object sender, EventArgs e)
        {

            ben_py_gui_builder.Form1 exMeth = new Form1();
            
            exMeth.create_btn();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ben_py_gui_builder.Form1 exMeth = new Form1();

            exMeth.create_radbtn();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            ben_py_gui_builder.Form1 exMeth = new Form1();

            exMeth.create_label();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            ben_py_gui_builder.Form1 exMeth = new Form1();

            exMeth.create_entry();

        }

        private void button5_Click(object sender, EventArgs e)
        {

            ben_py_gui_builder.Form1 exMeth = new Form1();

            exMeth.create_frame();


        }




        private void button7_Click(object sender, EventArgs e)
        {

            ben_py_gui_builder.Form1 exMeth = new Form1();

            exMeth.create_hscale();

        }

        private void button6_Click(object sender, EventArgs e)
        {

            ben_py_gui_builder.Form1 exMeth = new Form1();

            exMeth.create_checkbox();


        }

        private void button8_Click(object sender, EventArgs e)
        {
            ben_py_gui_builder.Form1 exMeth = new Form1();

            exMeth.create_vscale();

        }

        private void button9_Click(object sender, EventArgs e)
        {

            ben_py_gui_builder.Form1 exMeth = new Form1();

            exMeth.create_progressbar();

        }
    }
}
