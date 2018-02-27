using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navigation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            createGraph();
            InitializeComponent();
            pictureInitialize(1);
            pictureInitialize(2);
        }
        int MAX = 20000;
        int distance = 0;
        public bool[, ,] P = new bool[N, N, N];
        public int box = 0;//标注当前光标所在框的编号
        static int N = 17; //声明共有17个节点

        //static int[] Vex_location_x = new int[N];//建立坐标横轴值
        //static int[] Vex_location_y = new int[N];//建立坐标纵轴值
        static int[] Vex_number = new int[N];//建立节点编号

        static string[] Vex_info = new string[N];//建立景点介绍信息
        static string[] Vex_sight = new string[N];//建立景点的名称信息

        static int[,] Arc_Legth = new int[N, N];//建立节点间的距离数组

        string[,] new_vexnum = new string[N, N];
        int[] choices = new int[N];  //用于保存求最佳游览线路时的节点是否需要游览 
        int StartPoint = 0;
        
        static int[] newPath_value = new int[N];//用于保存新的路线带权长度

        public void createGraph()
        {
            for (int i = 1; i < N; i++)
            {
                Vex_number[i] = i;
            }
            Vex_info[1] = "全校最大的学生公寓群，位于华科西部";
            Vex_info[2] = "较小的学生公寓群，用于计算机学院学生居住";
            Vex_info[3] = "另一较大的学生公寓群，其中有著名的公主楼，位于华科东部";
            Vex_info[4] = "华科南大门，有著名的毛主席招手的雕像";
            Vex_info[5] = "华科学霸聚集地，由新馆和老馆组成";
            Vex_info[6] = "大学生活动中心，各种学生组织聚集地，周边银行较多";
            Vex_info[7] = "位于西边，是西边学生的活动中心";
            Vex_info[8] = "最大也是最好的运动场，每年军训阅兵式举办地";
            Vex_info[9] = "东边学生的活动中心";
            Vex_info[10] = "夏天醉晚亭与荷花的交相辉映是难得的美景";
            Vex_info[11] = "近两年建成，记载着华科不算悠久但值得缅怀的历史";
            Vex_info[12] = "位于东边的一个以爱因斯坦的雕像为主题的小广场";
            Vex_info[13] = "亚洲第三楼，华科第二大教学楼";
            Vex_info[14] = "亚洲第一楼，华科最大教学楼";
            Vex_info[15] = "华科最著名的实验室，没有之一";
            Vex_info[16] = "一个个进去，一对对出来，风景很好的小公园";

            Vex_sight[1] = "紫崧公寓";
            Vex_sight[2] = "沁苑公寓";
            Vex_sight[3] = "韵苑公寓";
            Vex_sight[4] = "南大门";
            Vex_sight[5] = "图书馆";
            Vex_sight[6] = "大活";
            Vex_sight[7] = "西操";
            Vex_sight[8] = "中操";
            Vex_sight[9] = "东操";
            Vex_sight[10] = "醉晚亭";
            Vex_sight[11] = "校史馆";
            Vex_sight[12] = "爱广";
            Vex_sight[13] = "西十二楼";
            Vex_sight[14] = "东九楼";
            Vex_sight[15] = "光电实验室";
            Vex_sight[16] = "青年园";

            
        }
      
        private void pictureInitialize(int box)
        {
            if (box == 1)
            {
                pictureBox1.Visible = false;
                pictureBox3.Visible = false;
                pictureBox9.Visible = false;
                pictureBox7.Visible = false;
                pictureBox5.Visible = false;
                pictureBox20.Visible = false;
                pictureBox18.Visible = false;
                pictureBox16.Visible = false;
                pictureBox14.Visible = false;
                pictureBox12.Visible = false;
                pictureBox11.Visible = false;
                pictureBox24.Visible = false;
                pictureBox23.Visible = false;
                pictureBox29.Visible = false;
                pictureBox27.Visible = false;
                pictureBox31.Visible = false;
            }
            if (box == 2)
            {
                pictureBox2.Visible = false;
                pictureBox4.Visible = false;
                pictureBox10.Visible = false;
                pictureBox8.Visible = false;
                pictureBox6.Visible = false;
                pictureBox21.Visible = false;
                pictureBox19.Visible = false;
                pictureBox17.Visible = false;
                pictureBox15.Visible = false;
                pictureBox13.Visible = false;
                pictureBox26.Visible = false;
                pictureBox25.Visible = false;
                pictureBox22.Visible = false;
                pictureBox30.Visible = false;
                pictureBox28.Visible = false;
                pictureBox32.Visible = false;
            }
        }
        //
        //绘制地标点
        //
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            box = 1;
            pictureInitialize(1);
            if (comboBox1.Text == "紫崧公寓") { display(Vex_number[1]); pictureBox1.Visible = true; }
            if (comboBox1.Text == "沁苑公寓") { display(Vex_number[2]); pictureBox3.Visible = true; }
            if (comboBox1.Text == "韵苑公寓") { display(Vex_number[3]); pictureBox9.Visible = true; }
            if (comboBox1.Text == "南大门") { display(Vex_number[4]); pictureBox7.Visible = true; }
            if (comboBox1.Text == "图书馆") { display(Vex_number[5]); pictureBox5.Visible = true; }
            if (comboBox1.Text == "大活") { display(Vex_number[6]); pictureBox20.Visible = true; }
            if (comboBox1.Text == "西操") { display(Vex_number[7]); pictureBox18.Visible = true; }
            if (comboBox1.Text == "中操") { display(Vex_number[8]); pictureBox16.Visible = true; }
            if (comboBox1.Text == "东操") { display(Vex_number[9]); pictureBox14.Visible = true; }
            if (comboBox1.Text == "醉晚亭") { display(Vex_number[10]); pictureBox12.Visible = true; }
            if (comboBox1.Text == "校史馆") { display(Vex_number[11]); pictureBox11.Visible = true; }
            if (comboBox1.Text == "爱广") { display(Vex_number[12]); pictureBox24.Visible = true; }
            if (comboBox1.Text == "西十二楼") { display(Vex_number[13]); pictureBox23.Visible = true; }
            if (comboBox1.Text == "东九楼") { display(Vex_number[14]); pictureBox29.Visible = true; }
            if (comboBox1.Text == "光电实验室") { display(Vex_number[15]); pictureBox27.Visible = true; }
            if (comboBox1.Text == "青年园") { display(Vex_number[16]); pictureBox31.Visible = true; }
        }
        //
        //下拉菜单1的操作
        //
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            box = 2;
            pictureInitialize(2);
            if (comboBox2.Text == "紫崧公寓") { display(Vex_number[1]); pictureBox2.Visible = true; }
            if (comboBox2.Text == "沁苑公寓") { display(Vex_number[2]); pictureBox4.Visible = true; }
            if (comboBox2.Text == "韵苑公寓") { display(Vex_number[3]); pictureBox10.Visible = true; }
            if (comboBox2.Text == "南大门") { display(Vex_number[4]); pictureBox8.Visible = true; }
            if (comboBox2.Text == "图书馆") { display(Vex_number[5]); pictureBox6.Visible = true; }
            if (comboBox2.Text == "大活") { display(Vex_number[6]); pictureBox21.Visible = true; }
            if (comboBox2.Text == "西操") { display(Vex_number[7]); pictureBox19.Visible = true; }
            if (comboBox2.Text == "中操") { display(Vex_number[8]); pictureBox17.Visible = true; }
            if (comboBox2.Text == "东操") { display(Vex_number[9]); pictureBox15.Visible = true; }
            if (comboBox2.Text == "醉晚亭") { display(Vex_number[10]); pictureBox13.Visible = true; }
            if (comboBox2.Text == "校史馆") { display(Vex_number[11]); pictureBox26.Visible = true; }
            if (comboBox2.Text == "爱广") { display(Vex_number[12]); pictureBox25.Visible = true; }
            if (comboBox2.Text == "西十二楼") { display(Vex_number[13]); pictureBox22.Visible = true; }
            if (comboBox2.Text == "东九楼") { display(Vex_number[14]); pictureBox30.Visible = true; }
            if (comboBox2.Text == "光电实验室") { display(Vex_number[15]); pictureBox28.Visible = true; }
            if (comboBox2.Text == "青年园") { display(Vex_number[16]); pictureBox32.Visible = true; }
        }
       
        private void display(int x)
        {
            int i = 1;
            for (i = 1; i < N; i++)
                if (i == x)
                    if (box == 1)
                    { textBox6.Text = Vex_info[i]; }
                    else if (box == 2)
                    { textBox7.Text = Vex_info[i];  }
        }
        
        private void Floyd()
        {
            distance = 0;
            Arc_Legth[1, 7] = Arc_Legth[7, 1] = 200;
            Arc_Legth[1, 13] = Arc_Legth[13, 1] = 300;
            Arc_Legth[13, 16] = Arc_Legth[16, 13] = 300;
            Arc_Legth[7, 16] = Arc_Legth[16, 7] = 100;
            Arc_Legth[5, 16] = Arc_Legth[16, 5] = 100;
            Arc_Legth[5, 6] = Arc_Legth[6, 5] = 300;
            Arc_Legth[6, 11] = Arc_Legth[11, 6] = 250;
            Arc_Legth[5, 11] = Arc_Legth[11, 5] = 100;
            Arc_Legth[4, 11] = Arc_Legth[11, 4] = 300;
            Arc_Legth[4, 10] = Arc_Legth[10, 4] = 400;
            Arc_Legth[10, 11] = Arc_Legth[11, 10] = 300;
            Arc_Legth[8, 10] = Arc_Legth[10, 8] = 300;
            Arc_Legth[2, 8] = Arc_Legth[8, 2] = 200;
            Arc_Legth[2, 14] = Arc_Legth[14, 2] = 1200;
            Arc_Legth[14, 15] = Arc_Legth[15, 14] = 200;
            Arc_Legth[9, 14] = Arc_Legth[14, 9] = 400;
            Arc_Legth[3, 9] = Arc_Legth[9, 3] = 200;
            Arc_Legth[3, 12] = Arc_Legth[12, 3] = 50;
            
            for (int c = 1; c < N; c++)
                for (int d = 1; d < N; d++)
                    if (Arc_Legth[c, d] == 0 && c != d)
                        Arc_Legth[c, d] = MAX;
            for (int v = 1; v < N; v++)
                for (int w = 1; w < N; w++)
                {
                    for (int u = 0; u < N; u++)
                        P[v, w, u] = false;
                    if (Arc_Legth[v, w] < MAX)
                    {
                        P[v, w, v] = true;
                        P[v, w, w] = true;
                    }
                }
            for (int v = 1; v < N; v++)
                for (int w = 1; w < N; w++)
                    for (int u = 1; u < N; u++)
                        if (Arc_Legth[v, u] + Arc_Legth[u, w] < Arc_Legth[v, w])
                        {
                            Arc_Legth[v, w] = Arc_Legth[v, u] + Arc_Legth[u, w];
                            new_vexnum[v, w] = new_vexnum[v, u] + u + "/" + new_vexnum[u, w];
                            for (int i = 1; i < N; i++)
                                P[v, w, i] = P[v, u, i] || P[u, w, i];
                        }
        }
        //
        //求出最短加权路径以及路线顺序,佛洛依德算法
        //
        private void showroad()
        {
            Floyd();
            int n = 0, k = 0;
            int p = 0, q = 0;
            for (int m = 1; m < N; m++)
            {
                if (comboBox1.Text == Vex_sight[m])
                    n = m;
                if (comboBox2.Text == Vex_sight[m])
                    k = m;
            }

            textBox5.Text = Vex_sight[n];
            textBox5.Text += "→";
            if (new_vexnum[n, k] != null)
            {
                string[] new_path = new_vexnum[n, k].Split('/');
                int[] connect = new int[new_path.Length + 1];
                connect[0] = n; connect[new_path.Length] = k;
                for (int i = 1; i < new_path.Length; i++)
                {
                    connect[i] = Convert.ToInt16(new_path[i - 1]);
                }
                for (int i = 0; i < new_path.Length; i++)
                {
                    distance += Arc_Legth[connect[i], connect[i + 1]];
                }
                for (int i = 0; i < new_path.Length - 1; i++)
                {
                    p = Convert.ToInt16(new_path[i]);
                    if (i == 0)
                        if (i + 1 < new_path.Length - 1 && i != 0)
                        {
                            p = Convert.ToInt16(new_path[i]);
                        }
                    textBox5.Text += Vex_sight[p];
                    textBox5.Text += "→";
                }
                distance += Arc_Legth[q , k];
            }
            else distance += Arc_Legth[n, k];
            textBox5.Text += Vex_sight[k];
            textBox4.Text = Convert.ToString(distance);
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            Floyd();
            showroad();
            Floyd();
            showroad();
            
        }
        
        
        private void 初始化复位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox1.Text = null;
            comboBox2.Text = null;
            textBox4.Text = null;
            pictureInitialize(1);
            pictureInitialize(2);
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("本系统为华中科技大学部分景点导航系统;\n 作者：CS1205赵子昂，HUST;\n E-mail:dexter.zhza@gmail.com");
        }

        private void 两景点最短距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button1.Enabled = true;
            button2.Enabled = false;
            button2.Visible = false;
            textBox2.Visible = true;
            textBox2.Enabled = true;
            textBox7.Visible = true;
            textBox7.Enabled = true;
            comboBox2.Visible = true;
            comboBox2.Enabled = true;
            checkedListBox1.Visible = false;
            checkedListBox1.Enabled = false;
            comboBox1.Enabled = true;
            textBox4.Visible = true;
            textBox4.Enabled = true;
        }

        private void 起点相同ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button1.Enabled = false;
            button2.Enabled = true;
            button2.Visible = true;
            textBox2.Visible = false;
            textBox2.Enabled = false;
            textBox7.Visible = false;
            textBox7.Enabled = false;
            comboBox2.Visible = false;
            comboBox2.Enabled = false;
            checkedListBox1.Visible = true;
            checkedListBox1.Enabled = true;
            comboBox1.Enabled = false;
            comboBox1.Text ="南大门";
            textBox4.Visible = false;
            textBox4.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Floyd();
            int[] choices = new int[N];  //用于保存求最佳游览线路时的节点是否需要游览 
            int StartPoint = 0;
            int[] route = new int[32];
            for (int m = 1; m < N; m++)
            {
                
                if (comboBox1.Text == Vex_sight[m])
                    StartPoint = m;
            }
            //choices[StartPoint] = 1;
            for (int i = 1; i < N; i++) 
            {
                if (checkedListBox1.GetItemChecked(i-1))
                    choices[i] = 1;
            
            }
            if (choices[13] == 1) 
            {
                route[1] = 11;
                route[2] = 5;
                route[3] = 16;
                route[4] = 13;
                if (choices[1] == 1 || choices[7]==1) 
                {
                    route[5] = 1;
                    route[6] = 7;
                    route[7] = 16;
                    route[8] = 5;
                    if (choices[6] == 1)
                    {
                        route[9] = 6;
                        route[10] = 11;
                        if (choices[15] == 1)
                        {
                            if (choices[12] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 15;
                                route[16] = 14;
                                route[17] = 9;
                                route[18] = 3;
                                route[19] = 12;
                                route[20] = 3;
                                route[21] = 9;
                                route[22] = 14;
                                route[23] = 2;
                                route[24] = 8;
                                route[25] = 10;
                                route[26] = 4;
                            }
                            else if (choices[3] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 15;
                                route[16] = 14;
                                route[17] = 9;
                                route[18] = 3;
                                route[19] = 9;
                                route[20] = 14;
                                route[21] = 2;
                                route[22] = 8;
                                route[23] = 10;
                                route[24] = 4;

                            }
                            else if (choices[9] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 15;
                                route[16] = 14;
                                route[17] = 9;
                                route[18] = 14;
                                route[19] = 2;
                                route[20] = 8;
                                route[21] = 10;
                                route[22] = 4;

                            }
                            else
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 15;
                                route[16] = 14;
                                route[17] = 2;
                                route[18] = 8;
                                route[19] = 10;
                                route[20] = 4;

                            }
                        }
                        else
                        {
                            if (choices[12] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 9;
                                route[16] = 3;
                                route[17] = 12;
                                route[18] = 3;
                                route[19] = 9;
                                route[20] = 14;
                                route[21] = 2;
                                route[22] = 8;
                                route[23] = 10;
                                route[24] = 4;

                            }
                            else if (choices[3] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 9;
                                route[16] = 3;
                                route[17] = 9;
                                route[18] = 14;
                                route[19] = 2;
                                route[20] = 8;
                                route[21] = 10;
                                route[22] = 4;


                            }
                            else if (choices[9] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 9;
                                route[16] = 14;
                                route[17] = 2;
                                route[18] = 8;
                                route[19] = 10;
                                route[20] = 4;


                            }
                            else if (choices[14] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 2;
                                route[16] = 8;
                                route[17] = 10;
                                route[18] = 4;
                            }
                            else if (choices[2] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 8;
                                route[15] = 10;
                                route[16] = 4;
                            }
                            else if (choices[8] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 10;
                                route[14] = 4;

                            }
                            else if (choices[10] == 1)
                            {
                                route[11] = 10;
                                route[12] = 4;

                            }
                            else 
                            {
                                route[11] = 4;
                            }

                        }

                    }
                    else                     
                    {
                            route[9] = 20;
                            route[10] = 11;
                            if (choices[15] == 1)
                            {
                                if (choices[12] == 1)
                                {
                                    route[11] = 10;
                                    route[12] = 8;
                                    route[13] = 2;
                                    route[14] = 14;
                                    route[15] = 15;
                                    route[16] = 14;
                                    route[17] = 9;
                                    route[18] = 3;
                                    route[19] = 12;
                                    route[20] = 3;
                                    route[21] = 9;
                                    route[22] = 14;
                                    route[23] = 2;
                                    route[24] = 8;
                                    route[25] = 10;
                                    route[26] = 4;
                                }
                                else if (choices[3] == 1)
                                {
                                    route[11] = 10;
                                    route[12] = 8;
                                    route[13] = 2;
                                    route[14] = 14;
                                    route[15] = 15;
                                    route[16] = 14;
                                    route[17] = 9;
                                    route[18] = 3;
                                    route[19] = 9;
                                    route[20] = 14;
                                    route[21] = 2;
                                    route[22] = 8;
                                    route[23] = 10;
                                    route[24] = 4;

                                }
                                else if (choices[9] == 1)
                                {
                                    route[11] = 10;
                                    route[12] = 8;
                                    route[13] = 2;
                                    route[14] = 14;
                                    route[15] = 15;
                                    route[16] = 14;
                                    route[17] = 9;
                                    route[18] = 14;
                                    route[19] = 2;
                                    route[20] = 8;
                                    route[21] = 10;
                                    route[22] = 4;

                                }
                                else
                                {
                                    route[11] = 10;
                                    route[12] = 8;
                                    route[13] = 2;
                                    route[14] = 14;
                                    route[15] = 15;
                                    route[16] = 14;
                                    route[17] = 2;
                                    route[18] = 8;
                                    route[19] = 10;
                                    route[20] = 4;

                                }
                            }
                            else
                            {
                                if (choices[12] == 1)
                                {
                                    route[11] = 10;
                                    route[12] = 8;
                                    route[13] = 2;
                                    route[14] = 14;
                                    route[15] = 9;
                                    route[16] = 3;
                                    route[17] = 12;
                                    route[18] = 3;
                                    route[19] = 9;
                                    route[20] = 14;
                                    route[21] = 2;
                                    route[22] = 8;
                                    route[23] = 10;
                                    route[24] = 4;

                                }
                                else if (choices[3] == 1)
                                {
                                    route[11] = 10;
                                    route[12] = 8;
                                    route[13] = 2;
                                    route[14] = 14;
                                    route[15] = 9;
                                    route[16] = 3;
                                    route[17] = 9;
                                    route[18] = 14;
                                    route[19] = 2;
                                    route[20] = 8;
                                    route[21] = 10;
                                    route[22] = 4;


                                }
                                else if (choices[9] == 1)
                                {
                                    route[11] = 10;
                                    route[12] = 8;
                                    route[13] = 2;
                                    route[14] = 14;
                                    route[15] = 9;
                                    route[16] = 14;
                                    route[17] = 2;
                                    route[18] = 8;
                                    route[19] = 10;
                                    route[20] = 4;


                                }
                                else if (choices[14] == 1)
                                {
                                    route[11] = 10;
                                    route[12] = 8;
                                    route[13] = 2;
                                    route[14] = 14;
                                    route[15] = 2;
                                    route[16] = 8;
                                    route[17] = 10;
                                    route[18] = 4;
                                }
                                else if (choices[2] == 1)
                                {
                                    route[11] = 10;
                                    route[12] = 8;
                                    route[13] = 2;
                                    route[14] = 8;
                                    route[15] = 10;
                                    route[16] = 4;
                                }
                                else if (choices[8] == 1)
                                {
                                    route[11] = 10;
                                    route[12] = 8;
                                    route[13] = 10;
                                    route[14] = 4;

                                }
                                else if (choices[10] == 1)
                                {
                                    route[11] = 10;
                                    route[12] = 4;


                                }
                                else 
                                {
                                    route[11] = 4;
                                }

                            }

                        }
                         
                }
                else 
                {
                    route[5] = 16;
                    route[6] = 5;
                    route[7] = 20;
                    route[8] = 20;
                    if (choices[6] == 1)
                    {
                        route[9] = 6;
                        route[10] = 11;
                        if (choices[15] == 1)
                        {
                            if (choices[12] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 15;
                                route[16] = 14;
                                route[17] = 9;
                                route[18] = 3;
                                route[19] = 12;
                                route[20] = 3;
                                route[21] = 9;
                                route[22] = 14;
                                route[23] = 2;
                                route[24] = 8;
                                route[25] = 10;
                                route[26] = 4;
                            }
                            else if (choices[3] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 15;
                                route[16] = 14;
                                route[17] = 9;
                                route[18] = 3;
                                route[19] = 9;
                                route[20] = 14;
                                route[21] = 2;
                                route[22] = 8;
                                route[23] = 10;
                                route[24] = 4;

                            }
                            else if (choices[9] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 15;
                                route[16] = 14;
                                route[17] = 9;
                                route[18] = 14;
                                route[19] = 2;
                                route[20] = 8;
                                route[21] = 10;
                                route[22] = 4;

                            }
                            else
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 15;
                                route[16] = 14;
                                route[17] = 2;
                                route[18] = 8;
                                route[19] = 10;
                                route[20] = 4;

                            }
                        }
                        else
                        {
                            if (choices[12] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 9;
                                route[16] = 3;
                                route[17] = 12;
                                route[18] = 3;
                                route[19] = 9;
                                route[20] = 14;
                                route[21] = 2;
                                route[22] = 8;
                                route[23] = 10;
                                route[24] = 4;

                            }
                            else if (choices[3] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 9;
                                route[16] = 3;
                                route[17] = 9;
                                route[18] = 14;
                                route[19] = 2;
                                route[20] = 8;
                                route[21] = 10;
                                route[22] = 4;


                            }
                            else if (choices[9] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 9;
                                route[16] = 14;
                                route[17] = 2;
                                route[18] = 8;
                                route[19] = 10;
                                route[20] = 4;


                            }
                            else if (choices[14] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 2;
                                route[16] = 8;
                                route[17] = 10;
                                route[18] = 4;
                            }
                            else if (choices[2] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 8;
                                route[15] = 10;
                                route[16] = 4;
                            }
                            else if (choices[8] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 10;
                                route[14] = 4;

                            }
                            else if (choices[10] == 1)
                            {
                                route[11] = 10;
                                route[12] = 4;

                            }
                            else
                            {
                                route[11] = 4;
                            }

                        }

                    }
                    else
                    {
                        route[9] = 20;
                        route[10] = 11;
                        if (choices[15] == 1)
                        {
                            if (choices[12] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 15;
                                route[16] = 14;
                                route[17] = 9;
                                route[18] = 3;
                                route[19] = 12;
                                route[20] = 3;
                                route[21] = 9;
                                route[22] = 14;
                                route[23] = 2;
                                route[24] = 8;
                                route[25] = 10;
                                route[26] = 4;
                            }
                            else if (choices[3] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 15;
                                route[16] = 14;
                                route[17] = 9;
                                route[18] = 3;
                                route[19] = 9;
                                route[20] = 14;
                                route[21] = 2;
                                route[22] = 8;
                                route[23] = 10;
                                route[24] = 4;

                            }
                            else if (choices[9] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 15;
                                route[16] = 14;
                                route[17] = 9;
                                route[18] = 14;
                                route[19] = 2;
                                route[20] = 8;
                                route[21] = 10;
                                route[22] = 4;

                            }
                            else
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 15;
                                route[16] = 14;
                                route[17] = 2;
                                route[18] = 8;
                                route[19] = 10;
                                route[20] = 4;

                            }
                        }
                        else
                        {
                            if (choices[12] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 9;
                                route[16] = 3;
                                route[17] = 12;
                                route[18] = 3;
                                route[19] = 9;
                                route[20] = 14;
                                route[21] = 2;
                                route[22] = 8;
                                route[23] = 10;
                                route[24] = 4;

                            }
                            else if (choices[3] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 9;
                                route[16] = 3;
                                route[17] = 9;
                                route[18] = 14;
                                route[19] = 2;
                                route[20] = 8;
                                route[21] = 10;
                                route[22] = 4;


                            }
                            else if (choices[9] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 9;
                                route[16] = 14;
                                route[17] = 2;
                                route[18] = 8;
                                route[19] = 10;
                                route[20] = 4;


                            }
                            else if (choices[14] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 14;
                                route[15] = 2;
                                route[16] = 8;
                                route[17] = 10;
                                route[18] = 4;
                            }
                            else if (choices[2] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 2;
                                route[14] = 8;
                                route[15] = 10;
                                route[16] = 4;
                            }
                            else if (choices[8] == 1)
                            {
                                route[11] = 10;
                                route[12] = 8;
                                route[13] = 10;
                                route[14] = 4;

                            }
                            else if (choices[10] == 1)
                            {
                                route[11] = 10;
                                route[12] = 4;


                            }
                            else
                            {
                                route[11] = 4;
                            }

                        }

                    }   
                
                }
               
            }
            else if (choices[1] == 1) 
            {
                route[1] = 11;
                route[2] = 5;
                route[3] = 16;
                route[4] = 7;
                route[5] = 1;
                route[6] = 7;
                route[7] = 16;
                route[8] = 5;
                if (choices[6] == 1)
                {
                    route[9] = 6;
                    route[10] = 11;
                    if (choices[15] == 1)
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 12;
                            route[20] = 3;
                            route[21] = 9;
                            route[22] = 14;
                            route[23] = 2;
                            route[24] = 8;
                            route[25] = 10;
                            route[26] = 4;
                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;

                        }
                        else
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;

                        }
                    }
                    else
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 12;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;


                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;


                        }
                        else if (choices[14] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 2;
                            route[16] = 8;
                            route[17] = 10;
                            route[18] = 4;
                        }
                        else if (choices[2] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 8;
                            route[15] = 10;
                            route[16] = 4;
                        }
                        else if (choices[8] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 10;
                            route[14] = 4;

                        }
                        else if (choices[10] == 1)
                        {
                            route[11] = 10;
                            route[12] = 4;

                        }
                        else
                        {
                            route[11] = 4;
                        }

                    }

                }
                else
                {
                    route[9] = 20;
                    route[10] = 11;
                    if (choices[15] == 1)
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 12;
                            route[20] = 3;
                            route[21] = 9;
                            route[22] = 14;
                            route[23] = 2;
                            route[24] = 8;
                            route[25] = 10;
                            route[26] = 4;
                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;

                        }
                        else
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;

                        }
                    }
                    else
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 12;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;


                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;


                        }
                        else if (choices[14] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 2;
                            route[16] = 8;
                            route[17] = 10;
                            route[18] = 4;
                        }
                        else if (choices[2] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 8;
                            route[15] = 10;
                            route[16] = 4;
                        }
                        else if (choices[8] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 10;
                            route[14] = 4;

                        }
                        else if (choices[10] == 1)
                        {
                            route[11] = 10;
                            route[12] = 4;


                        }
                        else
                        {
                            route[11] = 4;
                        }

                    }

                }  
            }
            else if (choices[7] == 1) 
            {
                route[1] = 11;
                route[2] = 5;
                route[3] = 16;
                route[4] = 7;
                route[5] = 16;
                route[6] = 5;
                route[7] = 20;
                route[8] = 20;
                if (choices[6] == 1)
                {
                    route[9] = 6;
                    route[10] = 11;
                    if (choices[15] == 1)
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 12;
                            route[20] = 3;
                            route[21] = 9;
                            route[22] = 14;
                            route[23] = 2;
                            route[24] = 8;
                            route[25] = 10;
                            route[26] = 4;
                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;

                        }
                        else
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;

                        }
                    }
                    else
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 12;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;


                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;


                        }
                        else if (choices[14] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 2;
                            route[16] = 8;
                            route[17] = 10;
                            route[18] = 4;
                        }
                        else if (choices[2] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 8;
                            route[15] = 10;
                            route[16] = 4;
                        }
                        else if (choices[8] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 10;
                            route[14] = 4;

                        }
                        else if (choices[10] == 1)
                        {
                            route[11] = 10;
                            route[12] = 4;

                        }
                        else
                        {
                            route[11] = 4;
                        }

                    }

                }
                else
                {
                    route[9] = 20;
                    route[10] = 11;
                    if (choices[15] == 1)
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 12;
                            route[20] = 3;
                            route[21] = 9;
                            route[22] = 14;
                            route[23] = 2;
                            route[24] = 8;
                            route[25] = 10;
                            route[26] = 4;
                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;

                        }
                        else
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;

                        }
                    }
                    else
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 12;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;


                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;


                        }
                        else if (choices[14] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 2;
                            route[16] = 8;
                            route[17] = 10;
                            route[18] = 4;
                        }
                        else if (choices[2] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 8;
                            route[15] = 10;
                            route[16] = 4;
                        }
                        else if (choices[8] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 10;
                            route[14] = 4;

                        }
                        else if (choices[10] == 1)
                        {
                            route[11] = 10;
                            route[12] = 4;


                        }
                        else
                        {
                            route[11] = 4;
                        }

                    }

                }  


            }
            else if (choices[16] == 1) 
            {
                route[1] = 11;
                route[2] = 5;
                route[3] = 16;
                route[4] = 5;
                route[5] = 20;
                route[6] = 20;
                route[7] = 20;
                route[8] = 20;
                if (choices[6] == 1)
                {
                    route[9] = 6;
                    route[10] = 11;
                    if (choices[15] == 1)
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 12;
                            route[20] = 3;
                            route[21] = 9;
                            route[22] = 14;
                            route[23] = 2;
                            route[24] = 8;
                            route[25] = 10;
                            route[26] = 4;
                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;

                        }
                        else
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;

                        }
                    }
                    else
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 12;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;


                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;


                        }
                        else if (choices[14] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 2;
                            route[16] = 8;
                            route[17] = 10;
                            route[18] = 4;
                        }
                        else if (choices[2] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 8;
                            route[15] = 10;
                            route[16] = 4;
                        }
                        else if (choices[8] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 10;
                            route[14] = 4;

                        }
                        else if (choices[10] == 1)
                        {
                            route[11] = 10;
                            route[12] = 4;

                        }
                        else
                        {
                            route[11] = 4;
                        }

                    }

                }
                else
                {
                    route[9] = 20;
                    route[10] = 11;
                    if (choices[15] == 1)
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 12;
                            route[20] = 3;
                            route[21] = 9;
                            route[22] = 14;
                            route[23] = 2;
                            route[24] = 8;
                            route[25] = 10;
                            route[26] = 4;
                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;

                        }
                        else
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;

                        }
                    }
                    else
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 12;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;


                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;


                        }
                        else if (choices[14] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 2;
                            route[16] = 8;
                            route[17] = 10;
                            route[18] = 4;
                        }
                        else if (choices[2] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 8;
                            route[15] = 10;
                            route[16] = 4;
                        }
                        else if (choices[8] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 10;
                            route[14] = 4;

                        }
                        else if (choices[10] == 1)
                        {
                            route[11] = 10;
                            route[12] = 4;


                        }
                        else
                        {
                            route[11] = 4;
                        }

                    }

                }  
            }
            else if (choices[5] == 1)
            {
                route[1] = 11;
                route[2] = 5;
                route[3] = 20;
                route[4] = 20;
                route[5] = 20;
                route[6] = 20;
                route[7] = 20;
                route[8] = 20;
                if (choices[6] == 1)
                {
                    route[9] = 6;
                    route[10] = 11;
                    if (choices[15] == 1)
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 12;
                            route[20] = 3;
                            route[21] = 9;
                            route[22] = 14;
                            route[23] = 2;
                            route[24] = 8;
                            route[25] = 10;
                            route[26] = 4;
                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;

                        }
                        else
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;

                        }
                    }
                    else
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 12;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;


                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;


                        }
                        else if (choices[14] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 2;
                            route[16] = 8;
                            route[17] = 10;
                            route[18] = 4;
                        }
                        else if (choices[2] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 8;
                            route[15] = 10;
                            route[16] = 4;
                        }
                        else if (choices[8] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 10;
                            route[14] = 4;

                        }
                        else if (choices[10] == 1)
                        {
                            route[11] = 10;
                            route[12] = 4;

                        }
                        else
                        {
                            route[11] = 4;
                        }

                    }

                }
                else
                {
                    route[9] = 20;
                    route[10] = 11;
                    if (choices[15] == 1)
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 12;
                            route[20] = 3;
                            route[21] = 9;
                            route[22] = 14;
                            route[23] = 2;
                            route[24] = 8;
                            route[25] = 10;
                            route[26] = 4;
                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;

                        }
                        else
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;

                        }
                    }
                    else
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 12;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;


                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;


                        }
                        else if (choices[14] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 2;
                            route[16] = 8;
                            route[17] = 10;
                            route[18] = 4;
                        }
                        else if (choices[2] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 8;
                            route[15] = 10;
                            route[16] = 4;
                        }
                        else if (choices[8] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 10;
                            route[14] = 4;

                        }
                        else if (choices[10] == 1)
                        {
                            route[11] = 10;
                            route[12] = 4;


                        }
                        else
                        {
                            route[11] = 4;
                        }

                    }

                }

            }
            else if (choices[11] == 1)
            {
                route[1] = 11;
                route[2] = 20;
                route[3] = 20;
                route[4] = 20;
                route[5] = 20;
                route[6] = 20;
                route[7] = 20;
                route[8] = 20;
                if (choices[6] == 1)
                {
                    route[9] = 6;
                    route[10] = 11;
                    if (choices[15] == 1)
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 12;
                            route[20] = 3;
                            route[21] = 9;
                            route[22] = 14;
                            route[23] = 2;
                            route[24] = 8;
                            route[25] = 10;
                            route[26] = 4;
                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;

                        }
                        else
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;

                        }
                    }
                    else
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 12;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;


                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;


                        }
                        else if (choices[14] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 2;
                            route[16] = 8;
                            route[17] = 10;
                            route[18] = 4;
                        }
                        else if (choices[2] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 8;
                            route[15] = 10;
                            route[16] = 4;
                        }
                        else if (choices[8] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 10;
                            route[14] = 4;

                        }
                        else if (choices[10] == 1)
                        {
                            route[11] = 10;
                            route[12] = 4;

                        }
                        else
                        {
                            route[11] = 4;
                        }

                    }

                }
                else
                {
                    route[9] = 20;
                    route[10] = 20;
                    if (choices[15] == 1)
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 12;
                            route[20] = 3;
                            route[21] = 9;
                            route[22] = 14;
                            route[23] = 2;
                            route[24] = 8;
                            route[25] = 10;
                            route[26] = 4;
                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;

                        }
                        else
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;

                        }
                    }
                    else
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 12;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;


                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;


                        }
                        else if (choices[14] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 2;
                            route[16] = 8;
                            route[17] = 10;
                            route[18] = 4;
                        }
                        else if (choices[2] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 8;
                            route[15] = 10;
                            route[16] = 4;
                        }
                        else if (choices[8] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 10;
                            route[14] = 4;

                        }
                        else if (choices[10] == 1)
                        {
                            route[11] = 10;
                            route[12] = 4;


                        }
                        else
                        {
                            route[11] = 4;
                        }

                    }

                }

            }
            else 
            {
                if (choices[6] == 1)
                {
                    route[1] = 11;
                    route[2] = 20;
                    route[3] = 20;
                    route[4] = 20;
                    route[5] = 20;
                    route[6] = 20;
                    route[7] = 20;
                    route[8] = 20;
                    route[9] = 6;
                    route[10] = 11;
                    if (choices[15] == 1)
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 12;
                            route[20] = 3;
                            route[21] = 9;
                            route[22] = 14;
                            route[23] = 2;
                            route[24] = 8;
                            route[25] = 10;
                            route[26] = 4;
                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;

                        }
                        else
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;

                        }
                    }
                    else
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 12;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;


                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;


                        }
                        else if (choices[14] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 2;
                            route[16] = 8;
                            route[17] = 10;
                            route[18] = 4;
                        }
                        else if (choices[2] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 8;
                            route[15] = 10;
                            route[16] = 4;
                        }
                        else if (choices[8] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 10;
                            route[14] = 4;

                        }
                        else if (choices[10] == 1)
                        {
                            route[11] = 10;
                            route[12] = 4;

                        }
                        else
                        {
                            route[11] = 4;
                        }

                    }

                }
                else
                {
                    route[1] = 20;
                    route[2] = 20;
                    route[3] = 20;
                    route[4] = 20;
                    route[5] = 20;
                    route[6] = 20;
                    route[7] = 20;
                    route[8] = 20;
                    route[9] = 20;
                    route[10] = 20;
                    if (choices[15] == 1)
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 12;
                            route[20] = 3;
                            route[21] = 9;
                            route[22] = 14;
                            route[23] = 2;
                            route[24] = 8;
                            route[25] = 10;
                            route[26] = 4;
                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;

                        }
                        else
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 15;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;

                        }
                    }
                    else
                    {
                        if (choices[12] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 12;
                            route[18] = 3;
                            route[19] = 9;
                            route[20] = 14;
                            route[21] = 2;
                            route[22] = 8;
                            route[23] = 10;
                            route[24] = 4;

                        }
                        else if (choices[3] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 3;
                            route[17] = 9;
                            route[18] = 14;
                            route[19] = 2;
                            route[20] = 8;
                            route[21] = 10;
                            route[22] = 4;


                        }
                        else if (choices[9] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 9;
                            route[16] = 14;
                            route[17] = 2;
                            route[18] = 8;
                            route[19] = 10;
                            route[20] = 4;


                        }
                        else if (choices[14] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 14;
                            route[15] = 2;
                            route[16] = 8;
                            route[17] = 10;
                            route[18] = 4;
                        }
                        else if (choices[2] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 2;
                            route[14] = 8;
                            route[15] = 10;
                            route[16] = 4;
                        }
                        else if (choices[8] == 1)
                        {
                            route[11] = 10;
                            route[12] = 8;
                            route[13] = 10;
                            route[14] = 4;

                        }
                        else if (choices[10] == 1)
                        {
                            route[11] = 10;
                            route[12] = 4;


                        }
                        else
                        {
                            route[11] = 4;
                        }

                    }

                }
  
            }
            textBox5.Text="南大门→";
            for (int p = 1; route[p] != 4; p++) 
            {
                if (route[p] < 19)
                {
                    textBox5.Text += Vex_sight[route[p]];
                    textBox5.Text += "→";
                }
            }
            textBox5.Text += "南大门";
        }
    }
}