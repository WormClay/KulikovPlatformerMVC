using UnityEngine;

namespace PlatformerMVC
{
    public class SimplePatrolAIModel
    {
        #region Fields
        private readonly AIConfig _config;
        private Transform _target;
        private int _currentPointIndex;
        private bool _isPlayerTarget = false;
        #endregion
        #region Class life cycles
        public SimplePatrolAIModel(AIConfig config)
        {
            _config = config;
            _target = GetNextWaypoint();
        }
        #endregion
        #region Methods
        public Vector2 CalculateVelocity(Vector2 fromPosition)
        {
            var sqrDistance = Vector2.SqrMagnitude((Vector2)_config.playerTransform.position - fromPosition);
            if (sqrDistance <= _config.maxDistanceToPlayer)
            {
                if (!_isPlayerTarget)
                {
                    _target = _config.playerTransform;
                    _isPlayerTarget = true;
                }
            }
            else
            {
                if (_isPlayerTarget) 
                {
                    _isPlayerTarget = false;
                    _target = GetNextWaypoint(); 
                }
                sqrDistance = Vector2.SqrMagnitude((Vector2)_target.position - fromPosition);
                if (sqrDistance <= _config.minDistanceToTarget)
                {
                    _target = GetNextWaypoint();
                }
            }
            var direction = ((Vector2)_target.position - fromPosition).normalized;
            direction.Set(direction.x, 0); 
            return _config.speed * direction;
        }
        private Transform GetNextWaypoint()
        {
            _currentPointIndex = (_currentPointIndex + 1) % _config.waypoints.Length;
            return _config.waypoints[_currentPointIndex];
        }
        #endregion
    }
}