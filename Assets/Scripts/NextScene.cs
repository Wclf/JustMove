using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] private int maxScore;

    public static int maxS;
    public Movement playerMovement;
    public GameObject successMessage;
    private void Start()
    {
        maxS = maxScore;

    }
    private void Update()
    {
       
        
        if(Score.score >= maxScore) 
        {
            Movement.canMove = false;
            successMessage.SetActive(true);
            StartCoroutine(LoadNextScene(3f));
           
        }   
    }

    private IEnumerator LoadNextScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
        Score.score = 0;
        Movement.canMove = true;
    }

}
