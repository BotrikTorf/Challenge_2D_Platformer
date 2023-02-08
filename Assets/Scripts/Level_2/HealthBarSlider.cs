using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBarSlider : MonoBehaviour
{
    [SerializeField] private Character _player;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _imageFill;
    [SerializeField] private float _duration;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _player.MaxHealth;
        _slider.value = _slider.maxValue;
        _imageFill.color = _gradient.Evaluate(1);
    }

    private void OnEnable() => _player.HealthChange += OnHealthChange;

    private void OnDisable() => _player.HealthChange -= OnHealthChange;

    private void OnHealthChange(int health) => StartCoroutine(Filling(_slider.value, health, _duration));

    private IEnumerator Filling(float startValue, float endValue, float duration)
    {
        float elapsed = 0;
        float nextValue;

        while (elapsed < duration)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
            _slider.value = nextValue;
            elapsed += Time.deltaTime;
            yield return null;
        }

        _imageFill.color = _gradient.Evaluate(_slider.normalizedValue);
        _slider.value = _player.Health;
        StopCoroutine(Filling(_slider.value, _player.Health, 1F));
    }
}
