using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AbilityManager : IAbilityService
    {
        IAbilityDal _abilityDal;

        public AbilityManager(IAbilityDal abilityDal)
        {
            _abilityDal = abilityDal;
        }

        public List<Ability> GetList()
        {
           return _abilityDal.List();
        }
    }
}
