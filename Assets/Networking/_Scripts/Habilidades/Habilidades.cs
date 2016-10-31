using UnityEngine;
using System.Collections;

public class Habilidades : MonoBehaviour
{

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
    public bool preClick = false;
    private GameObject circRadius;
    public GameObject cilo;
    public Texture radiusTexture;

    void Start()
    {
        floor = LayerMask.GetMask("Floor");
    }

    void Update()
    {
        UpdateTimers();
    }

    void ToggleRadius()
    {
        if (!circRadius)
        {
            circRadius = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            circRadius.transform.position = transform.position - new Vector3(0.0f, 1.0f, 0.0f);
            circRadius.transform.SetParent(this.transform);

            circRadius.GetComponent<CapsuleCollider>().radius = range;
            Vector3 cSize = circRadius.GetComponent<CapsuleCollider>().bounds.size;
            circRadius.transform.localScale = new Vector3(cSize.x, 0.01f, cSize.z);


            circRadius.GetComponent<Renderer>().material.color = Color.magenta;
            circRadius.GetComponent<CapsuleCollider>().isTrigger = true;
            circRadius.GetComponent<Renderer>().material.mainTexture = radiusTexture;
            circRadius.GetComponent<Renderer>().material.shader = Shader.Find("Sprites/Default");
        }
        else Destroy(circRadius);


    }

    //void SwitchRadius()
    //{
    //    GameObject isto = GameObject.Instantiate(cilo);
    //    isto.transform.position = transform.position - new Vector3(0.0f, 1.0f, 0.0f);

    //    isto.GetComponent<CapsuleCollider>().radius = range;
    //    Vector3 cSize = isto.GetComponent<CapsuleCollider>().bounds.size;
    //    isto.transform.localScale = new Vector3(cSize.x, 0.01f, cSize.z);

    //    isto.GetComponent<Renderer>().material.color = Color.magenta;
    //    isto.GetComponent<CapsuleCollider>().isTrigger = true;
    //}

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
        DeactivateAll();
        if (!quickCast)
        {
            ToggleRadius();

            //SwitchRadius();
            if (preClick)
            {
                VerifyRange();
                if (inRange)
                {
                    ready = false;
                    timer = 0;
                    GetComponent<Movement>().LookToMouse();
                    GetComponent<Movement>().StopToAttack(duration);


                }
                preClick = false;
            }
            else if (ready) preClick = true;
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

    public virtual void DeactivateAll()
    {
        Habilidades[] abs = GetComponents<Habilidades>();
        foreach (Habilidades a in abs)
        {
            if (a != this)
            {
                a.ready = false;
                a.preClick = false;
                if (a.circRadius) a.ToggleRadius();
            }
        }
    }


}
