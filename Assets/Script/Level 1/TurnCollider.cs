using UnityEngine;

public class TurnCollider : MonoBehaviour
{
    public GameObject playerObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Rotate the player object by 90 degrees around the y-axis
            playerObject.transform.Rotate(0, 90, 0);
        }
    }
}
