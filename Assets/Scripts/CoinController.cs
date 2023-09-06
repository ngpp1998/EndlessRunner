using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 17f;

    CoinMove coinMoveScript;
    
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        coinMoveScript = gameObject.GetComponent<CoinMove>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(250 * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerManager.numberOfCoins += 1;
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().PlaySound("CoinSound");
        }
    }
}
