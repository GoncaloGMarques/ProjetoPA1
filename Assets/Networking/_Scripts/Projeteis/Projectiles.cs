using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour {
    public float speed;

	void Update () {
        transform.position += transform.forward * speed * Time.deltaTime;
	}
}
