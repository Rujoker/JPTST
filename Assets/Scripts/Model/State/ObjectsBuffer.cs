using System.Collections.Generic;

namespace Model.State
{
    internal static class ObjectsBuffer
    {
        internal static Dictionary<long, ObjectState> CreatedFigures = new Dictionary<long, ObjectState>();
    }
}

