using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class ProjectileSpawner : MonoBehaviour
{
    public float projectileSpeed;
    public float fireRateCap;
    public float spread;
    public int numOfPellets;
    public GameObject projectilePrefab;
    public Camera cam;
    public int shotCounter = 0;
    private float timeSinceLastFired;
    AudioSource blast;
    
    
    //private float timeSinceLastFired;

    void Start()
    {
        timeSinceLastFired = Time.time;
        blast = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("RightTrigger"))
        {
            Fire();
        }
    }
    public void Fire()
    {

        //Debug.Log((Time.time - timeSinceLastFired));

        //restricts time between shots and checks if there is ammo loaded in the gun
        if (shotCounter > 0 && (Time.time - timeSinceLastFired) > fireRateCap)
        {
            Debug.Log("yoink");

            GameObject proj;

            for (int i = 0; i < numOfPellets; i++)
            {
                proj = Instantiate(projectilePrefab, this.transform.position, Quaternion.identity);

                Rigidbody projRB = proj.GetComponent<Rigidbody>();

                Vector3 direction = new Vector3(-(this.transform.forward.normalized.x + Random.Range(-spread, spread)),
                                                -(this.transform.forward.normalized.y + Random.Range(-spread, spread)),
                                                -(this.transform.forward.normalized.z));

                //was shooting out the back of the gun, so I reversed it, and this references the gun transform
                projRB.velocity = direction * projectileSpeed;
            }

            shotCounter -= 1;
            Debug.Log(shotCounter);
            timeSinceLastFired = Time.time;
            blast.Play();
        }
    }
    
}
