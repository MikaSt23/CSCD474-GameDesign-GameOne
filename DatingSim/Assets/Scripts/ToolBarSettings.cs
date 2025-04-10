using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolBarSettings : MonoBehaviour
{
	//Objects we'll manipulate through the scripts
	public Outline itemOne;
	public Outline itemTwo;
	public Outline itemThree;
	
	// Default, and selected color
	private Color defaultColor = new Color(0,0,0,128);
	private Color selected = new Color(219,180,0,128);
	
	//Flag that tells us which item is selected
	private byte flag = 0;
	
	//Booleans to tell which items are selected
	private bool isOne = false;
	private bool isTwo = false;
	private bool isThree = false;
	
    // Start is called before the first frame update
    void Start()
    {
        itemOne.effectColor = defaultColor;
		itemTwo.effectColor = defaultColor;
		itemThree.effectColor = defaultColor;
    }
	
	void Update()
	{
		if(Input.GetKeyDown("1"))
		{
			flag = 1;
			UpdateSelector();
		}else if(Input.GetKeyDown("2"))
		{
			flag = 2;
			UpdateSelector();
		}else if(Input.GetKeyDown("3"))
		{
			flag = 3;
			UpdateSelector();
		}
	}
	
	
	private void UpdateSelector()
	{
		if(flag == 1)
		{
			itemTwo.effectColor = defaultColor;
			itemThree.effectColor = defaultColor;
			
			if(isOne){
				itemOne.effectColor = defaultColor;
				isOne = false;
			}else{
				itemOne.effectColor = selected;
				isOne = true;
				isTwo = false;
				isThree = false;
			}
			
		}else if(flag == 2)
		{
			itemOne.effectColor = defaultColor;
			itemThree.effectColor = defaultColor;
			
			if(isTwo){
				itemTwo.effectColor = defaultColor;
				isTwo = false;
			}else{
				itemTwo.effectColor = selected;
				isTwo = true;
				isOne = false;
				isThree = false;
			}
		}else if(flag == 3)
		{
			itemOne.effectColor = defaultColor;
			itemTwo.effectColor = defaultColor;
			
			if(isThree){
				itemThree.effectColor = defaultColor;
				isThree = false;
			}else{
				itemThree.effectColor = selected;
				isThree = true;
				isOne = false;
				isTwo = false;
			}
		}else{
			itemOne.effectColor = defaultColor;
			itemTwo.effectColor = defaultColor;
			itemThree.effectColor = defaultColor;
		}
	}
}
