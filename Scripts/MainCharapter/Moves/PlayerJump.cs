using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {

    public LayerMask ground;
    private Transform groundChecker;

    public bool inAir = false;
    public bool canJump = true;
    public bool jump = false;
    public bool canDounbleJump = false;
    public bool doubleJump = false;

    public float jumpDelay = 1f;
    private bool onGround;
    	
    void Awake()
    {
        groundChecker = GameObject.Find("GroundChecker").transform;
    }

	// Update is called once per frame
	void Update () {
        onGround = Physics2D.OverlapCircle(groundChecker.position, 0.52f, ground);

        if(!canDounbleJump && onGround)
        {
            canDounbleJump = true;
        }

        if(Input.GetKey(KeyCode.Space) && onGround)
        {
            jump = true;    
        }

        if(Input.GetKeyDown(KeyCode.Space) && !onGround && canDounbleJump)
        {
            doubleJump = true;
            canDounbleJump = false;
        }
    }

    void FixedUpdate()
    {
        if (jump)
        {
            Jump();
            jump = false;
        }

        if (doubleJump)
        {
            DoubleJump();
            doubleJump = false;
        }
    }

    public void Jump()
    {  
        var force = new Vector2(PlayerStats._rigidbody2D.velocity.x, PlayerStats._playerStats.jumpPower);
        PlayerStats._rigidbody2D.velocity = new Vector2(PlayerStats._rigidbody2D.velocity.x, 0);
        PlayerStats._rigidbody2D.AddForce(force);
    }

    public void DoubleJump()
    {
        var force = new Vector2(PlayerStats._rigidbody2D.velocity.x, PlayerStats._playerStats.jumpPower);
        PlayerStats._rigidbody2D.velocity = new Vector2(PlayerStats._rigidbody2D.velocity.x, 0);
        PlayerStats._rigidbody2D.AddForce(force);
    }
}
