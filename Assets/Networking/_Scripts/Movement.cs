using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody))]

public class Movement : NetworkBehaviour {
    
    public float speed;
    //public Camera cam;
    LayerMask floor;
    float maxDistance = 300.0f;
    public float lookHeight = 0.0f;
    float horizontal, vertical;
    public float attackTimer = 0.0f;
    public bool isAttacking = false;
    public GameObject camera;
    public GameObject cam;
    private Hero hero;
  

	void Start () {
        floor = LayerMask.GetMask("Floor");
        speed = GetComponent<Hero>().moveSpeed;
        hero = GetComponent<Hero>();
        SpawnCamera();
	}

    private void SpawnCamera()
    {
        //GameObject.FindGameObjectWithTag("SceneCamera").SetActive(false);
        GameObject[] cams = GameObject.FindGameObjectsWithTag("MainCamera");
        foreach (GameObject c in cams)
        {
            c.SetActive(false);
        }
        cam = GameObject.Instantiate(camera);
        cam.transform.position = Vector3.zero;
        cam.GetComponent<CameraScript>().player = gameObject;
        cam.tag = "MainCamera";
        cam.SetActive(true);
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }

    void Update ()
	{
	    if (!isLocalPlayer)
	    {
            
	        return;
	    }

        if (!isAttacking)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            transform.position += new Vector3(horizontal, 0, vertical) * Time.deltaTime * speed;

            if (horizontal == 0 && vertical == 00) LookToMouse();

            else if (horizontal > 0 && vertical == 0) transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
            else if (horizontal < 0 && vertical == 0) transform.rotation = Quaternion.AngleAxis(-90, Vector3.up);
            else if (horizontal == 0 && vertical > 0) transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
            else if (horizontal == 0 && vertical < 0) transform.rotation = Quaternion.AngleAxis(180, Vector3.up);

            else if (horizontal > 0 && vertical > 0) transform.rotation = Quaternion.AngleAxis(45, Vector3.up);
            else if (horizontal < 0 && vertical > 0) transform.rotation = Quaternion.AngleAxis(-45, Vector3.up);
            else if (horizontal > 0 && vertical < 0) transform.rotation = Quaternion.AngleAxis(135, Vector3.up);
            else if (horizontal < 0 && vertical < 0) transform.rotation = Quaternion.AngleAxis(-135, Vector3.up);
        }
        else
        {
            if (attackTimer > 0) attackTimer -= Time.deltaTime;
            else isAttacking = false;
        }

        if (Input.GetMouseButtonDown(0)) hero.habs[0].Use();
        if (Input.GetMouseButtonDown(1)) hero.habs[3].Use();
        if (Input.GetKeyDown(KeyCode.Space)) hero.habs[1].Use();
        if (Input.GetKeyDown(KeyCode.R)) hero.habs[2].Use();
        if (Input.GetKeyDown(KeyCode.E)) hero.habs[4].Use();
	}

    public void LookToMouse()
    {
        
        Vector3 lookTarget = Vector3.zero;
        RaycastHit hit;
        Ray ray = cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out  hit, maxDistance, floor))
        {
            lookTarget = hit.point;
        }
        Vector3 actualLook = new Vector3(lookTarget.x, lookHeight, lookTarget.z);
        if (Vector3.Distance(transform.position, actualLook) >= 1) transform.LookAt(actualLook);
        
    }

    public void StopToAttack(float duration)
    {
        attackTimer = duration;
        isAttacking = true;
    }

}
