using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> _shirts;

        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts;

            // TODO: data preparation and initialisation of additional data structures to improve performance goes here.

        }


        public SearchResults Search(SearchOptions options)
        {
            var colourList = options.Colors.Any() ? options.Colors.Select(c => c.Name).ToList() : Color.All.Select(c => c.Name).ToList();
            var sizeList = options.Sizes.Any() ? options.Sizes.Select(s => s.Name).ToList() : Size.All.Select(s => s.Name).ToList();
            var results = _shirts
                .Where(s => colourList.Contains(s.Color.Name) && sizeList.Contains(s.Size.Name))
                .ToList();

            return new SearchResults
            {
                Shirts = results,
                SizeCounts = new List<SizeCount>()
                {
                    new SizeCount() { Count = results.Count(r => r.Size.Name == Size.Small.Name), Size = Size.Small},
                    new SizeCount() { Count = results.Count(r => r.Size.Name == Size.Medium.Name), Size = Size.Medium},
                    new SizeCount() { Count = results.Count(r => r.Size.Name == Size.Large.Name), Size = Size.Large}
                },
                ColorCounts = new List<ColorCount>()
                {
                    new ColorCount() { Count = results.Count(r => r.Color.Name == Color.White.Name), Color = Color.White},
                    new ColorCount() { Count = results.Count(r => r.Color.Name == Color.Red.Name), Color = Color.Red},
                    new ColorCount() { Count = results.Count(r => r.Color.Name == Color.Blue.Name), Color = Color.Blue},
                    new ColorCount() { Count = results.Count(r => r.Color.Name == Color.Black.Name), Color = Color.Black},
                    new ColorCount() { Count = results.Count(r => r.Color.Name == Color.Yellow.Name), Color = Color.Yellow},
                }
            };
        }
    }
}