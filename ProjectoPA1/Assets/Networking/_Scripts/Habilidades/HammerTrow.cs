using UnityEngine;
using System.Collections;

public class HammerTrow : Habilidades {
    public GameObject projectile;
    public override void Use()
    {
        if (ready)
        {
            base.Use();
            if(inRange)
            {
                GameObject proj = GameObject.Instantiate(projectile);
                proj.transform.position = transform.position;
                proj.GetComponent<Martelo>().MoveTo(new Vector3(hitPos.x, transform.position.y, hitPos.z));
                proj.GetComponent<Martelo>().owner = gameObject;
                proj.GetComponent<Martelo>().damage = damage;
            }
        }
    }
}
