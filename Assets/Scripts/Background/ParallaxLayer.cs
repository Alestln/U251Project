using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _parallaxFactor = 0.5f;

    private Vector3 _lastCameraPosition;

    private void Start()
    {
        _lastCameraPosition = _cameraTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 delta = _cameraTransform.position - _lastCameraPosition;
        transform.position += new Vector3(delta.x * _parallaxFactor, delta.y * _parallaxFactor, 0);
        _lastCameraPosition = _cameraTransform.position;
    }
}
