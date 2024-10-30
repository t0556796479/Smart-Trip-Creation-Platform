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
    public class UserService : ILoginService
    {
        private readonly ILogin<User> repository;
        private readonly IMapper mapper;
        public UserService(ILogin<User> repository, IMapper _mapper)
        {
            this.repository = repository;
            this.mapper = _mapper;
        }
        public async Task<UserDto> AddItem(UserDto item)
        {
            return mapper.Map<UserDto>(await repository.AddItem(mapper.Map<User>(item)));
        }

        public async Task DeleteItem(int id)
        {
            await repository.DeleteItem(id);
        }

        public async Task<List<UserDto>> GetAll()
        {
            return mapper.Map<List<UserDto>>(await repository.GetAll());
        }

        public async Task<UserDto> GetById(int id)
        {
            return mapper.Map<UserDto>(await repository.GetById(id));
        }

        public UserDto Login(string username, string passward)
        {
            return mapper.Map<UserDto>(repository.Login(username, passward));
        }

        public async Task UpdateItem(UserDto item, int id)
        {
            await repository.UpdateItem(mapper.Map<User>(item), id);
        }
    }
}
