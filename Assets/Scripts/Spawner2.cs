using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    public GameObject drone;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;
    public int dronenum = 0;
    //public GameObject target;
    public Vector3[] spawnPositions;
    //index     postion
    //0         front 
    //1         front 
    //2         back 
    //3         back 

    public Transform[] targets;
    //index     postion
    //0         front left
    //1         front right
    //2         back right
    //3         back left



    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            //get target and spawn point for drone
            //spawn and target shouldn't be close to eachother
            int spawnPostion = Random.Range(0, spawnPositions.Length);
            int targetPosition;

            //drones in front should be able to have any target
            //if (spawnPostion < 2)
            //{
            targetPosition = Random.Range(0, targets.Length);
            while (Vector3.Distance(spawnPositions[spawnPostion], targets[targetPosition].position) < 15)
            {
                targetPosition = Random.Range(0, targets.Length);
            }
           // }
            //drones in back should stay in the back
            /*else
            {
                targetPosition = Random.Range(2, targets.Length);
                while (Vector3.Distance(spawnPositions[spawnPostion], targets[targetPosition].position) < 15)
                {
                    targetPosition = Random.Range(2, targets.Length);
                }
            }*/

            //instantiate a new drone
            GameObject newDrone = Instantiate(drone, spawnPositions[spawnPostion] + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);


            //give target to drone nav

            DroneController newDroneNav = newDrone.GetComponentInChildren<DroneController>();
            newDroneNav.target = targets[targetPosition];

            //connect the nav to the new drone
            FixedJoint dronetonav = newDrone.GetComponent<FixedJoint>();
            dronetonav.connectedBody = newDroneNav.GetComponentInParent<Rigidbody>();

            //set new location of the box
            AmazonBoxBehavior box = newDrone.GetComponentInChildren<AmazonBoxBehavior>();
            Transform boxObject = box.GetComponentInParent<Transform>();
            Vector3 localObj = boxObject.localPosition;
            boxObject.localPosition = new Vector3(localObj.x, localObj.y + ((dronenum % 2) * 3), localObj.z);

            //set new location of the dronebody
            Target droneBody = newDrone.GetComponentInChildren<Target>();
            Transform droneBodyObject = droneBody.GetComponentInParent<Transform>();
            localObj = droneBodyObject.localPosition;
            droneBodyObject.localPosition = new Vector3(localObj.x, localObj.y + ((dronenum % 2) * 3), localObj.z);

            FixedJoint navtodronebody = newDroneNav.GetComponentInParent<FixedJoint>();
            navtodronebody.connectedBody = droneBody.GetComponentInParent<Rigidbody>();

            FixedJoint dronebodytobox = droneBody.GetComponentInParent<FixedJoint>();
            dronebodytobox.connectedBody = box.GetComponentInParent<Rigidbody>();







            dronenum++;
            yield return new WaitForSeconds(spawnWait);
        }
    }
}