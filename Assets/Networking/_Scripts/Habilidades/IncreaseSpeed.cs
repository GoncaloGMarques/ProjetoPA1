using UnityEngine;
using System.Collections;

public class IncreaseSpeed : Habilidades {

    public float speedDuration;
    private float speedTimer;

    void Update()
    {
        UpdateTimers();
        if (speedTimer >= speedDuration)
        {
            GetComponent<Movement>().speed = GetComponent<Hero>().moveSpeed;
        }
        else speedTimer += Time.deltaTime;
    }
    
    public override void Use()
    {
        if (ready)
        {
            base.Use();
            if (inRange)
            {
                GetComponent<Movement>().speed *= 4;
                speedTimer = 0;
            }
        }
    }

}
