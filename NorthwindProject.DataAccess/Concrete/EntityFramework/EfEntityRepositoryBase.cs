﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NorthwindProject.DataAccess.Abstract;
using NorthwindProject.Entities.Abstract;

namespace NorthwindProject.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity> 
        where TEntity : class, IEntity, new()
        where TContext:DbContext,new()
    {
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context =new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, 
            Func<IQueryable<TEntity>, 
            IOrderedQueryable<TEntity>> orderBy = null, 
            int? page = null, 
            int? pageSize = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();

                if (filter!=null)
                {
                    query = query.Where(filter);
                }

                if (orderBy!=null)
                {
                    query = orderBy(query);
                }
                //Page Size = 10
                //Page 2
                //ItemCount = 100 
                if (page!=null && pageSize!=null)
                {
                    query = query.Skip((page.Value - 1)*pageSize.Value).Take(pageSize.Value);
                }

                return query.ToList();
            }
        }

        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
