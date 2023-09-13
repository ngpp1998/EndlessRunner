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

    void Update()
    {
        if (feverPowerUp.isActivated == true)
        {
            Destroy(gameObject); //destroying all obstacles with this script intact
        }
    }
}
