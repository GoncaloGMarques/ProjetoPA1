using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class fadeInOut : MonoBehaviour
{
    private Image img;
    void Start()
    {
        img = GetComponent<Image>();
    }

	void Update ()
	{

        Debug.Log("Alpha = " + img.canvasRenderer.GetAlpha());
	    if (img.canvasRenderer.GetAlpha() > 0.9)
	    {
            
            img.CrossFadeAlpha(0, 1.0f, false);        
	    }
        img.CrossFadeAlpha(1, 1.0f, false);

	}
}
