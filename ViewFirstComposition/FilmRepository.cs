using System.Collections.Generic;
using System.Threading.Tasks;

namespace ViewFirstComposition
{
    public class FilmRepository
    {
        public async Task<IList<Film>> GetTop200()
        {
            // We would go and download this list from a database/web service/etc.

            var films = new List<Film>
            {
                new Film { Title = "The Shawshank Redemption", Date = 1994 },
                new Film { Title = "The Godfather", Date = 1972 },
                new Film { Title = "The Godfather: Part II", Date = 1974 },
                new Film { Title = "Pulp Fiction", Date = 1994 },
                new Film { Title = "The Good, the Bad and the Ugly", Date = 1966 },

                // ...
            };

            return await Task.FromResult(films);
        }
    }
}