namespace Controllers.Scenes
{
    public class SecondSceneController : SwitchableSceneController
    {
        public const string SceneName = "2_SecondScene";

        protected override string DestinationName => FirstSceneController.SceneName;
    }
}