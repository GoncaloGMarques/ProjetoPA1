using UnityEngine;
using System.Collections;

public class Shoot : Habilidades
{
    public GameObject projectile;
    public override void Use()
    {
        if (ready)
        {
            base.Use();
            if (inRange)
            {
                GameObject proj = GameObject.Instantiate(projectile);
                proj.transform.position = transform.position;
                proj.transform.LookAt(new Vector3(hitPos.x, transform.position.y, hitPos.z));
                Destroy(proj, 3.0f);
                ready = false;
                inRange = false;
            }
        }
    }
}
