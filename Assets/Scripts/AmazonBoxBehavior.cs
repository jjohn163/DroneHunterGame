using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmazonBoxBehavior : MonoBehaviour
{
    public GameObject drone;
    public bool fallen = false;
    public float timeToDestruct = 0f;

    void Update()
    {
        if(fallen && Time.time > timeToDestruct)
        {
            Destroy(drone);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "startTrigger")
        {
            SceneManager.LoadScene("Main");
            Debug.Log("StartTrigger");
        }

        if (other.tag == "menuTrigger")
        {
            SceneManager.LoadScene("Intro");
            Debug.Log("menuTrigger");
        }
    }
}
