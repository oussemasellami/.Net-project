using Data;
using Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SkillsService : Service<skills> , ISkillsService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public SkillsService() : base(utk)
        {

        }
        public object GetById(string id)
        {
            throw new NotImplementedException();
        }

    }
}
