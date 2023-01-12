using UnityEngine;
namespace PlatformerMVC
{
    public class EnemiesConfigurator : MonoBehaviour
    {
        [SerializeField] private AIConfig _simplePatrolAIConfig;
        [SerializeField] private LevelObjectView _simplePatrolAIView;
        #region Fields
        private SimplePatrolAI _simplePatrolAI;
        #endregion
        #region Unity methods
        private void Start()
        {
            _simplePatrolAI = new SimplePatrolAI(_simplePatrolAIView, new SimplePatrolAIModel(_simplePatrolAIConfig));
        }
        private void FixedUpdate()
        {
            if (_simplePatrolAI != null) _simplePatrolAI.FixedUpdate();
        }
        #endregion
    }
}