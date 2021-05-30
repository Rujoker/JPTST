using System;
using Model.Data;
using SergeyPchelintsev.Controllers;
using UnityEngine;
using Utils;

namespace Model.Behaviours
{
    internal class RotateBehaviour : IBehaviour
    {
        private readonly Vector3 from;
        private readonly Vector3 to;
        private readonly int time;

        public RotateBehaviour(FigureBehaviour data)
        {
            from = Util.FromListToVector3(data.from);
            to = Util.FromListToVector3(data.to);
            time = data.time;
        }

        public bool Act(Figure figure, float timer)
        {
            if (timer >= time) return false;
            
            var part = (float)Math.Round(timer / time, 2);
            figure.transform.rotation = Quaternion.Euler(from + (to - from) * part);

            return true;
        }
    }   
}

