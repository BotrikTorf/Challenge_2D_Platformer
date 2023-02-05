using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthBarOne : MonoBehaviour
{
    [SerializeField] private PlayerLevel2 _player;
    [SerializeField] private Heart _heart;

    private List<Heart> _hearts = new List<Heart>();

    private void Start()
    {
        for (int i = 0; i < _player.MaxHealth; i++)
            CreateHeart();
    }

    public void CreateHeart()
    {
        Heart newHeart = Instantiate(_heart, transform);
        _hearts.Add(newHeart);
        newHeart.ToFill();
    }

    public void DestroyHeart()
    {
        Heart endHeard = _hearts.Last();
        _hearts.Remove(endHeard);
        endHeard.ToEmpty();
    }
}
