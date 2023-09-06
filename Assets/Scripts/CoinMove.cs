using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    CoinController coinControllerScript;
    // Start is called before the first frame update

    private MagnetPowerUp magnetPowerUp;

    void Start()
    {
        coinControllerScript = gameObject.GetComponent<CoinController>();

        magnetPowerUp = FindObjectOfType<MagnetPowerUp>();
    }

    // Update is called once per frame
    void Update()
    {
        if (magnetPowerUp.isActivated == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, coinControllerScript.playerTransform.position, coinControllerScript.moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
