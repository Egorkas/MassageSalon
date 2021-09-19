using MassageSalon.DAL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MassageSalon.BLL.Interfaces
{
    public interface  IRoleService
    {
        Role Get(Func<Role, bool> predicate);
    }
}
