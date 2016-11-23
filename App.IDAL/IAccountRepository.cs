using App.Models;

namespace App.IDAL
{
    public interface IAccountRepository
    {
        SysUser Login(string username, string pwd);
    }
}