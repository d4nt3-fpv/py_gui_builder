namespace ben_py_gui_builder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_btn = new System.Windows.Forms.Button();
            this.lbl_btn = new System.Windows.Forms.Button();
            this.radio_btn = new System.Windows.Forms.Button();
            this.entry_btn = new System.Windows.Forms.Button();
            this.checkbox_btn = new System.Windows.Forms.Button();
            this.progressbar_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_btn
            // 
            this.btn_btn.Location = new System.Drawing.Point(12, 41);
            this.btn_btn.Name = "btn_btn";
            this.btn_btn.Size = new System.Drawing.Size(75, 23);
            this.btn_btn.TabIndex = 0;
            this.btn_btn.Text = "Button";
            this.btn_btn.UseVisualStyleBackColor = true;
            this.btn_btn.Click += new System.EventHandler(this.btn_btn_Click);
            // 
            // lbl_btn
            // 
            this.lbl_btn.Location = new System.Drawing.Point(12, 70);
            this.lbl_btn.Name = "lbl_btn";
            this.lbl_btn.Size = new System.Drawing.Size(75, 23);
            this.lbl_btn.TabIndex = 1;
            this.lbl_btn.Text = "Label";
            this.lbl_btn.UseVisualStyleBackColor = true;
            this.lbl_btn.Click += new System.EventHandler(this.lbl_btn_Click);
            // 
            // radio_btn
            // 
            this.radio_btn.Location = new System.Drawing.Point(12, 99);
            this.radio_btn.Name = "radio_btn";
            this.radio_btn.Size = new System.Drawing.Size(75, 23);
            this.radio_btn.TabIndex = 2;
            this.radio_btn.Text = "Radio Button";
            this.radio_btn.UseVisualStyleBackColor = true;
            this.radio_btn.Click += new System.EventHandler(this.radio_btn_Click);
            // 
            // entry_btn
            // 
            this.entry_btn.Location = new System.Drawing.Point(13, 128);
            this.entry_btn.Name = "entry_btn";
            this.entry_btn.Size = new System.Drawing.Size(75, 23);
            this.entry_btn.TabIndex = 4;
            this.entry_btn.Text = "Entry";
            this.entry_btn.UseVisualStyleBackColor = true;
            this.entry_btn.Click += new System.EventHandler(this.entry_btn_Click);
            // 
            // checkbox_btn
            // 
            this.checkbox_btn.Location = new System.Drawing.Point(13, 157);
            this.checkbox_btn.Name = "checkbox_btn";
            this.checkbox_btn.Size = new System.Drawing.Size(75, 23);
            this.checkbox_btn.TabIndex = 5;
            this.checkbox_btn.Text = "Checkbox";
            this.checkbox_btn.UseVisualStyleBackColor = true;
            this.checkbox_btn.Click += new System.EventHandler(this.checkbox_btn_Click);
            // 
            // progressbar_btn
            // 
            this.progressbar_btn.Location = new System.Drawing.Point(12, 186);
            this.progressbar_btn.Name = "progressbar_btn";
            this.progressbar_btn.Size = new System.Drawing.Size(75, 23);
            this.progressbar_btn.TabIndex = 6;
            this.progressbar_btn.Text = "Progressbar";
            this.progressbar_btn.UseVisualStyleBackColor = true;
            this.progressbar_btn.Click += new System.EventHandler(this.progressbar_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(120, 646);
            this.Controls.Add(this.progressbar_btn);
            this.Controls.Add(this.checkbox_btn);
            this.Controls.Add(this.entry_btn);
            this.Controls.Add(this.radio_btn);
            this.Controls.Add(this.lbl_btn);
            this.Controls.Add(this.btn_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_btn;
        private System.Windows.Forms.Button lbl_btn;
        private System.Windows.Forms.Button radio_btn;
        private System.Windows.Forms.Button entry_btn;
        private System.Windows.Forms.Button checkbox_btn;
        private System.Windows.Forms.Button progressbar_btn;
    }
}