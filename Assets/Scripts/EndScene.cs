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
        string playerStatusAndGroup = (GlobalValues.group == GhostBehaviorTestGroups.FOLLOW) ? "FollowBehaviorGroup_" : "DirectionalBehaviorGroup_"; ;
        if (GlobalValues.playerIsAlive)
        {
            winText.SetActive(true);
            loseText.SetActive(false);
            loseProp.SetActive(false);

            playerStatusAndGroup += "Escaped";
        }
        else
        {
            winText.SetActive(false);
            loseText.SetActive(true);
            loseProp.SetActive(true);

            playerStatusAndGroup += "DidNotEscape";
        }

        AnalyticsService.Instance.RecordEvent(playerStatusAndGroup);
        AnalyticsService.Instance.Flush();
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
