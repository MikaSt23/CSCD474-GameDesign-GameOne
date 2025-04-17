using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tree;

namespace DataTree{
public class DateData : MonoBehaviour
{
	
	//Dialogue tree for the whole date
	TreeNode[,] dialogueTree = new TreeNode[42, 2];
    // Start is called before the first frame update
    void Start()
    {
        buildTree();
    }
	
	
	private void buildTree()
	{
		//Start of date 1
		byte[] childrenTracker = {1, 2, 3};
		this.dialogueTree[0, 0] = new TreeNode(0, "Yo dude, nice to meet you! You said your name was Anon-Kun? \n You probably already know me, I'm Alpha Carrotene whats your job brah?", childrenTracker, 1);
		this.dialogueTree[0, 1] = new TreeNode(0, "Hi, you're Anon-Kun I assume, I'm Diyonce you looked better on your photo if I'm being honest. \n What do you do for a living?", childrenTracker, 2);
		
		//Branch lvl-1
		this.dialogueTree[1, 0] = new TreeNode(1, "Well, I'm a farmer! How about you?", (new byte[] {12}), 0);
		this.dialogueTree[2, 0] = new TreeNode(2, "I am a hard earned entrepreneur, what do you do?", (new byte[] {4}), 0);
		this.dialogueTree[3, 0] = new TreeNode(3, "Stare at them", (new byte[] {5}), 0);
		
		//Response lvl-2
		childrenTracker = new byte[] {6, 7, 8};
		this.dialogueTree[4, 0] = new TreeNode(4, ("I am a gym teacher for a elementary school.\n Entrepre..manure huh? Thats too big of a word for me to understand brah... \n but it sounds like a lot of money! What do are you gunna do in your future?"), 
												(childrenTracker), 1);
		this.dialogueTree[4, 1] = new TreeNode(4, ("Hm! that's not too impressive I've dated men who are multi millionaires. \nBut I suppose its not that bad. \nAs for me I am a model you might have seen me around. What are your like future plans or something?"), 
												(childrenTracker), 2);
		childrenTracker = new byte[] {9, 10, 11};
		this.dialogueTree[5, 0] = new TreeNode(5, "Woah Cutey, my eyes are up here! \n But if you must stare...\n  take a picture it'll last longer brah!", childrenTracker, 1);
		this.dialogueTree[5, 1] = new TreeNode(5, "(￣ヘ￣) Bruh.mp3.\n Well, at least someone knows how to appreciate my beauty.\n Feel free to take a photo.", childrenTracker, 2);
		
		//Branch lvl-2
		this.dialogueTree[6, 0] = new TreeNode(6, "", (new byte[] {}), 0);
		this.dialogueTree[7, 0] = new TreeNode(7, "", new byte[] {}, 0);
		this.dialogueTree[8, 0] = new TreeNode(8, "", new byte[] {}, 0);
		this.dialogueTree[9, 0] = new TreeNode(9, "", new byte[] {}, 0);
		this.dialogueTree[10, 0] = new TreeNode(10, "", new byte[] {}, 0);
		this.dialogueTree[11, 0] = new TreeNode(11, "", new byte[] {}, 0);
		
		//Response lvl-3
		this.dialogueTree[12, 0] = new TreeNode(12, "yeet!", (new byte[] {18, 19, 20}), 1);
		this.dialogueTree[12, 1] = new TreeNode(12, "Ick", (new byte[] {18, 19, 20}), 2);
	}
	
	
	//return the list of 
	public TreeNode[] getNode(byte index)
	{
		TreeNode[] dialogue = new TreeNode[2];
		for(byte i = 0; i < dialogue.Length; i++)
		{
			dialogue[i] = this.dialogueTree[index, i];
		}
		
		return dialogue;
	}
}

}
