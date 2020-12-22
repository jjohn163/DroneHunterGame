
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int power = 300;
    public Camera cam;
    public ProjectileSpawner projScript;

    //public ParticleSystem muzzleflash;
    // Update is called once per frame

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Debug.Log("point");

        //GameController.instance.decreaseAmmo();

        projScript.Fire();

        //muzzleflash.Play();
        /*RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * power);
            }
        }*/
    }
}
