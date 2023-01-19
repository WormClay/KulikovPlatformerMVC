using System;
using UnityEngine;
namespace PlatformerMVC
{
    public sealed class QuestObjectView : LevelObjectView
    {
        public int Id => _id;
        [SerializeField] private Color _completedColor;
        [SerializeField] private int _id;
        public Action<LevelObjectView> OnLevelObjectContact { get; set; }
        private Color _defaultColor;
        #region Unity methods
        private void Awake()
        {
            _defaultColor = SpriteRenderer.color;
        }
        #endregion
        #region Methods
        public void ProcessComplete()
        {
            SpriteRenderer.color = _completedColor;
        }
        public void ProcessActivate()
        {
            SpriteRenderer.color = _defaultColor;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out LevelObjectView contactView)) 
            {
                OnLevelObjectContact?.Invoke(contactView);
            }
        }
        #endregion
    }
}