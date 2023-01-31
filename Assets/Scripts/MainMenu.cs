using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menuMain;
    [SerializeField] private GameObject _menuOptions;
    [SerializeField] private Button _buttonPlay;
    [SerializeField] private Button _buttonOptions;
    [SerializeField] private Button _buttonQuit;
    [SerializeField] private Button _buttonBackArrow;


    void Start()
    {
        _menuOptions.SetActive(false);
        _menuMain.SetActive(true);
    }

    private void OnEnable()
    {
        _buttonPlay.onClick.AddListener(OnButtonPlayClick);
        _buttonQuit.onClick.AddListener(OnButtonQuitClick);
        _buttonOptions.onClick.AddListener(OnButtonOptionsClick);
        _buttonBackArrow.onClick.AddListener(OnButtonBackArrowClick);
    }

    private void OnDisable()
    {
        _buttonPlay.onClick.RemoveListener(OnButtonPlayClick);
        _buttonQuit.onClick.RemoveListener(OnButtonQuitClick);
        _buttonOptions.onClick.RemoveListener(OnButtonOptionsClick);
        _buttonBackArrow.onClick.RemoveListener(OnButtonBackArrowClick);
    }

    private void OnButtonPlayClick() => SceneManager.LoadScene(1);

    private void OnButtonQuitClick() => Application.Quit();

    private void OnButtonOptionsClick()
    {
        _menuMain.SetActive(false);
        _menuOptions.SetActive(true);
    }

    private void OnButtonBackArrowClick()
    {
        _menuOptions.SetActive(false);
        _menuMain.SetActive(true);
    }
}
