using UnityEngine;
namespace PlatformerMVC
{
    public class CameraController
    {
        private LevelObjectView _player;
        private Transform _playerT;
        private Transform _cameraT;
        private float _cameraSpeed = 1.2f;

        private float X;
        private float Y;

        private float _offsetX;
        private float _offsetY;

        private float _xAxisInput;
        private float _yAxisInput;

        private float _treshold;

        public CameraController(LevelObjectView player, Transform camera)
        {
            _player = player;
            _playerT = player.transform;
            _cameraT = camera;
            _treshold = 0.2f;
        }

        public void Update()
        {
            _xAxisInput = Input.GetAxis("Horizontal");
            _yAxisInput = _player.Rigidbody2D.velocity.y;

            X = _playerT.position.x;
            Y = _playerT.position.y;
            if (_xAxisInput > _treshold)
            {
                _offsetX = 4;
            }
            else if (_xAxisInput < -_treshold)
            {
                _offsetX = -4;
            }
            else 
            {
                _offsetX = 0;
            }

            if (_yAxisInput > _treshold)
            {
                _offsetY = 4;
            }
            else if (_yAxisInput < -_treshold)
            {
                _offsetY = -4;
            }
            else
            {
                _offsetY = 0;
            }

            _cameraT.position = Vector3.Lerp(_cameraT.position,
                                            new Vector3(X+_offsetX, Y+_offsetY, _cameraT.position.z),
                                            Time.deltaTime * _cameraSpeed
                                            );

        }
    }
}
