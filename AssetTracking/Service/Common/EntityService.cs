using Core.Data;
using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        private readonly IDbContext _context;
        private IDbSet<T> _entities;

        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }

        public EntityService(IDbContext context)
        {
            _context = context;
        }

        public virtual T GetById(object id)
        {
            //see some suggested performance optimization (not tested)
            //http://stackoverflow.com/questions/11686225/dbset-find-method-ridiculously-slow-compared-to-singleordefault-on-id/11688189#comment34876113_11688189
            return this.Entities.Find(id);
        }

        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.Entities.Add(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);

                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public virtual void Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                foreach (var entity in entities)
                    this.Entities.Add(entity);

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                //_context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.Entities.Remove(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                //Winson Huang - change from foreach (var entity in entities) to foreach (var entity in entities.ToList())
                //otherwise it will throw the exception "Collection was modified; enumeration operation may not execute"
                foreach (var entity in entities.ToList())
                    this.Entities.Remove(entity);

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        //public virtual void DeleteObject(T entity)
        //{
        //    try
        //    {
        //        if (entity == null)
        //        {
        //            throw new ArgumentNullException("entity");
        //        }

        //        ObjectContext oc = ((IObjectContextAdapter)_context).ObjectContext;
        //        oc.DeleteObject(entity);
        //        this._context.SaveChanges();
        //    }
        //    catch (DbEntityValidationException dbEx)
        //    {
        //        var msg = string.Empty;

        //        foreach (var validationErrors in dbEx.EntityValidationErrors)
        //            foreach (var validationError in validationErrors.ValidationErrors)
        //                msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

        //        var fail = new Exception(msg, dbEx);
        //        //Debug.WriteLine(fail.Message, fail);
        //        throw fail;
        //    }
        //}

        //public virtual void DeleteObject(IEnumerable<T> entities)
        //{
        //    try
        //    {
        //        if (entities == null)
        //            throw new ArgumentNullException("entities");

        //        //Winson Huang - change from foreach (var entity in entities) to foreach (var entity in entities.ToList())
        //        //otherwise it will throw the exception "Collection was modified; enumeration operation may not execute"
        //        ObjectContext oc = ((IObjectContextAdapter)_context).ObjectContext;
        //        foreach (var entity in entities.ToList())
        //            oc.DeleteObject(entity);   

        //        this._context.SaveChanges();
        //    }
        //    catch (DbEntityValidationException dbEx)
        //    {
        //        var msg = string.Empty;

        //        foreach (var validationErrors in dbEx.EntityValidationErrors)
        //            foreach (var validationError in validationErrors.ValidationErrors)
        //                msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

        //        var fail = new Exception(msg, dbEx);
        //        //Debug.WriteLine(fail.Message, fail);
        //        throw fail;
        //    }
        //}

        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        public virtual IQueryable<T> TableNoTracking
        {
            get
            {
                return this.Entities.AsNoTracking();
            }
        }
    }
}
