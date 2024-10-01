using _2._7_back.Data.Models;
using _2._7_back.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7_back.Service
{

    public interface IServiceServicio
    {
        Task<List<TServicio>> GetAll();
        Task<TServicio> GetById(int id);
        Task Update(TServicio TServicio);
        void Delete(int id);
        void Add(TServicio TServicio);
    }
    public class ServiceServicio : IServiceServicio
    {
        private readonly IServicioRepository _repository;

        public ServiceServicio(IServicioRepository repository)
        {
            _repository = repository;
        }

        public void Add(TServicio TServicio)
        {
            _repository.Add(TServicio);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public async Task<List<TServicio>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<TServicio> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(TServicio TServicio)
        {
            await _repository.Update(TServicio);
        }
    }
}
