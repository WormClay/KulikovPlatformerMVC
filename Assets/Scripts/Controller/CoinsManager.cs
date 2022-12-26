using System;
using System.Collections.Generic;
using UnityEngine;
namespace PlatformerMVC
{
    public sealed class CoinsManager : IDisposable
    {
        private const float _animationsSpeed = 10;
        private LevelObjectView _characterView;
        private SpriteAnimator _spriteAnimator;
        private List<LevelObjectView> _coinViews;
        public CoinsManager(LevelObjectView characterView, List<LevelObjectView> coinViews)
        {
            _characterView = characterView;
            SpriteAnimationsConfig config = Resources.Load<SpriteAnimationsConfig>("AnimCoin");
            _spriteAnimator = new SpriteAnimator(config);
            _coinViews = coinViews;
            _characterView.OnLevelObjectContact += OnLevelObjectContact;
            foreach (var coinView in coinViews)
            {
                _spriteAnimator.StartAnimation(coinView.SpriteRenderer, Track.idle, true, _animationsSpeed);
            }
        }
        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_coinViews.Contains(contactView))
            {
                _spriteAnimator.StopAnimation(contactView.SpriteRenderer);
                GameObject.Destroy(contactView.gameObject);
            }
        }
        public void Update() 
        {
            _spriteAnimator.Update();
        }
        public void Dispose()
        {
            _characterView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}