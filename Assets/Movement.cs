using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Public variables that can be tweaked in the editor
    public float speed = 70.0f;
    public float leftRightSpeed = 100;
    public float jumpHeight = 20.0f;

    // Private variables
    private CharacterController myCharacterController;
    private Animator myAnimator;
    

    // Start is called before the first frame update
    void Start()
    {
        // Get references to the CharacterController and Animator components
        myCharacterController = GetComponent<CharacterController>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player forward
        myCharacterController.Move(transform.forward * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Slide();
        }
        MoveLeft();
        MoveRight();
        // Apply gravity to the player character
        //myCharacterController.Move(Vector3.down * 50.0f * Time.deltaTime);
        
    }

    public void Jump()
    {
        if (myAnimator != null)
        {
            myAnimator.Play("Jump");
        }
        float jumpForce = Mathf.Sqrt(2 * jumpHeight * Physics.gravity.magnitude);
        myCharacterController.Move(Vector3.up * jumpForce * Time.deltaTime);
    }


    public void Slide()
    {
        if (myAnimator != null)
        {
            myAnimator.Play("Slide");
        }
    }

    public void MoveLeft()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
        }
    }

    public void MoveRight()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
           transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
        }
    }
}
