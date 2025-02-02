using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.Internal.Mappers;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AsyncCrudAppService<TEntity, TPrimaryKey, TEntityDto, TEntityCreateDto, TEntityUpdateDto> : IAsyncCrudAppService<TPrimaryKey, TEntityDto, TEntityCreateDto, TEntityUpdateDto>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TEntityCreateDto : IEntityDto<TPrimaryKey>
        where TEntityUpdateDto : IEntityDto<TPrimaryKey>
    {
        protected readonly IRepository<TEntity, TPrimaryKey> _repository;

        private readonly IMapper _mapper;
        public AsyncCrudAppService(IRepository<TEntity , TPrimaryKey> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task CreateAsync(TEntityCreateDto input)
        {
            TEntity entity = MapToEntity(input);
            await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(TPrimaryKey id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<TEntityDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(MapToEntityDto).ToList();
        }

        public async Task<TEntityDto> GetByIdAsync(TPrimaryKey id)
        {
            TEntity entity = await _repository.GetAsync(id);
            return MapToEntityDto(entity);
        }

        public async Task UpdateAsync(TEntityUpdateDto input)
        {
            TEntity entity = await GetEntityByIdAsync(input.Id);

             MapToEntity(input , entity);
            await _repository.UpdateAsync(entity);

        }
        protected virtual Task<TEntity> GetEntityByIdAsync(TPrimaryKey id)
        {
            return _repository.GetAsync(id);
        }

        protected virtual TEntityDto MapToEntityDto(TEntity entity)
        {
            return _mapper.Map<TEntityDto>(entity);
        }

        /// <summary>
        /// Maps <typeparamref name="TEntityDto"/> to <typeparamref name="TEntity"/> to create a new entity.
        /// It uses <see cref="IObjectMapper"/> by default.
        /// It can be overrided for custom mapping.
        /// </summary>
        protected virtual TEntity MapToEntity(TEntityCreateDto createInput)
        {
            return _mapper.Map<TEntity>(createInput);
        }

        /// <summary>
        /// Maps <typeparamref name="TUpdateInput"/> to <typeparamref name="TEntity"/> to update the entity.
        /// It uses <see cref="IObjectMapper"/> by default.
        /// It can be overrided for custom mapping.
        /// </summary>
        protected virtual void MapToEntity(TEntityUpdateDto updateInput, TEntity entity)
        {
            _mapper.Map(updateInput, entity);
        }
    }
}
