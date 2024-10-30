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
    public class CategoriesService : IService<CategoriesDto>
    {
        private readonly IRepository<Categories> repository;
        private readonly IMapper mapper;
        public CategoriesService(IRepository<Categories> repository, IMapper _mapper)
        {
            this.repository = repository;
            this.mapper = _mapper;
        }
        public async Task<CategoriesDto> AddItem(CategoriesDto item)
        {
            return mapper.Map<CategoriesDto>(await repository.AddItem(mapper.Map<Categories>(item)));
        }

        public  async Task DeleteItem(int id)
        {
            await repository.DeleteItem(id);
        }

        public async Task<List<CategoriesDto>> GetAll()
        {
            return mapper.Map<List<CategoriesDto>>(await repository.GetAll());
        }

        public async Task<CategoriesDto> GetById(int id)
        {
            return mapper.Map<CategoriesDto>(await repository.GetById(id));
        }

        public async Task UpdateItem(CategoriesDto item, int id)
        {
            await repository.UpdateItem(mapper.Map<Categories>(item), id);
        }
    }
}
