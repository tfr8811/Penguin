using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.spriteRenderer.color = new Color(0, 0, 255);
    }
    public override void UpdateState(PlayerStateManager player)
    {
        // grounded actions
        // horizontal movement
        Vector2 stickDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (stickDir.x > 0.1)
        {
            player.rb.velocity = new Vector2(stickDir.x * player.runSpeed, player.rb.velocity.y);
        }
        else if (stickDir.x < -0.1)
        {
            player.rb.velocity = new Vector2(stickDir.x * player.runSpeed, player.rb.velocity.y);
        }
        else
        {
            player.rb.velocity = new Vector2(0.0f, player.rb.velocity.y);
        }

        // not walkin'
        if (stickDir.magnitude < 0.1)
        {
            player.switchState(player.idleState);
        }

        // Jump
        if (Input.GetButtonDown("Jump"))
        {
            player.switchState(player.jumpState);
        }
    }
    public override void OnCollisionEnter(PlayerStateManager player, Collision collision)
    {

    }
}
