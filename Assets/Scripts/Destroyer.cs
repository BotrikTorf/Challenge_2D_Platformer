using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private Vector3 _destroy;
    private float _distancePlayer;

    private void Start()
    {
        _destroy = transform.position;
        _distancePlayer = _destroy.x;
    }

    private void Update()
    {
        _destroy.x = _player.transform.position.x + _distancePlayer;
        transform.position = _destroy;
    }
}
