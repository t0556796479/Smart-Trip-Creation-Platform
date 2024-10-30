using AutoMapper;
using MyProject.Common.Entities;
using MyProject.Repository.Entities;
using MyProject.Repository.Interfaces;
using MyProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Service.Services
{
    public class FiltersService : IFiltersService
    {
        private readonly IFiltersRepository repository;
        private readonly IMapper mapper;
        public FiltersService(IFiltersRepository repository, IMapper _mapper)
        {
            this.repository = repository;
            this.mapper = _mapper;
        }
        public async Task<FiltersDto> AddItem(FiltersDto item)
        {
            return mapper.Map<FiltersDto>(await repository.AddItem(mapper.Map<Filters>(item)));
        }

        public async Task DeleteItem(int id)
        {
            await repository.DeleteItem(id);
        }

        public async Task<List<FiltersDto>> GetAll()
        {
            return mapper.Map<List<FiltersDto>>(await repository.GetAll());
        }

        public async Task<List<FiltersDto>> GetByCategoryId(int categoryId)
        {
            return mapper.Map<List<FiltersDto>>(await repository.GetByCategoryId(categoryId));
        }

        public async Task<FiltersDto> GetById(int id)
        {
            return mapper.Map<FiltersDto>(await repository.GetById(id));
        }

        public async Task UpdateItem(FiltersDto item, int id)
        {
            await repository.UpdateItem(mapper.Map<Filters>(item), id);
        }
    }
}
