using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // The obstacle prefab to be spawned
    public GameObject player; // The player object
    public Animator playerAnimator; // The animator for the player's death animation

    public float minXPos = -1f; // The minimum X position for spawning
    public float maxXPos = 1f; // The maximum X position for spawning
    public float spawnInterval = 2f; // The time interval between obstacle spawns
    public float obstacleSpeed = 5f; // The speed at which obstacles move forward
    public float branchOffset = 2f; // The offset for the branches from the middle
    public float branchDistance = 3f; // The distance between left and right branches

    private float timer; // The timer for obstacle spawning

    void Update()
    {
        // Increase the timer
        timer += Time.deltaTime;

        // Check if it's time to spawn a new obstacle
        if (timer >= spawnInterval)
        {
            // Reset the timer
            timer = 0f;

            // Choose a random X position for the obstacle
            float xPos = Random.Range(minXPos, maxXPos);

            // Instantiate the obstacle prefab
            GameObject obstacle = Instantiate(obstaclePrefab);

            // Set the obstacle's position and rotation
            obstacle.transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
            obstacle.transform.rotation = Quaternion.identity;

            // Generate branches on the middle, left, and right of the obstacle
            GenerateBranch(obstacle.transform, 0f); // Middle branch
            GenerateBranch(obstacle.transform, branchOffset); // Right branch
            GenerateBranch(obstacle.transform, -branchOffset); // Left branch

            // Set the obstacle's speed
            ObstacleMovement obstacleMovement = obstacle.GetComponent<ObstacleMovement>();
            if (obstacleMovement != null)
            {
                obstacleMovement.speed = obstacleSpeed;
            }
        }
    }

    // Generates a branch on the specified side of the obstacle
    void GenerateBranch(Transform obstacleTransform, float xOffset)
    {
        // Instantiate a branch prefab
        GameObject branch = Instantiate(obstaclePrefab);

        // Set the branch's position and rotation
        branch.transform.position = new Vector3(obstacleTransform.position.x + xOffset, obstacleTransform.position.y, obstacleTransform.position.z);
        branch.transform.rotation = Quaternion.identity;

        // Disable the branch's collider
        Collider branchCollider = branch.GetComponent<Collider>();
        if (branchCollider != null)
        {
            branchCollider.enabled = false;
        }

        // Make the branch a child of the obstacle
        branch.transform.SetParent(obstacleTransform);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the other object is the player
        if (other.gameObject == player)
        {
            // Play the player's death animation
            playerAnimator.SetTrigger("Die");
        }
    }
}
