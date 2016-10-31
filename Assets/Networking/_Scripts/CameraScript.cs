using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CameraScript : NetworkBehaviour {
    public float cameraHeight, cameraDistance;
    public GameObject player;
    public Texture2D[] cursors;


	void Update () {
	    if (player != null && player)
	    {
	        Vector3 pPos = player.transform.position;
	        transform.position = new Vector3(pPos.x, pPos.y + cameraHeight, pPos.z - cameraDistance);
	        transform.LookAt(player.transform.position);
	        //ChangeCursor();
	    }
        //else
        //{
        //    GameObject tmpPlayer;
            
        //    tmpPlayer = GameObject.FindGameObjectWithTag("Player");

        //    if (tmpPlayer != null && tmpPlayer.GetComponent<Movement>().isLocalPlayer)
        //    {
        //        player = tmpPlayer;
        //    }
        //}

        
	}

    void ChangeCursor()
    {
        //Ray raio = cam.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        //if (Physics.Raycast(raio, out hit))
        //{
        //    if (hit.collider.gameObject.GetComponent<Damageable>())
        //    {
        //        if (hit.collider.gameObject.GetComponent<Damageable>().equipa != heroeScript.equipa)
        //            Cursor.SetCursor(cursors[1], Vector2.zero, CursorMode.ForceSoftware);
        //    }
        //    else Cursor.SetCursor(cursors[0], Vector2.zero, CursorMode.ForceSoftware);
        //}
        Cursor.SetCursor(cursors[0], Vector2.zero, CursorMode.ForceSoftware);
        Cursor.lockState = CursorLockMode.Confined;
    }
}
