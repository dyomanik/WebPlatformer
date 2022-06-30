using UnityEngine.Tilemaps;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace My2DPlatformer.Tilemaps
{
    public class GenerateLevelView : MonoBehaviour
    {
        [SerializeField]
        private List<LevelData> _levelData;

        [SerializeField]
        private Tilemap _tileMapGround;

        [SerializeField]
        private Tilemap _tileMapWater;

        [SerializeField]
        private Tile _tileGround;

        [SerializeField]
        private Tile _tileWater;

        [SerializeField]
        private int _widthMap;

        [SerializeField]
        private int _heightMap;

        [SerializeField]
        private int _factorSmooth;

        [SerializeField]
        [Range(0, 100)]
        private int _randomFillPercent;

        public Tilemap TileMapGround => _tileMapGround;
        public Tilemap TileMapWater => _tileMapWater;
        public Tile TileGround => _tileGround;
        public Tile TileWater => _tileWater;
        public int WidthMap => _widthMap;
        public int HeightMap => _heightMap;
        public int FactorSmooth => _factorSmooth;
        public int RandomFillPercent => _randomFillPercent;
        public List<LevelData> LevelData => _levelData;
    }

    [Serializable]
    public class LevelData
    {
        public TileType tileType;
        public Tilemap tileMap;
        public Tile tile;
    }

    public enum TileType
    {
        none,
        ground,
        water,
    }
}