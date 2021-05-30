using System.Collections.Generic;
using Model.Behaviours;
using UnityEngine;

namespace Model.State
{
    internal class ObjectState
    {
        public ObjectState(ObjectType type, Vector3 position, Vector3 rotation, 
            float timer, List<IBehaviour> behaviours)
        {
            Type = type;
            Position = position;
            Rotation = rotation;
            Timer = timer;
            Behaviours = behaviours;
        }
        
        internal ObjectType Type { get; }
        internal Vector3 Position { get; }
        internal Vector3 Rotation { get; }
        internal float Timer { get; }
        internal List<IBehaviour> Behaviours { get; }
    }
}