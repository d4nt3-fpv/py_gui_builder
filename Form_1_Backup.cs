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
        public void Bens_Knopf_Test(string widget_typ = "Button")
        {
            
            if (i == 0)     // The first time, this method is running
            {
                myNewForm.Show();
                
                var anz_btn = 0;
                var anz_lbl = 0;
                var anz_radbtn = 0;
                var anz_entry = 0;
                var anz_checkbox = 0;
                var anz_prgsbar = 0;
                
                List<string> list_of_all_ui_elements = new List<string>();
                List<string> list_of_all_buttons = new List<string>();
                List<string> list_of_all_labels = new List<string>();
                List<string> list_of_all_radiobtns = new List<string>();
                List<string> list_of_all_entrys = new List<string>();
                List<string> list_of_all_checkboxes = new List<string>();
                List<string> list_of_all_prgsbars = new List<string>();
                
                // mytestlist.Add("Testa");
                // mytestlist.Add("TestB");
                // Console.WriteLine(mytestlist[0]);

                i++;    // WICHTIG!!!
            }
            else // Runs every time, when the method is called
            {
                if (widget_typ == "Button")
                {
                    Button MyButton = new Button();
                    MyButton.Text = "Submit";
                    myNewForm.Controls.Add(MyButton);
                    ControlExtension.Draggable(MyButton, true);
                }
                else if (widget_typ == "Label")
                {
                    Label mylab = new Label();
                    mylab.Text = "GeeksforGeeks";
                    myNewForm.Controls.Add(mylab);
                    ControlExtension.Draggable(mylab, true);
                }

                else if (widget_typ == "Radiobutton")
                {
                    RadioButton r1 = new RadioButton();
                    r1.Text = "Intern";
                    myNewForm.Controls.Add(r1);
                    ControlExtension.Draggable(r1, true);
                }

                else if (widget_typ == "Entry")
                {
                    TextBox Mytextbox = new TextBox();
                    Mytextbox.Text = "Text here";
                    myNewForm.Controls.Add(Mytextbox);
                    ControlExtension.Draggable(Mytextbox, true);
                }

                
                else if (widget_typ == "Checkbox")
                {
                    CheckBox Mycheckbox = new CheckBox();
                    Mycheckbox.Text = "Married";
                    myNewForm.Controls.Add(Mycheckbox);
                    ControlExtension.Draggable(Mycheckbox, true);
                }

                else if (widget_typ == "Progressbar")
                {
                    ProgressBar myProgressBar = new ProgressBar();
                    myProgressBar.Text = "Progress";
                    myNewForm.Controls.Add(myProgressBar);
                    ControlExtension.Draggable(myProgressBar, true);
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            Bens_Knopf_Test("Checkbox");

        }

    }
}