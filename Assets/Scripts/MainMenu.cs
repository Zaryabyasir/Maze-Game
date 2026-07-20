using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void PlayLevel1()
    { 
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void PlayLevel2() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2); 
    }

    public void PlayLevel3()
    { 
        Time.timeScale = 1f; 
        SceneManager.LoadScene(3);
    }
        

    
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    
}
