using UnityEngine;
using System.Collections;

public class HammerSmash : Habilidades
{
    public float radius;
    public float delay = 0.0f;
    //public GameObject shower;
    private GameObject cyl;

    public override void Use()
    {
        base.Use();
        if (inRange)
        {
            cyl = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            cyl.transform.position = hitPos;

            cyl.GetComponent<CapsuleCollider>().radius = radius;
            Vector3 cSize = cyl.GetComponent<CapsuleCollider>().bounds.size;
            cyl.transform.localScale = new Vector3(cSize.x, 0.01f, cSize.z);

            cyl.GetComponent<Renderer>().material.color = Color.magenta;
            cyl.GetComponent<CapsuleCollider>().isTrigger = true;
            Invoke("Land", delay);
            ready = false;
            inRange = false;
        }



    }


    public void Land()
    {
        Collider[] hits = Physics.OverlapSphere(hitPos, radius);
        foreach (Collider c in hits)
        {
            if (c.GetComponent<Hero>())
            {
                Hero h = c.GetComponent<Hero>();
                if (h != GetComponent<Hero>())
                {
                    h.health -= damage;
                    Debug.Log("Hit");
                }
            }
        }
        cyl.GetComponent<Renderer>().material.color = Color.green;
        Destroy(cyl, 1.0f);
    }
}
