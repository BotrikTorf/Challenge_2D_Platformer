using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBarTwo : MonoBehaviour
{
    [SerializeField] private PlayerLevel2 _player;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _imageFill;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _player.MaxHealth;
        _slider.wholeNumbers = true;
        _slider.value = _slider.maxValue;
        _imageFill.color = _gradient.Evaluate(1);
    }

    public void SetHealth()
    {
        _slider.value = _player.Health;
        _imageFill.color = _gradient.Evaluate(_slider.normalizedValue);
    }

}
