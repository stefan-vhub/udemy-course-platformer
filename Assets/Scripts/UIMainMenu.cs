using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    public string sceneName;
    private UIFadeEffect fadeEffect;

    private void Awake()
    {
        fadeEffect = GetComponentInChildren<UIFadeEffect>();
    }

    private void Start()
    {
        fadeEffect.ScreenFade(0, 1.5f);
    }

    public void NewGame()
    {
        fadeEffect.ScreenFade(1, 1.5f, LoadLevelScene);
    }

    private void LoadLevelScene() => SceneManager.LoadScene(sceneName);
}