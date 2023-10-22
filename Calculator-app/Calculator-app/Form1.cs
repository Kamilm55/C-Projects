using System.Diagnostics;
using System.Windows.Forms;

namespace Calculator_app
{
    public partial class Form1 : Form
    {
        private String currentOperation = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "7";
        }

        private void button3_Click(object sender, EventArgs e)
        {

            richTextBox1.Text += "1";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "0";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "2";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "4";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "5";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "6";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "8";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "9";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += ".";
        }


        //Operations
        //Addition +
        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "+";
        }
        //Subtraction -
        private void button16_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "-";
        }
        //Multiplication
        private void button15_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "*";
        }
        //Division
        private void button14_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "/";
        }

        // DELETE ALL EXPRESSION "C"
        private void button17_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
        //End of the operation "="
        private void button12_Click(object sender, EventArgs e)
        {
            //input , text of the richbox
            //expression = 15+2-4*12+56.5-14*12.87/2.85+78-9*15
            string expression = richTextBox1.Text;
            try
            {
                double result = ExpressionEvaluator.Evaluate(expression);
                richTextBox1.Text = "";
                richTextBox1.Text += result;
                Debug.WriteLine("Result: " + result);
            }
            catch (ArgumentException ex)
            {
                Debug.WriteLine("Invalid expression: " + ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
        }

        
    }
}