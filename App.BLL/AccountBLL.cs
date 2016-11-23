using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.IBLL;
using App.IDAL;
using App.Models;
using Microsoft.Practices.Unity;

namespace App.BLL
{
    public class AccountBLL : IAccountBLL
    {
        [Dependency]
        public IAccountRepository accountRepository { get; set; }

        public SysUser Login(string username, string pwd)
        {
            return accountRepository.Login(username, pwd);
        }
    }
}
