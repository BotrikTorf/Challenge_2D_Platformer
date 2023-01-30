using System.Collections;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _prefabBird;
    [SerializeField] private float _secondBetweenSpawn;
    [SerializeField] private Transform[] _spawnPoints;

    private Vector3 _spawner;
    private float _distancePlayer;
    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _spawner = transform.position;
        _distancePlayer = _spawner.x;
        Initialize(_prefabBird);
        _waitForSeconds = new WaitForSeconds(_secondBetweenSpawn);
        StartCoroutine(SpawnBird());
    }

    private void Update()
    {
        _spawner.x = _player.transform.position.x + _distancePlayer;
        transform.position = _spawner;
    }

    private IEnumerator SpawnBird()
    {
        while (true)
        {
            if (TryGetObject(out GameObject bird))
            {
                int spawntPointNumber = Random.Range(0, _spawnPoints.Length);
                SetBird(bird, _spawnPoints[spawntPointNumber].position);
            }
            yield return _waitForSeconds;
        }
    }

    private void SetBird(GameObject bird, Vector3 spawntPoint)
    {
        bird.SetActive(true);
        bird.transform.position = spawntPoint;
    }
}
