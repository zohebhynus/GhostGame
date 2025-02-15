using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.Analytics;


public enum GhostBehaviorTestGroups
{
    FOLLOW,
    DIRECTIONAL
}

public class GlobalValues
{
    public static GhostBehaviorTestGroups group = GhostBehaviorTestGroups.FOLLOW;
    public static bool playerIsAlive = true;
    public static bool isRunFirstTime = true;

}
