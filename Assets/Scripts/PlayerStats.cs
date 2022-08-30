using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    public static float playerPoints = 0;

    [SerializeField] Text scorePointsText;
    [SerializeField] Transform playerDistance;

    private Rigidbody rb;
    private Color defaultColor;

    [SerializeField] GameObject reloadPanel;

    private void Start()
    {
        playerPoints = 0;
        rb = GetComponent<Rigidbody>();
        defaultColor = scorePointsText.color;
    }

    private void Update()
    {
        CheckOnPoints();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var vel = rb.velocity;
        playerPoints += (float) (vel.z * 0.001);
        scorePointsText.color = defaultColor;
        scorePointsText.text = ((int)playerPoints).ToString();
    }

    private void CheckOnPoints()
    {
        if (playerPoints < 0)
        {
            Destroy(gameObject);
            reloadPanel.SetActive(true);
        }

        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
            reloadPanel.SetActive(true);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            playerPoints -= 10;
            scorePointsText.color = Color.red;
        }


        if (collision.gameObject.tag == "BonusObstacle")
        {
            playerPoints += 20;
            scorePointsText.color = Color.green;
        }
    }


}
