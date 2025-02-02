using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAsyncCrudAppService< TPrimaryKey, TEntityDto , TEntityCreateDto, TEntityUpdateDto> 
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TEntityCreateDto : IEntityDto<TPrimaryKey>
        where TEntityUpdateDto : IEntityDto<TPrimaryKey>
    { 
        Task<List<TEntityDto>> GetAllAsync();
        Task<TEntityDto> GetByIdAsync(TPrimaryKey id);
        Task CreateAsync(TEntityCreateDto product);
        Task DeleteAsync(TPrimaryKey id);
        Task UpdateAsync(TEntityUpdateDto product);
    }
}
