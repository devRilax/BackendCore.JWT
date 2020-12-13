using BackendCore.Dal.Repositories;
using BackendCore.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendCore.Business
{
    public class ComunaBL : BaseBL
    {

        private readonly ComunaRepository repository;
        public ComunaBL(IConfiguration configuration) : base(configuration)
        {
            repository = new ComunaRepository(configuration);
        }


        public async Task<long> Create(Comuna entity)
        {
            entity.CreatedAt = DateTime.Now;
            return await repository.CreateWithSP(entity);
        }

        public async Task<List<Comuna>> All()
        { 
            return await repository.All();
        }

        public async Task<Comuna> ById(long id)
        {
            return await repository.ById(id);
        }

        public async Task<List<Comuna>> FakeGet()
        {
            return new List<Comuna>()
            {
                new Comuna(){ Id = 1, Name = "Independencia", CreatedAt = DateTime.Now },
                new Comuna(){ Id = 2, Name = "Concghhalí", CreatedAt = DateTime.Now },
                new Comuna(){ Id = 3, Name = "Providencia", CreatedAt = DateTime.Now },
                new Comuna(){ Id = 4, Name = "Huechuraba", CreatedAt = DateTime.Now },
            };
        }
    }
}
