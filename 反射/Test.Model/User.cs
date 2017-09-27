using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    public class User
    {
        public  string Name { set; get; }
        public string Account { set; get; }
        public string Password { set; get; }
        public string Email { set; get; }
        public string Mobile { set; get; }
        public string CompanyName { set; get; }
        /// <summary>
        /// 用户的状态：0正常 1冻结 2删除
        /// </summary>
        public int State { set; get; }
        /// <summary>
        /// 用户的类型：1、普通管理员 2、管理员 3、超级管理员
        /// </summary>
        public int UserType { set; get; }


    }
}
