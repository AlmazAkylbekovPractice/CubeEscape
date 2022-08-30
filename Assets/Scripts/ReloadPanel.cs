using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReloadPanel : MonoBehaviour
{
    [SerializeField] private Button restartButtton;
    [SerializeField] private Button quitButton;

    private void Start()
    {
        restartButtton.onClick.AddListener(ReloadScene);
        quitButton.onClick.AddListener(GoBackToMenu);
        gameObject.SetActive(false);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GoBackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
