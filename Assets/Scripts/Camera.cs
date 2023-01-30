using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Vector3 _camera;

    private void Start() => _camera = transform.position;

    private void Update()
    {
        _camera.x = _player.transform.position.x;
        transform.position = _camera;
    }
}
