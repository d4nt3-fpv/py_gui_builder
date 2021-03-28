using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
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

        public void generate_gui()
        {


            saveFileDialog1.FileName = "python-GUI";
            saveFileDialog1.Title = "SAVE PYTHON GUI";
            saveFileDialog1.Filter = "Python files|*.py";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.ShowDialog();
            string location = saveFileDialog1.FileName;
            Console.WriteLine(location);

            var height_window = myNewForm.Height;
            var width_window = myNewForm.Width;
            var geometry_string = "window.geometry('" + width_window + "x" + height_window + "+10" + "+20" + "')";
            

            File.WriteAllText(location, "from tkinter import *");
            File.AppendAllText(location, "\n");
            File.AppendAllText(location, "from tkinter.ttk import *");
            File.AppendAllText(location, "\n");
            File.AppendAllText(location, "window=Tk()");
            File.AppendAllText(location, "\n");
            File.AppendAllText(location, "window.title('Python GUI')");
            File.AppendAllText(location, "\n");
            File.AppendAllText(location, geometry_string);
            File.AppendAllText(location, "\n");
            File.AppendAllText(location, "\n");


            for (int j = 0; j < list_of_all_buttons.Count; j++)
            {
                if (j == 0)
                {
                    File.AppendAllText(location, "########### Buttons ###########");
                    File.AppendAllText(location, "\n");
                }
                
                var akt_btn = list_of_all_buttons[j];
                var btn_loc_x = myNewForm.Controls.Find(akt_btn, true)[0].Location.X;
                var btn_loc_y = myNewForm.Controls.Find(akt_btn, true)[0].Location.Y;
                var tkinter_button_string = akt_btn + " = Button(window, text='" + akt_btn + "').place(x=" + btn_loc_x + "," + "y=" + btn_loc_y + ")";
                File.AppendAllText(location, tkinter_button_string);
                File.AppendAllText(location, "\n");
                Console.WriteLine(tkinter_button_string);

                if (j == list_of_all_buttons.Count - 1)
                {
                    File.AppendAllText(location, "\n");
                }

            }

            for (int j = 0; j < list_of_all_labels.Count; j++)
            {
                if (j == 0)
                {
                    File.AppendAllText(location, "########### Labels ###########");
                    File.AppendAllText(location, "\n");
                }

                var akt_lbl = list_of_all_labels[j];
                var lbl_loc_x = myNewForm.Controls.Find(akt_lbl, true)[0].Location.X;
                var lbl_loc_y = myNewForm.Controls.Find(akt_lbl, true)[0].Location.Y;
                var tkinter_label_string = akt_lbl + " = Label(window, text='" + akt_lbl + "').place(x=" + lbl_loc_x + "," + "y=" + lbl_loc_y + ")";
                File.AppendAllText(location, tkinter_label_string);
                File.AppendAllText(location, "\n");
                Console.WriteLine(tkinter_label_string);

                if (j == list_of_all_labels.Count - 1)
                {
                    File.AppendAllText(location, "\n");
                }

            }

            for (int j = 0; j < list_of_all_checkboxes.Count; j++)
            {

                if (j == 0)
                {
                    File.AppendAllText(location, "########### Checkboxes ###########");
                    File.AppendAllText(location, "\n");
                }

                var aktcheckbox = list_of_all_checkboxes[j];
                var chbox_loc_x = myNewForm.Controls.Find(aktcheckbox, true)[0].Location.X;
                var chbox_loc_y = myNewForm.Controls.Find(aktcheckbox, true)[0].Location.Y;
                var tkinter_chbox_string = aktcheckbox + " = Checkbutton(window, text='" + aktcheckbox + "').place(x=" + chbox_loc_x + "," + "y=" + chbox_loc_y + ")";
                File.AppendAllText(location, tkinter_chbox_string);
                File.AppendAllText(location, "\n");
                Console.WriteLine(tkinter_chbox_string);

                if (j == list_of_all_checkboxes.Count - 1)
                {
                    File.AppendAllText(location, "\n");
                }

            }

            for (int j = 0; j < list_of_all_entrys.Count; j++)
            {
                if (j == 0)
                {
                    File.AppendAllText(location, "########### Entrys ###########");
                    File.AppendAllText(location, "\n");
                }

                var aktentry = list_of_all_entrys[j];
                var entry_loc_x = myNewForm.Controls.Find(aktentry, true)[0].Location.X;
                var entry_loc_y = myNewForm.Controls.Find(aktentry, true)[0].Location.Y;
                var tkinter_entry_string = aktentry + " = Entry(window, text='" + aktentry + "').place(x=" + entry_loc_x + "," + "y=" + entry_loc_y + ")";
                File.AppendAllText(location, tkinter_entry_string);
                File.AppendAllText(location, "\n");
                Console.WriteLine(tkinter_entry_string);

                if (j == list_of_all_entrys.Count - 1)
                {
                    File.AppendAllText(location, "\n");
                }

            }

            for (int j = 0; j < list_of_all_prgsbars.Count; j++)
            {

                if (j == 0)
                {
                    File.AppendAllText(location, "########### Progressbars ###########");
                    File.AppendAllText(location, "\n");
                }

                var aktprgsbar = list_of_all_prgsbars[j];
                var prgsbar_loc_x = myNewForm.Controls.Find(aktprgsbar, true)[0].Location.X;
                var prgsbar_loc_y = myNewForm.Controls.Find(aktprgsbar, true)[0].Location.Y;
                var tkinter_prgsbar_string = aktprgsbar + " = Progressbar(window, length = 100, orient = HORIZONTAL).place(x=" + prgsbar_loc_x + "," + "y=" + prgsbar_loc_y + ")";
                File.AppendAllText(location, tkinter_prgsbar_string);
                File.AppendAllText(location, "\n");
                Console.WriteLine(tkinter_prgsbar_string);

                if (j == list_of_all_prgsbars.Count - 1)
                {
                    File.AppendAllText(location, "\n");
                }

            }


            for (int j = 0; j < list_of_all_radiobtns.Count; j++)
            {

                if (j == 0)
                {
                    File.AppendAllText(location, "########### Radiobuttons ###########");
                    File.AppendAllText(location, "\n");
                }

                var aktradbtn = list_of_all_radiobtns[j];
                var radbtn_loc_x = myNewForm.Controls.Find(aktradbtn, true)[0].Location.X;
                var radbtn_loc_y = myNewForm.Controls.Find(aktradbtn, true)[0].Location.Y;
                var tkinter_radbtn_string = aktradbtn + " = Radiobutton(window, text='" + aktradbtn + "').place(x=" + radbtn_loc_x + "," + "y=" + radbtn_loc_y + ")";
                File.AppendAllText(location, tkinter_radbtn_string);
                File.AppendAllText(location, "\n");
                Console.WriteLine(tkinter_radbtn_string);

                if (j == list_of_all_radiobtns.Count - 1)
                {
                    File.AppendAllText(location, "\n");
                }
                
            }


            File.AppendAllText(location, "window.mainloop()");

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

        private void button1_Click(object sender, EventArgs e)
        {
            generate_gui();
        }
    }
}
