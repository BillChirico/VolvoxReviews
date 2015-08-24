using System.Collections.Generic;
using Volvox.Reviews.Domain.Models.Products;
using Volvox.Reviews.Domain.Models.Products.Movies;
using Volvox.Reviews.Domain.Models.Reviews;
using Volvox.Reviews.Repository.Products;
using Volvox.Reviews.Repository.Products.Movies;
using Volvox.Reviews.Service.Common;

namespace Volvox.Reviews.Service.Products.Movies
{
    public class MovieService : EntityService<Movie>, IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
            : base(movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Movie GetById(int id)
        {
            return _movieRepository.GetById(id);
        }
    }
}
