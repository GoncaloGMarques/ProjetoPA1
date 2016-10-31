using UnityEngine;
using System.Collections;

public class Martelo : Projectiles {
    Vector3 destination;
    bool going = true;
    public GameObject owner;
    public float damage;

    void Update()
    {
        if (Vector3.Distance(transform.position, destination) < 0.1f && going)
        {
            speed *= 3.0f;
            going = false;
        }
        else if (going) transform.position = Vector3.MoveTowards(transform.position, destination, speed);
        else if (Vector3.Distance(transform.position, owner.transform.position) < 0.1f) Destroy(gameObject);
        else transform.position = Vector3.MoveTowards(transform.position, owner.transform.position, speed);

        transform.Rotate(new Vector3(0.0f,0.0f,10.0f));
        
    }
    public void MoveTo(Vector3 loc)
    {
        destination = loc;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != owner) other.gameObject.GetComponent<Hero>().health -= damage;
    }
}
