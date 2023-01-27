using UnityEngine;

public class Bird_Mover : MonoBehaviour
{
    private float _speed = 5;

    void Update() => transform.Translate(Vector3.left * _speed * Time.deltaTime);

}
