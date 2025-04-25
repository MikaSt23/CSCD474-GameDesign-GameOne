using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextBoxController : MonoBehaviour
{
	bool talked = false;
	public Text text;
	public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        this.text.text = "**Press SPACE to advance dialogue**";
		this.button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
		{
			Talk();
		}
    }
	
	void Talk()
	{
		if(this.talked){
			this.text.text = "(I should Head Inside Now)";
			this.button.SetActive(true);
		}else{
			this.text.text = "Boy howdy am I excited for this date! \n I sure hope they like me! \n tehee.";
			this.talked = true;
		}
	}
	
	public void GoInside()
	{
		SceneManager.LoadScene("DateSceneMVP");
	}
}
