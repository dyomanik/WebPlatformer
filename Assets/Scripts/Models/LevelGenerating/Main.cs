using UnityEngine;
namespace My2DPlatformer.Tilemaps
{
    public class Main : MonoBehaviour
    {
        [SerializeField]
        private GenerateLevelView _generateLevelView;
        private GeneratorLevelController _generatorLevelController;

        private void Awake()
        {
            _generatorLevelController = new GeneratorLevelController(_generateLevelView);
            _generatorLevelController.Awake();
        }
    }
}