using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.DAL.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MassageSalon.BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IGenericRepository<Role> _repository;
        public RoleService(IGenericRepository<Role> repository)
        {
            _repository = repository;
        }
        public Role Get(Func<Role, bool> predicate)
        {
            return _repository.Find(predicate).FirstOrDefault();
        }
    }
}
