using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner
{/*
    Поле
        клетка[N,M]

    Заполнение поля
       +  Рандомные бомбы

        - Цифры на клетки
           - Пройтись по всем сторонам и посчитать кол-во бомб


    Открытие клетки
    Проверка, что все клетки не бомбы открыты

    Клетка
        - X
        - Y
        - Тип
    
    Тип 
        - Бомба 
        - Цифра 0-8



     */

    class Field
    {
        public Cell[,] Cells { get; set; }


        public Field(int N, int M)
        {
            Cells = new Cell[N, M];
            Fill(N, M);
            FillBomb(N, M);
            FillNumber(N, M);
        }

        private void Fill(int N, int M)
        {
            //Заполение пустыми кетками
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Cell cell = new Cell(i, j, Tip.Number);
                    Cells[i, j] = cell;
                }

            }
        }

        private void FillBomb(int N, int M)
        {
            // Изменение типа на бомба
            Random rnd = new Random();

            for (int i = 0; i < 8; i++)
            {
                int x = rnd.Next(0, N - 1);
                int y = rnd.Next(0, M - 1);

                Tip tip = Tip.Bomb;
                Cell cell = new Cell(x, y, tip);
                Cells[x, y] = cell;
            }
        }

        private void FillNumber(int N, int M)
        {
            // счетчик бомб вокруг и присваевание цифры
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (Cells[i, j].Tip == Tip.Number)
                    {
                        Cell cell = new Cell(i, j, Tip.Number);
                        cell.Number = Counter(i, j);
                        switch (cell.Number)
                        {
                            case 0:
                                cell.Color = ColorCell.Zero;
                                break;
                            case 1:
                                cell.Color = ColorCell.One;
                                break;
                            case 2:
                                cell.Color = ColorCell.Two;
                                break;
                            case 3:
                                cell.Color = ColorCell.Three;
                                break;
                            case 4 - 8:
                                cell.Color = ColorCell.All;
                                break;

                            default:
                                break;
                        }
                        Cells[i, j] = cell;
                    }
                }

            }

        }

        private int Counter(int i, int j)
        {
            Cells[i, j].Number = 0;

            try
            {
                if (Cells[i - 1, j - 1].Tip == Tip.Bomb)
                {
                    Cells[i, j].Number++;
                }
            }
            catch { }

            try
            {
                if (Cells[i, j - 1].Tip == Tip.Bomb)
                {
                    Cells[i, j].Number++;
                }
            }
            catch { }

            try
            {
                if (Cells[i + 1, j - 1].Tip == Tip.Bomb)
                {
                    Cells[i, j].Number++;
                }
            }
            catch { }



            try
            {
                if (Cells[i - 1, j].Tip == Tip.Bomb)
                {
                    Cells[i, j].Number++;
                }
            }
            catch { }

            try
            {
                if (Cells[i + 1, j].Tip == Tip.Bomb)
                {
                    Cells[i, j].Number++;
                }
            }
            catch { }



            try
            {
                if (Cells[i - 1, j + 1].Tip == Tip.Bomb)
                {
                    Cells[i, j].Number++;
                }
            }
            catch { }

            try
            {
                if (Cells[i + 1, j + 1].Tip == Tip.Bomb)
                {
                    Cells[i, j].Number++;
                }
            }
            catch { }

            try
            {
                if (Cells[i, j + 1].Tip == Tip.Bomb)
                {
                    Cells[i, j].Number++;
                }
            }
            catch { }





            return Cells[i, j].Number;
        }
    }
}
