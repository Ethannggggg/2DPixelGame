using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
  public float runSpeed;
  public float jumpSpeed;
  public float doubleJumpSpeed;
  public Vector2 RespawnPosition;
  public Joystick joystick;
  

    private Rigidbody2D myRigidbody;
    private Animator myAnim;
    private BoxCollider2D myFeet;
    private bool isGround;
    private bool canDoubleJump;
    //Start is called before the first frame update
    void Start()
    {
       myRigidbody = GetComponent<Rigidbody2D>();
       myAnim = GetComponent<Animator>();
       myFeet = GetComponent<BoxCollider2D>();
       RespawnPosition = transform.position;
       

    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.isGameAlive)
        {
           Run();
           Filp();
           Attack();
           CheckGrounded();
           Switch();
        }
        

    }

    void CheckGrounded()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) ||
                   myFeet.IsTouchingLayers(LayerMask.GetMask("MovingPlatform"));
        Debug.Log(isGround);
    }

    void Filp()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if(playerHasXAxisSpeed)
        {
            if(myRigidbody.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            
            if(myRigidbody.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
    public void Run()
  {
    float moveDir = joystick.Horizontal;
    Vector2 playerVel = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);
    myRigidbody.velocity = playerVel;
    bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
    myAnim.SetBool("Run", playerHasXAxisSpeed);

   }

   public void Jump()
   {
       if(isGround)
            {
             myAnim.SetBool("Jump", true);
             Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
             myRigidbody.velocity = Vector2.up * jumpVel;
             canDoubleJump = true;
             }
             else
             {
                  if(canDoubleJump)
                  {
                        myAnim.SetBool("Double Jump", true);
                        Vector2 doubleJumpVel = new Vector2(0.0f,doubleJumpSpeed); 
                        myRigidbody.velocity = Vector2.up * doubleJumpVel;
                        canDoubleJump = false;
                  }
             }
          
   }

   void Attack()
   {
          if(Input.GetButtonDown("Attack"))
          {
                myAnim.SetTrigger("Attack");
          }
   }

   void Switch()
   {
          myAnim.SetBool("Idle", false);
          if(myAnim.GetBool("Jump"))
          {
                if(myRigidbody.velocity.y < 0.0f)
                {
                    myAnim.SetBool("Jump", false);
                    myAnim.SetBool("Fall", true);
                }
          }
          else if(isGround)
          {
                myAnim.SetBool("Fall", false);
                myAnim.SetBool("Idle", true);
          }

           if(myAnim.GetBool("Double Jump"))
          {
                if(myRigidbody.velocity.y < 0.0f)
                {
                    myAnim.SetBool("Double Jump", false);
                    myAnim.SetBool("Double Fall", true);
                }
          }
          else if(isGround)
          {
                myAnim.SetBool("Double Fall", false);
                myAnim.SetBool("Idle", true);
          }
   }

   
}