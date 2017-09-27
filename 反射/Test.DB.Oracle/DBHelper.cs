using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DB.Interface;

namespace Test.DB.Oracle
{
    public class DBHelper : IDBHelper
    {
        public DBHelper()
        {
            Console.WriteLine("这里是{0}的无参的构造函数", this.GetType().FullName);
        }

        public void Query()
        {
            Console.WriteLine("这里是{0}的Query", this.GetType().FullName);
        }

    }
}
