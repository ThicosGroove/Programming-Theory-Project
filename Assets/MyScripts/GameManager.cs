using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    GameObject player;
    GameObject environment;

    [Header("CanvasUI")]
    public TMP_Text gameOverText;

    [Header("Obstacles")]
    public GameObject[] obstacleList;
    Vector3 obstaclePos = new Vector3(0f, 0f, 100f);

    [Header("Road")]
    public GameObject roadPrefab;
    Vector3 roadInitialPos;
    Vector3 roadNewPos = Vector3.zero;

    [Header("Points")]
    public int points;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        environment = GameObject.FindGameObjectWithTag("Environment");
        CreatingPlayer();
    }

    private void Start()
    {
        InvokeRepeating("CreatingObstacles", 0f, 2f);

        roadInitialPos = roadPrefab.transform.position;
        InvokeRepeating("CreatingRoads", 0f, 2f);
    }

    void CreatingPlayer()
    {
        if (player != null) { return; }

        player = SavingData.Instance._vehicle;

        Instantiate(player, null);
    }

    void CreatingObstacles()
    {
        int randomObstacle = Random.Range(0, obstacleList.Length);

        GameObject newObstacle = Instantiate(obstacleList[randomObstacle], player.transform.position + obstaclePos, Quaternion.identity);
    }

    void CreatingRoads()
    {
        
        roadNewPos += new Vector3(0f, 0f, 200f) + roadInitialPos;

        GameObject newRoad = Instantiate(roadPrefab, roadNewPos, Quaternion.Euler(0f,90f,0f), environment.transform);
    }

    public void AddPoints()
    {
        points += 100;
    }

    public void GameOver()
    {
        gameOverText.enabled = true;
    }

}
