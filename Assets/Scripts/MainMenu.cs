using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menuMain;
    [SerializeField] private GameObject _menuOptions;
    [SerializeField] private GameObject _menuSceneSelection;
    [SerializeField] private Button _buttonSceneSelection;
    [SerializeField] private Button _buttonOptions;
    [SerializeField] private Button _buttonQuit;
    [SerializeField] private Button _buttonBackArrow;
    [SerializeField] private Button _buttonLevel1;
    [SerializeField] private Button _buttonLevel2;

    void Start()
    {
        _menuOptions.SetActive(false);
        _menuSceneSelection.SetActive(false);
        _menuMain.SetActive(true);
    }

    private void OnEnable()
    {
        _buttonSceneSelection.onClick.AddListener(OnButtonSceneSelectionClick);
        _buttonQuit.onClick.AddListener(OnButtonQuitClick);
        _buttonOptions.onClick.AddListener(OnButtonOptionsClick);
        _buttonBackArrow.onClick.AddListener(OnButtonBackArrowClick);
        _buttonLevel1.onClick.AddListener(OnButtonLevel1Click);
        _buttonLevel2.onClick.AddListener(OnButtonLevel2Click);

    }

    private void OnDisable()
    {
        _buttonSceneSelection.onClick.RemoveListener(OnButtonLevel1Click);
        _buttonQuit.onClick.RemoveListener(OnButtonQuitClick);
        _buttonOptions.onClick.RemoveListener(OnButtonOptionsClick);
        _buttonBackArrow.onClick.RemoveListener(OnButtonBackArrowClick);
        _buttonLevel1.onClick.RemoveListener(OnButtonLevel1Click);
        _buttonLevel2.onClick.RemoveListener(OnButtonLevel2Click);
    }

    private void OnButtonLevel1Click() => SceneManager.LoadScene(1);

    private void OnButtonLevel2Click() => SceneManager.LoadScene(2);

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

    private void OnButtonSceneSelectionClick()
    {
        _menuMain.SetActive(false);
        _menuSceneSelection.SetActive(true);
    }
}
