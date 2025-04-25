using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolBarSettings : MonoBehaviour
{
    public static int currentTool = 0;

    public Outline itemOne;
    public Outline itemTwo;
    public Outline itemThree;

    private Color defaultColor = new Color(0, 0, 0, 128);
    private Color selected = new Color(219, 180, 0, 128);

    private void Start()
    {
        itemOne.effectColor = defaultColor;
        itemTwo.effectColor = defaultColor;
        itemThree.effectColor = defaultColor;
    }

    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            currentTool = 1;
            UpdateSelector();
        }
        else if (Input.GetKeyDown("2"))
        {
            currentTool = 2;
            UpdateSelector();
        }
        else if (Input.GetKeyDown("3"))
        {
            currentTool = 3;
            UpdateSelector();
        }
    }

    private void UpdateSelector()
    {
        itemOne.effectColor = (currentTool == 1) ? selected : defaultColor;
        itemTwo.effectColor = (currentTool == 2) ? selected : defaultColor;
        itemThree.effectColor = (currentTool == 3) ? selected : defaultColor;
    }
}
