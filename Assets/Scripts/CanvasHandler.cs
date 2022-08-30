using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasHandler : MonoBehaviour
{
    [SerializeField] private Button pauseButton;

    private bool paused;

    private void Awake()
    {
        pauseButton.onClick.AddListener(PauseGame);
    }

    private void PauseGame()
    {

        if (paused)
        {
            paused = false;
            Time.timeScale = 1;
        } else
        {
            paused = true;
            Time.timeScale = 0;
        }
    }
}
