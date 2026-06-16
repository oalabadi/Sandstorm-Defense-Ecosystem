using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject cars;        // A collection of 3D car models
    public Rigidbody[] car;        // Get the RigidBody component of eeach car
    public GameObject roads;       // Collection of roads
    public Transform[] road;       // The initial point of the car spawn location
    public float maxSpawnRate;     // The time to spawn a new car
    public float time;             // The time when to spawn a car
    public float carSpeed;         // The speed of the car after it spawns

    private void Start()
    {
        // Collecting all the cars GameObjects
        car = cars.GetComponentsInChildren<Rigidbody>();
    } 
    
    private void Update()
    {
        // The time to spawn a car
        time += Time.deltaTime;
        if (time >= randomSpawnRate) SpawnCar();
    }

    public float randomSpawnRate;
    void SpawnCar()
    {
        // Setting a random spawn rate 
        randomSpawnRate = Random.Range(1, maxSpawnRate);

        // Iterating through each car
        int randomCar = Random.Range(0, car.Length);
        int randomLine = Random.Range(0, road.Length);
        Quaternion rot = Quaternion.Euler(-90f, 0, 90f);

        // Spawn the car in a random road line
        GameObject currentCar = Instantiate(car[randomCar].gameObject, road[randomLine].position, rot);

        // Setting a random speed value for variety
        float randomSpeed = Random.Range(carSpeed, carSpeed + 50f);

        // Where the car should face based on the road
        if (road[randomLine] == road[0] || road[randomLine] == road[1])
        {
            currentCar.transform.rotation = Quaternion.Euler(-90f, 180f, 90f);
            currentCar.GetComponent<Rigidbody>().velocity = new Vector3(randomSpeed, 0, 0);
        }
        else
            currentCar.GetComponent<Rigidbody>().velocity = new Vector3(-randomSpeed, 0, 0);

        // Resetting time to 0 to spawn the next car
        time = 0;
    }
}
