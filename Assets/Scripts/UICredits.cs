using UnityEngine;
using UnityEngine.SceneManagement;

public class UICredits : MonoBehaviour
{
    private UIFadeEffect fadeEffect;
    [SerializeField] private RectTransform rectT;
    [SerializeField] private float scrollSpeed = 200;
    [SerializeField] private string mainMeniuSceneName = "MainMeniu";
    [SerializeField] private float offScreenPosition = 1800;
    private bool creditsSkipped;

    private void Awake()
    {
        fadeEffect = GetComponentInChildren<UIFadeEffect>();
        fadeEffect.ScreenFade(0, 1);
    }

    private void Update()
    {
        rectT.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
        if (rectT.anchoredPosition.y > offScreenPosition) GoToMainMenu();
    }

    public void SkipCredits()
    {
        if (creditsSkipped == false)
        {
            scrollSpeed *= 10;
            creditsSkipped = true;
        }
        else GoToMainMenu();
    }

    private void GoToMainMenu() => fadeEffect.ScreenFade(1, 1, SwitchToMenuScene);

    private void SwitchToMenuScene()
    {
        SceneManager.LoadScene(mainMeniuSceneName);
    }
}