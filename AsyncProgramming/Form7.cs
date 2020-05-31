using AsyncProgramming;
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
    /*キャンセルの方法（非推奨）フラグ編*/
    //bool型のフラグを利用する問題点
    //GetDataは大抵DBからデータをとってくる等、画面の処理とは異なるところで処理が行われる
    //フラグの管理が煩雑になってくる
    public partial class Form7 : Form
    {
        //private bool _isCancel;
        private DataBase _dataBase = new DataBase();

        public Form7()
        {
            InitializeComponent();
        }
        //「async」が必要
        private async void button1_Click(object sender, EventArgs e)
        {
            /*await syncを組み合わせた例
             より同期プログラミングと似たような記述ができる
            GetDataが終了するまで messageBoxの処理を待つ
             */
            //_isCancel = false;
            dataGridView1.DataSource =await Task.Run(()=>_dataBase.GetData());
            if (_dataBase.IsCancel)
            {
                MessageBox.Show("キャンセルされました。");
            }else
            {
                MessageBox.Show("完了");
            }
            

        }

        //private List<Dto> GetData()
        //{
        //    var result = new List<Dto>();
        //    for (int i = 0; i < 5; i++)
        //    {
        //        if (_isCancel)
        //        {
        //            return null;
        //        }
        //        System.Threading.Thread.Sleep(1000);
        //        result.Add(new Dto ( i.ToString(),  "Name" + i ));
        //    }


        //    return result;

        //}

        private void CancelButton_Click(object sender, EventArgs e)
        {
            //_isCancel = true;
            _dataBase.Cancel();
        }
    }
}
