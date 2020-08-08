using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Forms.DataVisualization;
using Quantum.QRNGGUI;

using Microsoft.Quantum.Simulation.Simulators;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Intrinsic;

namespace FormQS
{
    public partial class Form1 : Form
    {
        public string[] alphabet = new string[10] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        public int[] chk = new int[10] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        public bool loop = true;
        public Form1()
        {
            InitializeComponent();
        }

        public void Qrng_OTP()
        {
            int max = 9;
            int time = 0;
            int chk_num = 0;
            int chk_time = 0;
            loop = true;
            for (int i = 0; i < 9; i++)
            {
                chk[i] = 1;
            }
            using (var sim = new QuantumSimulator())
            {
                //MessageBox.Show("실행 성공!");
                while (loop)
                {
                    var res = QRNG.Run(sim, max).Result;
                    foreach (int j in chk) //배열의 합
                    {
                        chk_num += j;
                    }
                    if (chk_num == 1) //배열 chk의 합이 1일 때
                    {
                        foreach (int i in chk)
                        {
                            if (chk_time >= 3) break;
                            //MessageBox.Show(chk_time.ToString() + "번째  값: " + i.ToString());
                            if (i == 1)
                            {
                                //MessageBox.Show(chk_time.ToString() + "번째  값: " + i.ToString());
                                //MessageBox.Show("[버그 탐색용] 결과: " + alphabet[chk_time]);
                                button10.Text = alphabet[chk_time];
                                chk[chk_time] = 0;
                                //MessageBox.Show("변경 완료!");
                                break;
                            }
                            chk_time++;
                        }
                        //continue;
                    }
                    else if (chk_num == 0)
                    {
                        loop = false;
                    }
                    if (chk[res] == 1)
                    {
                        //MessageBox.Show(res.ToString() + "의 값 상태: " + chk[res].ToString());
                        //MessageBox.Show("time 상태: " + time.ToString());
                        switch (time)
                        {
                            case 0:
                                button1.Text = alphabet[res];
                                break;
                            case 1:
                                //MessageBox.Show("[버그 탐색용] 결과: " + alphabet[res]);
                                button2.Text = alphabet[res];
                                break;
                            case 2:
                                button3.Text = alphabet[res];
                                break;
                            case 3:
                                button4.Text = alphabet[res];
                                break;
                            case 4:
                                button5.Text = alphabet[res];
                                break;
                            case 5:
                                button6.Text = alphabet[res];
                                break;
                            case 6:
                                button7.Text = alphabet[res];
                                break;
                            case 7:
                                button8.Text = alphabet[res];
                                break;
                            case 8:
                                button9.Text = alphabet[res];
                                break;
                            default:
                                break;
                        }
                        chk[res] = 0;
                        time++;
                    }
                    //MessageBox.Show(chk_num.ToString());
                    chk_num = 0;
                }
            }
        }

        private void Qrng_Btn_Click(object sender, EventArgs e)
        {
            Qrng_OTP();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Output.Text += button1.Text;
            Qrng_OTP();
        }
    }
}
