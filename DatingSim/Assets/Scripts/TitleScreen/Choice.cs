using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Choice
{
	public static bool isCarrot = false;
	public static bool isRich = false;

	public static void SetIsCarrot(bool choice)
	{
		isCarrot = choice;
	}
	
	public static bool GetIsCarrot()
	{
		return isCarrot;
	}
}
