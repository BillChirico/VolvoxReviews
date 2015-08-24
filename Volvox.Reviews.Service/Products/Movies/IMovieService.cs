using Volvox.Reviews.Domain.Models.Products;
using Volvox.Reviews.Domain.Models.Products.Movies;
using Volvox.Reviews.Service.Common;

namespace Volvox.Reviews.Service.Products.Movies
{
    public interface IMovieService : IEntityService<Movie>
    {
        Movie GetById(int id);
    }
}
