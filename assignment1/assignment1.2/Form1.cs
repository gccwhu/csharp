using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1: Form
    {
        TextBox txt1 = new TextBox();
        TextBox txt2 = new TextBox();
        ComboBox cmb = new ComboBox();
        Button btn = new Button();
        Label label = new Label();
        Label lbl = new Label();
        
        public Form1()
        {    
            InitializeComponent();
            txt1.Location = new Point(10, 10);
            txt1.Size = new Size(100, 30);
            txt1.Text = "";
            Controls.Add(txt1);

            txt2.Location = new Point(210, 10);
            txt2.Size = new Size(100, 30);
            txt2.Text = "";
            Controls.Add(txt2);

            cmb.Location = new Point(110, 10);
            cmb.Size = new Size(100, 30);
            cmb.Items.Add("+");
            cmb.Items.Add("-");
            cmb.Items.Add("*");
            cmb.Items.Add("/"); 
            cmb.SelectedIndex = 0;
            Controls.Add(cmb);

            btn.Location = new Point(110, 50);
            btn.Size = new Size(100, 30);
            btn.Text = "计算";
            btn.Click += new EventHandler(btn_Click);
            Controls.Add(btn);

            label.Location = new Point(310, 15);
            label.Size = new Size(10, 30);
            label.Text = "=";
            Controls.Add(label);

            lbl.Location = new Point(320, 15);
            lbl.Size = new Size(100, 30);
            lbl.Text = "";
            Controls.Add(lbl);
        }   

        public void btn_Click(object sender, EventArgs e)
        {
            string str1 = txt1.Text;
            string str2 = txt2.Text;    
            double num1 = Convert.ToDouble(str1);
            double num2 = Convert.ToDouble(str2);
            string op = cmb.Text;   
            switch(op)
            {
                case "+":
                    lbl.Text = (num1 + num2).ToString();
                    break;
                case "-":
                    lbl.Text = (num1 - num2).ToString();
                    break;
                case "*":
                    lbl.Text = (num1 * num2).ToString();
                    break;
                case "/":
                    lbl.Text = (num1 / num2).ToString();
                    break;
            }
        }
    }
}
