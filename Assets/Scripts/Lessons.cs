using System.Collections.Generic;
using UnityEngine;
namespace PlatformerMVC 
{
    public class Lessons : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SpriteRenderer _back;
        [SerializeField] private LevelObjectView _characterView;
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private CannonView _cannonView;
        [SerializeField] private GeneratorLevelView _generatorView;
        private ParalaxManager _paralaxManager;
        private SpriteAnimator _spriteAnimatorEnemy;
        // private MainHeroWalker _mainHeroWalker;
        private MainHeroPhysicsWalker _mainHeroWalker;
        private AimingMuzzle _aimingMuzzle;
        private List<BulletView> _bulletViews = new List<BulletView>();
        private BulletsEmitter _bulletsEmitter;
        private List<LevelObjectView> _coinViews = new List<LevelObjectView>();
        private CoinsManager _coinsManager;
        private List<LevelObjectView> _deathZones = new List<LevelObjectView>();
        private List<LevelObjectView> _winZones = new List<LevelObjectView>();
        private LevelCompleteManager _levelCompleteManager;
        //private MoveCamera _moveCamera;
        private CameraController _cameraController;
        private GeneratorController _generatorController;
        private void Start()
        {
            _mainHeroWalker = new MainHeroPhysicsWalker(_characterView);
            _aimingMuzzle = new AimingMuzzle(_cannonView.MuzzleTransform, _characterView.transform);

            var bullet = Resources.Load<BulletView>("Bullet");
            _bulletViews.Add(Instantiate(bullet));
            _bulletViews.Add(Instantiate(bullet));
            _bulletViews.Add(Instantiate(bullet));
            _bulletsEmitter = new BulletsEmitter(_bulletViews, _cannonView.MuzzleTransform);

            _paralaxManager = new ParalaxManager(_camera.transform, _back.transform);

            _coinViews.AddRange(GameObject.Find("Coins").GetComponentsInChildren<LevelObjectView>());
            _coinsManager = new CoinsManager(_characterView, _coinViews);

            _deathZones.AddRange(GameObject.Find("DeathZones").GetComponentsInChildren<LevelObjectView>());
            _winZones.AddRange(GameObject.Find("WinZones").GetComponentsInChildren<LevelObjectView>());
            _levelCompleteManager = new LevelCompleteManager(_characterView, _deathZones, _winZones);

            //_moveCamera = new MoveCamera(_camera.transform);
            _cameraController = new CameraController(_characterView, _camera.transform);

            _generatorController = new GeneratorController(_generatorView);
            _generatorController.Start();
        }
        private void Update()
        {
            //_spriteAnimator.Update();
            //_mainHeroWalker.Update();
            _aimingMuzzle.Update();
            _bulletsEmitter.Update();
            //_spriteAnimatorEnemy.Update();
            _paralaxManager.Update();
            _coinsManager.Update();
            _levelCompleteManager.Update();
            //_moveCamera.Update(_characterView.transform.position);
            _cameraController.Update();
        }
        private void FixedUpdate()
        {
            _mainHeroWalker.FixedUpdate();
        }
        private void OnDestroy()
        {
        }
    } 
}
