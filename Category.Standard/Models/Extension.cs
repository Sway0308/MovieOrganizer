using Newtonsoft.Json;
using System.Collections.Generic;

namespace Category.Standard.Models
{
    public class Extension
    {
        [JsonIgnore]
        public IList<string> TempExtensions { get; } = new List<string>();

        public IList<string> FilmExtensions { get; } = new List<string>();

        public IList<string> OtherExtensions { get; } = new List<string>();
    }
}
