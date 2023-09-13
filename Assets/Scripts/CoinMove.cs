using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    CoinController coinControllerScript;
    private MagnetPowerUp magnetPowerUp;

    void Start()
    {
        coinControllerScript = gameObject.GetComponent<CoinController>();

        magnetPowerUp = FindObjectOfType<MagnetPowerUp>();
    }

    void Update()
    {
        //moves coins towards player
        if (magnetPowerUp.isActivated == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, coinControllerScript.playerTransform.position, coinControllerScript.moveSpeed * Time.deltaTime);
        }
    }
}
