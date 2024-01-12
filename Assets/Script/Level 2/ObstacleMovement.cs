using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5f; // speed of the obstacle
    public float spawnOffset = 2f; // distance between each pair of obstacles

    private bool isPassedCamera = false;
    private Vector3 targetPosition;

    void Start()
    {
        // set the initial target position to move straight in the z-axis
        targetPosition = transform.position + Vector3.back * 100f; // move towards the camera
    }

    void Update()
    {
        // move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // check if the obstacle has passed the camera
        if (!isPassedCamera && transform.position.z < Camera.main.transform.position.z)
        {
            isPassedCamera = true;

            // spawn the next pair of obstacles
            SpawnNextObstacles();
        }

        // check if the obstacle has gone too far behind
        if (transform.position.z < -20f)
        {
            // destroy the obstacle object
            Destroy(gameObject);
        }
    }

    void SpawnNextObstacles()
    {
        // spawn the next obstacle pair with a parallel distance of spawnOffset to the left and right
        Vector3 leftSpawnPos = transform.position + Vector3.left * spawnOffset;
        Vector3 rightSpawnPos = transform.position + Vector3.right * spawnOffset;
        Instantiate(gameObject, leftSpawnPos, Quaternion.identity);
        Instantiate(gameObject, rightSpawnPos, Quaternion.identity);
    }
}
