using System;
using System.Collections.Generic;
using UnityEngine;
namespace PlatformerMVC
{
    public sealed class LevelCompleteManager : IDisposable
    {
        private const float _animationsSpeed = 10;
        private Vector3 _startPosition;
        private LevelObjectView _characterView;
        private SpriteAnimator _spriteAnimator;
        private List<LevelObjectView> _deathZones;
        private List<LevelObjectView> _winZones;
        public LevelCompleteManager(LevelObjectView characterView, List<LevelObjectView> deathZones, List<LevelObjectView> winZones)
        {
            _startPosition = characterView.Transform.position;
            characterView.OnLevelObjectContact += OnLevelObjectContact;
            _characterView = characterView;
            _deathZones = deathZones;
            _winZones = winZones;
            SpriteAnimationsConfig config = Resources.Load<SpriteAnimationsConfig>("AnimFire");
            _spriteAnimator = new SpriteAnimator(config);
            foreach (var deathZone in deathZones)
            {
                _spriteAnimator.StartAnimation(deathZone.SpriteRenderer, Track.idle, true, _animationsSpeed);
            }
        }
        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_deathZones.Contains(contactView))
            {
                _characterView.Transform.position = _startPosition;
            }
            if (_winZones.Contains(contactView))
            {
                Time.timeScale = 0.1f;
                Debug.Log("WIN");
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