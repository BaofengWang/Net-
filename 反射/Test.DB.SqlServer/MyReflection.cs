using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DB.SqlServer
{
     public class MyReflection
    {
        public void show()
        {
            Console.WriteLine("这里是{0}的show方法", this.GetType().FullName);
        }

        public void show1( string name)
        {
            Console.WriteLine("这里是{0}的show方法----参数为{1}", this.GetType().FullName,name);
        }
        public void show11(string name,int age)
        {
            Console.WriteLine("这里是{0}的show方法----参数1为{1}---参数2为{2}", this.GetType().FullName, name,age);
        }
        //函数的重载
        public void show2()
        {
            Console.WriteLine("这里是{0}的show2方法", this.GetType().FullName);
        }
        public void show2(int ID)
        {
            Console.WriteLine("这里是{0}的show2方法----参数名字为{1}", this.GetType().FullName,ID);
        }
        public void show2(string name)
        {
            Console.WriteLine("这里是{0}的show2方法----参数名字为{1}", this.GetType().FullName,name);
        }

        //私有方法的函数

        private void show3(string name)
        {
            Console.WriteLine("这里是{0}的show3方法----参数名字为{1}", this.GetType().FullName,name);
        }
    }
}
