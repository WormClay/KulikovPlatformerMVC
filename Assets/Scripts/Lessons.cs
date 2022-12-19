using UnityEngine;
namespace PlatformerMVC 
{
    public class Lessons : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SpriteRenderer _back;
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private EnemyView _enemyView;
        private ParalaxManager _paralaxManager;
        private SpriteAnimator _spriteAnimator;
        private SpriteAnimator _spriteAnimatorEnemy;
        private void Start()
        {
            SpriteAnimationsConfig config = Resources.Load<SpriteAnimationsConfig>("SpriteAnimationsConfig");
            _spriteAnimator = new SpriteAnimator(config);
            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.walk, true, 10);

            SpriteAnimationsConfig configEnemy = Resources.Load<SpriteAnimationsConfig>("SpriteAnimationsConfigEnemy");
            _spriteAnimatorEnemy = new SpriteAnimator(configEnemy);
            _spriteAnimatorEnemy.StartAnimation(_enemyView.SpriteRenderer, Track.walk, true, 10);

            _paralaxManager = new ParalaxManager(_camera.transform, _back.transform);
        }
        private void Update()
        {
            _spriteAnimator.Update();
            _spriteAnimatorEnemy.Update();
            _paralaxManager.Update();
        }
        private void FixedUpdate()
        {
            //_someManager.FixedUpdate();
            //update logic managers here <6>
        }
        private void OnDestroy()
        {
            _spriteAnimator.Dispose();
            //_someManager.Dispose();
            //dispose logic managers here <7>
        }
    } 
}
