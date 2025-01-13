using UnityEngine;

public class UIInGame : MonoBehaviour
{
    public static UIInGame instance;
    public UIFadeEffect fadeEffect;

    private void Awake()
    {
        instance = this;
        fadeEffect = GetComponentInChildren<UIFadeEffect>();
    }

    private void Start()
    {
        fadeEffect.ScreenFade(0, 1);
    }
}