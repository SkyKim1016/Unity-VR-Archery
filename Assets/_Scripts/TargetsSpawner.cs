using UnityEngine;

public class TargetsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _targetPrefab; // Reference to the target prefab
    [SerializeField] private int _numberOfTargetsToSpawn = 60; // Number of targets to spawn
    [SerializeField] private float yRange = 2; // Range for y-axis spawning
    [SerializeField] private float xRange = 5; // Range for x-axis spawning
    [SerializeField] private float zRange = 2; // Range for z-axis spawning


    private void Start()
    {
        SpawnTargets();
    }
    // Method to spawn targets
    public void SpawnTargets()
    {
        for (int i = 0; i < _numberOfTargetsToSpawn; i++)
        {
            float spawnX = Random.Range(transform.position.x - xRange / 2, transform.position.x + xRange / 2); // Calculate random x position
            float spawnY = Random.Range(transform.position.y, transform.position.y + yRange); // Calculate random y position
            float spawnZ = Random.Range(transform.position.z, transform.position.z + zRange); // Calculate random z position

            Vector3 spawnPosition = new Vector3(spawnX, spawnY, spawnZ); // Create spawn position vector

            Instantiate(_targetPrefab, spawnPosition, Quaternion.identity, transform); // Instantiate the target prefab at the calculated position
        }
    }

    // Method to destroy all targets
    public void DestroyAllTargets()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject); // Destroy each child game object under this spawner's transform
        }
    }
}
