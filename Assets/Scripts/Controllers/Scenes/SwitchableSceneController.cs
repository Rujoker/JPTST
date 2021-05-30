using Model.Behaviours;
using Model.Data;
using Model.State;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Controllers.Scenes
{
    public abstract class SwitchableSceneController : MonoBehaviour
    {
        protected abstract string DestinationName { get; }

        [SerializeField] private Button switchButton;
        [SerializeField] private Transform objectsRoot;
        [SerializeField] private FigurePrefabHub figuresHub;
        [SerializeField] private string jsonFileName = "json";
        
        private void Awake()
        {
            switchButton.onClick.AddListener(SwitchScene);
            PrepareState();
        }
        
        private void SwitchScene()
        {
            SceneManager.LoadSceneAsync(DestinationName);
        }

        #region States
        private void PrepareState()
        {
            if (ObjectsBuffer.CreatedFigures.Count == 0) CreateState();
            else RestoreState();
        }
        
        private void RestoreState()
        {
            foreach (var figure in ObjectsBuffer.CreatedFigures)
            {
                var prefab = figuresHub.FindByType(figure.Value.Type);
                if (prefab == null) continue;

                var createdFigure = Instantiate(prefab, objectsRoot);
                createdFigure.transform.position = figure.Value.Position;
                createdFigure.transform.rotation = Quaternion.Euler(figure.Value.Rotation);
                createdFigure.Timer = figure.Value.Timer;
                createdFigure.Behaviours.AddRange(figure.Value.Behaviours);
            }
            ObjectsBuffer.CreatedFigures.Clear();
        }

        private Data PrepareConfig()
        {
            var textAsset = Resources.Load<TextAsset>(jsonFileName);
            
            if (textAsset == null)
            {
                Debug.Log($"File {jsonFileName} not found! Check file name!");
                return null;
            }
            
            var data = JsonConvert.DeserializeObject<Data>(textAsset.text);
            Resources.UnloadAsset(textAsset);
            return data;
        }
        
        private void CreateState()
        {
            var data = PrepareConfig();
            if (data == null) return;
            
            foreach (var figure in data.Objects)
            {
                var prefab = figuresHub.FindByType(figure.type);
                if (prefab == null) continue;
                
                var createdFigure = Instantiate(prefab, objectsRoot);
                
                foreach (var behaviourData in figure.behaviours)
                {
                    var behaviour = BehaviourCreator.Create(behaviourData);
                    if (behaviour != null) createdFigure.Behaviours.Add(behaviour);
                }
            }
        }
        #endregion
    }
}

