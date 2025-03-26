using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.DAL.Persistent.Data.Context;

namespace Shipping.DAL.Persistent.Repositries
{
    public class GenericRepositry<T> where T : class
    {
        protected readonly ShippingContext context;

        public GenericRepositry(ShippingContext context)
        {
            this.context = context;
        }
        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }
        public IEnumerable<T> paginated(int page, int pageSize)
        {
            return context.Set<T>().Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public IEnumerable<T> search(string Searchword)
        {
            return context.Set<T>().Select(x => x).Where(x => x.ToString().Contains(Searchword)).ToList();
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
        public T Delete(int id) 
        {
            var entity = GetById(id);
            return entity;
        }
    }
}
