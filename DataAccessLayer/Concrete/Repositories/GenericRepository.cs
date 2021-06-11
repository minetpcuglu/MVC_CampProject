using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T:class
    {
        Context c = new Context();

        DbSet<T> _object; //objeye deger atamak için constroctur yıkıcı metotu kullanıyoruz

        public GenericRepository()
        {
            _object =c.Set<T>();
        }

        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T p)
        {
            var addedEntity = c.Entry(p);           //değişken tanımlama
            addedEntity.State = EntityState.Added; //durum ve ekleme işlemi 
            //_object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {

            var updatedEntity = c.Entry(p);             //güncelleme işlemleri olması için 
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges(); //değişiklikleri kaydet
        }
    }
}
