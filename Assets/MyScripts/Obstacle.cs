using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    GameManager gameManager;

    GameObject player;

    bool canMakePoint;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = FindObjectOfType<GameManager>();

        canMakePoint = true;
    }

    private void Update()
    {
        if (this.transform.position.z < player.transform.position.z - 10f && canMakePoint)
        {
            canMakePoint = false;
            MakingPoints();

            Destroy(this.gameObject, 1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CannonBall"))
        {
            Destroy(this.gameObject);
        }
    }


    void MakingPoints()
    {
        gameManager.AddPoints();
    }
}
