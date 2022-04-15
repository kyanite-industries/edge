using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    //reference of the player (Local view)
    public CharacterController controller;

    public float walkingBobbingSpeed = 14f;
    public float bobbingAmount = 0.05f;

    public bool isPaused = false;

    float timer = 0;
    float defaultPosY = 0;

    //speed control
    public float speed;
    //velocity for gravity
    Vector3 velocity;
    //gravity float
    public float gravity = -9.81f;
    //Jumpheight
    public float Jumpheight = 3f;

    bool isSprinting;
    //refernce for the IsGroundCheck
    public Transform IsGroundCheck;
    //makes the distance for the invisible sphere distance checker
    public float IsGroundCheckDistance = 0.4f;
    //Checks if the IsGroundCheck is touching the groundlayer and NOT the player
    public LayerMask groundMask;
    //Gives the state of being grounded
    bool isGrounded;
    //Shake rate integer
    public int ShakeRate = 1;
    //Checks if the object is moving (bool)
    bool isMoving;
    //Sprint speed
    public float SprintRate = 150f;

    void Start()
    {
        defaultPosY = transform.localPosition.y;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Define isGrounded bool
        isGrounded = Physics.CheckSphere(IsGroundCheck.position, IsGroundCheckDistance, groundMask);
        //Define isMoving bool
        isMoving = (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"));

        //Checks for being Grounded
        if (isGrounded && velocity.y < 0)
        {
            //resets velocity
            velocity.y = -2f;
        }

        //Get input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //use the input (Local view)
        Vector3 move = transform.right * x + transform.forward * z;

        //moves character with speed
        controller.Move(move * speed * Time.deltaTime);

        //Sprinting
        if (Input.GetKey("left shift") && isGrounded && !isPaused)
        {
            isSprinting = true;
            speed = 6f;
        }
        else
        {
            isSprinting = false;
            speed = 4f;
        }

        //making gravity accelerate
        velocity.y += gravity * Time.deltaTime;

        //add gravity to player
        controller.Move(velocity * Time.deltaTime);
        //Jump (NEED FIXES)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            timer = 0;
            velocity.y = Mathf.Sqrt(Jumpheight * -2f * gravity);

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                isPaused = true;
                speed = 0f;

            }
            if (!isPaused)
            {
                isPaused = false;
                speed = 0f;
            }
        }

    }
    }

