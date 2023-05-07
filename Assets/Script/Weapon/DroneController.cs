using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public int currentLever = 1;
    [SerializeField] int amount;
    [SerializeField] float speed, radius;
    [SerializeField] GameObject dronePF;
    [SerializeField] List<GameObject> Drones;
    // Start is called before the first frame update
    void Start()
    {
        Arrange();
    }

    // Update is called once per frame
    void Arrange()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        Drones.Clear();
        float angle = 2*Mathf.PI / amount;
        for (int i = 0; i < amount; i++)
        {
            Vector2 offset = new Vector2(Mathf.Cos(angle * i), Mathf.Sin(angle * i));
            GameObject newDrone = GameObject.Instantiate(dronePF, transform.position + (Vector3)offset, transform.rotation,gameObject.transform);
            OrbitalMovement droneMovement = newDrone.GetComponent<OrbitalMovement>();
            droneMovement.speed = speed;
            droneMovement.radius = radius;
            Drones.Add(newDrone);
        }
        
    }
    public void LeverUp()
    {      
        switch(currentLever)
        {
            case 1: amount += 1; Arrange(); break;
            case 2: speed += 30; Arrange(); break;
            case 3: amount += 1; Arrange(); break;
            case 4: radius += 0.2f; Arrange(); break;
            case 5: amount += 2; Arrange(); break;
            default: Arrange(); break;
        }
        currentLever++;
    }
}
