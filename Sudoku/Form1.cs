using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form1 : Form
    {

        TextBox[,] tb = new TextBox[9, 9];
        int[,] gf = new int[9, 9];

        int x, y, horizontalLines, verticalLines, smallSqueres, a=0, b=0;

        int[,] passibilityCounter = new int[9, 9];

        int[,,] advice = new int[9, 9, 9];
        int[,] advCounter = new int[9, 9];

        int[,] horizontalCounter = new int[9, 9];
        int[,] verticalCounter = new int[9, 9];
        int[,] smallCounter = new int[9, 9];

        private void buttonSolve_Click(object sender, EventArgs e)
        {
            for(int x_solve=0; x_solve < 9; x_solve++)
            {
                for (int y_solve = 0; y_solve < 9; y_solve++)
                {
                    ReadSudoku();
                    GetAdvice(x_solve, y_solve);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            AddLabels();
            for(int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    advCounter[x, y] = 9;
                }
            }           
        }

        private void buttonAdvice_Click(object sender, EventArgs e)
        {
            ReadSudoku();
            GetAdvice(a, b++);
            if (b == 9)
            {
                b = 0;
                a++;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            ReadSudoku();          
        }

        private void AddLabels()
        {

            for (int x_add = 0; x_add < 9; x_add++)
            {
                for (int y_add = 0; y_add < 9; y_add++)
                {
                    tb[x_add, y_add] = new TextBox();
                    tableLayoutPanel1.Controls.Add(tb[x_add, y_add], x_add, y_add);
                }
            }
        }

        private void ReadSudoku()
        {
            for (int x_read = 0; x_read < 9; x_read++)
            {
                for (int y_read = 0; y_read < 9; y_read++)
                {
                    try
                    {
                        gf[x_read, y_read] = new int();
                        gf[x_read, y_read] = Int32.Parse(tb[x_read, y_read].Text);
                    }
                    catch
                    {

                    }

                }
            }
        }
        /*
         * 00 10 20 | 30 40 50 | 60 70 80
         * 01 11 21 | 31 41 51 | 61 71 81
         * 02 12 22 | 32 42 52 | 62 72 82
         * ==============================
         * 03 13 23 | 33 43 53 | 63 73 83
         * 04 14 24 | 34 44 54 | 64 74 84
         * 05 15 25 | 35 45 55 | 65 75 85
         * ==============================
         * 06 16 26 | 36 46 56 | 66 76 86
         * 07 17 27 | 37 47 57 | 67 77 87
         * 08 18 28 | 38 48 58 | 68 78 88
         * 
         * 
         * 
         *  1 | 2 | 3
         *  =========
         *  4 | 5 | 6
         *  =========
         *  7 | 8 | 9
         */

        private void AdviceSwitch(int x_switch, int y_switch, int x_get, int y_get)
        {
            switch (gf[x_switch, y_switch])
            {
                case 1:
                    if (advice[x_get, y_get, 0] != 1)
                    {
                        advice[x_get, y_get, 0] = 1;
                        advCounter[x_get, y_get]--;
                    }
                    break;
                case 2:
                    if (advice[x_get, y_get, 1] != 2)
                    {
                        advice[x_get, y_get, 1] = 2;
                        advCounter[x_get, y_get]--;
                    }
                    break;
                case 3:
                    if (advice[x_get, y_get, 2] != 3)
                    {
                        advice[x_get, y_get, 2] = 3;
                        advCounter[x_get, y_get]--;
                    }
                    break;
                case 4:
                    if (advice[x_get, y_get, 3] != 4)
                    {
                        advice[x_get, y_get, 3] = 4;
                        advCounter[x_get, y_get]--;
                    }
                    break;
                case 5:
                    if (advice[x_get, y_get, 4] != 5)
                    {
                        advice[x_get, y_get, 4] = 5;
                        advCounter[x_get, y_get]--;
                    }
                    break;
                case 6:
                    if (advice[x_get, y_get, 5] != 6)
                    {
                        advice[x_get, y_get, 5] = 6;
                        advCounter[x_get, y_get]--;
                    }
                    break;
                case 7:
                    if (advice[x_get, y_get, 6] != 7)
                    {
                        advice[x_get, y_get, 6] = 7;
                        advCounter[x_get, y_get]--;
                    }
                    break;
                case 8:
                    if (advice[x_get, y_get, 7] != 8)
                    {
                        advice[x_get, y_get, 7] = 8;
                        advCounter[x_get, y_get]--;
                    }
                    break;
                case 9:
                    if (advice[x_get, y_get, 8] != 9)
                    {
                        advice[x_get, y_get, 8] = 9;
                        advCounter[x_get, y_get]--;
                    }
                    break;
            }
        }

        private void GetAdvice_v2(int x_get, int y_get)
        {
        }

        private void GetAdvice(int x_get, int y_get)
        {
            
            if (x_get < 3 && y_get < 3)
            {
            
                //1
                for (int x_small = 0; x_small < 3; x_small++)
                {
                    for (int y_small = 0; y_small < 3; y_small++)
                    {
                        AdviceSwitch(x_small, y_small, x_get, y_get);
                    }
                }
            }
            if (x_get > 2 && x_get < 6 && y_get < 3)
            {
                //2
                for (int x_small = 3; x_small < 6; x_small++)
                {
                    for (int y_small = 0; y_small < 3; y_small++)
                    {
                        AdviceSwitch(x_small, y_small, x_get, y_get);
                    }
                }
            }
            if (x_get > 5 && y_get < 3)
            {
                //3
                for (int x_small = 6; x_small < 9; x_small++)
                {
                    for (int y_small = 0; y_small < 3; y_small++)
                    {
                        AdviceSwitch(x_small, y_small, x_get, y_get);
                    }
                }
            }

            if (x_get < 3 && y_get > 2 && y_get < 6)
            {
                //4
                for (int x_small = 0; x_small < 3; x_small++)
                {
                    for (int y_small = 3; y_small < 6; y_small++)
                    {
                        AdviceSwitch(x_small, y_small, x_get, y_get);
                    }
                }
            }
            if (x_get > 2 && x_get < 6 && y_get > 2 && y_get < 6)
            {
                //5
                for (int x_small = 3; x_small < 6; x_small++)
                {
                    for (int y_small = 3; y_small < 6; y_small++)
                    {
                        AdviceSwitch(x_small, y_small, x_get, y_get);
                    }
                }
            }
            if (x_get > 5 && y_get > 2 && y_get < 6)
            {
                //6
                for (int x_small = 6; x_small < 9; x_small++)
                {
                    for (int y_small = 3; y_small < 6; y_small++)
                    {
                        AdviceSwitch(x_small, y_small, x_get, y_get);
                    }
                }
            }

            if (x_get < 3 && y_get > 5)
            {
                //7
                for (int x_small = 0; x_small < 3; x_small++)
                {
                    for (int y_small = 6; y_small < 9; y_small++)
                    {
                        AdviceSwitch(x_small, y_small, x_get, y_get);
                    }
                }
            }
            if (x_get > 2 && x_get < 6 && y_get > 5)
            {
                //8
                for (int x_small = 3; x_small < 6; x_small++)
                {
                    for (int y_small = 6; y_small < 9; y_small++)
                    {
                        AdviceSwitch(x_small, y_small, x_get, y_get);
                    }
                }
            }
            if (x_get > 5 && y_get > 5)
            {
                //9
                for (int x_small = 6; x_small < 9; x_small++)
                {
                    for (int y_small = 6; y_small < 9; y_small++)
                    {
                        AdviceSwitch(x_small, y_small, x_get, y_get);
                    }
                }
            }

            for (int i = 0; i < 9; i++)
            {
                AdviceSwitch(x_get, i, x_get, y_get);
                AdviceSwitch(i, y_get, x_get, y_get);               
            }

            MessageBox.Show(advCounter[x_get, y_get].ToString());
            for (int i = 0; i < 9; i++)
            {
                if (advice[x_get, y_get, i] != i+1 && gf[x_get, y_get] == 0)
                {                  
                    gf[x_get, y_get] = (i+1);
                    tb[x_get, y_get].Text = gf[x_get, y_get].ToString();
                }
            }
            
        }


















        /*
        private void CountPossibility()
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    //if(gf[x,y] != gf[0,0] && gf[x, y] != gf[0, 0] && gf[x, y] != gf[0, 0] && gf[x, y] != gf[0, 0] && gf[x, y] != gf[0, 0] && gf[x, y] != gf[0, 0] && gf[x, y] != gf[0, 0] && gf[x, y] != gf[0, 0] && gf[x, y] != gf[0, 0])
                }
            }
        }

        /* SMALL SQUERE
                00 01 02 | 03 04 05 | 06 07 08
                10 11 12 | 13 14 15 | 16 17 18
                20 21 22 | 23 24 25 | 26 27 28
                ---------|----------|---------
                30 31 32 | 33 34 35 | 36 37 38
                40 41 42 | 43 44 45 | 46 47 48
                50 51 52 | 53 54 55 | 56 57 58
                ---------|----------|---------
                60 61 62 | 63 64 65 | 66 67 68
                70 71 72 | 73 74 75 | 76 77 78
                80 81 82 | 83 84 85 | 86 87 88    
                
                 1 | 2 | 3
                ---|---|---
                 4 | 5 | 6
                -- |---|---
                 7 | 8 | 9
                
                

        private void horizontalLinesCounter(int x, int y)
        {
            switch (gf[x, y])
            {
                case 1:
                    horizontalCounter[x, 0]++;
                    break;
                case 2:
                    horizontalCounter[x, 1]++;
                    break;
                case 3:
                    horizontalCounter[x, 2]++;
                    break;
                case 4:
                    horizontalCounter[x, 3]++;
                    break;
                case 5:
                    horizontalCounter[x, 4]++;
                    break;
                case 6:
                    horizontalCounter[x, 5]++;
                    break;
                case 7:
                    horizontalCounter[x, 6]++;
                    break;
                case 8:
                    horizontalCounter[x, 7]++;
                    break;
                case 9:
                    horizontalCounter[x, 8]++;
                    break;
            }
        }

        private void verticalLinesCounter(int y, int x)
        {
            switch (gf[y, x])
            {
                case 1:
                    verticalCounter[x, 0]++;
                    break;
                case 2:
                    verticalCounter[x, 1]++;
                    break;
                case 3:
                    verticalCounter[x, 2]++;
                    break;
                case 4:
                    verticalCounter[x, 3]++;
                    break;
                case 5:
                    verticalCounter[x, 4]++;
                    break;
                case 6:
                    verticalCounter[x, 5]++;
                    break;
                case 7:
                    verticalCounter[x, 6]++;
                    break;
                case 8:
                    verticalCounter[x, 7]++;
                    break;
                case 9:
                    verticalCounter[x, 8]++;
                    break;
            }
        }

        private void smallSqueresCounter(int x, int y, int squere)
        {
            switch (gf[x, y])
            {
                case 1:
                    smallCounter[squere, 0]++;
                    break;
                case 2:
                    smallCounter[squere, 1]++;
                    break;
                case 3:
                    smallCounter[squere, 2]++;
                    break;
                case 4:
                    smallCounter[squere, 3]++;
                    break;
                case 5:
                    smallCounter[squere, 4]++;
                    break;
                case 6:
                    smallCounter[squere, 5]++;
                    break;
                case 7:
                    smallCounter[squere, 6]++;
                    break;
                case 8:
                    smallCounter[squere, 7]++;
                    break;
                case 9:
                    smallCounter[squere, 8]++;
                    break;
            }
        }

        private void checkGame1()
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (x < 3)
                    {
                        if (y < 3)
                        {
                            smallSqueresCounter(x, y, 0);
                        }
                        else if (y >= 3 && y < 6)
                        {
                            smallSqueresCounter(x, y, 1);
                        }
                        else if (y >= 6)
                        {
                            smallSqueresCounter(x, y, 2);
                        }
                    }
                    else if (x >= 3 && x < 6)
                    {
                        if (y < 3)
                        {
                            smallSqueresCounter(x, y, 3);
                        }
                        else if (y >= 3 && y < 6)
                        {
                            smallSqueresCounter(x, y, 4);
                        }
                        else if (y >= 6)
                        {
                            smallSqueresCounter(x, y, 5);
                        }
                    }
                    else
                    {
                        if (y < 3)
                        {
                            smallSqueresCounter(x, y, 6);
                        }
                        else if (y >= 3 && y < 6)
                        {
                            smallSqueresCounter(x, y, 7);
                        }
                        else if (y >= 6)
                        {
                            smallSqueresCounter(x, y, 8);
                        }
                    }
                    horizontalLinesCounter(x, y);
                    verticalLinesCounter(y, x);
                }
            }
        }

        private void checkGame2()
        {
            for (int x = 0; x < 9; x++)
            {
                if (horizontalCounter[x, 0] == 1 && horizontalCounter[x, 1] == 1 && horizontalCounter[x, 2] == 1 && horizontalCounter[x, 3] == 1 && horizontalCounter[x, 4] == 1 && horizontalCounter[x, 5] == 1 && horizontalCounter[x, 6] == 1 && horizontalCounter[x, 7] == 1 && horizontalCounter[x, 8] == 1) horizontalLines++;
                if (verticalCounter[x, 0] == 1 && verticalCounter[x, 1] == 1 && verticalCounter[x, 2] == 1 && verticalCounter[x, 3] == 1 && verticalCounter[x, 4] == 1 && verticalCounter[x, 5] == 1 && verticalCounter[x, 6] == 1 && verticalCounter[x, 7] == 1 && verticalCounter[x, 8] == 1) verticalLines++;
                if (smallCounter[x, 0] == 1 && smallCounter[x, 1] == 1 && smallCounter[x, 2] == 1 && smallCounter[x, 3] == 1 && smallCounter[x, 4] == 1 && smallCounter[x, 5] == 1 && smallCounter[x, 6] == 1 && smallCounter[x, 7] == 1 && smallCounter[x, 8] == 1) smallSqueres++;
            }
            //System.out.println("Poziome linie ok: "+horizontalLines);
            //System.out.println("Pionowe linie ok: "+verticalLines);
            //System.out.println("Małe kwadraty ok: "+smallSqueres);
            if (horizontalLines == 9 && verticalLines == 9 && smallSqueres == 9) MessageBox.Show("Gratulacje :) rozwiązanie poprawne!");
            else MessageBox.Show("Niestety :( Twoje rozwiązanie zawiera błędy");
        }
        */
    }
}
