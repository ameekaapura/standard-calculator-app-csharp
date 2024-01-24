using System;
using System.Windows.Forms;

namespace Standard_Calculator
{
    public partial class Form1 : Form
    {
        double enterFirstValue, enterSecondValue;
        string operators;
        bool isFirstValueEntered;
        public Form1()
        {
            InitializeComponent();
            isFirstValueEntered = false;
        }

        private void EqualButton(object sender, EventArgs e)
        {
            if (isFirstValueEntered)
            {
                enterSecondValue = Convert.ToDouble(txtResult.Text);

                switch (operators)
                {
                    case "+":
                        txtResult.Text = (enterFirstValue + enterSecondValue).ToString();
                        break;
                    case "-":
                        txtResult.Text = (enterFirstValue - enterSecondValue).ToString();
                        break;
                    case "*":
                        txtResult.Text = (enterFirstValue * enterSecondValue).ToString();
                        break;
                    case "/":
                        if (enterSecondValue != 0)
                        {
                            txtResult.Text = (enterFirstValue / enterSecondValue).ToString();
                        }
                        else
                        {
                            txtResult.Text = "0";
                            return;
                        }
                        break;
                    default:
                        break;
                }

                isFirstValueEntered = false;
            }
        }

        private void EnterNumbers(object sender, EventArgs e)
        {
            Button num = (Button)sender;

            if (isFirstValueEntered)
            {
                if (txtResult.Text == "0")
                    txtResult.Text = "";

                if (num.Text == ".")
                {
                    if (!txtResult.Text.Contains("."))
                        txtResult.Text = txtResult.Text + num.Text;
                }
                else
                {
                    txtResult.Text = txtResult.Text + num.Text;
                }
            }
            else
            {
                txtResult.Text = num.Text;
                isFirstValueEntered = true;
            }
        }

        private void NumberOperators(object sender, EventArgs e)
        {
            if (isFirstValueEntered)
            {
                Button num = (Button)sender;
                enterFirstValue = Convert.ToDouble(txtResult.Text);
                operators = num.Text;
                txtResult.Text = "";
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
        }

        private void Clear_Entry_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
        }

        private void PlusMinus(object sender, EventArgs e)
        {
            if (isFirstValueEntered)
            {
                double q = Convert.ToDouble(txtResult.Text);
                txtResult.Text = Convert.ToString(-1 * q);
            }
        }

        private void Backspace(object sender, EventArgs e)
        {
            if (txtResult.Text.Length > 0)
            {
                txtResult.Text = txtResult.Text.Remove(txtResult.Text.Length - 1, 1);
            }
            if (txtResult.Text == "")
            {
                txtResult.Text = "0";
            }
        }

        private void Exp2_Button(object sender, EventArgs e)
        {
            if (isFirstValueEntered)
            {
                double x;
                x = Convert.ToDouble(txtResult.Text) * Convert.ToDouble(txtResult.Text);
                txtResult.Text = Convert.ToString(x);
            }
        }

        private void Sqr_Button(object sender, EventArgs e)
        {
            if (isFirstValueEntered)
            {
                double sqr = Convert.ToDouble(txtResult.Text);
                sqr = Math.Sqrt(sqr);
                txtResult.Text = Convert.ToString(sqr);
            }
        }

        private void One_Over_X(object sender, EventArgs e)
        {
            if (isFirstValueEntered)
            {
                double overX;
                overX = Convert.ToDouble(1) / Convert.ToDouble(txtResult.Text);
                txtResult.Text = Convert.ToString(overX);
            }
        }

        private void Percentage(object sender, EventArgs e)
        {
            if (isFirstValueEntered)
            {
                double v = Convert.ToDouble(txtResult.Text) / Convert.ToDouble(100);
                double percentage = v;
                txtResult.Text = Convert.ToString(percentage);
            }
        }
    }
}
