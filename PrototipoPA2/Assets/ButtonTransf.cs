using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonTransf : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enableMenu;
    [SerializeField]
    private GameObject[] disableMenu;

    [SerializeField] 
    private bool disableParent = true;

    private Button butt;
	// Use this for initialization
	void Start ()
	{
	    butt = GetComponent<Button>();
        butt.onClick.AddListener(MudaMenu);
	}


    void MudaMenu()
    {
        for (int i = 0; i < enableMenu.Length; i++)
        {
            enableMenu[i].SetActive(true);
        }
        for (int i = 0; i < disableMenu.Length; i++)
        {
            disableMenu[i].SetActive(false);
        }

        if (disableParent)
            transform.parent.gameObject.SetActive(false);
    }
	
}
