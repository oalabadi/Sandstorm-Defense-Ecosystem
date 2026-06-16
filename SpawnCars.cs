using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject cars;
    public Rigidbody[] car;
    public GameObject roads;
    public Transform[] road;
    public float maxSpawnRate;
    public float time;
    public float carSpeed;
    public float randomSpawnRate;

    private void Start()
    {
        car = cars.GetComponentsInChildren<Rigidbody>();
        //road = roads.GetComponentsInChildren<Transform>();

    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= randomSpawnRate) SpawnCar();
    }

    void SpawnCar()
    {
        randomSpawnRate = Random.Range(1, maxSpawnRate);
        int randomCar = Random.Range(0, car.Length);
        int randomLine = Random.Range(0, road.Length);
        Quaternion rot = Quaternion.Euler(-90f, 0, 90f);
        GameObject currentCar = Instantiate(car[randomCar].gameObject, road[randomLine].position, rot);
        float randomSpeed = Random.Range(carSpeed, carSpeed + 50f);
        if (road[randomLine] == road[0] || road[randomLine] == road[1])
        {
            currentCar.transform.rotation = Quaternion.Euler(-90f, 180f, 90f);
            currentCar.GetComponent<Rigidbody>().velocity = new Vector3(randomSpeed, 0, 0);
        }
        else
            currentCar.GetComponent<Rigidbody>().velocity = new Vector3(-randomSpeed, 0, 0);
        time = 0;
    }
}
