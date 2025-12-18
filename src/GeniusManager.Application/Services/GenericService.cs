using GeniusManager.Application.DTO;
using GeniusManager.Domain.Common;
using GeniusManager.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusManager.Application.Services
{
    public class GenericService<T> where T : BaseEntity, new()
    {
        private readonly IRepository<T> _repository;

        public GenericService(IRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<LookupDto>> GetAllAsync()
        {
            var entitied = await _repository.GetAllAsync();
            return entitied.Select(x => new LookupDto
            {
                Id = x.Id,
                Name = x.Name
            });
        }
        public async Task<LookupDto> GetByIdAsync(long id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;
            return new LookupDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
        public async Task AddAsync(LookupDto dto)
        {
            var entity = new T
            {
                Name = dto.Name
            };
            await _repository.AddAsync(entity);
        }
        public async Task DeleteAsync(long id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new InvalidOperationException("العنصر غير موجود");
            await _repository.DeleteAsync(entity);
        }
        public async Task UpadateAsync(LookupDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null) throw new InvalidOperationException("العنصر غير موجود");
            entity.Name = dto.Name;
            entity.UpdatedAt=DateTime.Now;
            await _repository.UpdateAsync(entity);
        }
    }
}
