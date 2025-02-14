using UnityEngine;

[CreateAssetMenu(menuName = "GhostSettings")]
public class GhostSettings : ScriptableObject
{
    public float speed;
    public Vector3 startPosition;
    public GhostLogic logic;
}
