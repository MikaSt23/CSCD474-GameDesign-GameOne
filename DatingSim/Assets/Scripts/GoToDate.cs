using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToDate : MonoBehaviour
{
	public GameObject dateButton;
	int amnt = 0;
	int quota = 100;
    // Start is called before the first frame update
    void Start()
    {
        this.dateButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if(amnt >= quota)
	   {
		   this.dateButton.SetActive(true);
		   if(amnt - quota >= 100)
		   {
			   Choice.isRich = true;
		   }
		   amnt = 0;
	   }		   
    }
	
	public void UpdateCurrAmnt(int amnt)
	{
		this.amnt = amnt;
	}
	
	public void UpdateQuota(int Quota)
	{
		this.quota = Quota;
	}
	
	public void GoOutsideCafe()
	{
		SceneManager.LoadScene("OutsideCafe");
	}
}
