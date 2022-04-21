using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    GameObject player;
    GameObject environment;

    [Header("Obstacles")]
    public GameObject[] obstacleList;
    Vector3 obstaclePos = new Vector3(0f, 0f, 100f);

    [Header("Road")]
    public GameObject roadPrefab;
    Vector3 roadInitialPos = Vector3.zero;

    [Header("Points")]
    public int points;
    public bool isGameOver;

    private void Awake()
    {
        CreatingPlayer();

        environment = GameObject.FindGameObjectWithTag("Environment");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {

        InvokeRepeating("CreatingObstacles", 0f, 2f);

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
        Vector3 roadNewPos = roadInitialPos + new Vector3(0f, 0f, 200f);
        Vector3 roadNextPos = roadNewPos + new Vector3(0f, 0f, 200f);

        GameObject newRoad = Instantiate(roadPrefab, roadNewPos, Quaternion.Euler(0f, 90f, 0f), environment.transform);
    }

    public void AddPoints()
    {
        points += 100;

        CheckHighScore();
    }

    public void CheckHighScore()
    {
        if (SavingData.Instance._highScore < points)
        {
            SavingData.Instance._highScore = points;
            SavingData.Instance._bestPlayer = SavingData.Instance._name;

            SavingData.Instance.SaveNewData();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}
