using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _health;
    private float _changeFactor;

    public event UnityAction<int> HealthChange;

    public int Health => _health;
    public int MaxHealth => _maxHealth;

    private void Start()
    {
        _health = _maxHealth;
        _changeFactor = transform.localScale.x / _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        int tempHealth = _health;

        if (_health > 0)
        {
            _health -= damage;

            if (_health < 0)
            {
                _health = 0;
                damage = tempHealth;
            }

            ChangeScale(-_changeFactor * damage);
            HealthChange?.Invoke(_health);
        }
    }

    public void ReceiveHealing(int cure)
    {
        int tempCure = _maxHealth - _health;

        if (tempCure > 0)
        {
            _health += cure;

            if (_health > _maxHealth)
                _health = _maxHealth;
            else
                tempCure = cure;

            ChangeScale(_changeFactor * tempCure);
            HealthChange?.Invoke(_health);
        }
    }

    private void ChangeScale(float changeFactor) =>
        transform.localScale += new Vector3(1, 1, 0) * changeFactor;
}
