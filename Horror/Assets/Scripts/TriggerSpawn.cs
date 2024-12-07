using UnityEngine;

public class TriggerSpawn : MonoBehaviour
{
    public GameObject objectToSpawn; // The prefab to spawn
    public Transform spawnPoint;    // The empty GameObject's transform for spawn position
    private bool hasSpawned = false; // Tracks if the object has already been spawned

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the trigger and if the object hasn't been spawned yet
        if (other.CompareTag("Player") && !hasSpawned)
        {
            if (objectToSpawn != null && spawnPoint != null)
            {
               Quaternion spawnRotation = spawnPoint.rotation * Quaternion.Euler(0, 180, 0);
                Instantiate(objectToSpawn, spawnPoint.position, spawnRotation);
                hasSpawned = true; // Mark as spawned
            }
            else
            {
                Debug.LogWarning("Object to spawn or spawn point is not assigned.");
            }
        }
    }
}

