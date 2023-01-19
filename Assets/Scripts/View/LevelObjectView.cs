using System;
using UnityEngine;
namespace PlatformerMVC
{
    public class LevelObjectView : MonoBehaviour
    {
        public Transform Transform;
        public SpriteRenderer SpriteRenderer;
        public Collider2D Collider2D;
        public Rigidbody2D Rigidbody2D;
        public Action<LevelObjectView> OnLevelObjectContact { get; set; }
        public DangerType DangerType = DangerType.fire;
        void OnTriggerEnter2D(Collider2D collider)
        {
            var levelObject = collider.gameObject.GetComponent<LevelObjectView>();
            OnLevelObjectContact?.Invoke(levelObject);
        }
    }
}