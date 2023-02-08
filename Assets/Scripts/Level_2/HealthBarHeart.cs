using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthBarHeart : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Heart _heart;

    private List<Heart> _hearts = new List<Heart>();

    private void Start() => CreateHeart(_character.MaxHealth);

    private void OnEnable() => _character.HealthChange += OnHealthChange;

    private void OnDisable() => _character.HealthChange -= OnHealthChange;

    private void OnHealthChange(int health)
    {
        if (health > _hearts.Count)
            CreateHeart(health - _hearts.Count);
        else
            DestroyHeart(_hearts.Count - health);
    }

    private void CreateHeart(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Heart newHeart = Instantiate(_heart, transform);
            _hearts.Add(newHeart);
            newHeart.ToFill();
        }
    }

    private void DestroyHeart(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Heart endHeard = _hearts.Last();
            _hearts.Remove(endHeard);
            endHeard.ToEmpty();
        }
    }
}
