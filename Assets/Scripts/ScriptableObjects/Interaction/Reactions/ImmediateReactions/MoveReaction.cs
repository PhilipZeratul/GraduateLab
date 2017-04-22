using UnityEngine;

public class MoveReaction : Reaction {

    public GameObject player;
    public Transform interactionLocation;


    protected override void ImmediateReaction()
    {
        player.transform.SetPositionAndRotation(interactionLocation.position, interactionLocation.rotation);
    }
}
