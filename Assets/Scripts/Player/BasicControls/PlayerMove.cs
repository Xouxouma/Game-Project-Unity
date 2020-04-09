using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float normalSpeed = 5.0f;
    public float runSpeed = 10.0f;
    public float speed;
    private float verticalVelocity;
    public float jumpForce = 60.0f;
    public CharacterController _charController;
    private float gravityJump = 14.0f;
    public float gravity = -9.8f;
    private bool doubleJumpAvailable = true;

    public PlayerAnimate playerAnimate;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        speed = normalSpeed;
        // isJumping = false;
        //_charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Updateplayermove avant : " + transform.position);
        Debug.Log("Updateplayermove Controller avant : " + _charController.transform.position);
        if (Input.GetKeyDown(KeyCode.LeftShift) && _charController.isGrounded)
        {
            speed = runSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && _charController.isGrounded)
        {
            speed = normalSpeed;
        }



        /*float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;
        transform.Translate(straffe, 0, translation);
        */
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        Vector3 movement = new Vector3(straffe, 0, translation);
        Debug.Log("Updateplayermove 0: " + transform.position);
        Debug.Log("Updateplayermove Controller 0 : " + _charController.transform.position);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        Debug.Log("Updateplayermove 0.5 : " + transform.position);
        Debug.Log("Updateplayermove Controller 0.5 : " + _charController.transform.position);
        Debug.Log("movement : " + movement);
        _charController.Move(movement);
        Debug.Log("Updateplayermove 1: " + transform.position);
        Debug.Log("Updateplayermove Controller 1 : " + _charController.transform.position);
        if (_charController.isGrounded)
        {
            // state handle
            if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
            {
                if (speed == normalSpeed)
                    playerAnimate.state = PlayerAnimate.State.Walk;
                else playerAnimate.state = PlayerAnimate.State.Run;
            }
            else
            {
                playerAnimate.state = PlayerAnimate.State.Idle;
            }
            ResetDoubleJump();
            verticalVelocity = -gravityJump * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerAnimate.state = PlayerAnimate.State.Jump;
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && doubleJumpAvailable)
            {
                playerAnimate.state = PlayerAnimate.State.DoubleJump;
                doubleJumpAvailable = false;
                verticalVelocity = jumpForce;
            }
            else
            {
                verticalVelocity -= gravityJump * Time.deltaTime;
            }
        }

        Debug.Log("Updateplayermove 2: " + transform.position);
        Debug.Log("Updateplayermove Controller 2 : " + _charController.transform.position);
        Vector3 jumpVector = new Vector3(0, verticalVelocity, 0);
        _charController.Move(jumpVector * Time.deltaTime);        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        Debug.Log("Updateplayermove AP : " + transform.position);
        Debug.Log("Updateplayermove Controller AP : " + _charController.transform.position);

    }

    public void ResetDoubleJump()
    {
        doubleJumpAvailable = true;
    }

}
