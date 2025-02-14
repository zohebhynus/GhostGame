using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public  Image keyMessagePanel;
    private TMP_Text keyMessageText;
    private float keyMessagePanelInitialAlpha;
    private float keyMessageTextInitialAlpha;

    public Image ghostMessagePanel;
    private TMP_Text ghostMessageText;
    private float ghostMessagePanelInitialAlpha;
    private float ghostMessageTextInitialAlpha;


    public Image onScreenPickUpButtonImage;
    private TMP_Text onScreenPickUpButtonText;
    private float onScreenPickUpButtonImageInitialAlpha;
    private float onScreenPickUpButtonTextInitialAlpha;

    public GameObject onScreenControls;


    private bool startFade = true;
    private float fadeDuration = 4.0f;
    private float fadeTimer = 0.0f;
    private float fadeDelay = 1.0f;


    void Start()
    {
#if !UNITY_ANDROID
        onScreenControls.SetActive(false);
#endif

        keyMessageText = keyMessagePanel.GetComponentInChildren<TMP_Text>();
        ghostMessageText = ghostMessagePanel.GetComponentInChildren<TMP_Text>();

        keyMessagePanelInitialAlpha = keyMessagePanel.color.a;
        keyMessageTextInitialAlpha = keyMessageText.color.a;

        ghostMessagePanelInitialAlpha = ghostMessagePanel.color.a;
        ghostMessageTextInitialAlpha = ghostMessageText.color.a;

        onScreenPickUpButtonText = onScreenPickUpButtonImage.GetComponentInChildren<TMP_Text>();
        onScreenPickUpButtonImageInitialAlpha = onScreenPickUpButtonImage.color.a;
        onScreenPickUpButtonTextInitialAlpha = onScreenPickUpButtonText.color.a;
    }

    void Update()
    {
        FadeOutMessages();
    }

    void FadeOutMessages()
    {
        if (startFade)
        {
            fadeTimer += Time.deltaTime;

            float fadeRatioFirst = fadeTimer / fadeDuration;

            float fadeRatioSecond = (fadeTimer - fadeDelay) / fadeDuration;
            fadeRatioSecond = Mathf.Clamp01(fadeRatioSecond);
            float newAlpha = 0.0f;

            if (fadeRatioFirst <= 1.0f)
            {
                newAlpha = Mathf.Lerp(keyMessagePanelInitialAlpha, 0.0f, fadeRatioFirst);
                keyMessagePanel.color = new Color(keyMessagePanel.color.r, keyMessagePanel.color.g, keyMessagePanel.color.b, newAlpha);

                newAlpha = Mathf.Lerp(keyMessageTextInitialAlpha, 0.0f, fadeRatioFirst);
                keyMessageText.color = new Color(keyMessageText.color.r, keyMessageText.color.g, keyMessageText.color.b, newAlpha);

                newAlpha = Mathf.Lerp(onScreenPickUpButtonImageInitialAlpha, 0.0f, fadeRatioFirst);
                onScreenPickUpButtonImage.color = new Color(onScreenPickUpButtonImage.color.r, onScreenPickUpButtonImage.color.g, onScreenPickUpButtonImage.color.b, newAlpha);

                newAlpha = Mathf.Lerp(onScreenPickUpButtonTextInitialAlpha, 0.0f, fadeRatioFirst);
                onScreenPickUpButtonText.color = new Color(onScreenPickUpButtonText.color.r, onScreenPickUpButtonText.color.g, onScreenPickUpButtonText.color.b, newAlpha);
            }


            if (fadeRatioSecond > 0)
            {
                newAlpha = Mathf.Lerp(ghostMessagePanelInitialAlpha, 0.0f, fadeRatioSecond);
                ghostMessagePanel.color = new Color(ghostMessagePanel.color.r, ghostMessagePanel.color.g, ghostMessagePanel.color.b, newAlpha);

                newAlpha = Mathf.Lerp(ghostMessageTextInitialAlpha, 0.0f, fadeRatioSecond);
                ghostMessageText.color = new Color(ghostMessageText.color.r, ghostMessageText.color.g, ghostMessageText.color.b, newAlpha);
            }


            if (fadeTimer >= fadeDuration + fadeDelay)
            {
                startFade = false;
            }
        }
    }
}
