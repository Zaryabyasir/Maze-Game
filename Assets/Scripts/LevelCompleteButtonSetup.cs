using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteButtonSetup : MonoBehaviour
{
    public Button restartButton;
    public Button nextButton;

    void Start()
    {
        restartButton.onClick.AddListener(() => LevelManager.Instance.Restart());
        nextButton.onClick.AddListener(() => LevelManager.Instance.NextLevel());
    }
}