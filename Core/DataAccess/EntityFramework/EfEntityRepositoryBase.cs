using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext> : IEntityRepository<TEntity>
        where TEntity: class,IEntity ,new ()
        where TContext: DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext()) //işi bitince bellekten atılacak performans için faydalı
            {
                var addedEntity = context.Entry(entity);//referansı yakalamak
                addedEntity.State = EntityState.Added; //ekleme olarak set et
                context.SaveChanges();//ve kaydet

            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext()) //işi bitince bellekten atılacak performans için faydalı
            {
                var deletedEntity = context.Entry(entity);//referansı yakalamak
                deletedEntity.State = EntityState.Deleted; //delete olarak set et
                context.SaveChanges();//ve kaydet

            }
        }
        public void Update(TEntity entity)
        {
            using (TContext context = new TContext()) //işi bitince bellekten atılacak performans için faydalı
            {
                var updatedEntity = context.Entry(entity);//referansı yakalamak
                updatedEntity.State = EntityState.Modified; //modife olarak set et
                context.SaveChanges();//ve kaydet

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }
    }
}
