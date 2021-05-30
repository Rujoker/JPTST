using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class Util
    {
        public static Vector3 FromListToVector3(List<int> array)
        {
            var x = array.Count > 0 ? array[0]: 0;
            var y = array.Count > 1 ? array[1]: 0;
            var z = array.Count > 2 ? array[2]: 0;
            return new Vector3(x, y, z);
        }
    }
}