using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverPowerUp : MonoBehaviour
{
    public float FeverDuration = 10f;
    public bool isActivated = false;
    private Renderer objectRenderer;

    void Start()
    {
        // Get the Renderer component of the object
        objectRenderer = GetComponent<Renderer>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isActivated)
            {
                isActivated = true;
                ActivateForDuration();
            }
            // Hide the object immediately
            objectRenderer.enabled = false;
            DestroyObjectDelayed(10f);
        }
    }

    private void ActivateForDuration()
    {
        isActivated = true;
        Invoke("DeactivateObject", FeverDuration);
    }

    private void DeactivateObject()
    {
        //tilePuzzlePanel.SetActive(false);
        isActivated = false;
    }

    void DestroyObjectDelayed(float delay)
    {
        // Use the Destroy method with a delay
        Destroy(gameObject, delay);
    }
}
