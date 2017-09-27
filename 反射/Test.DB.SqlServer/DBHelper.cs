using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DB.Interface;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace Test.DB.SqlServer

{
   public class DBHelper:IDBHelper
    {
        //获取连接数据库的字符串 
        private static string ConnectionStringCustomers = ConfigurationManager.ConnectionStrings["customer"].ConnectionString;

        public DBHelper()
        {
            Console.WriteLine("这里是{0}的无参的构造函数", this.GetType().FullName);
        }

        public void Query()
        {
            Console.WriteLine("这里是{0}的Query", this.GetType().FullName);
        }



        //QueryDomain一个方法可以实现访问所有的数据库表，
        public T QueryDomain<T>()　//T 相当于一个泛型的对象   
        {
            int Id = 23;//目前是写死的要查询的默认id (意思就是查询当前 T 对象的对应ID = 23 的信息 )  
            Type type = typeof(T);

            T t =(T)Activator.CreateInstance(type);//强制转换为T类型
            foreach(var prop in type.GetProperties())
            {
                Console.WriteLine("属性的名称为{0}",prop.Name);
            }
            //linq相关的知识
            //获取对象Ｔ的成员的属性　并按照指定的格式拼接　
            string columns = string.Join(",", type.GetProperties().Select(p => string.Format("[{0}]", p.Name)));
            //继续拼接成SQL语句
            string sql = string.Format("select {0} from {1} where ID = {2}", columns, type.Name, Id);

            using (SqlConnection conn = new SqlConnection(ConnectionStringCustomers))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader myreader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (myreader.Read())
                {
                    //将查询得到的对象成员一 一赋值操作
                    foreach(var prop in type.GetProperties())
                    {
                        string propertyName = prop.Name;
                        prop.SetValue(t, myreader[propertyName]);

                        Console.WriteLine("属性的名称为{0}-----值为{1}", prop.Name,prop.GetValue(t));
                    }
                }
            }
            //返回对象
             return t;
        }

    }
}
