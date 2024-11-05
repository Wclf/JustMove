using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetG : MonoBehaviour
{
    public static void Restart()
    {
        
        Score.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Movement.canMove = true;
    }

}
