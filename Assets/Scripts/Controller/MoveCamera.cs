using UnityEngine;
namespace PlatformerMVC
{
    public class MoveCamera
    {
        private Transform _camera;
        public MoveCamera(Transform camera)
        {
            _camera = camera;
        }
        public void Update(Vector3 target)
        {
            _camera.position = new Vector3(target.x, target.y, _camera.position.z);
        }
    }
}
