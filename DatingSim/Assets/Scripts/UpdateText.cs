using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System;

public class UpdateText : MonoBehaviour
{
    public int currAmnt = 0;
    public Text Kp_Display;

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
	Kp_Display.text = Convert.ToString(currAmnt);
    }
	
	void Start()
	{
		Kp_Display.text = Convert.ToString(currAmnt);
	}
	
}
