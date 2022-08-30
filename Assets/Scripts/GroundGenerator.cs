using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField] GameObject ground_1;
    [SerializeField] GameObject ground_2;
    [SerializeField] GameObject ground_3;
    [SerializeField] GameObject obstacle;

    [SerializeField] GameObject movingObstacle;
    [SerializeField] GameObject movingObstacleTwo;

    [SerializeField] GameObject bonusObstacle;

    [SerializeField] Transform player;

    [SerializeField] private List<GameObject> obstaclesList;

    [SerializeField] private int generatedObstacles = 60;
    [SerializeField] private int gemeratedMovingObstacles = 20;
    [SerializeField] private int gneratedBonusObstacles = 10;

    private float playerDistanseZ = 500f;

    private void Awake()
    {
        GenerateObstaclesOnAwake();
        GenerateMovingObstacles();
        GenerateBonusObstacles();
    }

    void Update()
    {
        if (player != null)
            MoveGrounds();
    }

    private void LateUpdate()
    {
        if (player != null)
            MoveObstacles();
    }

    private void MoveGrounds()
    {
        ChangeGroundOne();
        ChangeGroundTwo();
        ChangeGroundThree();
    }

    private void ChangeGroundOne()
    {
        
        if (player.position.z > ground_2.transform.position.z &&
            player.position.z < ground_3.transform.position.z)
        {
            ground_1.transform.position = new Vector3(
                ground_1.transform.position.x,
                ground_1.transform.position.y,
                ground_3.transform.position.z + playerDistanseZ);
        }
    }

    private void ChangeGroundTwo()
    {
        if (player.position.z > ground_3.transform.position.z &&
            player.position.z < ground_1.transform.position.z)
        {
            ground_2.transform.position = new Vector3(
            ground_2.transform.position.x,
            ground_2.transform.position.y,
            ground_1.transform.position.z + playerDistanseZ);
        }
    }

    private void ChangeGroundThree()
    {
        if (player.position.z > ground_1.transform.position.z &&
            player.position.z < ground_2.transform.position.z)
        {

            ground_3.transform.position = new Vector3(
                ground_3.transform.position.x,
                ground_3.transform.position.y,
                ground_2.transform.position.z + playerDistanseZ);
        }

    }

    private void GenerateBonusObstacles()
    {
        for (int i = 0; i < gneratedBonusObstacles; i++)
        {
            var bonusObstaclePosition = new Vector3(1,1,1);
            bonusObstaclePosition.z = Random.Range(player.transform.position.z + 30, 3000);

            Instantiate(bonusObstacle, bonusObstaclePosition, Quaternion.identity, gameObject.transform);

        }
    }

    private void GenerateObstaclesOnAwake()
    {

        for (int i = 0; i < generatedObstacles; i++)
        {
            var obstacleScale = new Vector3(1, 1, 1);
            obstacleScale.x = Random.Range(1, Random.Range(6,14));
              
            var obstaclePosition = new Vector3(1, 1, 1);
            obstaclePosition.x = Random.Range(-(15f - obstacleScale.x) / 2, (15f - obstacleScale.x) / 2);
            obstaclePosition.z = Random.Range(player.transform.position.z + 30 , 1500);

            obstacle.transform.localScale = obstacleScale;
            obstacle.transform.position = obstaclePosition;

            var obstacleInstance = Instantiate(obstacle, obstacle.transform.position, Quaternion.identity, gameObject.transform);

            obstaclesList.Add(obstacleInstance);
        }
    }

    private void GenerateMovingObstacles()
    {
        for (int i = 0; i < gemeratedMovingObstacles; i++)
        {
            var movingOnstacle = Random.Range(1, 3);
            var movingObstaclePositionOne = new Vector3(movingObstacle.transform.position.x,movingObstacle.transform.position.y, Random.Range(0,1500));
            var movingObstaclePositionTwo = new Vector3(movingObstacleTwo.transform.position.x, movingObstacleTwo.transform.position.y, Random.Range(0, 1500));

            if (movingOnstacle == 1)
            {
                var movingObstacleInstanceOne = Instantiate(movingObstacle, movingObstaclePositionOne, Quaternion.identity, gameObject.transform);
                obstaclesList.Add(movingObstacleInstanceOne);
            }
            else if (movingOnstacle == 2)
            {
                var movingObstacleInstanceTwo = Instantiate(movingObstacleTwo, movingObstaclePositionTwo, Quaternion.identity, gameObject.transform);
                obstaclesList.Add(movingObstacleInstanceTwo);
            }

        }
    }

    private void MoveObstacles()
    {
        foreach (GameObject obstacle in obstaclesList)
        {
            if (obstacle.transform.position.z < player.position.z - 20)
            {
                obstacle.transform.position = new Vector3(
                    obstacle.transform.position.x,
                    obstacle.transform.position.y,
                    obstacle.transform.position.z + Random.Range(1000, 1500));
            }
        }

    }
} // class
