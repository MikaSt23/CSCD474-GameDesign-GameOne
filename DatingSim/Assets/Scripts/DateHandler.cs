using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tree;
using DataTree;

namespace DateTree{
public class DateHandler : MonoBehaviour
{
	//Checks if you can access the hidden choice.
	bool isRich = true;
	
	//conversation state tracker/prev child node variable
	byte[] prevChildren;
	
	//temp variable
	TreeNode[] action;
	
	//sentinel variable
	private byte code = 5;
	
	//boolean to see whether we are dating carrot or dragon fruit
	private bool person;
	
	//the choice flag we'll use to check what box was clicked
	public int currChoice;
	
	//The data we'll grab for handling dialogue.
	public DateData tree;
	
	//self explanatory.
	public Text dialogueBox;
	public Text speaker;
	
	//All the dialogue boxes so we can set them to what we get from the dialogue tree.
	public GameObject choice_1;
	public Text choice_1Text;
	public GameObject choice_2;
	public Text choice_2Text;
	public GameObject choice_3;
	public Text choice_3Text;
	
	
	//Both Carrot and Dragon Fruit will be present for ease of development(for now)
	public GameObject carrot;
	public GameObject df;
	
    // Start is called before the first frame update
    void Start()
    {
		//random chance for date to be df or carrot
		int option = Random.Range(0, 100);
		if(option < 49){
			person = true;
		}else{
			person = false;
		}
		
		
		//Start of the scene
		choice_1.SetActive(false);
		choice_2.SetActive(false);
		choice_3.SetActive(false);
		carrot.SetActive(false);
		df.SetActive(false);
		
        speaker.text = "Anon-Kun(you)";
		dialogueBox.text = "Ahh, my date is already here!";
		choice_1Text.text = "";
		choice_2Text.text = "";
		choice_3Text.text = "";
		
		if(person){carrot.SetActive(true);}else{df.SetActive(true);}
		
		action = talkToGM(0);
		
		if(person){this.code = 1;} else{this.code = 2;}
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKeyDown(KeyCode.Space) | this.currChoice != 0){ 
			RunGame(this.action); 
		}
		
    }
	
	private TreeNode[] talkToGM(byte index)//our method for grabbing nodes
	{
		return this.tree.getNode(index);
	}
	
	//updates the dialogue and choice boxes after a 'space'
	private void RunGame(TreeNode[] action)
	{
		//clear all text and choice buttons, read dialogue and clear the actions.
		if(action[1] != null)
		{
			ClearChoices();
			TreeNode dialogue = ReadDialogue(action);
			UpdateDialogue(dialogue);
			this.action = new TreeNode[2];
			this.currChoice = 0;
		}else{
			//enable choices and select the appropriate treeNode
			if(this.action[0] != null)
			{
				if(this.action[0].GetFlag() == 3)
				{
					//print("Now we in the end-game!");
					EndGame(this.action);
				}
			}
			EnableChoices((byte)(this.prevChildren.Length), prevChildren);
		}
		
		
		
	}
	
	//once we've reached an end game state
	private void EndGame(TreeNode[] action)
	{
		ClearChoices();
		Application.Quit();
		UnityEditor.EditorApplication.isPlaying = false;
	}
	
	//Our on-click function
	public void CheckChoice(int choiceNum)
	{
		this.currChoice = choiceNum;
		this.code = 0;
		//print(currChoice);
		byte index = this.prevChildren[choiceNum - 1];
		this.action = talkToGM(index);
		this.prevChildren = this.action[0].GetChildren();
	}
	
	//clears the choice buttons
	private void ClearChoices()
	{
		choice_1.SetActive(false);
		choice_2.SetActive(false);
		choice_3.SetActive(false);
		
		choice_1Text.text = "";
		choice_2Text.text = "";
		choice_3Text.text = "";
		
		speaker.text = "";
		dialogueBox.text = "";
	}
	
	//reads the dialogue response to our choice
	private TreeNode ReadDialogue(TreeNode[] nodes)
	{
		TreeNode node1 = nodes[0];
		TreeNode node2 = nodes[1];
		
		if(node1.GetId() == 31)
		{
			if(isRich)
			{
				this.code = node2.GetFlag();
				return node2;
			}
			else{
				this.code = node1.GetFlag();
				return node1;
			}
		}
		if(person){
			this.code = node1.GetFlag();
			return node1;
		}else{
			this.code = node2.GetFlag();
			return node2;
		}
				
	}
	
	//updates the UI so the player can see the NPC's reaction.
	private void UpdateDialogue(TreeNode dialogue)
	{
		this.dialogueBox.text = dialogue.GetText();
		if(this.person && this.code != 0 && this.code != 3)
		{
			this.speaker.text = "Carrot";
		}else if(this.code != 0 && this.code != 3){
			this.speaker.text = "Dragon Fruit";
		}else if(this.code != 3){
			this.speaker.text = "Anon-Kun(you)";
		}else{
			this.speaker.text = "Narrator";
		}
		this.prevChildren = dialogue.GetChildren();
		
	}
	
	
	//re-enables choices for the player
	private void EnableChoices(byte numChoices, byte[] children)
	{
		//foreach(byte child in children){print(child);}
		
		if(numChoices > 0){ 
			this.choice_1.SetActive(true);
			//print(children[0]);
			this.action = talkToGM(children[0]);
			this.choice_1Text.text = action[0].GetText();
		}
		if(numChoices > 1){
			this.choice_2.SetActive(true);
			//print(children[1]);
			this.action = talkToGM(children[1]);
			this.choice_2Text.text = action[0].GetText();
		}
		if(numChoices > 2){
			this.choice_3.SetActive(true);
			//print(children[2]);
			this.action = talkToGM(children[2]);
			this.choice_3Text.text = action[0].GetText();
		}
		
	}
	
}

}
