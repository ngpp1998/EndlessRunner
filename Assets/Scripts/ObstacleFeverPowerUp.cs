using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFeverPowerUp : MonoBehaviour
{
    private FeverPowerUp feverPowerUp;

    void Start()
    {
        feverPowerUp = FindObjectOfType<FeverPowerUp>();
    }

    // Update is called once per frame
    void Update()
    {
        if (feverPowerUp.isActivated == true)
        {
            Destroy(gameObject);
        }
    }
}
