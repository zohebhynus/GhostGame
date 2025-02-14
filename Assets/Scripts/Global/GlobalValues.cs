using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.Analytics;


public enum TestGroup
{
    GROUPA,
    GROUPB
}

public class GlobalValues
{
    public static TestGroup group = TestGroup.GROUPA;
    public static bool playerIsAlive = true;

    public static void SetGroup()
    {
        int randomGroup = Random.Range(0, 2);
        group = (randomGroup == 0) ? TestGroup.GROUPA : TestGroup.GROUPB;

        Debug.Log("Player assigned to: " + group);

        GroupAssignment assignment = new GroupAssignment
        {
            GroupAssigned = randomGroup
        };

        AnalyticsService.Instance.RecordEvent(assignment);
        AnalyticsService.Instance.Flush();
    }
}
