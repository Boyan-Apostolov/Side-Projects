using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikoveICravi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int numbersCount = 3;
        private int number = 0;
        private int currentRevieledNums = 0;
        private int tries = 0;
        Random r = new Random();

        //Number Generation
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) numbersCount = 3;
            if (radioButton2.Checked) numbersCount = 4;
            if (radioButton3.Checked) numbersCount = 5;
            if (radioButton4.Checked) numbersCount = 6;

            List<int> numbers = new List<int>();

            currentRevieledNums = 0;
            tries = 0;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            textBox1.Enabled = true;

            //Generate A Random Valid Number
            int i = 1;
            while (i <= numbersCount)
            {
                if (i == numbers.Count)
                {
                    break;
                }
                int MyNumber = r.Next(1, 9);

                if (!numbers.Contains(MyNumber))
                {
                    numbers.Add(MyNumber);
                    i++;
                }
            }


            string numberStringed = string.Join(string.Empty, numbers);

            number = int.Parse(numberStringed);

            listBox1.Items.Add($"Намислих си число с {numbersCount} цифри");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //Validating input
        private void button4_Click(object sender, EventArgs e)
        {
            string stringFromTextbox1 = textBox1.Text;
            List<int> insertedNumber = new List<int>();

            //Validate Input:

            foreach (char symbol in stringFromTextbox1)
            {
                if (!char.IsDigit(symbol))
                {
                    listBox1.Items.Add("Програмата работи само с цифри:)");
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                    return;
                }
                int currNum = 0;
                if (!int.TryParse(symbol.ToString(), out currNum))
                {
                    listBox1.Items.Add("Програмата работи само с цифри:)");
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                }

                
                if (!insertedNumber.Contains(currNum))
                {
                    insertedNumber.Add(currNum);
                }
                else
                {
                    listBox1.Items.Add("Моля добавяйте само различни цифри:)");
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                    return;
                }
            }

            if (insertedNumber.Count != number.ToString().Length)
            {
                listBox1.Items.Add("Моля не добавяйте повече/по-малко цифри:)");
                listBox1.TopIndex = listBox1.Items.Count - 1;
                return;
            }
            //
            tries++;
            int numberFromTextBox = 0;

            if (!int.TryParse(textBox1.Text, out numberFromTextBox))
            {
                listBox1.Items.Add("Програмата работи само с цифри:)");
                listBox1.TopIndex = listBox1.Items.Count - 1;
                return;
            }
            else
            {
                numberFromTextBox = int.Parse(string.Join(String.Empty,insertedNumber));
            }

            List<int> myNumbertoString = new List<int>();
            string temp = number.ToString();

            foreach (char ch in temp)
            {
                myNumbertoString.Add(int.Parse(ch.ToString()));
            }

            //Winning Logic
            if (numberFromTextBox == number)
            {
                listBox1.Items.Add($"Браво! Ти спечели!, Числото беше {number}");
                listBox1.Items.Add($"Справи се с {tries} опита");
                listBox1.Items.Add($"Пробвай се пак, но се помъчи да го познаеш по-бързо");
                listBox1.TopIndex = listBox1.Items.Count - 1;

                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                textBox1.Enabled = false;
            }//Bikove And Kravi Logic
            else
            {
                int bikove = 0;
                int kravi = 0;

                for (int i = 0; i < numbersCount; i++)
                {
                    if (insertedNumber[i] == myNumbertoString[i])
                    {
                        bikove++;
                    }
                    else
                    {
                        kravi++;
                    }
                }

                listBox1.Items.Add($"{bikove} бик/а ,{kravi} крава/и");
                listBox1.TopIndex = listBox1.Items.Count - 1;
            }
        }

        //Reveal Some Numbers
        private void button3_Click(object sender, EventArgs e)
        {
            currentRevieledNums++;
            string myNumberToStr = number.ToString();
            tries++;
            if (numbersCount == 3)
            {
                switch (currentRevieledNums)
                {
                    case 1:
                        listBox1.Items.Add($"{myNumberToStr[0]}**");
                        break;
                    case 2:
                        listBox1.Items.Add($"{myNumberToStr[0]}{myNumberToStr[1]}*");
                        break;
                    default: currentRevieledNums--;
                        tries--;
                        break;
                }
            }
            else if (numbersCount == 4)
            {
                switch (currentRevieledNums)
                {
                    case 1:
                        listBox1.Items.Add($"{myNumberToStr[0]}***");
                        break;
                    case 2:
                        listBox1.Items.Add($"{myNumberToStr[0]}{myNumberToStr[1]}**");
                        break;
                    case 3:
                        listBox1.Items.Add($"{myNumberToStr[0]}{myNumberToStr[1]}{myNumberToStr[2]}*");
                        break;
                    default:
                        currentRevieledNums--;
                        tries--;
                        break;
                }
            }
            else if (numbersCount == 5)
            {
                switch (currentRevieledNums)
                {
                    case 1:
                        listBox1.Items.Add($"{myNumberToStr[0]}****");
                        break;
                    case 2:
                        listBox1.Items.Add($"{myNumberToStr[0]}{myNumberToStr[1]}***");
                        break;
                    case 3:
                        listBox1.Items.Add($"{myNumberToStr[0]}{myNumberToStr[1]}{myNumberToStr[2]}**");
                        break;
                    case 4:
                        listBox1.Items.Add($"{myNumberToStr[0]}{myNumberToStr[1]}{myNumberToStr[2]}{myNumberToStr[3]}*");
                        break;
                    default:
                        currentRevieledNums--;
                        tries--;
                        break;
                }
            }
            else
            {
                switch (currentRevieledNums)
                {
                    case 1:
                        listBox1.Items.Add($"{myNumberToStr[0]}*****");
                        break;
                    case 2:
                        listBox1.Items.Add($"{myNumberToStr[0]}{myNumberToStr[1]}****");
                        break;
                    case 3:
                        listBox1.Items.Add($"{myNumberToStr[0]}{myNumberToStr[1]}{myNumberToStr[2]}***");
                        break;
                    case 4:
                        listBox1.Items.Add($"{myNumberToStr[0]}{myNumberToStr[1]}{myNumberToStr[2]}{myNumberToStr[3]}**");
                        break;
                    case 5:
                        listBox1.Items.Add($"{myNumberToStr[0]}{myNumberToStr[1]}{myNumberToStr[2]}{myNumberToStr[3]}{myNumberToStr[4]}*");
                        break;
                    default:
                        currentRevieledNums--;
                        tries--;
                        break;
                }
            }
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add($"Жалко, числото беше {number}");
            listBox1.TopIndex = listBox1.Items.Count - 1;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            textBox1.Enabled = false;
        }
    }
}
