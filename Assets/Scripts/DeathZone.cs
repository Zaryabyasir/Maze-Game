using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public float respawnDelay = 0.25f;
    private bool isRespawning = false; 
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || isRespawning) return;

        var playerRespawn = other.GetComponent<PlayerRespawn>();
        if (playerRespawn != null)
        {
            if (playerRespawn.hasCheckpoint)
            {
                isRespawning = true; 
                StartCoroutine(RespawnAfterDelay(playerRespawn));
            }
            else
            {
                ShowGameOver();
            }
        }
    }

    void ShowGameOver()
    {
        if (gameOverCanvas != null) gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    System.Collections.IEnumerator RespawnAfterDelay(PlayerRespawn pr)
    {
        yield return new WaitForSecondsRealtime(respawnDelay);
        pr.Respawn();
        isRespawning = false; 
    }
}