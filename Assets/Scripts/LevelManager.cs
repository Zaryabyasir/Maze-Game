using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private GameObject levelCompletePanel;
    private bool levelWon = false;

   
    private TimerAndScore timer;

    void Awake()
    {
     
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
        timer = FindFirstObjectByType<TimerAndScore>();
    }
    
    public void WinLevel()
    {
        if (levelWon) return;
        levelWon = true;
 
      
        var timer = FindFirstObjectByType<TimerAndScore>();
        if (timer != null) timer.OnLevelComplete();
        
        levelCompletePanel.SetActive(true);
        Time.timeScale = 0f;
        
        if (timer == null)
            timer = FindFirstObjectByType<TimerAndScore>();

        if (timer != null)
        {
            timer.StopTimer();
        }
        else
        {
            Debug.LogWarning("TimerAndScore not found in scene when winning level.");
        }
        
        if (levelCompletePanel != null)
            levelCompletePanel.SetActive(true);
        else
            Debug.LogWarning("LevelCompletePanel not assigned on LevelManager.");

        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextIndex);
        else
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
