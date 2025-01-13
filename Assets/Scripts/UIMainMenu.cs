using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    private UIFadeEffect fadeEffect;
    public string sceneName;

    [SerializeField] private GameObject[] uiElements;

    private void Awake()
    {
        fadeEffect = GetComponentInChildren<UIFadeEffect>();
    }

    private void Start()
    {
        fadeEffect.ScreenFade(0, 1.5f);
    }

    public void SwitchUI(GameObject uiToEnable)
    {
        foreach (GameObject ui in uiElements)
        {
            ui.SetActive(false);
        }

        uiToEnable.SetActive(true);
    }

    public void NewGame()
    {
        fadeEffect.ScreenFade(1, 1.5f, LoadLevelScene);
    }

    private void LoadLevelScene() => SceneManager.LoadScene(sceneName);
}