using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IEntityService<T> : IService where T : BaseEntity
    {
        T GetById(object id);
        void Insert(T entity);
        void Insert(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        //void DeleteObject(T entity);
        //void DeleteObject(IEnumerable<T> entities);
        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }
    }
}
