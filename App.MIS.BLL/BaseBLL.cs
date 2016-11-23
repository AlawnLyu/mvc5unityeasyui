using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;

namespace App.MIS.BLL
{
    public class BaseBLL:IDisposable
    {
        protected DBContainer db
        {
            get { return new DBContainer(); }
        }
        public void Dispose()
        {
        }
    }
}
