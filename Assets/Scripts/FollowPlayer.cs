using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 25f;
    public float maxSpeed = 45f;
    public float speedIncreaseRate = 0.15f;


    private void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;

        if (player != null)
        {
            //calculating the direction from the ghost to the player
            Vector3 directionToPlayer = player.position - transform.position;

            //normalizing the direction vector and moving the ghost towards the player
            transform.Translate(directionToPlayer.normalized * followSpeed * Time.deltaTime);
            followSpeed = Mathf.Min(followSpeed + speedIncreaseRate * Time.deltaTime, maxSpeed);

            float distanceToPlayer = directionToPlayer.magnitude;
            if (distanceToPlayer < 1.0f)
            {
                PlayerManager.gameOver = true;
            }
        }
    }
}
