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
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* Threadにはvoid型で引数なしのメソッドが必要 */
            //var t = new System.Threading.Thread(GetData);
            //t.Start();
            //dataGridView1.DataSource = GetData();
            
            
            /*ThreadPoolの利用*/

            //第二引数をつけるときはobjectなので何でもよい。サンプルは適当
            //System.Threading.ThreadPool.QueueUserWorkItem(GetData,new Dto("5","6"));
            //今回は引数なし
            System.Threading.ThreadPool.QueueUserWorkItem(GetData);
            //注意　別スレッド実行後すぐに制御がこちらに戻るため。以下のような処理は不都合が生じる
            //もし入れるのであれば　別スレッド側に入れる
            //MessageBox.Show("完了");
        }

        //private List<Dto> GetData()
        private void GetData(object o)
        {
            // 第二引数有りのときGetData,new Dto("5","6")　何かの処理をする例
            //var dto = o as Dto;
            //if (dto == null)
            //{
            //    return;
            //}


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
                MessageBox.Show("完了");
                });
            
            //return result;

        }
    }
}
