using Model.Data;

namespace Model.Behaviours
{
    internal class BehaviourCreator
    {
        public static IBehaviour Create(FigureBehaviour data)
        {
            switch (data.type)
            {
                case BehaviourType.move:
                    return new MoveBehaviour(data);
                case BehaviourType.rotate:
                    return new RotateBehaviour(data);
                default:
                    return null;
            }
        }
    }   
}

