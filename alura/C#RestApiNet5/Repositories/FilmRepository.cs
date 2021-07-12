using System.Collections.Generic;
using C_RestApiNet5.Models;
using C_RestApiNet5.Data;
using System.Linq;

namespace C_RestApiNet5.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private FilmsContext _context;
        public FilmRepository(FilmsContext context)
        {
            _context = context;
        }
        public bool Create(Film entity)
        {
            try {
                _context.Films.Add(entity);
                _context.SaveChanges();

                return true;
            } catch {

                return false;
            }
        }

        public bool Delete(int id)
        {
           try {
                var film = _context.Films.First(f => f.Id == id);
                _context.Remove(film);
                _context.SaveChanges();

                return true;
            } catch {

                return false;
            }
        }

        public IEnumerable<Film> GetAll()
        {
            return _context.Films;
        }

        public Film GetBy<V>(string propertyName, V PropertyValue)
        {
            throw new System.NotImplementedException();
        }

        public Film GetById(int id)
        {
            return _context.Films.FirstOrDefault(f => f.Id.Equals(id));
        }

        public bool Update(Film entity)
        {
            try {
                _context.Update<Film>(entity);
                _context.SaveChanges();

                return true;
            } catch {

                return false;
            }
        }
    }
}