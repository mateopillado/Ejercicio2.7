using _2._7_back.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7_back.Repository
{

    public interface IServicioRepository
    {
        Task<List<TServicio>> GetAll();
        Task<TServicio> GetById(int id);
        Task Update(TServicio TServicio);
        void Delete(int id);
        void Add (TServicio TServicio);

    }
    public class ServicioRepository : IServicioRepository
    {
        private readonly TurnosContext _turnosContext;

        public ServicioRepository(TurnosContext turnosContext)
        {
            _turnosContext = turnosContext;
        }

        public void Add(TServicio TServicio)
        {
            _turnosContext.Add(TServicio);
            _turnosContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var devuelto = _turnosContext.TServicios.Find(id);
            if (devuelto != null)
            {
                _turnosContext.Remove(devuelto);
                _turnosContext.SaveChanges();
            }    

        }

        public async Task<List<TServicio>> GetAll() //si recibe parametro se cambia la condicion del is active
        {
            return await _turnosContext.TServicios.ToListAsync();

            //_turnosContext.TServicios.Where(p => p.isActivo ==true).ToList();
        }

        public async Task<TServicio> GetById(int id)
        {
            return await _turnosContext.TServicios.FindAsync(id);
        }

        public async Task Update(TServicio servicio)
        {
            //_turnosContext.Update(TServicio);    de esta forma no
            //_turnosContext.SaveChanges();
            var servicioExist = await _turnosContext.TServicios.FindAsync(servicio.Id);
            if(servicioExist == null)
            {
                return;
            }
            _turnosContext.Entry(servicioExist).CurrentValues.SetValues(servicio);

            await _turnosContext.SaveChangesAsync();

        }
    }
}
