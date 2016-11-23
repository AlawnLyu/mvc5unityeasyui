using System;
using System.Linq;
using App.IDAL;
using App.Models;

namespace App.DAL
{
    public class AccountRepository : IAccountRepository, IDisposable
    {
        public SysUser Login(string username, string pwd)
        {
            using (DBContainer db = new DBContainer())
            {
                SysUser user = db.SysUser.SingleOrDefault(o => o.UserName == username && o.Password == pwd);
                return user;
            }
        }

        public void Dispose()
        {
        }
    }
}