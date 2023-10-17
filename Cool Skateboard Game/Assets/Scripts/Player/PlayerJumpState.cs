using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.rb.velocity = new Vector2(player.rb.velocity.x, player.jumpForce);
        player.spriteRenderer.color = new Color(255, 0, 0);
    }
    public override void UpdateState(PlayerStateManager player)
    {
        // the jump physics
        if (player.rb.velocity.y > 35)
        {
            if (Input.GetButtonUp("Jump") && player.rb.velocity.y < player.jumpForce)
            {
                player.rb.velocity = new Vector2(player.rb.velocity.x, 35);
            }
            player.gravityScale = player.defaultGravity;
        }
        else
        {
            player.gravityScale = player.fallGravityScale * player.defaultGravity;
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

        // enter fall state when the player begins falling
        if (player.rb.velocity.y < 0)
        {
            player.switchState(player.fallState);
        }
    }
    public override void OnCollisionEnter(PlayerStateManager player, Collision collision)
    {

    }
}
