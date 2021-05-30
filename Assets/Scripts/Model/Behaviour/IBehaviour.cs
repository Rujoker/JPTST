using SergeyPchelintsev.Controllers;

namespace Model.Behaviours
{
    internal interface IBehaviour
    {
        public bool Act(Figure figure, float timer);
    }   
}

