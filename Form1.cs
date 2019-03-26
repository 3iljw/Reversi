using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//  此程式為黑白棋
//  但尚未優化，故會執行的較慢，
//  原因為過多例外狀況(按越多 錯越多)，
//  而這位李姓工程師太懶所以沒去修 抱歉

//  進程
//  將Go_check()功能拆開改成"判斷是否能下在此位置" 以及 "執行吃子之動作"
//  判斷黑棋白棋是否可繼續下子 若是不行 則自動換對手下，雙方都不能下，則結束遊戲
//  此判斷由Go_check()的功能"判斷是否能下在此位置"來實作
//  for loop所有的棋格傳入Go_check 來判斷 回傳的參數為bicm & wicm
namespace Visual_studio
{
    public partial class Form1 : Form
    {
        Label[,] gobroad = new Label[8, 8];         // 棋盤物件
        Boolean change_hands;                       // 換黑子下 => true 換白子下 => false
        Boolean chess_check;                        // 可以下在這裡 =>true 反之 => false
        int b, w;                                   // 記錄黑子與白子的數量
        //int bicm = 1, wicm = 1;                     // 判斷黑棋白棋是否可繼續下子 若是不行 則自動換對手下，雙方都不能下，則結束遊戲

        public Form1()
        {
            InitializeComponent();
        }

