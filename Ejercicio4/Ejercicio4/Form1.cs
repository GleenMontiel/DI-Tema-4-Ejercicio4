using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio4
{
    public delegate double Operation(double a, double b);
    public partial class Form1 : Form
    {
        Hashtable operaciones = new Hashtable();
        Operation op;

        public Form1()
        {
            InitializeComponent();
            operaciones.Add(radioButton1.Text, new Operation((a, b) => { return a + b; }));
            operaciones.Add(radioButton2.Text, new Operation((a, b) => { return a - b; }));
            operaciones.Add(radioButton3.Text, new Operation((a, b) => { return a * b; }));
            operaciones.Add(radioButton4.Text, new Operation((a, b) => { return a / b; }));
            op = (Operation)operaciones[radioButton1.Text];
            label1.Text = radioButton1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a;
            double b;
 
            if (double.TryParse(textBox1.Text,out a) && double.TryParse(textBox2.Text, out b))
            {
              MessageBox.Show(op(a, b).ToString());
            }
           
        }

        private void seleccionarOperacion(object sender , EventArgs e)
        {
            op = (Operation)operaciones[((RadioButton)sender).Text];
            label1.Text = ((RadioButton)sender).Text;
        }
    }
}
