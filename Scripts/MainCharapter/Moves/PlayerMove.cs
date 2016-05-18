using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    [SerializeField]
    private float moveForce = 350f;
    private Animation anim;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");


        if (Mathf.Abs(h) != 0)
        {
            this.GetComponent<Animator>().SetBool("run", true);
            this.GetComponent<Animator>().speed = Mathf.Abs(PlayerStats._rigidbody2D.velocity.x);

        }
        else
        {
            this.GetComponent<Animator>().SetBool("run", false);
            this.GetComponent<Animator>().speed = 1;
        }

        if(h > 0 && PlayerStats._spriteRenderer.flipX)
        {
            PlayerStats._spriteRenderer.flipX = false;
        }
        if (h < 0 && !PlayerStats._spriteRenderer.flipX)
        {
            PlayerStats._spriteRenderer.flipX = true;
        }
        PlayerRun(h);
    }

    private void PlayerRun(float direction)
    {
        if (direction * PlayerStats._rigidbody2D.velocity.x < PlayerStats._playerStats.maxSpeed)
        {
            PlayerStats._rigidbody2D.AddForce(Vector2.right * direction * moveForce);
        }

        if (Mathf.Abs(PlayerStats._rigidbody2D.velocity.x) >= PlayerStats._playerStats.maxSpeed)
        {
            PlayerStats._rigidbody2D.velocity = new Vector2(Mathf.Sign(PlayerStats._rigidbody2D.velocity.x) * PlayerStats._playerStats.maxSpeed, PlayerStats._rigidbody2D.velocity.y);
        }
    }
}
