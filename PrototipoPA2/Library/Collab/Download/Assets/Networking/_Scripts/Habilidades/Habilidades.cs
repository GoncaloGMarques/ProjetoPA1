using UnityEngine;
using System.Collections;

public class Habilidades : MonoBehaviour {

    LayerMask floor;
    float maxDistance = 300.0f;

    public float duration = 0.1f;
    public float cooldown = 1.0f;
    private float timer = 0.0f;
    public bool ready = true;
    public float damage = 1.0f;
    public float range = 200.0f;
    public Vector3 hitPos;
    public bool inRange = false;
    public bool quickCast = true;
    private bool preClick = false;
    private Transform rangeObj;

	void Start () {
        floor = LayerMask.GetMask("Floor");
        rangeObj = transform.FindChild("Radius");
	}

	void Update () {
        UpdateTimers();
	}

    public virtual void UpdateTimers()
    {
        if (!ready && timer >= cooldown)
        {
            ready = true;
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    void VerifyRange()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out  hit, maxDistance, floor))
        {
            hitPos = hit.point;
            if (range == 0) inRange = true;
            else
            {
                if (Vector3.Distance(hitPos, transform.position) <= range)
                {
                    inRange = true;
                }
                else inRange = false;
            }
            
        }
    }

    public virtual void Use()
    {
        if (!quickCast)
        {
            if (preClick)
            {
                VerifyRange();
                if (inRange)
                {
                    GetComponent<Movement>().LookToMouse();
                    GetComponent<Movement>().StopToAttack(duration);
                    ready = false;
                    timer = 0;
                    
                }
                preClick = false;
            }
            else preClick = true;
        }
        else
        {
            VerifyRange();
            if (inRange)
            {
                GetComponent<Movement>().LookToMouse();
                GetComponent<Movement>().StopToAttack(duration);
                ready = false;
                timer = 0;
            }
        }


    }

    void ShowRange()
    {
//rangeObj.GetComponent<Renderer>().
    }

}
