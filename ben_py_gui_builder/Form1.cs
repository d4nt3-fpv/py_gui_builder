using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        public settings_window form3 = new settings_window();
        public void Bens_main_function(string widget_typ = "Button")
        {

            if (i == 0)     // The first time, this method is running
            {
                myNewForm.Show();
                // form3.Show();                    For the settings window!!!
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
                    anz_prgsbar = anz_prgsbar + 1;
                }


                for (int j = 0; j < list_of_all_ui_elements.Count; j++)
                {
                    var akt_ch_box = myNewForm.Controls.Find(list_of_all_ui_elements[j], true)[0];

                    akt_ch_box.Click += new EventHandler(dynamic_control_click);

                }



            }
        }

        public static bool runonce = true; // bool zum überprüfen, ob die Funktion schonmal gestartet wurde.
        public static Control lastcontrol; // Die checkbox variable für die letzte checkbox
        public static Control selected_control; // The var for the selected control
        
        
        JArray button_array = new JArray(); // the array for the different buttons, labels, etc.
        JArray label_array = new JArray(); // the array for the different buttons, labels, etc.
        JArray radio_array = new JArray(); // the array for the different buttons, labels, etc.
        JArray entry_array = new JArray(); // the array for the different buttons, labels, etc.
        JArray checkbox_array = new JArray(); // the array for the different buttons, labels, etc.
        JArray progressbar_array = new JArray(); // the array for the different buttons, labels, etc.



        protected void dynamic_control_click(object sender, EventArgs e)
        {

            Control clicked_control = sender as Control; // sender gibt zurück, welches control/objekt das event ausgelöst hat.
            // clicked_control.BackColor = Color.Aqua; // Das Control, das ausgelöst hat rot färben, use ForceColor for text highlighting
            clicked_control.ForeColor = Color.DarkViolet;
            Console.WriteLine("Click"); // In Konsole Printen, dass geklickt wurde
            selected_control = clicked_control; // The public variable selected contol to the clicked_control
            if (!runonce) // Wenn die Funktion noch nicht ausgeführt wurde...
            {
                if (lastcontrol != clicked_control) // normalerweise wird die letzte checkbox auf schwarz gefärbt, doch was, wenn es die selbe ist...
                {
                    // lastcontrol.BackColor = Color.Transparent; // wenn es nicht die selbe ist, wird die box schwarz gefärbt.
                    lastcontrol.ForeColor = Color.Black;
                }

            }

            Console.WriteLine(clicked_control.Name);

            // TODO: If you click delete it will delete the selected control and not the clicked control...
            
            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add("Delete", new EventHandler(delete_click)); 
            cm.MenuItems.Add("Item 2");
            
            clicked_control.ContextMenu = cm;
            
            
            
            lastcontrol = clicked_control;    // die letzte checkbox auf die aktuelle setzen...
            runonce = false; // wenn die funktion einmal durchlaufen ist, muss die runonce bool auf false gesetzt werden

        }





        public void generate_json()
        {
            Console.WriteLine("Generate json");

            saveFileDialog2.FileName = "guifile";
            saveFileDialog2.Title = "SAVE GUI AS JSON FILE";
            saveFileDialog2.Filter = "GUI files|*.json";
            saveFileDialog2.AddExtension = true;
            saveFileDialog2.ShowDialog();
            string json_location = saveFileDialog2.FileName;
            Console.WriteLine(json_location);

            JObject json_god_object = new JObject(); // This is the main object, the god object

            JObject settings_object = new JObject(); // Object for the settings 


            var json_height_window = myNewForm.Height - 39; // the 39 and 16 for the right export size with tkinter
            var json_width_window = myNewForm.Width - 16;

            settings_object.Add("Window_height", json_height_window);
            settings_object.Add("Window_width", json_width_window);
            settings_object.Add("Window_title", "title");
            settings_object.Add("Window_sizable", true);
            settings_object.Add("Window_bgcolor", null);

            for (int j = 0; j < list_of_all_buttons.Count; j++)
            {
                JObject button_objects = new JObject(); // Object for the buttons 

                var akt_btn = list_of_all_buttons[j];
                var btn_loc_x = myNewForm.Controls.Find(akt_btn, true)[0].Location.X;
                var btn_loc_y = myNewForm.Controls.Find(akt_btn, true)[0].Location.Y;

                 button_objects.Add("Name", akt_btn);
                 button_objects.Add("Color", null);
                 button_objects.Add("Width", null);
                 button_objects.Add("Height", null);
                 button_objects.Add("location_x", btn_loc_x);
                 button_objects.Add("location_y", btn_loc_y);

                 button_array.Add(button_objects);
            }

            for (int j = 0; j < list_of_all_labels.Count; j++)
            {

                JObject label_objects = new JObject(); // Object for the buttons 

                var akt_lbl = list_of_all_labels[j];
                var lbl_loc_x = myNewForm.Controls.Find(akt_lbl, true)[0].Location.X;
                var lbl_loc_y = myNewForm.Controls.Find(akt_lbl, true)[0].Location.Y;

                label_objects.Add("Name", akt_lbl);
                label_objects.Add("Color", null);
                label_objects.Add("Width", null);
                label_objects.Add("Height", null);
                label_objects.Add("location_x", lbl_loc_x);
                label_objects.Add("location_y", lbl_loc_y);
                label_array.Add(label_objects);

            }

            for (int j = 0; j < list_of_all_checkboxes.Count; j++)
            {
                JObject checkbox_objects = new JObject(); // Object for the buttons 

                var aktcheckbox = list_of_all_checkboxes[j];
                var chbox_loc_x = myNewForm.Controls.Find(aktcheckbox, true)[0].Location.X;
                var chbox_loc_y = myNewForm.Controls.Find(aktcheckbox, true)[0].Location.Y;

                checkbox_objects.Add("Name", aktcheckbox);
                checkbox_objects.Add("Color", null);
                checkbox_objects.Add("Width", null);
                checkbox_objects.Add("Height", null);
                checkbox_objects.Add("location_x", chbox_loc_x);
                checkbox_objects.Add("location_y", chbox_loc_y);

                checkbox_array.Add(checkbox_objects);
            }
            
            for (int j = 0; j < list_of_all_entrys.Count; j++)
            {
                JObject entry_objects = new JObject(); // Object for the entrys 

                var aktentry = list_of_all_entrys[j];
                var entry_loc_x = myNewForm.Controls.Find(aktentry, true)[0].Location.X;
                var entry_loc_y = myNewForm.Controls.Find(aktentry, true)[0].Location.Y;

                entry_objects.Add("Name", aktentry);
                entry_objects.Add("Color", null);
                entry_objects.Add("Width", null);
                entry_objects.Add("Height", null);
                entry_objects.Add("location_x", entry_loc_x);
                entry_objects.Add("location_y", entry_loc_y);

                entry_array.Add(entry_objects);
            }

            for (int j = 0; j < list_of_all_prgsbars.Count; j++)
            {

                JObject prgsbar_objects = new JObject(); // Object for the entrys 
                
                var aktprgsbar = list_of_all_prgsbars[j];
                var prgsbar_loc_x = myNewForm.Controls.Find(aktprgsbar, true)[0].Location.X;
                var prgsbar_loc_y = myNewForm.Controls.Find(aktprgsbar, true)[0].Location.Y;

                prgsbar_objects.Add("Name", aktprgsbar);
                prgsbar_objects.Add("Color", null);
                prgsbar_objects.Add("Width", null);
                prgsbar_objects.Add("Height", null);
                prgsbar_objects.Add("location_x", prgsbar_loc_x);
                prgsbar_objects.Add("location_y", prgsbar_loc_y);
                progressbar_array.Add(prgsbar_objects);

            }
            for (int j = 0; j < list_of_all_radiobtns.Count; j++)
            {
                JObject radiobtn_objects = new JObject(); // Object for the entrys 

                var aktradbtn = list_of_all_radiobtns[j];
                var radbtn_loc_x = myNewForm.Controls.Find(aktradbtn, true)[0].Location.X;
                var radbtn_loc_y = myNewForm.Controls.Find(aktradbtn, true)[0].Location.Y;

                radiobtn_objects.Add("Name", aktradbtn);
                radiobtn_objects.Add("Color", null);
                radiobtn_objects.Add("Width", null);
                radiobtn_objects.Add("Height", null);
                radiobtn_objects.Add("location_x", radbtn_loc_x);
                radiobtn_objects.Add("location_y", radbtn_loc_y);
                radio_array.Add(radiobtn_objects);
            }



            json_god_object["Settings"] = settings_object;
            json_god_object["Buttons"] = button_array;
            json_god_object["Labels"] = label_array;
            json_god_object["Checkboxes"] = checkbox_array;
            json_god_object["Entrys"] = entry_array;
            json_god_object["Progressbars"] = progressbar_array;
            json_god_object["Radiobuttons"] = radio_array;

            string json = json_god_object.ToString(); // show the main object
            Console.WriteLine(json);
            File.WriteAllText(json_location, json);


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

            var height_window = myNewForm.Height - 39; // the 39 and 16 for the right export size with tkinter
            var width_window = myNewForm.Width - 16;
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


        public void open_json()
        {
            Console.WriteLine("open json");

            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "GUI files|*.json";
            openFileDialog1.AddExtension = true;
            openFileDialog1.ShowDialog();
            string open_json_location = openFileDialog1.FileName;
            Console.WriteLine(open_json_location);
            string opend_json_file_string = File.ReadAllText(open_json_location, Encoding.UTF8);
            // Console.WriteLine(opend_json_file_string);


            dynamic dynamic_json = Newtonsoft.Json.JsonConvert.DeserializeObject(opend_json_file_string);

            
            // Setting up the window settings

            var json_loaded_height_window = dynamic_json.Settings.Window_height + 39;
            var json_loaded_width_window = dynamic_json.Settings.Window_width + 16;

            myNewForm.Width = json_loaded_width_window.ToObject<int>();
            myNewForm.Height = json_loaded_height_window.ToObject<int>();


            foreach (var item in dynamic_json.Buttons)
            {
                Button MyButton = new Button();
                MyButton.Text = "Button";
                MyButton.Name = item.Name;
                MyButton.Location = new Point(item.location_x.ToObject<int>(), item.location_y.ToObject<int>());
                myNewForm.Controls.Add(MyButton);
                ControlExtension.Draggable(MyButton, true);
                list_of_all_buttons.Add(MyButton.Name);
                list_of_all_ui_elements.Add(MyButton.Name);
                anz_btn = anz_btn + 1;
            }
            
            
            // TODO Do that with all the other ui elements...
            
            
            

            for (int j = 0; j < list_of_all_ui_elements.Count; j++)
            {
                var akt_ch_box = myNewForm.Controls.Find(list_of_all_ui_elements[j], true)[0];

                akt_ch_box.Click += new EventHandler(dynamic_control_click);

            }



        }


        public void ask_for_save() // TODO: this is the window for asking if you wanna save. but it dosnt work haha. I neet to track if the form is closed or not.
        {
                DialogResult dialog = new DialogResult();

                dialog = MessageBox.Show("Do you want to save before closing?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    generate_json();
                    Application.ExitThread();
                }

                else if (dialog == DialogResult.No)
                {
                    //Application.Exit();
                    Application.ExitThread();
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

        private void button1_Click(object sender, EventArgs e)
        {
            generate_gui();
        }

        private void gen_json_btn_Click(object sender, EventArgs e)
        {
            generate_json();
        }

        private void open_json_btn_Click(object sender, EventArgs e)
        {
            open_json();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ask_for_save();

            e.Cancel = true;

        }


        // --------------------


        public void delete_click(object sender, EventArgs e)
        {
            Console.WriteLine("Test");
        }

    }


}
    

