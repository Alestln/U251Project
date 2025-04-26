using UnityEngine;

public class StaticBackground : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;

    private void Awake()
    {
        if (_cameraTransform is null)
        {
            _cameraTransform = Camera.main.transform;
        }
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(_cameraTransform.position.x, _cameraTransform.position.y, transform.position.z);
    }
}
