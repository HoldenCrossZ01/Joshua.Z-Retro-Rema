using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public KeyCode left = KeyCode.A, right = KeyCode.D, up = KeyCode.W, down = KeyCode.S, jump = KeyCode.W;
    public float speed = 10,jumpheight = 15;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input.GetKey() is for HOLDING a key
        //Input.GetKeyDown() is for PRESSING a key
        //Input.GetKeyUp() is for RELEASING a key

        if (Input.GetKey(left)) // Check for the player HOLDING DOWN the left button
        {
            _rb.velocity = Vector2.left * speed;
        }
        else if (Input.GetKey(right)) // Check for the player HOLDING DOWN the right button
        {
            _rb.velocity = Vector2.right * speed;
        }
        if (Input.GetKey(up)) // Check for the player HOLDING DOWN the up button
        {
            _rb.velocity = Vector2.up * speed;
        }
        else if (Input.GetKey(down)) // Check for the player HOLDING DOWN the down button
        {
           _rb.velocity = Vector2.down * speed;
        }

        if (Input.GetKeyDown(jump)) // Check for the player PRESSING the jump button
        {
            _rb.velocity = Vector2.up * jumpheight;
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
           _rb.gravityScale *= -1;
        }
    }
}
