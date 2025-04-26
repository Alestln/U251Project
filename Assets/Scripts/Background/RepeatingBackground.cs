using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RepeatingBackground : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [Range(0f, 1f)][SerializeField] private float _parallaxFactor = 0.5f;

    private float _spriteWidth;
    private Transform _left;
    private Transform _right;
    private Transform _center;

    private Vector3 _lastCameraPosition;
    private Vector3 _parallaxOffset;

    private void Start()
    {
        _spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;

        _center = transform;
        _left = transform.parent.Find("Left");
        _right = transform.parent.Find("Right");

        _left.position = _center.position - new Vector3(_spriteWidth, 0f, 0f);
        _right.position = _center.position + new Vector3(_spriteWidth, 0f, 0f);

        _lastCameraPosition = _camera.transform.position;
        _parallaxOffset = Vector3.zero;
    }

    private void LateUpdate()
    {
        /*Vector3 cameraDelta = _camera.transform.position - _lastCameraPosition;
        _parallaxOffset -= new Vector3(cameraDelta.x * _parallaxFactor, cameraDelta.y * _parallaxFactor, 0f);
        _lastCameraPosition = _camera.transform.position;

        Vector3 basePosition = _camera.transform.position + _parallaxOffset;
        Vector3 newCenterPosition = new Vector3(basePosition.x, _center.position.y, _center.position.z);
        _center.position = newCenterPosition;

        _left.position = _center.position - new Vector3(_spriteWidth, 0f, 0f);
        _right.position = _center.position + new Vector3(_spriteWidth, 0f, 0f);*/

        float cameraHalfWidth = _camera.orthographicSize * _camera.aspect; // 1920x1080 => aspect = 1920 / 1080 = 1.7777

        float cameraLeftEdge = _camera.transform.position.x - cameraHalfWidth;
        float cameraRightEdge = _camera.transform.position.x + cameraHalfWidth;

        float centerLeftEdge = _center.position.x - _spriteWidth / 2f;
        float centerRightEdge = _center.position.x + _spriteWidth / 2f;

        if (cameraLeftEdge > centerRightEdge)
        {
            _left.position = _right.position + Vector3.right * _spriteWidth;
            (_left, _center, _right) = (_right, _left, _center);
        }
        else if(centerRightEdge < centerLeftEdge)
        {
            _right.position = _left.position - Vector3.right * _spriteWidth;
            (_left, _center, _right) = (_center, _right, _left);
        }
    }
}
