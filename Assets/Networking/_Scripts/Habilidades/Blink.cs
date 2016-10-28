using UnityEngine;
using System.Collections;

public class Blink : Habilidades {

    public float velo = 2;
    Vector3 dest;
    RaycastHit hit;
    public bool moving = false;
    Vector3 movePosition;
    private MeshRenderer m_meshRenderer;
    private BoxCollider m_boxCollider;
    private GameObject NoseGameObject;
    private GameObject ParticleGameObject;

    void Awake()
    {
        m_boxCollider = GetComponent<BoxCollider>();
        m_meshRenderer = GetComponent<MeshRenderer>();
        NoseGameObject = GameObject.Find("Nariz");
        ParticleGameObject = GameObject.Find("BlackTrail");
    }

    void Update()
    {
        UpdateTimers();
        if (transform.position == movePosition && moving == true) moving = false;
        if (Vector3.Distance(transform.position, movePosition) <= 0.1f && moving == true) moving = false;

        if (moving)
        {
            ParticleGameObject.SetActive(true);
            NoseGameObject.SetActive(false);
            m_meshRenderer.enabled = false;
            m_boxCollider.enabled = false;
            transform.position = Vector3.MoveTowards(transform.position, movePosition, velo);
            transform.LookAt(movePosition);
        }
        else
        {
            NoseGameObject.SetActive(true);
            ParticleGameObject.SetActive(false);
            m_meshRenderer.enabled = true;
            m_boxCollider.enabled = true;
        }
    }

    public override void Use()
    {
        if (ready)
        {
            base.Use();
            if (inRange)
            {
                dest = transform.position - hitPos;
                dest.Normalize();

                movePosition = new Vector3(hitPos.x, transform.position.y, hitPos.z);

                moving = true;
            }
        }
    } 
}
