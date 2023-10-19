using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkateState : PlayerBaseState
{
    // the amount of frames s has been held down (for leaving skateboard)
    private float sHeld;
    public override void EnterState(PlayerStateManager player)
    {
        player.spriteRenderer.color = new Color(1, 0.5f, 0);
        sHeld = 0;
    }
    public override void UpdateState(PlayerStateManager player)
    {
        if (Input.GetButtonDown("aButton")) //if the player presses a...
        {
            Debug.Log("I pressed A!");
            if (player.skateSubState == "none") //...and the player has not started a skate sequence...
            {
                //if (player.rb.velocity.x >= 0)
                //{
                    player.skateSubState = "startRight"; //...then they want to start a skate sequence going to the right
                    Debug.Log("Skate is: " + player.skateSubState);
                //}
            } else if (player.skateSubState == "midLeft" ) //&& player.rb.velocity.x <= 0) //but if the player has already started skating, and they are midway through skating...
            {
                player.rb.velocity = new Vector2(player.skateSpeedMultiplier * -player.runSpeed, player.rb.velocity.y); //then the player goes left
                player.skateSubState = "none"; //and then the player goes back to not having started a skate sequence
                Debug.Log("Skate is: " + player.skateSubState);
            } else if (player.skateSubState == "startLeft")
            {
                //you fucked up
                player.skateSubState = "none";
            }
        }
        if (Input.GetButtonDown("dButton")) //if the player presses d...
        {
            Debug.Log("I pressed D!");
            if (player.skateSubState == "none") //...and the player has not started a skate sequence...
            {
                //if (player.rb.velocity.x <= 0)
                //{
                    player.skateSubState = "startLeft"; //...then they want to start a skate sequence
                    Debug.Log("Skate is: " + player.skateSubState);
                //}
            } else if (player.skateSubState == "midRight") {//&& player.rb.velocity.x >= 0){  //but if the player has already started skating, and they are midway through skating...
                player.rb.velocity = new Vector2(player.skateSpeedMultiplier * player.runSpeed, player.rb.velocity.y); //then the player goes left
                player.skateSubState = "none"; //and then the player goes back to not having started a skate sequence
                Debug.Log("Skate is: " + player.skateSubState);
            } else if (player.skateSubState == "startRight")
            {
                //you fucked up
                player.skateSubState = "none";
            }
        } 
        if (Input.GetButtonDown("sButton"))
        {
            Debug.Log("I pressed S!");
            if(player.skateSubState == "startRight") // if the player presses s, and they have already started a skate sequence going to the right...
            {
                player.skateSubState = "midRight"; //..,then they progress their skate sequence to mid right...
                Debug.Log("Skate is: " + player.skateSubState);
            } else if (player.skateSubState == "startLeft") {
                player.skateSubState = "midLeft"; //but if the player has already started going left, then they progress their skate sequence to mid 
                Debug.Log("Skate is: " + player.skateSubState);
            }
        }

        // Get off skateboard
        if (Input.GetButton("getOnSkate"))
        {
            sHeld += Time.deltaTime;
        } else {
            sHeld = 0;
        }

        if (sHeld > 1) {
            player.switchState(player.idleState);
        }

        /*Vector2 stickDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (stickDir.x > 0.1 && player.rb.velocity.x >= 0)
        {
            player.rb.velocity = new Vector2(stickDir.x * player.runSpeed, player.rb.velocity.y);
        }
        else if (stickDir.x < -0.1 && player.rb.velocity.x <= 0)
        {
            player.rb.velocity = new Vector2(stickDir.x * player.runSpeed, player.rb.velocity.y);
        }*/
    }
    public override void OnCollisionEnter(PlayerStateManager player, Collision collision)
    {

    }
}
