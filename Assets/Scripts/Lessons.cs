using System.Collections.Generic;
using UnityEngine;
namespace PlatformerMVC 
{
    public class Lessons : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SpriteRenderer _back;
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private CannonView _cannonView;
        private ParalaxManager _paralaxManager;
        private SpriteAnimator _spriteAnimatorEnemy;
        private MainHeroWalker _mainHeroWalker;
        private AimingMuzzle _aimingMuzzle;
        private List<BulletView> _bulletViews = new List<BulletView>();
        private BulletsEmitter _bulletsEmitter;
        private void Start()
        {
            _mainHeroWalker = new MainHeroWalker(_characterView);
            _aimingMuzzle = new AimingMuzzle(_cannonView.MuzzleTransform, _characterView.transform);

            var bullet = Resources.Load<BulletView>("Bullet");
            _bulletViews.Add(Instantiate(bullet, _cannonView.MuzzleTransform));
            _bulletViews.Add(Instantiate(bullet, _cannonView.MuzzleTransform));
            _bulletViews.Add(Instantiate(bullet, _cannonView.MuzzleTransform));
            _bulletsEmitter = new BulletsEmitter(_bulletViews, _cannonView.MuzzleTransform);

            _paralaxManager = new ParalaxManager(_camera.transform, _back.transform);
        }
        private void Update()
        {
            //_spriteAnimator.Update();
            _mainHeroWalker.Update();
            _aimingMuzzle.Update();
            _bulletsEmitter.Update();
            //_spriteAnimatorEnemy.Update();
            _paralaxManager.Update();
        }
        private void FixedUpdate()
        {
            //_someManager.FixedUpdate();
            //update logic managers here <6>
        }
        private void OnDestroy()
        {
            _mainHeroWalker.OnDestroy();
            //_spriteAnimator.Dispose();
            //_someManager.Dispose();
            //dispose logic managers here <7>
        }
    } 
}
