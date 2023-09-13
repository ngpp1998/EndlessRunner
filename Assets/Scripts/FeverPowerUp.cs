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
            //hide the object
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
        isActivated = false;
    }

    void DestroyObjectDelayed(float delay)
    {
        Destroy(gameObject, delay);
    }
}
