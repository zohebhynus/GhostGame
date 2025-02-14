using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public GameObject winText;
    
    public GameObject loseText;
    public GameObject loseProp;


    void Start()
    {
        if (GlobalValues.playerIsAlive)
        {
            winText.SetActive(true);
            loseText.SetActive(false);
            loseProp.SetActive(false);

            PlayerStatus status = new PlayerStatus
            {
                status = "Alive"
            };

            AnalyticsService.Instance.RecordEvent(status);
            AnalyticsService.Instance.Flush();
        }
        else
        {
            winText.SetActive(false);
            loseText.SetActive(true);
            loseProp.SetActive(true);

            PlayerStatus status = new PlayerStatus
            {
                status = "Dead"
            };

            AnalyticsService.Instance.RecordEvent(status);
            AnalyticsService.Instance.Flush();
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
