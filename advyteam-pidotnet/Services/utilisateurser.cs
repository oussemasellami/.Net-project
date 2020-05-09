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
    public class utilisateurser : Service<utlisateur> , Iutilisateurser
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public utilisateurser() : base(utk)
        {

        }
        public object GetById(string id)
        {
            throw new NotImplementedException();
        }

    }
}
