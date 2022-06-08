using System;
using System.Collections.Generic;
using UnityEngine;
namespace My2DPlatformer
{
    [Serializable]
    public sealed class SpriteSequence
    {
        public Track Track;
        public List<Sprite> Sprites = new List<Sprite>();
    }
}