using System.Data.Entity;
using System.Linq;
using Volvox.Reviews.Domain.Models.Products;
using Volvox.Reviews.Domain.Models.Products.Movies;
using Volvox.Reviews.Repository.Common;

namespace Volvox.Reviews.Repository.Products.Movies
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(DbContext context)
            : base(context)
        {
            
        }

        public Movie GetById(int id)
        {
            return Dbset.FirstOrDefault(movie => movie.Id == id);
        }
    }
}
