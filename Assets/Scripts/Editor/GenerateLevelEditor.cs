using UnityEditor;
using UnityEngine;
namespace My2DPlatformer.Tilemaps
{
    [CustomEditor(typeof(GenerateLevelView))]
    public class GenerateLevelEditor : Editor
    {
        private GeneratorLevelController _generatorLevelController;

        private void OnEnable()
        {
            var generateLevelView = (GenerateLevelView)target;
            _generatorLevelController = new GeneratorLevelController(generateLevelView);
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            serializedObject.Update();
            GUILayout.Space(20);
            GUILayout.Label("Generator of tiles", EditorStyles.boldLabel);
            var tileMapGround = serializedObject.FindProperty("_tileMapGround");
            var tileMapWater = serializedObject.FindProperty("_tileMapWater");
            EditorGUILayout.PropertyField(tileMapGround);
            EditorGUILayout.PropertyField(tileMapWater);

            if (GUILayout.Button("Generate", EditorStyles.miniButtonMid))
            {
                _generatorLevelController.Awake();
            }
            
            if (GUILayout.Button("Clear", EditorStyles.miniButtonMid))
            {
                _generatorLevelController.ClearTileMap();
            }
            GUILayout.Space(100);
            serializedObject.ApplyModifiedProperties();
        }
    }
}