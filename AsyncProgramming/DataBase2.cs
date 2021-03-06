﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace AsyncProgramming
{
    internal class DataBase2
    {
        //Form7より移動
        //private bool _isCancel;
        //internal bool IsCancel
        //{
        //    get
        //    {
        //        return _isCancel;
        //    }
        //}
        internal List<Dto> GetData(System.Threading.CancellationToken token)
        {
            //_isCancel = false;
            var result = new List<Dto>();
            for (int i = 0; i < 5; i++)
            {
                //取消要求を監視、取り消し要求時に例外をスロー
                token.ThrowIfCancellationRequested();
                //if (_isCancel)
                //{
                //    return null;
                //}

                System.Threading.Thread.Sleep(1000);
                result.Add(new Dto(i.ToString(), "Name" + i));
            }


            return result;

        }
       

        //internal void Cancel()
        //{
        //    _isCancel = true;
        //}
    }
}
