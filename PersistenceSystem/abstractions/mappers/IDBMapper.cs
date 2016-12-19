﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceSystem.abstractions.mappers
{
    public interface IDBMapper
    {
        AbstractDomainObject GetById(int Id);
        List<AbstractDomainObject> GetAll();
        void SaveOrUpdate(AbstractDomainObject data);
        void Delete(AbstractDomainObject data);
    }
}
