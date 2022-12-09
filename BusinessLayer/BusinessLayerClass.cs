using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer;
using RepoLayer;

namespace BusinessLayer
{
    public interface IBusinessLayerClass
    {
        Task<Users> CreateUser(Users u);
    }

    public class BusinessLayerClass : IBusinessLayerClass
    {
        private readonly IRepositoryClass _repo;

        public BusinessLayerClass(IRepositoryClass repo)
        {
            _repo = repo;
        }
        public async Task<Users> CreateUser(Users u)
        {
            Users u1 = await this._repo.CreateUser(u);
            return u1;
        }
    }
}