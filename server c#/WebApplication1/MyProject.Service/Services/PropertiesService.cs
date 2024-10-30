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
    public class PropertiesService : IPropertiesService
    {
        private readonly IPropertiesRepository repository;
        private readonly IMapper mapper;
        public PropertiesService(IPropertiesRepository repository, IMapper _mapper)
        {
            this.repository = repository;
            this.mapper = _mapper;
        }
        public async Task<PropertiesDto> AddItem(PropertiesDto item)
        {
            return mapper.Map<PropertiesDto>(await repository.AddItem(mapper.Map<Properties>(item)));
        }

        public async Task DeleteItem(int id)
        {
            await repository.DeleteItem(id);
        }

        public async Task<List<PropertiesDto>> GetAll()
        {
            return mapper.Map<List<PropertiesDto>>(await repository.GetAll());
        }

        public async Task<List<PropertiesDto>> GetByFilterId(int filterId)
        {

            return mapper.Map<List<PropertiesDto>>(await repository.GetByFilterId(filterId));

        }

        public async Task<PropertiesDto> GetById(int id)
        {
            return mapper.Map<PropertiesDto>(await repository.GetById(id));
        }

        public async Task UpdateItem(PropertiesDto item, int id)
        {
            await repository.UpdateItem(mapper.Map<Properties>(item), id);
        }

    }
}
