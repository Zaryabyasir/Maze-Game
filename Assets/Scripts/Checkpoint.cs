using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool oneTime = true;       
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        var pr = other.GetComponent<PlayerRespawn>();
        if (pr != null)
        {
            pr.SetCheckpoint(transform.position + Vector3.up * 0.5f);
           
        }
    }
}