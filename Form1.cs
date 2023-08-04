using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;

namespace Calculator
{


    public partial class Form1 : Form
    {
        bool isOn = false;
        public int i = 0;
        public Form1()
        {
			InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
			Text = "Calculator";
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (isOn)
            {
                Button button = (Button)sender;
                if (textBox.Text == "0")
                {
                    textBox.Text = textBox.Text.Remove(0, 1);
                }
                textBox.Text += button.Text;
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CLR_Click(object sender, EventArgs e)
        {
            if (isOn)
            {
                textBox.Text = "0";
            }
        }

        private void MemoryCLR_Click(object sender, EventArgs e)
        {
            if (isOn)
            {
                textBox1.Text = "";
            }
        }

        private void DEL_Click(object sender, EventArgs e)
        {
            if (isOn)
            {
                if (textBox.Text == "0")
                {
                }
                else if (textBox.Text.Length > 0)
                {
                    textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
                }
            }
        }

        private void On_Off_Toggle(object sender, EventArgs e)
        {
            isOn = !isOn;
            if (isOn == true)
            {
                textBox.Text = "0";
            }
            else
            {
                textBox.Text = "";
            }
            textBox1.Text = "";
        }

        private void Operation_Click(object sender, EventArgs e)
        {
            if (isOn)
            {
                Button button = (Button)sender;
                textBox.Text += button.Text;
            }
        }

        private void Equal_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox.Text.Replace("log(", "l");
            textBox.Text = textBox.Text.Replace("ln(", "n");
            textBox.Text = textBox.Text.Replace("sqrt(", "r");
            textBox.Text = textBox.Text.Replace("sin(", "s");
            textBox.Text = textBox.Text.Replace("cos(", "c");
            textBox.Text = textBox.Text.Replace("tan(", "t");
            textBox.Text = textBox.Text.Replace("π", "3.141592654");
            double result = Bodmas(textBox.Text);
            textBox.Text = result.ToString();
            textBox1.Text = result.ToString();
        }

        public double Bodmas(string expression)
        {
            string validOperators = "+-×÷^";
            string specialOperators = "nlrsct";
            Stack<double> numbers = new Stack<double>();
            Stack<char> operators = new Stack<char>();
            for (int i = 0; i < expression.Length; i++)
            {
				char ch = expression[i];

                if (ch == '(')
                {
                    operators.Push(ch);
                }
                else if (ch == ')')
                {
                    while (operators.Peek() != '(')
                    {
                        char op = operators.Pop();
                        double param2 = numbers.Pop();
                        double param1 = numbers.Pop();
                        double newValue = MathOperation(op, param1, param2);
                        numbers.Push(newValue);
                    }
                    operators.Pop();
                }
                else if (validOperators.Contains(ch))
                {
                    while (operators.Count > 0 && Priority(operators.Peek()) >= Priority(ch))
                    {
                        char op = operators.Pop();
                        double param2 = numbers.Pop();
                        double param1 = numbers.Pop();
                        double newValue = MathOperation(op, param1, param2);
                        numbers.Push(newValue);
                    }
                    operators.Push(ch);
                }
                else if (specialOperators.Contains(ch))
                {
                    char last_op = ch;
                    i++;
                    ch = expression[i];
                    string inner_expression = "";
                    while (ch != ')')
                    {
                        inner_expression += ch;
                        i++;
                        if (i == expression.Length)
                        {
                            break;
                        }
                        ch = expression[i];
                    }
                    double newValue = Bodmas(inner_expression);
                    newValue = MathOperation(last_op, 0, newValue);
                    numbers.Push(newValue);
                }
                else if (char.IsDigit(ch) || ch == '.')
                {
                    string number = "";
                    while (char.IsDigit(ch) || ch == '.')
                    {
                        number += ch;
                        i++;
                        if (i == expression.Length)
                        {
                            break;
                        }
                        ch = expression[i];
                    }
                    i--;
                    numbers.Push(double.Parse(number));
                }
            }

            while (operators.Count > 0)
            {
                var op = operators.Pop();
                var param2 = numbers.Pop();
                var param1 = numbers.Pop();
                var newValue = MathOperation(op, param1, param2);
                numbers.Push(newValue);
            }
            return numbers.Pop();
        }
        public double MathOperation(char operation, double l_operand, double r_operand)
        {
            switch (operation)
            {
                case '+': return l_operand + r_operand;
                case '-': return l_operand - r_operand;
                case '×': return l_operand * r_operand;
                case '÷': return l_operand / r_operand;
                case '^': return Math.Pow(l_operand, r_operand);
                case 'l': return Math.Log(r_operand, 10);
                case 'n': return Math.Log(r_operand); ;
                case 'r': return Math.Sqrt(r_operand); ;
                case 's': return Math.Sin(r_operand * Math.PI / 180);
                case 'c': return Math.Cos(r_operand * Math.PI / 180);
                case 't': return Math.Tan(r_operand * Math.PI / 180);
                default: return 0.0;
            }
        }
        static int Priority(char operation)
        {
            switch (operation)
            {
                case '+': return 1;
                case '-': return 1;
                case '×': return 2;
                case '÷': return 2;
                case '^': return 3;
                case 'l': return 4;
                case 'n': return 4;
                case 'r': return 4;
                case 's': return 4;
                case 'c': return 4;
                case 't': return 4;
                default: return 0;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isOn)
            {
                switch (e.KeyChar)
                {
					case '(':
						if (textBox.Text == "0")
						{
							textBox.Text = textBox.Text.Remove(0, 1);
						}
						textBox.Text += "(";
						break;
					case ')':
						if (textBox.Text == "0")
						{
							textBox.Text = textBox.Text.Remove(0, 1);
						}
						textBox.Text += ")";
						break;
					case '0':
						if (textBox.Text == "0")
						{
							textBox.Text = textBox.Text.Remove(0, 1);
						}
						textBox.Text += "0";
                        break;
					case '1':
						if (textBox.Text == "0")
						{
							textBox.Text = textBox.Text.Remove(0, 1);
						}
						textBox.Text += "1";
						break;
					case '2':
						if (textBox.Text == "0")
						{
							textBox.Text = textBox.Text.Remove(0, 1);
						}
						textBox.Text += "2";
						break;
					case '3':
						if (textBox.Text == "0")
						{
							textBox.Text = textBox.Text.Remove(0, 1);
						}
						textBox.Text += "3";
						break;
					case '4':
						if (textBox.Text == "0")
						{
							textBox.Text = textBox.Text.Remove(0, 1);
						}
						textBox.Text += "4";
						break;
					case '5':
						if (textBox.Text == "0")
						{
							textBox.Text = textBox.Text.Remove(0, 1);
						}
						textBox.Text += "5";
						break;
					case '6':
						if (textBox.Text == "0")
						{
							textBox.Text = textBox.Text.Remove(0, 1);
						}
						textBox.Text += "6";
						break;
					case '7':
						if (textBox.Text == "0")
						{
							textBox.Text = textBox.Text.Remove(0, 1);
						}
						textBox.Text += "7";
						break;
					case '8':
						if (textBox.Text == "0")
						{
							textBox.Text = textBox.Text.Remove(0, 1);
						}
						textBox.Text += "8";
						break;
					case '9':
						if (textBox.Text == "0")
						{
							textBox.Text = textBox.Text.Remove(0, 1);
						}
						textBox.Text += "9";
						break;
					case '.':
						textBox.Text += ".";
						break;
					case '+':
						textBox.Text += "+";
						break;
					case '-':
						textBox.Text += "-";
						break;
					case '*':
						textBox.Text += "×";
						break;
					case '/':
						textBox.Text += "÷";
						break;
					case '^':
						textBox.Text += "^";
						break;
					case 'l':
						if (textBox.Text == "0")
						{
							textBox.Text = textBox.Text.Remove(0, 1);
						}
						textBox.Text += "log(";
						break;
					case 'n':
						if (textBox.Text == "0")
						{
							textBox.Text = textBox.Text.Remove(0, 1);
						}
						textBox.Text += "ln(";
						break;
					case 'r':
						if (textBox.Text == "0")
						{
							textBox.Text = textBox.Text.Remove(0, 1);
						}
						textBox.Text += "sqrt(";
						break;
					case 's':
						if (textBox.Text == "0")
						{
							textBox.Text = textBox.Text.Remove(0, 1);
						}
						textBox.Text += "sin(";
						break;
					case 'c':
						if (textBox.Text == "0")
						{
							textBox.Text = textBox.Text.Remove(0, 1);
						}
						textBox.Text += "cos(";
						break;
					case 't':
						if (textBox.Text == "0")
						{
							textBox.Text = textBox.Text.Remove(0, 1);
						}
						textBox.Text += "tan(";
						break;
                    case 'p':
						if (textBox.Text == "0")
						{
							textBox.Text = textBox.Text.Remove(0, 1);
						}
						textBox.Text += "3.141592654";
						break;
                    case '=':
						textBox.Text = textBox.Text.Replace("log(", "l");
						textBox.Text = textBox.Text.Replace("ln(", "n");
						textBox.Text = textBox.Text.Replace("sqrt(", "r");
						textBox.Text = textBox.Text.Replace("sin(", "s");
						textBox.Text = textBox.Text.Replace("cos(", "c");
						textBox.Text = textBox.Text.Replace("tan(", "t");
						textBox.Text = textBox.Text.Replace("π", "3.141592654");
						double result = Bodmas(textBox.Text);
						textBox.Text = result.ToString();
						textBox1.Text = result.ToString();
                        break;
                    case ((char)Keys.Back):
						if (isOn)
						{
							if (textBox.Text == "0")
							{
							}
							else if (textBox.Text.Length > 0)
							{
								textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
							}
						}
                        break;
				}
            }
        }
    }
}
