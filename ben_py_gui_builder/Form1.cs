using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ben_py_gui_builder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Bens_main_function();
        }

        public int anz_btn = 0;
        public int anz_lbl = 0;
        public int anz_radbtn = 0;
        public int anz_entry = 0;
        public int anz_checkbox = 0;
        public int anz_prgsbar = 0;

        public List<string> list_of_all_ui_elements = new List<string>();
        public List<string> list_of_all_buttons = new List<string>();
        public List<string> list_of_all_labels = new List<string>();
        public List<string> list_of_all_radiobtns = new List<string>();
        public List<string> list_of_all_entrys = new List<string>();
        public List<string> list_of_all_checkboxes = new List<string>();
        public List<string> list_of_all_prgsbars = new List<string>();

        public int i = 0;
        public Form2 myNewForm = new Form2();
        public void Bens_main_function(string widget_typ = "Button")
        {

            if (i == 0)     // The first time, this method is running
            {
                myNewForm.Show();
                i++;    // WICHTIG!!!

            }
            else // Runs every time, when the method is called
            {
                if (widget_typ == "Button")
                {
                    var btn_name = "Button_" + anz_btn.ToString();
                    Button MyButton = new Button();
                    MyButton.Text = "Button";
                    MyButton.Name = btn_name;
                    myNewForm.Controls.Add(MyButton);
                    ControlExtension.Draggable(MyButton, true);
                    list_of_all_buttons.Add(MyButton.Name);
                    list_of_all_ui_elements.Add(MyButton.Name);
                    anz_btn = anz_btn + 1;
                }
                else if (widget_typ == "Label")
                {
                    var lbl_name = "Label_" + anz_lbl.ToString();
                    Label mylab = new Label();
                    mylab.Text = "Label";
                    mylab.Name = lbl_name;
                    myNewForm.Controls.Add(mylab);
                    ControlExtension.Draggable(mylab, true);
                    list_of_all_labels.Add(mylab.Name);
                    list_of_all_ui_elements.Add(mylab.Name);
                    anz_lbl = anz_lbl + 1;

                }

                else if (widget_typ == "Radiobutton")
                {
                    var radbtn_name = "Radiobtn_" + anz_radbtn.ToString();
                    RadioButton r1 = new RadioButton();
                    r1.Text = "Radiobutton";
                    r1.Name = radbtn_name;
                    myNewForm.Controls.Add(r1);
                    ControlExtension.Draggable(r1, true);
                    list_of_all_radiobtns.Add(r1.Name);
                    list_of_all_ui_elements.Add(r1.Name);
                    anz_radbtn = anz_radbtn + 1;
                }

                else if (widget_typ == "Entry")
                {
                    var entry_name = "Entry_" + anz_entry.ToString();
                    TextBox Mytextbox = new TextBox();
                    Mytextbox.Text = "Entry";
                    Mytextbox.Name = entry_name;
                    myNewForm.Controls.Add(Mytextbox);
                    ControlExtension.Draggable(Mytextbox, true);
                    list_of_all_entrys.Add(Mytextbox.Name);
                    list_of_all_ui_elements.Add(Mytextbox.Name);
                    anz_entry = anz_entry + 1;
                }


                else if (widget_typ == "Checkbox")
                {
                    var checkbox_name = "Checkbox_" + anz_checkbox.ToString();
                    CheckBox Mycheckbox = new CheckBox();
                    Mycheckbox.Text = "Checkbox";
                    Mycheckbox.Name = checkbox_name;
                    myNewForm.Controls.Add(Mycheckbox);
                    ControlExtension.Draggable(Mycheckbox, true);
                    list_of_all_checkboxes.Add(Mycheckbox.Name);
                    list_of_all_ui_elements.Add(Mycheckbox.Name);
                    anz_checkbox = anz_checkbox + 1;

                }

                else if (widget_typ == "Progressbar")
                {
                    var progressbarname = "Progressbar_" + anz_prgsbar.ToString();
                    ProgressBar myProgressBar = new ProgressBar();
                    myProgressBar.Text = "Progressbar";
                    myProgressBar.Name = progressbarname;
                    myNewForm.Controls.Add(myProgressBar);
                    ControlExtension.Draggable(myProgressBar, true);
                    list_of_all_prgsbars.Add(myProgressBar.Name);
                    list_of_all_prgsbars.Add(myProgressBar.Name);
                    anz_prgsbar = anz_prgsbar + 1;
                }
            }
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            // Bens_main_function("Checkbox");
        }

        private void entry_btn_Click(object sender, EventArgs e)
        {
            Bens_main_function("Entry");
        }

        private void btn_btn_Click(object sender, EventArgs e)
        {
            Bens_main_function("Button");
        }

        private void lbl_btn_Click(object sender, EventArgs e)
        {
            Bens_main_function("Label");
        }

        private void radio_btn_Click(object sender, EventArgs e)
        {
            Bens_main_function("Radiobutton");
        }

        private void checkbox_btn_Click(object sender, EventArgs e)
        {
            Bens_main_function("Checkbox");
        }

        private void progressbar_btn_Click(object sender, EventArgs e)
        {
            Bens_main_function("Progressbar");
        }
    }
}
