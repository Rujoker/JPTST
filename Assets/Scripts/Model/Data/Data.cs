using System.Collections.Generic;
using Newtonsoft.Json;

namespace Model.Data
{
    [JsonObject]
    internal class Data
    {
        [JsonProperty("objects")] 
        public readonly List<FigureObject> Objects;
    }
}