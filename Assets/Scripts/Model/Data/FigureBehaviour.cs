using System.Collections.Generic;
using Newtonsoft.Json;

namespace Model.Data
{
    [JsonObject]
    internal class FigureBehaviour
    {
        [JsonProperty("type")] 
        public readonly BehaviourType type;
        
        [JsonProperty("from")] 
        public readonly List<int> from;
        
        [JsonProperty("to")] 
        public readonly List<int> to;        
        
        [JsonProperty("time")] 
        public readonly int time;
    }
}