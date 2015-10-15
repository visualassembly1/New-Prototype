using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    //Private - can't access from other scripts
    //[] - show that it is an array
    //serielizefield shows on inspector

    //Allows player to move from the physics
    private Rigidbody2D myRigidbody;

    private Animator myAnimator;

    //Change the movement speed of player
    [SerializeField]
    private float movementSpeed;

    //allows player to attack
    private bool attack;

    //Flips player so it is facing right when player to the right
    private bool facingRight;


    // Use this for initialization
    void Start()
    {
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

    }

    void Update()
    {
        HandleInput();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        HandleMovement(horizontal);

        Flip(horizontal);

        HandleAttacks();

        ResetValues();
    }

    //Handles the movement of the player
    private void HandleMovement(float horizontal)
    {
        //Checks if current animation is playing
        //animation on layer 0
        if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
        }


        //Returns the correct values
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    private void HandleAttacks()
    {
        if (attack && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            myAnimator.SetTrigger("attack");
            myRigidbody.velocity = Vector2.zero;
        }
    }

    private void HandleInput()
    {
        //Assigns the attack key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //If the attack button is pressed (space bar) then the player will attack
            attack = true;
        }
        }
    private void Flip(float horizontal)
    {
        //If it is larger than x axis is larger than 0
        //then player will flip to right
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            //scale of the player
            Vector3 theScale = transform.localScale;

            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
    private void ResetValues()
    {
        attack = false;
    }
   }

