using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float jumpForce = 20f;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (!isGrounded) return;
        
        var moveVertical = jumpForce;
        isGrounded = false;

        Vector2 movement = new Vector2(0, moveVertical);
        rb2d.AddForce(movement * 15f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Ground")) isGrounded = true;

        if (other.collider.CompareTag("MovingGround"))
        {
            isGrounded = true;
            gameObject.transform.SetParent(other.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("MovingGround"))
        {
            gameObject.transform.SetParent(null);
        }
    }
}