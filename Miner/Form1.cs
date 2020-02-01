using Miner.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Miner
{
    public partial class Form1 : Form
    {
        Field GameField;
        Cell[,] Cells = new Cell[5, 10];
        Button[,] buttons = new Button[5, 10];



        public Form1()
        {
            InitializeComponent();
            FillGame();
        }

        private void FillGame()
        {
            GameField = new Field(5, 10);

            const int ButtonWidth = 250;
            const int ButtonHeight = 250;
            tableLayoutPanel1.ColumnCount = 10;
            tableLayoutPanel1.RowCount = 5;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button pB = new Button();
                    pB.Width = ButtonWidth;
                    pB.Height = ButtonHeight;
                    pB.Location = new Point(i * 100, j * 100);
                    pB.Parent = tableLayoutPanel1;
                    pB.Tag = GameField.Cells[i, j];
                    pB.Click += h_onPBOnClick;
                    buttons[i, j] = pB;
                    Cells[i, j] = GameField.Cells[i, j];
                }

            }

        }

        private void OpenAll()
        {
            foreach (Button btn in buttons)
            {
                var pO = btn.Tag;
                var pF = pO as Cell;
                if (pF.Tip == Tip.Bomb)
                {

                    btn.Image = Image.FromFile("C:\\Users\\Alaran\\Desktop\\учеба\\2 семестр\\ооп\\Бомбы\\Miner\\Miner\\Properties\\13icon.png");
                    btn.FlatStyle = FlatStyle.Flat;

                }
            }
        }


        private void Enab()
        {
            foreach (Button btn in buttons)
            {
                btn.Enabled = false;
            }
        }


        private void h_onPBOnClick(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            var pO = btn.Tag;
            var pF = pO as Cell;
            if (pF.Tip == Tip.Bomb)
            {
                btn.Image = Image.FromFile("C:\\Users\\Alaran\\Desktop\\учеба\\2 семестр\\ооп\\Бомбы\\Miner\\Miner\\Properties\\13icon.png");
                btn.FlatStyle = FlatStyle.Flat;
                MessageBox.Show("Конец игры");
                OpenAll();
                Enab();

            }
            else
            {
                btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

                switch (pF.Color)
                {

                    case ColorCell.Zero:
                        btn.ForeColor = Color.Gray;
                        btn.Text = pF.Number.ToString();
                        break;
                    case ColorCell.One:
                        btn.ForeColor = Color.Black;
                        btn.Text = pF.Number.ToString();
                        break;
                    case ColorCell.Two:
                        btn.ForeColor = Color.Blue;
                        btn.Text = pF.Number.ToString();
                        break;
                    case ColorCell.Three:
                        btn.ForeColor = Color.Red;
                        btn.Text = pF.Number.ToString();
                        break;
                    case ColorCell.All:
                        btn.ForeColor = Color.Green;
                        btn.Text = pF.Number.ToString();
                        break;
                    default:
                        break;
                }
                IfEndGame();
            }
        }

        #region

        //private void OpenZero(int i, int j)
        //{
        //    try
        //    {



        //        var pO = buttons[i, j].Tag;
        //        var pF = pO as Cell;
        //        if (pF.Number == 0)
        //        {
        //            buttons[i, j].Text = pF.Number.ToString();

        //            //OpenZero(i, j - 1);
        //            //OpenZero(i - 1, j);
        //            //OpenZero(i, j + 1);
        //            //OpenZero(i + 1, j);

        //            //OpenZero(i - 1, j - 1);
        //            //OpenZero(i - 1, j + 1);
        //            //OpenZero(i + 1, j - 1);
        //            //OpenZero(i + 1, j + 1);
        //        }
        //        else
        //        {
        //            buttons[i, j].Text = pF.Number.ToString();
        //        }
        //    }
        //    catch { }


        //    //try
        //    //{
        //    //    var pO = buttons[i - 1, j - 1].Tag;
        //    //    var pF = pO as Cell;
        //    //    buttons[i - 1, j - 1].Text = pF.Number.ToString();
        //    //    if (pF.Number == 0)
        //    //    {
        //    //        OpenZero(i - 1, j - 1);
        //    //    }

        //    //}
        //    //catch { }



        //    //try
        //    //{
        //    //    var pO = buttons[i, j - 1].Tag;
        //    //    var pF = pO as Cell;
        //    //    buttons[i, j - 1].Text = pF.Number.ToString();
        //    //    if (pF.Number == 0)
        //    //    {
        //    //        OpenZero(i, j - 1);
        //    //    }

        //    //}
        //    //catch { }

        //    //try
        //    //{
        //    //    var pO = buttons[i + 1, j - 1].Tag;
        //    //    var pF = pO as Cell;
        //    //    buttons[i + 1, j - 1].Text = pF.Number.ToString();
        //    //    //if (pF.Number == 0)
        //    //    //{
        //    //    //    OpenZero(i + 1, j - 1);
        //    //    //}
        //    //}
        //    //catch { }



        //    //try
        //    //{
        //    //    var pO = buttons[i - 1, j].Tag;
        //    //    var pF = pO as Cell;
        //    //    buttons[i - 1, j].Text = pF.Number.ToString();
        //    //    if (pF.Number == 0)
        //    //    {
        //    //        OpenZero(i - 1, j);
        //    //    }
        //    //}
        //    //catch { }

        //    //try
        //    //{
        //    //    var pO = buttons[i + 1, j].Tag;
        //    //    var pF = pO as Cell;
        //    //    buttons[i + 1, j].Text = pF.Number.ToString();
        //    //    if (pF.Number == 0)
        //    //    {
        //    //        OpenZero(i + 1, j);
        //    //    }
        //    //}
        //    //catch { }



        //    //try
        //    //{
        //    //    var pO = buttons[i - 1, j + 1].Tag;
        //    //    var pF = pO as Cell;
        //    //    buttons[i - 1, j + 1].Text = pF.Number.ToString();
        //    //    //if (pF.Number == 0)
        //    //    //{
        //    //    //    OpenZero(i - 1, j + 1);
        //    //    //}
        //    //}
        //    //catch { }

        //    //try
        //    //{
        //    //    var pO = buttons[i + 1, j + 1].Tag;
        //    //    var pF = pO as Cell;
        //    //    buttons[i + 1, j + 1].Text = pF.Number.ToString();
        //    //    //if (pF.Number == 0)
        //    //    //{
        //    //    //    OpenZero(i + 1, j + 1);
        //    //    //}
        //    //}
        //    //catch { }

        //    //try
        //    //{
        //    //    var pO = buttons[i, j + 1].Tag;
        //    //    var pF = pO as Cell;
        //    //    buttons[i, j + 1].Text = pF.Number.ToString();
        //    //    if (pF.Number == 0)
        //    //    {
        //    //        OpenZero(i, j + 1);
        //    //    }
        //    //}
        //    //catch { }


        //}
        #endregion

        private void IfEndGame()
        {
            int Count = 0;
            foreach (Button btn in buttons)
            {
                var pO = btn.Tag;
                var pF = pO as Cell;
                if (pF.Tip == Tip.Number & btn.Text.Length != 0)
                {
                    Count++;
                    if (Count == 42)
                    {
                        MessageBox.Show("Вы выиграли");
                        NewGame();
                    }
                }
            }

        }

        private void NewGame()
        {
            tableLayoutPanel1.Controls.Clear();
            FillGame();
            this.Refresh();
        }



        private void новаяИграToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NewGame();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
