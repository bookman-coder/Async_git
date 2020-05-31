using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp1
{
    //Threadクラスを用いた非同期プログラミング
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* Threadにはvoid型で引数なしのメソッドが必要 */
            var t = new System.Threading.Thread(GetData);
            t.Start();
            //dataGridView1.DataSource = GetData();
        }

        //private List<Dto> GetData()
        private void GetData()
        {
            var result = new List<Dto>();
            for (int i = 0; i < 5; i++)
            {
                System.Threading.Thread.Sleep(1000);
                result.Add(new Dto ( i.ToString(),  "Name" + i ));
            }
            //注意！この記述は問題がある。こちらはバックグラウンドスレッドのため、UIスレッド上のDatagridviewを
            //操作することはできない（エラーとなる　
            //この部分の処理をUIスレッドに戻す必要がある
            //dataGridView1.DataSource = result;
            this.Invoke((Action)delegate()
                {
                dataGridView1.DataSource = result;
            });
            
            //return result;

        }
    }
}
