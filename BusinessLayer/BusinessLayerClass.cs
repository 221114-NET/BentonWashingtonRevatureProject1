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
        Task<Users> GetUser(Users u);
        Task<Tickets> CreateTicket(Tickets t);
        Task<Tickets> UpdateTicket(Tickets t);
        Task<List<Tickets>> GetPendingTickets();
        Task<List<Tickets>> GetMyTickets(Tickets t);
        Task<Users> UpdateUser(Users u);
        
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

        public async Task<Users> GetUser(Users u)
        {
            Users u1 = await this._repo.GetUser(u);
            return u1;

        }
        public async Task<Tickets> CreateTicket(Tickets t)
        {
            Tickets t1 = await this._repo.CreateTicket(t);
            return t1;
        }
        public async Task<Tickets> UpdateTicket(Tickets t)
        {
            Tickets t1 = await this._repo.UpdateTicket(t);
            return t1;
        }
        public async Task<List<Tickets>> GetPendingTickets()
        {
            List<Tickets> l = await this._repo.GetPendingTickets();
            return l;
        }
        public async Task<List<Tickets>> GetMyTickets(Tickets t)
        {
            List<Tickets> l2 = await this._repo.GetMyTickets(t);
            return l2;
        }
        public async Task<Users> UpdateUser(Users u)
        {
            Users u1 = await this._repo.UpdateUser(u);
            return u1;
        }

    }
}