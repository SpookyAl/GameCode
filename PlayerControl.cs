using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 1;
    public float jumpForce = 1;

    private Rigidbody2D playerBody;
    private Animator animate;
    
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
    }

    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        float animationMovement = movement * speed;
        animate.SetFloat("Speed", Mathf.Abs(animationMovement));
        
        transform.position += new Vector3(movement,0,0) * Time.deltaTime * speed;
        //animate.SetFloat("Speed", Mathf.Abs(animationMovement));
        
        Jumping(); 
    }

    void FixedUpdate()
    {
        Turn();
    }

    void Turn()
    {
        float turnScale = Input.GetAxis("Horizontal");
        
        if(turnScale < 0)
        {
            playerBody.transform.localScale = new Vector2(-3.0f,3.0f);
        }
        else if(turnScale > 0)
        {
            playerBody.transform.localScale = new Vector2(3.0f,3.0f);
        }

    }

    void Jumping()
    {
        if(Input.GetButtonDown("Jump") && Mathf.Abs(playerBody.velocity.y) < 0.1f)
        {
            playerBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
