using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;

namespace Calculator
{

    public partial class Form1 : Form
    {
        bool isOn = false;
        readonly Eval eval = new Eval();
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
            button18.Focus(); //equal button name
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
            bool valid_expression = eval.VerifyExpression(textBox.Text);
            textBox.Text = textBox.Text.Replace("log(", "l");
            textBox.Text = textBox.Text.Replace("ln(", "n");
            textBox.Text = textBox.Text.Replace("sqrt(", "r");
            textBox.Text = textBox.Text.Replace("sin(", "s");
            textBox.Text = textBox.Text.Replace("cos(", "c");
            textBox.Text = textBox.Text.Replace("tan(", "t");
            textBox.Text = textBox.Text.Replace("π", "3.141592654");
            if (valid_expression)
            {
                double result = eval.Bodmas(textBox.Text);
                textBox.Text = result.ToString();
                textBox1.Text = result.ToString();
            }
            else
            {
                textBox.Text = "Invalid Expression";
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

    public class Eval
    {
        private enum Precedence
        { 
            Default = 0,
            Add = 1,
            Subtract = 1,
            Multiply = 2,
            Divide = 2,
            Power = 3,
            Log = 4,
            Ln = 4,
            Sqrt = 4,
            Sin = 4,
            Cos = 4,
            Tan = 4,
        }

        public bool VerifyExpression(string expression)
        {
            int j = new int();
            string validOperators = "+-×÷^";
            string specialOperators = "nlrsct";
            string temp = expression;
            Stack<int> open_parenthesis = new Stack<int>();
            Stack<int> closed_parenthesis = new Stack<int>();
            if (expression == "Invalid Expression")
            {
                return false;
            }

            // Check parenthesis
            while (temp.Contains('('))
            {
                int i = temp.IndexOf('(') + j;
                open_parenthesis.Push(i);
                temp = temp.Remove(i - j, 1);
                j++;
            }
            j = 0;
            while (temp.Contains(')'))
            {
                int i = temp.IndexOf(')') + j;
                closed_parenthesis.Push(i);
                temp = temp.Remove(i - j, 1);
                j++;
            }
            if (open_parenthesis.Count != closed_parenthesis.Count)
            {
                return false;
            }
            while (open_parenthesis.Count > 0)
            {
                int last_closed_index = closed_parenthesis.Pop();
                int last_open_index = open_parenthesis.Pop();
                if (last_closed_index - last_open_index < 1)
                {
                    return false;
                }
            }

            //Check valid operators, special operators and decimal
            temp = expression;
            temp = temp.Replace("log(", "l");
            temp = temp.Replace("ln(", "n");
            temp = temp.Replace("sqrt(", "r");
            temp = temp.Replace("sin(", "s");
            temp = temp.Replace("cos(", "c");
            temp = temp.Replace("tan(", "t");
            temp = temp.Replace("π", "3.141592654");
            for (int i = 0; i < temp.Length; i++)
            {
                char ch = temp[i];
                if (validOperators.Contains(ch))
                {
                    if (i + 1 == temp.Length)
                    {
                        return false;
                    }
                    if (Char.IsDigit(temp[i + 1]) || temp[i + 1] == '(' || specialOperators.Contains(temp[i + 1]))
                    {
                        if (Char.IsDigit(temp[i - 1]) || temp[i - 1] == ')')
                        {

                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (specialOperators.Contains(ch))
                {
                    if (temp[i + 1] == '(' || Char.IsDigit(temp[i + 1]))
                    {
                        if (i == 0)
                        {
                            continue;
                        }
                        else if (validOperators.Contains(temp[i - 1]) || temp[i - 1] == '(')
                        {
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (ch == '.')
                {
                    if (i == 0)
                    {
                        return false;
                    }
                    j = 1;
                    while (Char.IsDigit(temp[i + j]))
                    {
                        j++;
                        if (i + j == temp.Length)
                        {
                            break;
                        }
                    }
                    if (temp[i + j] == '.')
                    {
                        return false;
                    }
                }
            }
            return true;
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

        private int Priority(char operation)
        {
            switch (operation)
            {
                case '+': return (int)Precedence.Add;
                case '-': return (int)Precedence.Subtract;
                case '×': return (int)Precedence.Multiply;
                case '÷': return (int)Precedence.Divide;
                case '^': return (int)Precedence.Power;
                case 'l': return (int)Precedence.Log;
                case 'n': return (int)Precedence.Ln;
                case 'r': return (int)Precedence.Sqrt;
                case 's': return (int)Precedence.Sin;
                case 'c': return (int)Precedence.Cos;
                case 't': return (int)Precedence.Tan;
                default: return (int)Precedence.Default;
            }
        }
        private double MathOperation(char operation, double l_operand, double r_operand)
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
                default: return 0;
            }
        }
    }
}
