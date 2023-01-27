using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private Vector3 _camera;

    private void Start() => _camera = transform.position;
    private void Update()
    {
        _camera.x = _player.transform.position.x;
        transform.position = _camera;
    }
}
