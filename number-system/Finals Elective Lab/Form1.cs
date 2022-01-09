    using System;
    using System.Windows.Forms;

    namespace Finals_Elective_Lab
    {
        public partial class Form1 : Form
        {
            int currentNS = 10;
            public Form1()
            {
                InitializeComponent();
            
            }

            private void CheckBox1_CheckedChanged(object sender, EventArgs e)
            {
            
            }

            private void Form1_Load(object sender, EventArgs e)
            {
                rdDecimal.Checked = true;
            }

        private void btn0_Click(object sender, EventArgs e)
        {
            
            if (txtNum.Text == "0")
            {
                Button btn = (Button)sender;
                String text = btn.Text;
                txtNum.Text = text;
            }
            else
            {
                Button btn = (Button)sender;
                String text = btn.Text;
                txtNum.Text = txtNum.Text + text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNum.Text = "0";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if ((String.Compare(txtNum.Text, " ") < 0))
            {
                txtNum.Text = txtNum.Text.Substring(0, txtNum.Text.Length - 1 + 1);
            }
            else
            {
                txtNum.Text = txtNum.Text.Substring(0, txtNum.Text.Length - 1);
            }
            int txtLength = txtNum.Text.Length;
            //txtNum.Text = txtNum.Text.Remove(txtLength - 1, 1);
            if (txtLength == 0)
            {
                txtNum.Text = "0";
            }
        }

        private void rdDecimal_CheckedChanged(object sender, EventArgs e)
        {
            string result = "";
            bool check;
            if (currentNS == 2)
            {
                //binary to decimal
                long num = long.Parse(txtNum.Text);
                int base1 = 1;
                long resultnum = 0;
                while (num > 0)
                {
                    long remainder = num % 10;
                    num = num / 10;
                    resultnum += remainder * base1;
                    base1 = base1 * 2;
                }
                result = Convert.ToString(resultnum);
                txtNum.Text = result;
            }
            else if(currentNS == 8)
            {
                //octal to decimal
                int num = int.Parse(txtNum.Text);
                int base1 = 1;
                int resultnum = 0;
                while (num > 0)
                {
                    int remainder = num % 10;
                    num = num / 10;
                    resultnum += remainder * base1; 
                    base1 = base1 * 8;
                }
                result = Convert.ToString(resultnum);
                txtNum.Text = result;
            }
            else if(currentNS == 16)
            {
                //hexa to decimal
                int num;
                char[] hexChars = txtNum.Text.ToCharArray();
                Array.Reverse(hexChars);
                num = 0;
                int base1 = 1;
                foreach (char ch in hexChars)
                {
                    switch (ch)
                    {
                        case 'A':
                            num = 10 * base1 + num;
                            break;
                        case 'B':
                            num = 11 * base1 + num;
                            break;
                        case 'C':
                            num = 12 * base1 + num;
                            break;
                        case 'D':
                            num = 13 * base1 + num;
                            break;
                        case 'E':
                            num = 14 * base1 + num;
                            break;
                        case 'F':
                            num = 15 * base1 + num;
                            break;
                        default:
                            int currentNum = (int)(char.GetNumericValue(ch));
                            int resultnum = 0;
                            int remainder = currentNum % 10;
                            resultnum += remainder * base1;
                            num = resultnum + num;
                            break;
                    }
                    base1 = base1 * 16;
                }
                result = Convert.ToString(num);
                check = int.TryParse(result, out num);
                if (check == false)
                {
                    MessageBox.Show("Input is above the max value.");
                    txtNum.Text = "0";
                }
                else
                    txtNum.Text = result;
            }
            btn0.Enabled = true;
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;
            btnA.Enabled = false;
            btnB.Enabled = false;
            btnC.Enabled = false;
            btnD.Enabled = false;
            btnE.Enabled = false;
            btnF.Enabled = false;
            currentNS = 10;
        }

        private void rdBinary_CheckedChanged(object sender, EventArgs e)
        {
            string result;
            int num;
            bool check = int.TryParse(txtNum.Text, out num);
            if (check == false && currentNS != 16)
            {
                MessageBox.Show("Input is above the max value.");
                txtNum.Text = "0";
            }
            if (currentNS == 10)
            {
                //decimal to binary
                if (num >= 2048)
                {
                    MessageBox.Show("Input is above the max value.");
                    txtNum.Text = "0";
                    goto skip;
                }
                result = "";
                while (num > 1)
                {
                    int remainder = num % 2;
                    result = Convert.ToString(remainder) + result;
                    num /= 2;
                }
                result = Convert.ToString(num) + result;
                txtNum.Text = result;
            }
            else if (currentNS == 8)
            {
                //octal to decimal
                if (num >= 4000)
                {
                    MessageBox.Show("Input is above the max value.");
                    txtNum.Text = "0";
                    goto skip;
                }
                int base1 = 1;
                int resultnum = 0;
                while (num > 0)
                {
                    int remainder = num % 10;
                    num = num / 10;
                    resultnum += remainder * base1;
                    base1 = base1 * 8;
                }
                result = "";
                //decimal to binary
                num = resultnum;
                while (num > 1)
                {
                    int remainder = num % 2;
                    result = Convert.ToString(remainder) + result;
                    num /= 2;
                }
                result = Convert.ToString(num) + result;
                txtNum.Text = result;
            }
            else if (currentNS == 16)
            {
                //hexa to decimal
                char[] hexChars = txtNum.Text.ToCharArray();
                Array.Reverse(hexChars);
                num = 0;
                int base1 = 1;
                foreach (char ch in hexChars)
                {
                    switch (ch)
                    {
                        case 'A':
                            num = 10 * base1 + num;
                            break;
                        case 'B':
                            num = 11 * base1 + num;
                            break;
                        case 'C':
                            num = 12 * base1 + num;
                            break;
                        case 'D':
                            num = 13 * base1 + num;
                            break;
                        case 'E':
                            num = 14 * base1 + num;
                            break;
                        case 'F':
                            num = 15 * base1 + num;
                            break;
                        default:
                            int currentNum = (int)(char.GetNumericValue(ch));
                            int resultnum = 0;
                            int remainder = currentNum % 10;
                            resultnum += remainder * base1;
                            num = resultnum + num;
                            break;
                    }
                    base1 = base1 * 16;
                }
                result = Convert.ToString(num);
                check = int.TryParse(result, out num);
                if ((check == false || num == -1) || num >= 2048)
                {
                    MessageBox.Show("Input is above the max value.");
                    txtNum.Text = "0";
                    goto skip;
                }
                //decimal to binary
                result = "";
                while (num > 1)
                {
                    int remainder = num % 2;
                    result = Convert.ToString(remainder) + result;
                    num /= 2;
                }
                result = Convert.ToString(num) + result;
                txtNum.Text = result;
            }
        skip:
            btn0.Enabled = true;
            btn1.Enabled = true;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;
            btnA.Enabled = false;
            btnB.Enabled = false;
            btnC.Enabled = false;
            btnD.Enabled = false;
            btnE.Enabled = false;
            btnF.Enabled = false;
            currentNS = 2;
        }

        private void rdOctal_CheckedChanged(object sender, EventArgs e)
        {
            string result;
            
            bool check;
            if (currentNS == 2)
            {
                //binary to decimal
                long num = long.Parse(txtNum.Text);
                int base1 = 1;
                long resultnum = 0;
                while (num > 0)
                {
                    long remainder = num % 10;
                    num = num / 10;
                    resultnum += remainder * base1;
                    base1 = base1 * 2;
                }
                result = Convert.ToString(resultnum);
                num = resultnum;
                //decimal to octal
                result = "";
                while (num > 7)
                {
                    long remainder = num % 8;
                    result = Convert.ToString(remainder) + result;
                    num /= 8;
                }
                result = Convert.ToString(num) + result;
                txtNum.Text = result;
            }
            else if (currentNS == 10)
            {
                //decimal to octal
                int num = int.Parse(txtNum.Text);
                check = int.TryParse(txtNum.Text, out num);
                int v = 1073741824;
                if (check == false || num >= v)
                {
                    MessageBox.Show("Input is above the max value.");
                    txtNum.Text = "0";
                    goto skip;
                }
                result = "";
                while (num > 7)
                {
                    int remainder = num % 8;
                    result = Convert.ToString(remainder) + result;
                    num /= 8;
                }
                result = Convert.ToString(num) + result;
                txtNum.Text = result;
            }
            else if (currentNS == 16)
            {
                //hexa to decimal
                int num;
                char[] hexChars = txtNum.Text.ToCharArray();
                Array.Reverse(hexChars);
                num = 0;
                int base1 = 1;
                foreach (char ch in hexChars)
                {
                    switch (ch)
                    {
                        case 'A':
                            num = 10 * base1 + num;
                            break;
                        case 'B':
                            num = 11 * base1 + num;
                            break;
                        case 'C':
                            num = 12 * base1 + num;
                            break;
                        case 'D':
                            num = 13 * base1 + num;
                            break;
                        case 'E':
                            num = 14 * base1 + num;
                            break;
                        case 'F':
                            num = 15 * base1 + num;
                            break;
                        default:
                            int currentNum = (int)(char.GetNumericValue(ch));
                            int resultnum = 0;
                            int remainder = currentNum % 10;
                            resultnum += remainder * base1;
                            num = resultnum + num;
                            break;
                    }
                    base1 = base1 * 16;
                }
                result = Convert.ToString(num);
                check = int.TryParse(result, out num);
                int v = 1073741824;
                if (check == false || num >= v)
                {
                    MessageBox.Show("Input is above the max value.");
                    txtNum.Text = "0";
                    goto skip;
                }
                //decimal to octal
                result = "";
                while (num > 7)
                {
                    int remainder = num % 8;
                    result = Convert.ToString(remainder) + result;
                    num /= 8;
                }
                result = Convert.ToString(num) + result;
                txtNum.Text = result;
            }
        skip: 
            btn0.Enabled = true;
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = false;
            btn9.Enabled = false;
            btnA.Enabled = false;
            btnB.Enabled = false;
            btnC.Enabled = false;
            btnD.Enabled = false;
            btnE.Enabled = false;
            btnF.Enabled = false;
            currentNS = 8;
        }

        private void rdHexa_CheckedChanged(object sender, EventArgs e)
        {
            string result;
            if (currentNS == 2)
            {
                //binary to decimal
                long num = long.Parse(txtNum.Text);
                long base1 = 1;
                long resultnum = 0;
                while (num > 0)
                {
                    long remainder = num % 10;
                    num = num / 10;
                    resultnum += remainder * base1;
                    base1 = base1 * 2;
                }
                result = Convert.ToString(resultnum);
                //decimal to hexa
                num = resultnum;
                result = "";
                if (num >= 16)
                {
                    while (num > 0)
                    {
                        long remainder = num % 16;
                        switch (remainder)
                        {
                            case 10:
                                result = "A" + result;
                                break;
                            case 11:
                                result = "B" + result;
                                break;
                            case 12:
                                result = "C" + result;
                                break;
                            case 13:
                                result = "D" + result;
                                break;
                            case 14:
                                result = "E" + result;
                                break;
                            case 15:
                                result = "F" + result;
                                break;
                            default:
                                result = Convert.ToString(remainder) + result;
                                break;
                        }
                        num /= 16;
                    }
                    if (num != 0)
                        result = Convert.ToString(num) + result;
                }
                else
                {
                    switch (num)
                    {
                        case 10:
                            result = "A" + result;
                            break;
                        case 11:
                            result = "B" + result;
                            break;
                        case 12:
                            result = "C" + result;
                            break;
                        case 13:
                            result = "D" + result;
                            break;
                        case 14:
                            result = "E" + result;
                            break;
                        case 15:
                            result = "F" + result;
                            break;
                        default:
                            result = Convert.ToString(num) + result;
                            break;
                    }
                }
                txtNum.Text = result;
            }
            else if (currentNS == 8)
            {
                //octal to decimal
                int num = int.Parse(txtNum.Text);
                int base1 = 1;
                int resultnum = 0;
                while (num > 0)
                {
                    int remainder = num % 10;
                    num = num / 10;
                    resultnum += remainder * base1;
                    base1 = base1 * 8;
                }
                result = Convert.ToString(resultnum);
                result = "";
                //decimal to hexa
                num = resultnum;
                result = "";
                if (num >= 16)
                {
                    while (num > 0)
                    {
                        int remainder = num % 16;
                        switch (remainder)
                        {
                            case 10:
                                result = "A" + result;
                                break;
                            case 11:
                                result = "B" + result;
                                break;
                            case 12:
                                result = "C" + result;
                                break;
                            case 13:
                                result = "D" + result;
                                break;
                            case 14:
                                result = "E" + result;
                                break;
                            case 15:
                                result = "F" + result;
                                break;
                            default:
                                result = Convert.ToString(remainder) + result;
                                break;
                        }
                        num /= 16;
                    }
                    if (num != 0)
                        result = Convert.ToString(num) + result;
                }
                else
                {
                    switch (num)
                    {
                        case 10:
                            result = "A" + result;
                            break;
                        case 11:
                            result = "B" + result;
                            break;
                        case 12:
                            result = "C" + result;
                            break;
                        case 13:
                            result = "D" + result;
                            break;
                        case 14:
                            result = "E" + result;
                            break;
                        case 15:
                            result = "F" + result;
                            break;
                        default:
                            result = Convert.ToString(num) + result;
                            break;
                    }
                }
                txtNum.Text = result;
            }
            else if (currentNS == 10)
            {
                //decimal to  hexa
                int num = int.Parse(txtNum.Text);
                result = "";
                if (num >= 16)
                {
                    while (num > 0)
                    {
                        int remainder = num % 16;
                        switch (remainder)
                        {
                            case 10:
                                result = "A" + result;
                                break;
                            case 11:
                                result = "B" + result;
                                break;
                            case 12:
                                result = "C" + result;
                                break;
                            case 13:
                                result = "D" + result;
                                break;
                            case 14:
                                result = "E" + result;
                                break;
                            case 15:
                                result = "F" + result;
                                break;
                            default:
                                result = Convert.ToString(remainder) + result;
                                break;
                        }
                        num /= 16;
                    }
                    if (num != 0)
                        result = Convert.ToString(num) + result;
                }
                else
                {
                    switch (num)
                    {
                        case 10:
                            result = "A" + result;
                            break;
                        case 11:
                            result = "B" + result;
                            break;
                        case 12:
                            result = "C" + result;
                            break;
                        case 13:
                            result = "D" + result;
                            break;
                        case 14:
                            result = "E" + result;
                            break;
                        case 15:
                            result = "F" + result;
                            break;
                        default:
                            result = Convert.ToString(num) + result;
                            break;
                    }
                }
                txtNum.Text = result;
            }
            btn0.Enabled = true;
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;
            btnA.Enabled = true;
            btnB.Enabled = true;
            btnC.Enabled = true;
            btnD.Enabled = true;
            btnE.Enabled = true;
            btnF.Enabled = true;
            currentNS = 16;
        }
    }
}
