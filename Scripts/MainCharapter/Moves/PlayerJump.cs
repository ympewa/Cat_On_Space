using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {

    public LayerMask ground;
    private Transform groundChecker;

    private bool inAir = false;
    private bool canJump = true;
    private bool jump = false;
    private bool canDounbleJump = false;
    private bool doubleJump = false;

    public float jumpDelay = 1f;
    [SerializeField]
    private bool onGround;
    	
    void Awake()
    {
        groundChecker = GameObject.Find("GroundChecker").transform;
    }

	// Update is called once per frame
	void Update () {
        onGround = Physics2D.Linecast(this.transform.position, groundChecker.position, ground);

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
        var force = new Vector2(0, PlayerStats._playerStats.jumpPower);
        PlayerStats._rigidbody2D.AddForce(force);
    }

    public void DoubleJump()
    {
        var force = new Vector2(0, PlayerStats._playerStats.doubleJumpPower);
        PlayerStats._rigidbody2D.velocity = new Vector2(PlayerStats._rigidbody2D.velocity.x, 0);
        PlayerStats._rigidbody2D.AddForce(force);
    }
}
