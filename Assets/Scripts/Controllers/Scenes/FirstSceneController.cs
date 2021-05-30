namespace Controllers.Scenes
{
    public class FirstSceneController : SwitchableSceneController
    {
        public const string SceneName = "1_FirstScene";

        protected override string DestinationName => SecondSceneController.SceneName;
    }
}