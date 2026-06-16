using UnityEngine;

public class BranchSpawner : MonoBehaviour
{
    [Header("Prefab Setup")]
    public GameObject branchPrefab;     // The parent GameObject which will contain all the branches created
    public Material[] hydrationMats;    // A set of materials determining the initial hydration of the branch

    [Header("Planting Pattern")]
    public int numberOfPlants = 10;      // Total plants to spawn
    public float forwardSpacing = 2f;    // Distance between plants moving forward
    public float zigzagWidth = 1.5f;     // How far left and right

    void Start()
    {
        PlantZigzagRow();
    }

    void PlantZigzagRow()
    {
        // Check if the value has been assigned in the editor
        if (branchPrefab == null)
        {
            Debug.LogError("Branch Prefab is missing!");
            return;
        }

        // Loop through the total number of plants
        for (int i = 0; i < numberOfPlants; i++)
        {
            // Calculate Forward Position
            float zPosition = i * forwardSpacing;

            // Calculate Zigzag Position
            // If it is 0, it goes right. If it is 1, it goes left
            float xPosition = (i % 2 == 0) ? zigzagWidth : -zigzagWidth;

            // Combine them into a Vecotr3 (x, y, z)
            Vector3 spawnLocation = transform.position + new Vector3(zPosition, 0, xPosition);

            // Instantiate the Prefab at the calculated location
            GameObject newPlant = Instantiate(branchPrefab, spawnLocation, Quaternion.identity);
            int randomNumber = Random.Range(0, hydrationMats.Length);

            // Set the initial hydration level
            Material hydration = hydrationMats[randomNumber];
            newPlant.GetComponent<MeshRenderer>().material = hydration;

            // Group all branches into the parent GameObject
            newPlant.transform.parent = this.transform;
            newPlant.name = "ZigzagPlant_" + i;
        }
    }
}
