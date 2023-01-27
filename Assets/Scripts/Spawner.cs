using UnityEngine;

public class Spawner : Object_Pool
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _prefabBird;
    [SerializeField] private float _secondBetweenSpawn;
    [SerializeField] private Transform[] _spawnPoints;

    private Vector3 _spawner;
    private float _distancePlayer;
    private float _elapsedTime = 0;

    private void Start()
    {
        _spawner = transform.position;
        _distancePlayer = _spawner.x;
        Initialize(_prefabBird);
    }

    private void Update()
    {
        _spawner.x = _player.transform.position.x + _distancePlayer;
        transform.position = _spawner;

        _elapsedTime += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (_elapsedTime >= _secondBetweenSpawn)
        {
            if (TryGetObject(out GameObject bird))
            {
                _elapsedTime = 0;
                int spawntPointNumber = Random.Range(0, _spawnPoints.Length);
                SetBird(bird, _spawnPoints[spawntPointNumber].position);
            }
        }
    }

    private void SetBird(GameObject bird, Vector3 spawntPoint)
    {
        bird.SetActive(true);
        bird.transform.position = spawntPoint;
    }
}
