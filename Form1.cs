using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace Calculator
{ 
    public partial class Form1 : Form
    {
        bool isOn = false; // Toggle on off
        readonly Eval eval = new Eval();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "Calculator"; // Name of windows
        }

        // Button for digit or special operators
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

        // Backspace
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
            button18.Focus(); // As enter key is bind to this method on default, Focus() is used to change to Equal_Click() method
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

        // Button for valid operators and '.'
        private void Operation_Click(object sender, EventArgs e)
        {
            if (isOn)
            {
                Button button = (Button)sender;
                textBox.Text += button.Text;
            }
        }

        // Validate expression and evaluate
        private void Equal_Click(object sender, EventArgs e)
        {
            bool valid_expression = eval.VerifyExpression(textBox.Text);
            textBox.Text = eval.ConvertExpression(textBox.Text);
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

        // Keyboard input
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
                        textBox.Text += "π";
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
                    case ((char)Keys.Space):
                        if (isOn)
                        {
                            textBox.Text = "0";
                        }
                        break;
                }
            }
        }
    }

    public class Eval
    {
        // Priority Level
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
            string specialOperators = "nlrsct"; //symbols for Log, Ln, Sqrt, Sin, Cos and Tan respectively
            string temp = expression;
            Stack<int> open_parenthesis = new Stack<int>();
            Stack<int> closed_parenthesis = new Stack<int>();
            if (expression == "Invalid Expression")
            {
                return false;
            }

            // Check parenthesis
            GetIndexes('(', temp, open_parenthesis);
            GetIndexes(')', temp, closed_parenthesis);
            if (open_parenthesis.Count != closed_parenthesis.Count)
            {
                return false;
            }
            while (open_parenthesis.Count > 0)
            {
                int last_closed_index = closed_parenthesis.Pop();
                int last_open_index = open_parenthesis.Pop();
                if (last_closed_index - last_open_index < 1) //The sequence of parenthesis is incorrect
                {
                    return false;
                }
            }

            //Check valid operators, special operators and decimal
            temp = expression; //Replace back parenthesis
            temp = ConvertExpression(temp);

            for (int i = 0; i < temp.Length; i++)
            {
                char ch = temp[i];
                if (validOperators.Contains(ch))
                {
                    // Valid operators are at last character
                    if (i + 1 == temp.Length)
                    {
                        return false;
                    }
                    else if (Char.IsDigit(temp[i + 1]) || temp[i + 1] == '(' || specialOperators.Contains(temp[i + 1])) // Next Character Condition
                    {
                        if (Char.IsDigit(temp[i - 1]) || temp[i - 1] == ')') // Last Character Condition
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
                    if (temp[i + 1] == '(' || Char.IsDigit(temp[i + 1])) // Next Character Condition
                    {
                        if (i == 0)
                        {
                            continue;
                        }
                        if (validOperators.Contains(temp[i - 1]) || temp[i - 1] == '(') // Last Character Condition
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
                            return true;
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

        // Evaluate expression
        public double Bodmas(string expression)
        {
            string validOperators = "+-×÷^";
            string specialOperators = "nlrsct";
            Stack<double> numbers = new Stack<double>();
            Stack<char> operators = new Stack<char>();
            for (int i = 0; i < expression.Length; i++)
            {
                char ch = expression[i];

                if (ch == '(') // Parenthesis highest priority
                {
                    operators.Push(ch);
                }
                else if (ch == ')') // Most Inner parenthesis first then to outer
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
                    // Only calculate first op and params when second operator is reached
                    while (operators.Count > 0 && Priority(operators.Peek()) >= Priority(ch)) //Eval according to priority
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
                    string inner_expression = ""; // Inner expression between parenthesis
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
                    double newValue = Bodmas(inner_expression); // Evaluate again the inner parenthesis first before evaluate the special operation
                    newValue = MathOperation(last_op, 0, newValue); 
                    numbers.Push(newValue);
                }
                else if (char.IsDigit(ch) || ch == '.') // Get numbers 
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

            while (operators.Count > 0) // Solve others lower priority
            {
                char op = operators.Pop();
                double param2 = numbers.Pop();
                double param1 = numbers.Pop();
                double newValue = MathOperation(op, param1, param2);
                numbers.Push(newValue);
            }
            return numbers.Pop();
        }

        // Return priorit according to enum precedence
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

        // Get indexes of certain character
        private void GetIndexes(char ch, string expression, Stack<int> op)
        {
            int j = 0;
            while (expression.Contains(ch))
            {
                int i = expression.IndexOf(ch) + j;
                op.Push(i);
                expression = expression.Remove(i - j, 1);
                j++;
            }
        }

        // Convert expression suitable for evaluation
        public string ConvertExpression(string expression)
        {
            expression = expression.Replace("log(", "l");
            expression = expression.Replace("ln(", "n");
            expression = expression.Replace("sqrt(", "r");
            expression = expression.Replace("sin(", "s");
            expression = expression.Replace("cos(", "c");
            expression = expression.Replace("tan(", "t");
            expression = expression.Replace("π", "3.141592654");
            return expression;
        }
    }
}
