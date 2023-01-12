using System;
using System.Collections.Generic;
using UnityEngine;
namespace PlatformerMVC
{
    public enum Track
    {
        idle,
        walk,
        jump,
        ñrawl
    }
    [CreateAssetMenu(fileName = "SpriteAnimationsConfig", menuName = "Configs/SpriteAnimationsConfig", order = 1)]
    public class SpriteAnimationsConfig : ScriptableObject
    {
        [Serializable]
        public class SpritesSequence
        {
            public Track Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }
        public List<SpritesSequence> Sequences = new List<SpritesSequence>();
    }
}
