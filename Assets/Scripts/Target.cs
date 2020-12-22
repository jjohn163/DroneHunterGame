
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public GameObject nav;
    public AmazonBoxBehavior box;
    public GameObject billboard;

    void Start()
    {
        billboard = GameObject.FindGameObjectWithTag("Billboard");
    }

    public void TakeDamage(float damage)
    {
        health = health - damage;
        if (health <= 0f)
        {
            box.fallen = true;

            // function called when a drone is destroyed to increment player's score
            // score of 200 is used as a placeholder right now for all drones
            //GameController.instance.playerScored(200);

            //increments score on billboard by 200 when drone is hit, since this is called for every damage, increase score for each pellet hit to reward accuracy
            if (billboard != null)
            {
                billboard.GetComponent<BillboardCounter>().score += 200;
            }
            box.timeToDestruct = Time.time + 5f;
            Destroy(gameObject);
            Destroy(nav);
            
        }
    }
}
