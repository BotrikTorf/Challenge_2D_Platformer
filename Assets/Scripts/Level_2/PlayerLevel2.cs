using UnityEngine;

public class PlayerLevel2 : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private HealthBarOne _healthBarOne;
    [SerializeField] private HealthBarTwo _healthBarTwo;

    private int _health;
    private float _changeFactor;

    public int Health => _health;
    public int MaxHealth => _maxHealth;

    private void Start()
    {
        _health = _maxHealth;
        _changeFactor = transform.localScale.x / _health;
    }

    public void TakeDamage()
    {
        if (_health > 0)
        {
            _health -= 1;
            ChangeScale(-_changeFactor);
            _healthBarOne.DestroyHeart();
            _healthBarTwo.SetHealth();
        }
    }

    public void ReceiveHealing()
    {
        if (_health < _maxHealth)
        {
            _health += 1;
            ChangeScale(_changeFactor);
            _healthBarOne.CreateHeart();
            _healthBarTwo.SetHealth();
        }
    }

    private void ChangeScale(float changeFactor) => transform.localScale += new Vector3(1, 1, 0) * changeFactor;
}
