using UnityEngine;

public class BirdMover : MonoBehaviour
{
    private float _speed = 5;

    private void Update() => transform.Translate(Vector3.left * _speed * Time.deltaTime);

}
