using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atomic_Decomposition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Periodic elements storage
        private List<string> periodicTable = new List<string>(){"(empty)","H","He","Li","Be","B","C","N","O","F","Ne","Na","Mg","Al","Si","P","S","Cl","Ar","K","Ca","Sc","Ti","V","Cr","Mn","Fe","Co","Ni","Cu","Zn","Ga","Ge","As","Se","Br","Kr","Rb","Sr","Y","Zr","Nb","Mo","Tc","Ru","Rh","Pd","Ag","Cd","In","Sn","Sb","Te","I","Xe","Ca","Ba","La","Ce","Pr","Nc","Pm","Sm","Eu","Gd","Tb","Dy","Ho","Er","Tm","Yb","Lu","Hf","Ta","W","Re","Os","Ir","Pt","Au","Hg","Tl","Pb","Bi","Po","At","Rn","Fr","Ra","Ac","Th","Pa","U","Np","Pu","Am","Cm","Bk","Cf","Es","Fm","Md","No","Lr" };


        private void button2_Click(object sender, EventArgs e) //Reset app method (Reset button)
        {
            label6.Visible = false;
            label9.Visible = false;
            label10.Visible = false;

            textBox1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();

            label5.Text ="A";
            label7.Text = "Z";
            label8.Text = "E";

            label11.Visible = false;
            label12.Text = "";
        }

        private void button1_Click(object sender, EventArgs e) //Calculate Button
        {
            if (!checkNumbers())
            { onError(); return; }

            calculate();
        }

        private void calculate() // Main App logic
        {
            var A = int.Parse(textBox1.Text);
            var Z = int.Parse(textBox2.Text);
            var element = textBox3.Text;
            var decompositionType = getDecompositionType();

            switch (decompositionType)
            {
                case 0: alphaDecomp(A, Z); break;
                case 1: betaDecomp(A, Z); break;
                case 2: gamaDecomp(A, Z); break;
                default: onError(); break;
            }
        }

        private void alphaDecomp(int A, int Z) //Calculating Alpha Decomposition
        {
            A -= 4;
            Z -= 2;
            var el = periodicTable[Z];

            setOutput(A, Z, el, "α");
        }

        private void betaDecomp(int A, int Z) //Calculating Beta Decomposition
        {
            Z += 1;
            var el = periodicTable[Z];
            
            setOutput(A, Z, el,"β");
        }

        private void gamaDecomp(int A, int Z) //Calculating Gama Decomposition
        {
            textBox3.Text += "*";

            var el = periodicTable[Z];

            setOutput(A, Z, el, "γ");
        }

        private void setOutput(int A, int Z, string El,string type) //Displaying results after the decomposition
        {
            label11.Visible = true;
            label12.Text = type;

            label5.Text = A.ToString();
            label7.Text = Z.ToString();
            label8.Text = El.ToString();
        }

        private int getDecompositionType() //Getting the radio buttons' values
        {
            if (radioButton1.Checked)
            {
                return 0; // 0 represents alpha
            }

            if (radioButton2.Checked)
            {
                return 1; // 1 represents beta
            }

            if (radioButton3.Checked)
            {
                return 2; // 2 represents gama
            }

            return 3; //Error : Decomposition type not selected
        }

        private void onError() //Visualising red text when incorrect data is recieved
        {
            label6.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
        }

        private bool checkNumbers() //Validating user input
        {
            var box1 = 0;
            var box2 = 0;
            var box3 = 0;
            int.TryParse(textBox1.Text, out box1);
            int.TryParse(textBox2.Text, out box2);
            int.TryParse(textBox3.Text, out box3);

            return box1 != 0 && box2 != 0 && box3 == 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
