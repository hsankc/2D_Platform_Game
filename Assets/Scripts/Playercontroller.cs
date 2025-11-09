using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{

    Rigidbody2D playerRB;
    Animator playerAnimator;
    public float MoveSpeed = 1f;
    public float JumpSpeed = 1f, JumpFrequency = 1f , nextJumpTime; 

    bool facingRight = true;

    public bool isGrounded = false;
    public Transform GroundCheckPosition;
    public float GroundCheckRadius;
    public LayerMask GroundCheckLayer;


    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizantalMove();
        OnGroundCheck();

        if (playerRB.velocity.x < 0 && facingRight) 
        {
            FlipFace();
        }

        else if(playerRB.velocity.x > 0 && !facingRight) 
      
        {
            FlipFace();
        }

        void FlipFace()
        {
            facingRight = !facingRight;
            Vector3 tempLocalScale = transform.localScale;
            tempLocalScale.x *= -1;
            transform.localScale = tempLocalScale;
        }

        if ( Input.GetAxis("Vertical")>0 && isGrounded && (nextJumpTime<Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + JumpFrequency;
            Jump();
        }
    }
    void FixedUpdate()
    {
       
    }

    void HorizantalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed, playerRB.velocity.y);
        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));
    }
    void Jump( )
    {
        playerRB.AddForce(new Vector2(0f, JumpSpeed));
    } 

    void OnGroundCheck()
    {
       isGrounded = Physics2D.OverlapCircle( GroundCheckPosition.position,GroundCheckRadius,GroundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim", isGrounded);
    } 

}








