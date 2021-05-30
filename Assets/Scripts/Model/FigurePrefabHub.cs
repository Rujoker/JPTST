using System.Collections.Generic;
using System.Linq;
using SergeyPchelintsev.Controllers;
using UnityEngine;

namespace Model.Data
{
    [CreateAssetMenu(fileName = "FiguresPrefabHub", menuName = "FiguresPrefabHub", order = 0)]
    public class FigurePrefabHub : ScriptableObject
    {
        [SerializeField] private List<Figure> figures;

        public Figure FindByType(ObjectType type)
        {
            return figures.FirstOrDefault(figure => figure.FigureType == type);
        }
    }
}