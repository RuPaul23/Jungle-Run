using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Public variables that can be tweaked in the editor
    public float speed = 50.0f;
    public float leftRightSpeed = 10;
    public float jumpHeight = 10.0f;

    // Private variables
    private CharacterController myCharacterController;
    private Animator myAnimator;
    private bool jump = false;
    private bool slide = false;
    

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
        // Check if the jump or slide keys are pressed
        jump = Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        slide = Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);

        // Play the jump animation if the jump key is pressed
        if (jump)
        {
            myAnimator.Play("Jump");
            float jumpForce = Mathf.Sqrt(2 * jumpHeight * Physics.gravity.magnitude);
            myCharacterController.Move(Vector3.up * jumpForce * Time.deltaTime);
        }

        // Play the slide animation if the slide key is pressed
        else if (slide)
        {
            myAnimator.Play("Slide");
        }
         // Apply gravity to the player character
        //myCharacterController.Move(Vector3.down * 50.0f * Time.deltaTime);

        // Move the player forward
        myCharacterController.Move(transform.forward * speed * Time.deltaTime);
        
        // Move the player left if the corresponding keys are pressed
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
        }
        
        // Move the player right if the corresponding keys are pressed
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
        }
    }
}
