using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "boundary")
            Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "drone")
        {
            Target target = other.transform.GetComponent<Target>();

            if (target != null)
            {
                Debug.Log("damaged");
                target.TakeDamage(damage);
            }

            Destroy(this.gameObject);
        }
    }
}
