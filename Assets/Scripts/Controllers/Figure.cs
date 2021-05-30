using System.Collections;
using System.Collections.Generic;
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

        private const float Frequency = 0.02f;

        internal List<IBehaviour> Behaviours => behaviours;
        internal ObjectType FigureType => figureType;
        internal float Timer { get; set; }

        private void Start()
        {
            StartCoroutine(RunBehaviours());
        }

        private IEnumerator RunBehaviours()
        {
            var performingCount = int.MaxValue;
            
            while(performingCount > 0)
            {
                performingCount = 0;
                
                foreach (var behaviour in behaviours)
                {
                    if (behaviour.Act(this, Timer)) performingCount++;
                }
 
                yield return new WaitForSeconds(Frequency);
                
                Timer += Frequency;
            }
        }
        
        private void OnDestroy()
        {
            var state = new ObjectState(figureType, transform.position, 
                transform.rotation.eulerAngles, Timer, behaviours);
            ObjectsBuffer.CreatedFigures.Add(GetInstanceID(), state);
        }
    }   
}

