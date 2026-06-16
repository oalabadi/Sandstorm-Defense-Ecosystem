using UnityEngine;

public class BranchSpawner : MonoBehaviour
{
    [Header("Prefab Setup")]
    // This creates an empty slot in the Inspector where you will drag your Branch Prefab
    public GameObject branchPrefab;
    public Material[] hydrationMats;

    [Header("Planting Pattern")]
    public int numberOfPlants = 10;      // Total plants to spawn
    public float forwardSpacing = 2f;    // Distance between plants moving forward
    public float zigzagWidth = 1.5f;     // How far left and right they alternate

    void Start()
    {
        PlantZigzagRow();
    }

    void PlantZigzagRow()
    {
        // Safety check: ensure you didn't forget to assign the prefab
        if (branchPrefab == null)
        {
            Debug.LogError("Branch Prefab is missing! Please drag it into the script.");
            return;
        }

        // Loop through the total number of plants we want to spawn
        for (int i = 0; i < numberOfPlants; i++)
        {
            // 1. Calculate Forward Position (Z-axis)
            // Each plant moves further down the line
            float zPosition = i * forwardSpacing;

            // 2. Calculate Zigzag Position (X-axis)
            // The '%' (modulo) checks the remainder of division by 2. 
            // If it is 0 (even), it goes right. If it is 1 (odd), it goes left.
            float xPosition = (i % 2 == 0) ? zigzagWidth : -zigzagWidth;

            // Combine them into a 3D coordinate (relative to the Spawner's location)
            Vector3 spawnLocation = transform.position + new Vector3(zPosition, 0, xPosition);

            // 3. Instantiate the Prefab at the calculated location
            // Quaternion.identity means "zero rotation" (just use the prefab's default rotation)
            GameObject newPlant = Instantiate(branchPrefab, spawnLocation, Quaternion.identity);
            int randomNumber = Random.Range(0, hydrationMats.Length);
            Material hydration = hydrationMats[randomNumber];
            newPlant.GetComponent<MeshRenderer>().material = hydration;

            // Optional: Group them under this Spawner to keep your hierarchy clean
            newPlant.transform.parent = this.transform;
            newPlant.name = "ZigzagPlant_" + i;
        }
    }
}