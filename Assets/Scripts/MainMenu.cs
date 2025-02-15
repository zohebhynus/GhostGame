using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;



    private async void Awake()
    {
        if (GlobalValues.isRunFirstTime) 
        {
            await UnityServices.InitializeAsync();
            AnalyticsService.Instance.StartDataCollection();

            SetGroup();
            GlobalValues.isRunFirstTime = false;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public static void SetGroup()
    {
        int randomGroup = Random.Range(0, 2);
        GlobalValues.group = (randomGroup == 0) ? GhostBehaviorTestGroups.FOLLOW : GhostBehaviorTestGroups.DIRECTIONAL;

        string groupAssign = "";
        if(GlobalValues.group == GhostBehaviorTestGroups.FOLLOW)
        {
            groupAssign = "FollowBehaviorGroup";
        }
        else
        {
            groupAssign = "DirectionalBehaviorGroup";
        }
        Debug.Log("Player assigned to: " + groupAssign);
        AnalyticsService.Instance.RecordEvent(groupAssign);
        AnalyticsService.Instance.Flush();
    }

}
