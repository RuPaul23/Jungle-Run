using UnityEngine;

public class ObstacleMovement1 : MonoBehaviour
{
    public float speed = 5f; // The speed at which the obstacle moves forward

    void Update()
    {
        // Move the obstacle forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
