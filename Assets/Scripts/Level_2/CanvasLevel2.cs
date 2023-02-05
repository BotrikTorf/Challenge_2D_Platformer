using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasLevel2 : MonoBehaviour
{
    [SerializeField] private PlayerLevel2 _player;
    [SerializeField] private Button _buttonCure;
    [SerializeField] private Button _buttonDamage;
    [SerializeField] private TMP_Text _text;

    private void Start() => _text.text = _player.Health.ToString();
    
    private void OnEnable()
    {
        _buttonDamage.onClick.AddListener(OnButtonDamageClick);
        _buttonCure.onClick.AddListener(OnButtonCureClick);
    }

    private void OnDisable()
    {
        _buttonDamage.onClick.RemoveListener(OnButtonDamageClick);
        _buttonCure.onClick.RemoveListener(OnButtonCureClick);
    }

    private void OnButtonDamageClick()
    {
        _player.TakeDamage();
        _text.text = _player.Health.ToString();
    }

    private void OnButtonCureClick()
    {
        _player.ReceiveHealing();
        _text.text = _player.Health.ToString();
    }
}
