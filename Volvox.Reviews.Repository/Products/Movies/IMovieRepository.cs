using Volvox.Reviews.Domain.Models.Products;
using Volvox.Reviews.Domain.Models.Products.Movies;
using Volvox.Reviews.Repository.Common;

namespace Volvox.Reviews.Repository.Products.Movies
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Movie GetById(int id);
    }
}
