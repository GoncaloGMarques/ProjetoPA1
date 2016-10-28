using UnityEngine;
using System.Collections;

public class HammerSmash : Habilidades {

    [Range(0, 10)]
    public float radius = 3.0f;
    public float delay = 0.0f;
    //public GameObject shower;
    private GameObject cyl;

    public override void Use()
    {
        base.Use();
        cyl = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cyl.transform.position = hitPos;
        cyl.transform.localScale = new Vector3(radius, 0.02f, radius);
        cyl.GetComponent<Renderer>().material.color = Color.magenta;
        cyl.GetComponent<CapsuleCollider>().isTrigger = true;
        Invoke("Land", delay);

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
