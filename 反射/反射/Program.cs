using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Test.DB.Interface;
using Test.DB.SqlServer;

using System.Reflection;//反射引用的头文件

using System.Configuration;

using Test.Model;


namespace 反射
{
    class Program
    {

        /// <summary>
        /// 1.反射的介绍和原理
        /// 2.通过反射（动态）获取信息、（动态）创建对象、（动态）调用方法
        /// 3.实现程序的可配置
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            Console.WriteLine("反射的知识点的学习");

            //方式1：传统的做法，直接通过类来调用
            //使用接口来使用
            /*
            IDBHelper dbHelper = new DBHelper();
            dbHelper.Query();
            */



            //方式2：反射

            /*
        Console.WriteLine("*********Reflection*********");
        Console.WriteLine();

        //2、根基config配置文件读取   (注意的点：需要将新生成的dll文件和pbd文件拷贝)

        //只需要改变字符串["Test.DB.Oracle"]，不能改程序就可以，做相应的行为

        string nameSpace = ConfigurationManager.AppSettings["Test.DB.Oracle"]; 
        string[] nameSpaceArr = nameSpace.Split(',');


        Assembly assembly = Assembly.Load(nameSpaceArr[0]); //发射的入口  动态的加载dll
        Console.WriteLine("*********GetModules*********");
       foreach(Module module in assembly.GetModules())
        {
            Console.WriteLine("名称：{0}", module.FullyQualifiedName);
        }
        Console.WriteLine("*********GetTypes*********");
        foreach (Type type in assembly.GetTypes())
        {
            Console.WriteLine("名称：{0}",type.FullName );
        }
        Console.WriteLine("*********创建对象*********");

        Type dbHelperType = assembly.GetType(nameSpaceArr[1]);
        object oDBhelper = Activator.CreateInstance(dbHelperType);
        //通过接口来调用
        IDBHelper dbHelperReflection =(IDBHelper)oDBhelper;
        dbHelperReflection.Query();//完成方法的调用
        Console.ReadKey();
        */
            //直接通过具体的方法名来调用


            /*
            Assembly assmbly1 = Assembly.Load("Test.DB.SqlServer");
            Type type1 = assmbly1.GetType("Test.DB.SqlServer.MyReflection");
            object oObject = Activator.CreateInstance(type1);
            Console.WriteLine("*******GetMethods*********");
            foreach (MethodInfo method in type1.GetMethods())
            {
                Console.WriteLine("名称：{0}", method.Name);
            }
            //2.1获取方法

            //不带参数
            MethodInfo show = type1.GetMethod("show");
            show.Invoke(oObject, null);//调用show方法，null代表没有参数
            //带参数
            MethodInfo show_1 = type1.GetMethod("show1");
            show_1.Invoke(oObject, new object[] { "wangbaofeng"});
            //带2个参数
            MethodInfo show_11 = type1.GetMethod("show11");
            show_11.Invoke(oObject, new object[] { "wangbaofeng", 25 });
            //2.2调用重载函数

            //不带参数类型的
            MethodInfo show1 = type1.GetMethod("show2",new Type[] { } );
            show1.Invoke(oObject, null);
            //int类型的参数
            MethodInfo show2 = type1.GetMethod("show2",new Type[] { typeof(int)});
            show2.Invoke(oObject, new Object[] {11});
            //String类型的参数
            MethodInfo show3 = type1.GetMethod("show2", new Type[] { typeof(string) });
            show3.Invoke(oObject, new Object[] { "JIE" });

            //2.3访问私有方法
            MethodInfo show4 = type1.GetMethod("show3",BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic);
            show4.Invoke(oObject, new object[] { "访问的私有方法" });
            Console.ReadKey();

    */



            

            //3.声明一个person 对象，并且去赋值的常规的做法
            Person people = new Person();
            people.Name = "笨小孩";
            people.Id = 11;
            Console.WriteLine("people.Id = {0},people.name = {1}", people.Id, people.Name);

            //4.声明一个person 对象   不走寻常路(泛型)

            Type type = typeof(Person);//找到类型
            Object oObject = Activator.CreateInstance(type);//创建对象
            foreach(var prop in type.GetProperties())
            {
                if (prop.Name.Equals("Id"))
                {
                    prop.SetValue(oObject, 12);//可以给对象赋值
                }
                if (prop.Name.Equals("Name"))
                {
                    prop.SetValue(oObject, "哈哈");
                }
                Console.WriteLine("属性名称为{0}值是{1}",prop.Name,prop.GetValue(oObject));
            }

            //5. 查询数据中User表信息（注意：User模型的表的成员需要和数据中User表中的字段一一对应）‘
            //调用方法
            DBHelper dbHelper = new DBHelper();
            User oUser = dbHelper.QueryDomain<User>();
            Console.ReadKey();

        }
    }

    
}
