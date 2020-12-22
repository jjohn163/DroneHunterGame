using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneController : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    public GameObject drone;
    public GameObject billboard;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        billboard = GameObject.FindGameObjectWithTag("Billboard");
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(target.position, transform.position);
        if (dist < 2)
        {

            Destroy(gameObject);
            Destroy(drone);
            billboard.GetComponent<BillboardCounter>().deliveryRemaining -= 1;
            Debug.Log("Drone Reached Target");

        }
        else
        {
            agent.SetDestination(target.position);
        }
    }
}
