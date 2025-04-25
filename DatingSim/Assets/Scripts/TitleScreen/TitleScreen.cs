using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
	public GameObject start;
	public GameObject tutorial;
	public GameObject newGame;
	public GameObject camera;
	public GameObject title;
	public GameObject backLeft;
	public GameObject backRight;
	public GameObject carrot;
	public GameObject df;
	public GameObject exit;
	
	
    // Start is called before the first frame update
    void Start()
    {
        this.tutorial.SetActive(false);
		this.newGame.SetActive(false);
		this.backLeft.SetActive(false);
		this.backRight.SetActive(false);
		this.carrot.SetActive(false);
		this.df.SetActive(false);
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void StartGame()
	{
		this.start.SetActive(false);
		this.tutorial.SetActive(true);
		this.newGame.SetActive(true);
	}
	
	public void Tutorial()
	{
		MoveCamera(true);
		this.backRight.SetActive(true);
		this.tutorial.SetActive(false);
		this.newGame.SetActive(false);
		this.exit.SetActive(false);
	}
	
	public void NewGame()
	{
		MoveCamera(false);
		this.exit.SetActive(false);
		this.backLeft.SetActive(true);
		this.newGame.SetActive(false);
		this.tutorial.SetActive(false);
		
		this.carrot.SetActive(true);
		this.df.SetActive(true);
	}
	
	private void MoveCamera(bool lAndR)
	{
		float speed = 0f;
		if(lAndR) 
		{
			speed = -5f;
		}else{
			speed = 5f;
		}
		
		for(int i=0; i<24; i++)
		{
			this.camera.transform.position = this.camera.transform.position + new Vector3(i*speed*Time.deltaTime, 0, 0);
		}
		
	}
	
	public void BackToStart()
	{
		this.camera.transform.position = new Vector3(0f, -0.62f, -10f);
		this.newGame.SetActive(true);
		this.tutorial.SetActive(true);
		
		this.backLeft.SetActive(false);
		this.backRight.SetActive(false);
		
		this.carrot.SetActive(false);
		this.df.SetActive(false);
		
		this.exit.SetActive(true);
	}
	
	public void SetDateChoice(bool choice)
	{
		Choice.isCarrot = choice;
		Debug.Log("Choice is set to:" + Choice.isCarrot);
		SceneManager.LoadScene("Farm");
	}
	
	public void Quit()
	{
		Application.Quit();
		UnityEditor.EditorApplication.isPlaying = false;
	}
}
