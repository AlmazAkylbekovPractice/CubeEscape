using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField] private bool movingCube;
    [SerializeField] private bool movingUpAndDown;

    [SerializeField] private int minX;
    [SerializeField] private int maxX;

    [SerializeField] private int minY;
    [SerializeField] private int maxY;

    [SerializeField] private float movingSpeed = 2f;

    [SerializeField] private bool bonusObstacle;
    [SerializeField] private ParticleSystem bonusObstacleParticles;

    private bool rightDir = false;
    private bool upDir = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveObstacle();
    }

    private void MoveObstacle()
    {
        if (movingCube)
        {
            if (!movingUpAndDown)
            {
                if (rightDir)
                {

                    gameObject.transform.Translate(Vector3.right * movingSpeed * Time.deltaTime);
                }
                else
                {

                    gameObject.transform.Translate(Vector3.left * movingSpeed * Time.deltaTime);
                }

                if (gameObject.transform.position.x >= maxX)
                    rightDir = false;

                if (gameObject.transform.position.x <= minX)
                    rightDir = true;
            }
            else
            {
                if (upDir)
                {
                    gameObject.transform.Translate(Vector3.up * movingSpeed * Time.deltaTime);
                }
                else
                {
                    gameObject.transform.Translate(Vector3.down * movingSpeed * Time.deltaTime);
                }

                if (gameObject.transform.position.y >= maxY)
                    upDir = false;

                if (gameObject.transform.position.y <= minY)
                    upDir = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (bonusObstacle)
            {
                var bonusObstacleParticle = Instantiate(bonusObstacleParticles, transform.position, Quaternion.identity);
                bonusObstacleParticle.Play();
                Destroy(gameObject);
            }
        }

        
    }
}
