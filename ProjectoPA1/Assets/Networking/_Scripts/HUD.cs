using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
    public Text hpText;
    public Hero myHero;
    
	void Start () {
	
	}
	
	void Update () {
        if(myHero)
	    {
            //hpText.GetComponent<Text>().text = "Health: " + myHero.health.ToString();
            hpText.text = "Health: " + myHero.health.ToString();
        }
	}
}
