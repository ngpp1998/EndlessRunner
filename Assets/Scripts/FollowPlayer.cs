using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public float followSpeed = 25f; // Speed at which the prefab follows the player
    public float maxSpeed = 45f; // Maximum speed
    public float speedIncreaseRate = 0.15f; // Rate at which speed increases over time


    private void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;

        if (player != null)
        {
            // Calculate the direction from the prefab to the player
            Vector3 directionToPlayer = player.position - transform.position;

            // Normalize the direction vector and move the prefab towards the player
            transform.Translate(directionToPlayer.normalized * followSpeed * Time.deltaTime);
            followSpeed = Mathf.Min(followSpeed + speedIncreaseRate * Time.deltaTime, maxSpeed);

            // Check for collision with the player
            float distanceToPlayer = directionToPlayer.magnitude;
            if (distanceToPlayer < 1.0f) // Adjust this value based on your desired collision distance
            {
                // Game over logic (e.g., reload the scene)
                PlayerManager.gameOver = true;
                
            }
        }
        else
        {
            Debug.LogWarning("Player not found. Make sure you have tagged a GameObject as 'Player' and assigned it to the 'player' field of the script.");
        }
    }
}
