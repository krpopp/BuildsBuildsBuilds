using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyPlatformer : MonoBehaviour
{
    //for tuning
    public float speed;
    public float raycastDist;
    public float jumpForce;

    //gameplay
    int lives = 3;
    int score = 0;

    //physics
    Rigidbody2D myBody;
    float moveX;
    bool jump = false;
    bool onGround = false;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //inputs
        VerticalMovement();
        HorizontalMovement();
    }

    void FixedUpdate()
    {

        //horizontal velocity
        myBody.velocity = new Vector3(moveX, myBody.velocity.y);

        //vertical velocity aka jumping
        if (jump)
        {
            myBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }

        //ground check
        //also: trigger the hasHit bool if this is the first time we've hit the ground
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDist);
        if (hit.collider != null && hit.transform.tag == "Ground")
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }

    void HorizontalMovement()
    {
        moveX = (Input.GetAxis("Horizontal") * speed) * Time.fixedDeltaTime;
    }

    void VerticalMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            Debug.Log("hit");
            jump = true;
        }
    }
}
