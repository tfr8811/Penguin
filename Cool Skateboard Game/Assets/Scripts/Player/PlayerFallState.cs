using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        // fall speed
        player.gravityScale = player.fallGravityScale * player.defaultGravity;

        player.spriteRenderer.color = new Color(255, 255, 0);
    }
    public override void UpdateState(PlayerStateManager player)
    {
        // max fall speed
        if (player.rb.velocity.y < -player.maxFallSpeed)
        {
            player.rb.velocity = new Vector2(player.rb.velocity.x, -player.maxFallSpeed);
        }

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
    }
    public override void OnCollisionEnter(PlayerStateManager player, Collision collision)
    {

    }
}
