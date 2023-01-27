using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text _textCoin;
    [SerializeField] private TMP_Text _textHealth;

    private int _coin;
    private int _health;

    public event UnityAction Died;

    void Start()
    {
        _coin = 0;
        _health = 5;
        _textCoin.text = _coin.ToString();
        _textHealth.text = _health.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin _))
        {
            _coin++;
            _textCoin.text = _coin.ToString();
        }
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health > 0)
            _textHealth.text = _health.ToString();
        else
            Die();
    }

    public void Die()
    {
        Died?.Invoke();
    }
}
