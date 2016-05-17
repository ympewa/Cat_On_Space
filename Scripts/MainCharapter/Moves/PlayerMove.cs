using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    private int direction;
    int MOVE_LEFT = -1;
    int MOVE_RIGHT = 1;


	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
            {
                direction = MOVE_LEFT;
                PlayerStats._spriteRenderer.flipX = true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                direction = MOVE_RIGHT;
                PlayerStats._spriteRenderer.flipX = false;
            }
        }
        else
        {
            direction = 0;
        }
	}

    void FixedUpdate()
    {
      PlayerRun(direction);
    }

    private void PlayerRun(int direction)
    {
        Vector2 force = new Vector2 (direction * PlayerStats._playerStats.moveSpeed * Time.deltaTime, PlayerStats._rigidbody2D.velocity.y);
        PlayerStats._rigidbody2D.velocity  =  force;
    }
}
