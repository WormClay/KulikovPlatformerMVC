using UnityEngine;
namespace PlatformerMVC
{
    public sealed class BulletView : MonoBehaviour
    {
        public Transform Transform;
        public Rigidbody2D Rigidbody2D;
        public Collider2D Collider2D;
        public TrailRenderer TrailRenderer; 
        public void SetVisible(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}
