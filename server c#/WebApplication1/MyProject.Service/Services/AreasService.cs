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
    public class AreasService : IService<AreasDto>
    {
        private readonly IRepository<Areas> repository;
        private readonly IMapper mapper;
        public AreasService(IRepository<Areas> repository, IMapper _mapper)
        {
            this.repository = repository;
            this.mapper = _mapper;
        }
        public async Task<AreasDto> AddItem(AreasDto item)
        {
            return mapper.Map<AreasDto>(await repository.AddItem(mapper.Map<Areas>(item)));
        }

        public async Task DeleteItem(int id)
        {
            await repository.DeleteItem(id);
        }

        public async Task<List<AreasDto>> GetAll()
        {
            return mapper.Map<List<AreasDto>>(await repository.GetAll());
        }

        public async Task<AreasDto> GetById(int id)
        {
            return mapper.Map<AreasDto>(await repository.GetById(id));
        }

        public async Task UpdateItem(AreasDto item, int id)
        {
            await repository.UpdateItem(mapper.Map<Areas>(item), id);
        }
    }
}
