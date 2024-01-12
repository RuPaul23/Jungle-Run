using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject characterModel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            // Play the "Die" animation on the character model object
            characterModel.GetComponent<Animator>().Play("Die");

            // Disable the player controller component
            playerObject.GetComponent<PlayerController>().enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
        else if (other.CompareTag("TurnCollider"))
        {
            // Rotate the player object by 90 degrees around the y-axis
            playerObject.transform.Rotate(0, 90, 0);
        }
        else if (other.CompareTag("TurnCollider90"))
        {
            // Rotate the player object by 90 degrees around the y-axis
            playerObject.transform.Rotate(0, -90, 0);
        }
    }
}


