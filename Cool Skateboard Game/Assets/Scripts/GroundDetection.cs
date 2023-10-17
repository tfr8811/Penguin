using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class detects grounds by keeping count of the number of colliders 
// the players ground hitbox (shoebox) is on
public class GroundDetection : MonoBehaviour
{
    public GameObject playerObject;
    private PlayerStateManager playerScript;
    private int numGrounds;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = playerObject.GetComponent<PlayerStateManager>();
        numGrounds = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        numGrounds += 1;
        playerScript.switchState(playerScript.idleState);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        numGrounds -= 1;
        if (numGrounds < 0)
        {
            numGrounds = 0;
        }
        if (playerScript.currentState != playerScript.jumpState && numGrounds == 0)
        {
            playerScript.switchState(playerScript.fallState);
        }
    }
}
