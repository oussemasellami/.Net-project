using Data;
using Data.Infrastructure;
using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class JobService : Service<job> ,IJob
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public JobService() : base(utk)
        {

        }
        public object GetById(string id)
        {
            throw new NotImplementedException();
        }

       public IEnumerable<job> GetJobByuser(int id)
        {
            return GetMany(p => p.utlisateur.cin==id);
        }

       
    }
}
