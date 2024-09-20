using Library.DataAccess.Interfaces;
using Library.DataAccess.Repositories;
using Library.Domain.Models;
using Library.Services.Interaces;
using Library.Services.Mapper;
using Library.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Services
{
    public abstract class BaseService<TDto, TEntity> : IServiceRepository<TDto> where TDto : class where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper<TDto, TEntity> _mapper;

        public BaseService(IRepository<TEntity> repository, IMapper<TDto, TEntity> mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public virtual async Task<ServiceResult> CreateAsync(TDto entityDto)
        {
            try
            {
                var entity = _mapper.ToEntity(entityDto);

                await _repository.CreateAsync(entity);

                return ServiceResult.Success();
            }
            catch (Exception)
            {
                return ServiceResult.Failure("Failed to create book");
            }
        }

        public virtual async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var authors = await _repository.GetAllAsync();

            if (authors is null)
            {
                return Enumerable.Empty<TDto>();
            }
            var authorsDto = authors.Select(x => _mapper.ToDtoWithId(x)).ToList();

            return authorsDto;
        }

        public virtual async Task<TDto> GetAsync(int id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
                return null;

            var entityDto = _mapper.ToDtoWithId(entity);
            return entityDto;
        }

        public virtual async Task<ServiceResult> UpdateAsync(int id, TDto entityDto)
        {
            try
            {
                var entity = _mapper.ToEntityWithId(entityDto);

                await _repository.UpdateAsync(id, entity);
                return ServiceResult.Success();
            }
            catch (Exception)
            {
                return ServiceResult.Failure("Failed to update book");
            }
        }
    }
}
