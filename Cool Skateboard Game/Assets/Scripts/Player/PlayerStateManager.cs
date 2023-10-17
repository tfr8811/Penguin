using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    // global gravity, this should be elswhere but for now its here
    public static float globalGravity = -9.81f;

    // state manager stuff
    public PlayerBaseState currentState;
    public PlayerSkateState skateState = new PlayerSkateState();
    public PlayerIdleState idleState = new PlayerIdleState();
    public PlayerWalkState walkState = new PlayerWalkState();
    public PlayerJumpState jumpState = new PlayerJumpState();
    public PlayerFallState fallState = new PlayerFallState();

    // the player data
    public static float playerX;
    public static float playerY;

    public float gravityScale;
    public float jumpForce;
    public float runSpeed;
    public float airSpeed;
    public Rigidbody2D rb;
    public float defaultGravity;
    public float fallGravityScale;
    public float maxFallSpeed;
    public int isGrounded;
    public GameObject shoeBox;
    public BoxCollider2D boxCollider;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // set starting state
        currentState = fallState;
        currentState.EnterState(this);

        //set up the player stuff
        rb = this.GetComponent<Rigidbody2D>();

        boxCollider = shoeBox.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        // apply the current gravity
        rb.gravityScale = gravityScale;
    }

    void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }

    public void switchState(PlayerBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
