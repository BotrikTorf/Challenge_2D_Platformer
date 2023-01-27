using UnityEngine;

public class Bird : MonoBehaviour
{
    private int _damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
            gameObject.SetActive(false);
        }

        if (collision.TryGetComponent(out Destroyer _))
            gameObject.SetActive(false);
    }
}
