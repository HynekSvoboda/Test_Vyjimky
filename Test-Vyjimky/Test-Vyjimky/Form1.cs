using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Vyjimky
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = textBox1.Lines.Count();
            int[] pole = new int[n];
            int pomocna = 0;
            int soucet = 0;
            for(int i=0;i<n;i++)
            {
                try
                {
                    int cislo = Convert.ToInt32(textBox1.Lines[i]);
                    if (cislo < 0)
                    {
                        pole[pomocna] = 0;
                        checked { soucet += cislo; }
                        pomocna++;
                    }
                }
                catch(FormatException) { }
                catch (OverflowException) { }
                catch (ArithmeticException) { }
            }
            try
            {
               checked
                {
                    double prumer = (double)soucet /(double)pomocna;
                    if(prumer<0) MessageBox.Show(prumer.ToString(),"Průměr celých záporných čísel ",MessageBoxButtons.OK);
                    else MessageBox.Show(prumer.ToString(), "Žádná záporná čísla nenalezena ", MessageBoxButtons.OK);
                }
            }
            catch (DivideByZeroException) { }
        }
    }
}
