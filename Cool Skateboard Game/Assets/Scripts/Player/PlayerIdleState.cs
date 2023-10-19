using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.spriteRenderer.color = new Color(0, 0, 0);
    }
    public override void UpdateState(PlayerStateManager player)
    {
        // grounded actions
        // walkin'
        Vector2 stickDir = new Vector2(Input.GetAxisRaw("Horizontal"), 0.0f);
        if (stickDir.magnitude > 0.1f) {
            player.switchState(player.walkState);
        }

        //jump
        if (Input.GetButtonDown("Jump"))
        {
            player.switchState(player.jumpState);
        }
        
        // Get on skateboard
        if (Input.GetButtonDown("getOnSkate"))
        {
            player.switchState(player.skateState);
        }
    }
    public override void OnCollisionEnter(PlayerStateManager player, Collision collision)
    {

    }
}
