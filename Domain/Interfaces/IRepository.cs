using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity, TPrimaryKey>   where TEntity : class, IEntity<TPrimaryKey>
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(TPrimaryKey id);
        Task DeleteAsync(TPrimaryKey id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}
