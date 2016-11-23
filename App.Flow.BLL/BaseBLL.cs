using System;
using App.Models;

namespace App.Flow.BLL
{
    public class BaseBLL : IDisposable
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