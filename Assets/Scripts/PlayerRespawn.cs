using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerRespawn : MonoBehaviour
{
    public Vector3 respawnPoint;
    public bool hasCheckpoint = false; 

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPoint = transform.position;
        hasCheckpoint = false;
    }

    public void SetCheckpoint(Vector3 position)
    {
        respawnPoint = position;
        hasCheckpoint = true;
    }

    public void Respawn()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();

        transform.position = respawnPoint;
        Physics.SyncTransforms(); 
        rb.WakeUp();
        Debug.Log("Player Respawned at: " + respawnPoint);
    }

    System.Collections.IEnumerator TemporaryInvulnerability()
    {
        var col = GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = false;
            yield return new WaitForSecondsRealtime(0.5f);
            col.enabled = true;
        }
    }
}