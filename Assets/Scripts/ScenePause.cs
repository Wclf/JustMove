using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePause : MonoBehaviour
{
    [SerializeField] public GameObject pauseScreen;
    [SerializeField] public GameObject pauseView;
    [SerializeField] public GameObject VolumeScreen;
    private bool isOpen = false;
    

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScreen.SetActive(!isOpen);
            VolumeScreen.SetActive(false);
            pauseView.SetActive(true);
            isOpen = !isOpen;
            
        }

        
        if(isOpen)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    public void Resume()
    {
        isOpen = false;
        pauseScreen.SetActive(false);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        Score.score = 0;
    }



}
