using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManageButtons : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Button _buttonCure;
    [SerializeField] private Button _buttonDamage;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private int _damage;
    [SerializeField] private int _cure;

    private void Start() => _text.text = _character.MaxHealth.ToString();
    
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
        _character.TakeDamage(_damage);
        _text.text = _character.Health.ToString();
    }

    private void OnButtonCureClick()
    {
        _character.ReceiveHealing(_cure);
        _text.text = _character.Health.ToString();
    }
}
