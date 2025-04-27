using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System;

public class UpdateText : MonoBehaviour
{
    public int currAmnt = 0;
	public int quota = 100;
    public Text currAmnt_Display;
	public Text QuotaAmnt_Display;
	public GameObject FarmUI;
    public void updateScore (int amnt)
    {
        
        //if (MyCount == "X")
        //{
            //MyText="";
          //  MyCount="";
        //}

        //MyText += MyCount;
        //text.text = MyText;
		
		currAmnt += amnt;
		currAmnt_Display.text = Convert.ToString(currAmnt);
		FarmUI.SendMessage("UpdateCurrAmnt", currAmnt);
    }
	
	void Start()
	{
		currAmnt_Display.text = Convert.ToString(currAmnt);
		QuotaAmnt_Display.text = Convert.ToString(quota);
		
		FarmUI.SendMessage("UpdateQuota", quota);
		FarmUI.SendMessage("UpdateCurrAmnt", currAmnt);
	}
	
	void Update()
	{
	}
}
