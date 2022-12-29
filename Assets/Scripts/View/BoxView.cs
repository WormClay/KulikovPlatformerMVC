using UnityEngine;
namespace PlatformerMVC
{
    public class BoxView : MonoBehaviour
    {
        public SpriteRenderer CoinRenderer;
        void Start()
        {
            CoinRenderer.enabled = false;
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (CoinRenderer != null) CoinRenderer.enabled = true;
        }
    }
}
