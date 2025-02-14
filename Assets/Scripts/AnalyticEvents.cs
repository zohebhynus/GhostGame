using UnityEngine;

public class GroupAssignment : Unity.Services.Analytics.Event
{
    public GroupAssignment() : base("GroupAssignment")
    {
    }

    public int GroupAssigned { set { SetParameter("GroupAssigned", value); } }

}

public class PlayerStatus : Unity.Services.Analytics.Event
{
    public PlayerStatus() : base("PlayerStatus")
    {
    }

    public string status { set { SetParameter("status", value); } }

}


