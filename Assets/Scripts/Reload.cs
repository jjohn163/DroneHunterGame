using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
   
    public GameObject shotgun;
    private Rigidbody reloadCollider;
    private AudioSource reloadSound;
    void Start()
    {
        //access the collider capsule
        reloadCollider = GetComponent<Rigidbody>();
        reloadSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // if this capsule contacts the capsule attached to the other controller under the gun, reload 2 shots
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");

        if (other.tag == "reload")
        {
            shotgun.GetComponent<ProjectileSpawner>().shotCounter = 2;
            reloadSound.Play();
            Debug.Log("Reloaded");
        }
    }

    void OnTriggerExit(Collider other)
    {

    }
}
