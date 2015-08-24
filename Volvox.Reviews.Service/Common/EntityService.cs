using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Volvox.Reviews.Domain.Models.Common;
using Volvox.Reviews.Domain.Models.Identity;
using Volvox.Reviews.Repository.Common;

namespace Volvox.Reviews.Service.Common
{
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _repository;

        public EntityService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _repository.Add(entity);
            _repository.Save();
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _repository.Edit(entity);
            _repository.Save();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Delete(entity);
            _repository.Save();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
