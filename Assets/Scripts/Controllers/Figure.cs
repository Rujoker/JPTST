using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Model;
using Model.Behaviours;
using Model.State;
using UnityEngine;

namespace SergeyPchelintsev.Controllers
{
    public class Figure : MonoBehaviour
    {
        [SerializeField] private ObjectType figureType;

        private List<IBehaviour> behaviours = new List<IBehaviour>();
        private bool isAllFinished;
        
        internal List<IBehaviour> Behaviours => behaviours;
        internal ObjectType FigureType => figureType;
        internal float Timer { get; set; }

        private void Update()
        {
            if (isAllFinished) return;

            Timer += Time.deltaTime;
            var performingCount = behaviours.Count(behaviour => behaviour.Act(this, Timer));
            if (performingCount == 0) isAllFinished = true;
        }
        
        private void OnDestroy()
        {
            var state = new ObjectState(figureType, transform.position, 
                transform.rotation.eulerAngles, Timer, behaviours);
            ObjectsBuffer.CreatedFigures.Add(GetInstanceID(), state);
        }
    }   
}

