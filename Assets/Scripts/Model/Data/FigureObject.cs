using System.Collections.Generic;
using Newtonsoft.Json;

namespace Model.Data
{
    [JsonObject]
    internal class FigureObject
    {
        [JsonProperty("type")] 
        public readonly ObjectType type;
        
        [JsonProperty("behaviours")] 
        public readonly List<FigureBehaviour> behaviours;
    }
}