        public int Broad_updat_check(int check)     // 更新並且判斷版面是否能繼續遊戲
        {
            int i, j;
            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    gobroad[i, j].ForeColor = gobroad[i, j].BackColor;
                    gobroad[i, j].Font = new Font("Calibri",5f,FontStyle.Regular);
                    if (gobroad[i,j].Text == "-1")
                        gobroad[i, j].Image = Resource1.W;
                    else if (gobroad[i, j].Text == "-2")
                        gobroad[i, j].Image = Resource1.B;
                }
            }
            Black_count();
            White_count();
            if (b+w == 64)                //棋子已放滿
                return 1;                   
            else                            //棋子未放滿
                return 0;   
        }

        public void Initialization()                // 棋盤初始化
        {
            turn.SendToBack();
            turn.Location = new Point(7,14);
            change_hands = true;
            int i;
            for (i = 0; i < 64; i++)
            {
                Label la = new Label
                {
                    Name = "la" + i,
                    Size = new Size(50, 50),
                    Location = new Point(35 + ((i % 8) * 50), 100 + ((i / 8) * 50)),
                    BackColor = Color.BurlyWood,
                    Visible = true
                };
                if ((i % 2 == 1 && i / 8 % 2 == 0) || (i % 2 == 0 && i / 8 % 2 == 1))
                    la.BackColor = Color.Bisque;
                this.Controls.Add(la);

                gobroad[i / 8, i % 8] = la;
  
            }

            for (int j = 0; j < 8; j++)
            {
                for (int k = 0; k < 8; k++)
                {
                    gobroad[j, k].Text = (j*8+k).ToString();
                }
            } 

            gobroad[3, 3].Text = "-1";
            gobroad[4, 4].Text = "-1";
            gobroad[3, 4].Text = "-2";
            gobroad[4, 3].Text = "-2";
            Broad_updat_check(0);
            
        }

        public void Show_result()                   // 結果計算
        {
            Black_count();
            White_count();
            if (b > w)
                VS.Text = ("Black Win");
            else if (w > b)
                VS.Text = ("White Win");
            else
                VS.Text = ("Tie");
            turn.Location = new Point(163, 14);
        }        

        public int Black_count()                    // 黑棋數量計算
        {
            int i, j;
            int count;
            count = 0;
            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    if (gobroad[i, j].Text == "-2")
                        count++;
                }
            }
            blackx.Text = "x" + count;
            b = count;
            return b;
        }

        public int White_count()                    // 白棋數量計算
        {
            int i, j;
            int count;
            count = 0;
            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    if (gobroad[i, j].Text == "-1")
                        count = count +1;
                }
            }
            whitex.Text = "x" + count;
            w = count;
            return w;
        }

        public void Go_check(/*object sender,*/String A)              // 判斷是否能下在此位置
        {
            Label[,] axis = new Label[8,8];
            int x = 0, y = 0, neighbor = 0;
            neighbor = 0;
            x = (Int16.Parse(A)) / 8;
            y = (Int16.Parse(A)) % 8;
            
            for (int i = 0; i < 8; i++)                 // 清洗被點取的棋格之相對座標
            {
                for (int j = 0; j < 8; j++)
                {
                    axis[i, j] = null;
                }
            }          // 清洗被點取的棋格之相對座標

            for (int i = 0; i < 8; i++)              // 定義被點取的棋格之相對座標
            {
                for (int j = 0; j < 8; j++)
                {
                    try
                    {
                        switch (j)
                        {
                            case 0:
                                axis[i, j] = gobroad[x - 1 - i, y - 1 - i];
                                break;
                            case 1:
                                axis[i, j] = gobroad[x - 1 - i, y];
                                break;
                            case 2:
                                axis[i, j] = gobroad[x - 1 - i, y + 1 + i];
                                break;
                            case 3:
                                axis[i, j] = gobroad[x, y - 1 - i];
                                break;
                            case 4:
                                axis[i, j] = gobroad[x, y + 1 + i];
                                break;
                            case 5:
                                axis[i, j] = gobroad[x + 1 + i, y - 1 - i];
                                break;
                            case 6:
                                axis[i, j] = gobroad[x + 1 + i, y];
                                break;
                            case 7:
                                axis[i, j] = gobroad[x + 1 + i, y + 1 + i];
                                break;
                        }
                    }
                    catch (System.IndexOutOfRangeException)
                    {
                        continue;
                    }

                }
            }          // 定義被點取的棋格之相對座標

            if (A!="-1" && A!="-2")
            {
                if (change_hands == true)           // 現在是黑棋下
                {
                    for (int j = 0; j < 8; j++)
                    {
                        try
                        {
                            if (axis[0, j].Text == "-1")                // 判斷周圍是否有白棋
                            {
                                neighbor = 1;
                                for (int i = 1; i < 8; i++)
                                {
                                    if (axis[i, j].Text == "-1")
                                        neighbor = neighbor + 1; 
                                    if (neighbor == i && axis[i, j].Text == "-2")        // 判斷周圍白棋之延伸是否有黑棋
                                    {
                                        VS.Text = "VS";
                                        neighbor = 100;                                        
                                        chess_check = true;
                                        for (int a = 0; a < i; a++)     // 吃子
                                        {
                                            switch (j)
                                            {
                                                case 0:
                                                    gobroad[x - 1 - a, y - 1 - a].Text = "-2";
                                                    break;
                                                case 1:
                                                    gobroad[x - 1 - a, y].Text = "-2";
                                                    break;
                                                case 2:
                                                    gobroad[x - 1 - a, y + 1 + a].Text = "-2";
                                                    break;
                                                case 3:
                                                    gobroad[x, y - 1 - a].Text = "-2";
                                                    break;
                                                case 4:
                                                    gobroad[x, y + 1 + a].Text = "-2";
                                                    break;
                                                case 5:
                                                    gobroad[x + 1 + a, y - 1 - a].Text = "-2";
                                                    break;
                                                case 6:
                                                    gobroad[x + 1 + a, y].Text = "-2";
                                                    break;
                                                case 7:
                                                    gobroad[x + 1 + a, y + 1 + a].Text = "-2";
                                                    break;
                                            }
                                        }  
                                        break;                          // 吃子
                                    }
                                    else if (i == 7 && neighbor !=100) // 周圍白棋之延伸沒有黑棋
                                        chess_check = false;
                                }
                                continue;
                            }

                            if (j == 7 && neighbor==0)                 // 周圍沒有白棋
                                chess_check = false;
                        }
                        catch (System.NullReferenceException)
                        {
                           continue;
                        }
                        catch (System.IndexOutOfRangeException)
                        {
                            continue;
                        }

                    }
                }        // 黑子下
                if (change_hands == false)           // 現在是白棋下
                {
                    for (int j = 0; j < 8; j++)
                    {
                        try
                        {
                            if (axis[0, j].Text == "-2")                // 判斷周圍是否有黑棋
                            {
                                neighbor = 1;
                                for (int i = 1; i < 8; i++)
                                {
                                    if (axis[i, j].Text == "-2")
                                        neighbor = neighbor + 1;
                                    if (neighbor == i && axis[i, j].Text == "-1")        // 判斷周圍黑棋之延伸是否有白棋
                                    {
                                        VS.Text = "VS";
                                        neighbor = 100;                                        
                                        chess_check = true;
                                        for (int a = 0; a < i; a++)     // 吃子
                                        {
                                            switch (j)
                                            {
                                                case 0:
                                                    gobroad[x - 1 - a, y - 1 - a].Text = "-1";
                                                    break;
                                                case 1:
                                                    gobroad[x - 1 - a, y].Text = "-1";
                                                    break;
                                                case 2:
                                                    gobroad[x - 1 - a, y + 1 + a].Text = "-1";
                                                    break;
                                                case 3:
                                                    gobroad[x, y - 1 - a].Text = "-1";
                                                    break;
                                                case 4:
                                                    gobroad[x, y + 1 + a].Text = "-1";
                                                    break;
                                                case 5:
                                                    gobroad[x + 1 + a, y - 1 - a].Text = "-1";
                                                    break;
                                                case 6:
                                                    gobroad[x + 1 + a, y].Text = "-1";
                                                    break;
                                                case 7:
                                                    gobroad[x + 1 + a, y + 1 + a].Text = "-1";
                                                    break;
                                            }
                                        }
                                        break;                          // 吃子
                                    }
                                    else if (i == 7 && neighbor !=100) // 周圍黑棋之延伸沒有白棋
                                        chess_check = false;
                                }
                                continue;
                            }

                            if (j == 7 && neighbor == 0)                 // 周圍沒有黑棋
                                chess_check = false;
                        }
                        catch (System.NullReferenceException)
                        {
                            continue;
                        }
                        catch (System.IndexOutOfRangeException)
                        {
                            continue;
                        }

                    }
                }       // 白子下
            }
            else
                chess_check = false;

            Broad_updat_check(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Initialization();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    gobroad[i,j].Click += new EventHandler(lb_Click);
                }
            }
        }   // 主程式

        private void lb_Click(object sender, EventArgs e)       //label_click 
        {
            //throw new NotImplementedException();
            int check = 0;
            int b1 = 0, w1 = 0; //比較值
            Label click = sender as Label;
            string a = click.Text;
            b1 = b;
            w1 = w;
            Broad_updat_check(check);
            if (check == 0)                                     // 確定盤面還有空位
            {
                if (change_hands == true)                       // 黑子下
                {
                    Go_check(/*click,*/a);
                    if (chess_check == true)
                    {
                        click.Text = "-2";
                        change_hands = false;                   // 換手
                        turn.Location = new Point(318, 14);
                        chess_check = false;
                    }
                }
                else if (change_hands == false)                 // 白子下
                {
                    Go_check(/*click,*/a);
                    if (chess_check == true)
                    {
                        click.Text = "-1";
                        change_hands = true;                    // 換手
                        turn.Location = new Point(7, 14);
                        chess_check = false;
                    }
                }
                if (b1 == b || w1 == w)
                {
                    VS.Text = "ERROR";
                }
            }

            if (Broad_updat_check(check) == 1)                  // 沒空位了 遊戲結束
                Show_result();
        }

    }
}
