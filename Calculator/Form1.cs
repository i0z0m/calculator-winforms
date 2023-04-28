using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calculator
{
    public partial class Form_calculator : Form
    {
        private bool Label_overwrite = true; //表示ラベルの上書き
        private bool Num_Plus = true; // +/- ボタンの正負判定
        private bool Num_Dot = false; // .ドット の有無判定
        private double dNum; //ラベルをdouble型に格納する変数
        private double dNum_Pool; //ラベルの数字をプールする変数
        private enum MarksType //列挙子
        {
            NON,
            PLUS,
            MINUS,
            MULTIPLIED,
            DEVIDED,
            PERCENT
        }
        private MarksType mType = MarksType.NON;

        public Form_calculator()
        {
            InitializeComponent();
        }

        private void Form_calculator_Load(object sender, EventArgs e)
        {

        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (Label_overwrite == true)
            {
                textBox_Result.Text = button0.Text;
                Label_overwrite = false;
            }
            else
            {
                textBox_Result.Text += button0.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Label_overwrite == true)//Num_Labelを上書きするか？
            {
                //真の場合
                textBox_Result.Text = button1.Text;
                Label_overwrite = false;
            }
            else
            {
                //偽の場合
                textBox_Result.Text += button1.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Label_overwrite == true)
            {
                textBox_Result.Text = button2.Text;
                Label_overwrite = false;
            }
            else
            {
                textBox_Result.Text += button2.Text;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Label_overwrite == true)
            {
                textBox_Result.Text = button3.Text;
                Label_overwrite = false;
            }
            else
            {
                textBox_Result.Text += button3.Text;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Label_overwrite == true)
            {
                textBox_Result.Text = button4.Text;
                Label_overwrite = false;
            }
            else
            {
                textBox_Result.Text += button4.Text;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Label_overwrite == true)
            {
                textBox_Result.Text = button5.Text;
                Label_overwrite = false;
            }
            else
            {
                textBox_Result.Text += button5.Text;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Label_overwrite == true)
            {
                textBox_Result.Text = button6.Text;
                Label_overwrite = false;
            }
            else
            {
                textBox_Result.Text += button6.Text;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Label_overwrite == true)
            {
                textBox_Result.Text = button7.Text;
                Label_overwrite = false;
            }
            else
            {
                textBox_Result.Text += button7.Text;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Label_overwrite == true)
            {
                textBox_Result.Text = button8.Text;
                Label_overwrite = false;
            }
            else
            {
                textBox_Result.Text += button8.Text;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Label_overwrite == true)
            {
                textBox_Result.Text = button9.Text;
                Label_overwrite = false;
            }
            else
            {
                textBox_Result.Text += button9.Text;
            }
        }

        private void buttonAllClear_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            Label_overwrite = true;
            Num_Dot = false;
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
        }

        private void buttonClearEntry_Click(object sender, EventArgs e)
        {
        }

        private void ButtonSign_Click(object sender, EventArgs e)
        {
            if (Num_Plus == true)
            {
                textBox_Result.Text = "-" + textBox_Result.Text;
                Num_Plus = false;
            }
            else
            {
                textBox_Result.Text = textBox_Result.Text.Replace("-", "");
                Num_Plus = true;
            }
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (Num_Dot == false)
            {
                textBox_Result.Text = textBox_Result.Text + ".";
                Num_Dot = true;
                Label_overwrite = false;
            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            Num_Dot = false;
            Label_overwrite = true;
            Num_PoolMethod();
            mType = MarksType.PLUS;
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            Num_Dot = false;
            Label_overwrite = true;
            Num_PoolMethod();
            mType = MarksType.MINUS;
        }


        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            Num_Dot = false;
            Label_overwrite = true;
            Num_PoolMethod();
            mType = MarksType.MULTIPLIED;
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            Num_Dot = false;
            Label_overwrite = true;
            Num_PoolMethod();
            mType = MarksType.DEVIDED;
        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            Num_Dot = false;
            Label_overwrite = true;
            mType = MarksType.PERCENT;
            Num_PoolMethod();
            mType = MarksType.NON;
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            Num_PoolMethod();
            mType = MarksType.NON;
            Num_Dot = false;
            Label_overwrite = true;
        }

        private void buttonSquareRoot_Click(object sender, EventArgs e)
        {

        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {

        }

        private void buttonOver_Click(object sender, EventArgs e)
        {

        }

        private void Num_PoolMethod()// ＋ ー × ÷ ％ 演算子の計算処理
        {
            dNum = double.Parse(textBox_Result.Text);
            switch (mType)
            {
                case MarksType.NON://＝
                    dNum_Pool = dNum;
                    break;
                case MarksType.PLUS://＋
                    dNum_Pool += dNum;
                    break;
                case MarksType.MINUS://ー
                    dNum_Pool -= dNum;
                    break;
                case MarksType.MULTIPLIED://×
                    dNum_Pool *= dNum;
                    break;
                case MarksType.DEVIDED://÷
                    dNum_Pool /= dNum;
                    break;
                case MarksType.PERCENT://%
                    dNum_Pool = dNum * 0.01;
                    break;
            }
            textBox_Result.Text = dNum_Pool.ToString();//表示が更新される
        }

        private void textBox_Formula_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Result_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox_Result.Text, out double result))
            {
                textBox_Result.Text = "0";
                MessageBox.Show("入力値が無効です。数字を入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (textBox_Result.Text.Contains("."))
            {
                string[] parts = textBox_Result.Text.Split('.');
                if (parts[0].Length + parts[1].Length > 12)
                {
                    textBox_Result.Text = "0";
                    MessageBox.Show("整数部と少数部の合計が13桁以上の計算は不可", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Num_Dot = false;
                    Label_overwrite = true;
                }
            }
            else if (textBox_Result.Text.Length > 12)
            {
                textBox_Result.Text = "0";
                MessageBox.Show("整数部と少数部の合計が13桁以上の計算は不可", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Num_Dot = false;
                Label_overwrite = true;
            }
        }
    }
}
