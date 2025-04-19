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
	string[] endings = new string[7];
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
		this.dialogueTree[6, 0] = new TreeNode(6, "I want to be a farmer! Have a bunch of cute animals, maybe named Bob and Jared. What are you interested in?", (new byte[] {12}), 0);
		this.dialogueTree[7, 0] = new TreeNode(7, "Become a multi millionaire and rule the world. I guess I could take some time to know what you want in the future.", new byte[] {13}, 0);
		this.dialogueTree[8, 0] = new TreeNode(8, "Start a family, what are you interested in?", new byte[] {14}, 0);
		this.dialogueTree[9, 0] = new TreeNode(9, "Sorry, you're just so beautiful!", new byte[] {15}, 0);
		this.dialogueTree[10, 0] = new TreeNode(10, "Oh, right, sorry, spaced out there for a second, lol.", new byte[] {16}, 0);
		this.dialogueTree[11, 0] = new TreeNode(11, "*Stares and takes photo* Yes Brah...", new byte[] {17}, 0);
		
		//Response lvl-3
		childrenTracker = new byte[] {18, 19, 20};
		this.dialogueTree[12, 0] = new TreeNode(12, "Wow a farmer bro? Thats a very girlie pop mindset as the youngins say. \nMe brah? I'd love to start my own family, being with kids everyday really prepared me to be a dad. \nWhat food groups are you interested in brah? I love me my vitamin D, ya know brah!", 
									childrenTracker, 1);
		this.dialogueTree[12, 1] = new TreeNode(12, "Oh that's a career I guess... Never dated a farmer before. What kind food do you like I guess?", childrenTracker, 2);
		this.dialogueTree[13, 0] = new TreeNode(13, "Oh, ambious brah very cool. I wanna get rich too gotta provide for mah fam. Am I right brah! So uhh... what do you like to eat?", childrenTracker, 1);
		this.dialogueTree[13, 1] = new TreeNode(13, "DF: Pft, that sounds kinda stupid, are you some kind of kid still? \nAnd who are you to talk to me like that jeez, I just want enough money to buy all my designer bags. \nAnyway what kind of trash food taste do you have?", 
									childrenTracker, 2);
		this.dialogueTree[14, 0] = new TreeNode(14, "YOOOOO, BROOO, SAAAAMMMMMMMEEE!! Ever since I've been teaching up these kids I really wanted a family of my own!", childrenTracker, 1);
		this.dialogueTree[14, 1] = new TreeNode(14, "A family? Ugh, ew, don't you think it's a little bit early to be thinking about that? \nAnyways, let's bring the conversaiton back to food before I loose my appetite, \nso what do you like to eat anyways I guess?", 
									childrenTracker, 2);
		
		//part 2
		childrenTracker = new byte[] {21, 22, 23};
		this.dialogueTree[15, 0] = new TreeNode(15, "Ahh, you're sweet, thanks brah! So, what're going to order?", childrenTracker, 1);
		this.dialogueTree[15, 1] = new TreeNode(15, "Geeze, I knew I was hot, but, like I didn't expect to take your breath away. \nAhagh ahagh hagghhh. \nAnyways, what're you ordering?", childrenTracker, 2);
		this.dialogueTree[16, 0] = new TreeNode(16, "All good brah! So, whatcha eating?", childrenTracker, 1);
		this.dialogueTree[16, 1] = new TreeNode(16, "Well I can't blame you, I am quite breath taking. So anyways, what're ordering for me tonight?", childrenTracker, 2);
		this.dialogueTree[17, 0] = new TreeNode(17, "( ͡° ͜ʖ ͡°) ", childrenTracker, 1);
		this.dialogueTree[17, 1] = new TreeNode(17, "Wait what!? You know I was joking you creep!! \nUgh, I'm out of here!", (new byte[] {24}), 2);
		
		//Branch lvl-3
		this.dialogueTree[18, 0] = new TreeNode(18, "Pescatarian", (new byte[] {25}), 0);
		this.dialogueTree[19, 0] = new TreeNode(19, "Oh you know, I love me a good steak.", (new byte[] {26}), 0);
		this.dialogueTree[20, 0] = new TreeNode(20, "Vegatarian!", (new byte[] {27}), 0);
		this.dialogueTree[21, 0] = new TreeNode(21, "You", (new byte[] {28}), 0);
		this.dialogueTree[22, 0] = new TreeNode(22, "Steak", (new byte[] {29}), 0);
		this.dialogueTree[23, 0] = new TreeNode(23, "Fish!", (new byte[] {30}), 0);
		
		//
		//Unique ending
			//choice-button
		this.dialogueTree[24, 0] = new TreeNode(24, "Wait, no. \nCome Back! ", ( new byte[] {31} ), 0);
			//dialogue box choices
		this.dialogueTree[31, 0] = new TreeNode(31, "But before you can say anythin more, \nthey're gone!", ( new byte[] {41} ), 3);
		this.dialogueTree[31, 1] = new TreeNode(31, "You tip the waiter $100, then, /n they suddenly start walking back!", (new byte[] {38}), 3);
		//
		
		//Response lvl-4
		this.dialogueTree[25, 0] = new TreeNode(25, "Ohh, yeah I think I've heard of that one, that's the one where you eat like a ton of fish right??", (new byte[] {32}), 1);
		this.dialogueTree[25, 1] = new TreeNode(25, "Ohh, yeah I think I've heard of that one, that's the one where you eat like a ton of fish right??", (new byte[] {32}), 2);
		this.dialogueTree[26, 0] = new TreeNode(26, "Well that can't be healthy, right?", (new byte[] {33, 34}), 1);
		this.dialogueTree[26, 1] = new TreeNode(26, "Well that can't be healthy, right?", (new byte[] {33, 34}), 2);
		this.dialogueTree[27, 0] = new TreeNode(27, "Uhhh, wut!!?", (new byte[] {33, 34, 35}), 1);
		this.dialogueTree[27, 1] = new TreeNode(27, "Uhhh, wut!!?", (new byte[] {33, 34, 35}), 2);
		
		//part 2
		this.dialogueTree[28, 0] = new TreeNode(28, "I'm leaving", (new byte[] {24}), 1);
		this.dialogueTree[28, 1] = new TreeNode(28, "I'm leaving", (new byte[] {24}), 2);
		this.dialogueTree[29, 0] = new TreeNode(29, "MY MAN!!", (new byte[] {39}), 1);
		this.dialogueTree[29, 1] = new TreeNode(29, "Steak huh, I guess I could take an order of that", (new byte[] {39}), 2);
		this.dialogueTree[30, 0] = new TreeNode(30, "Huh, well if you say so.", (new byte[] {40}), 1);
		this.dialogueTree[30, 1] = new TreeNode(30, "No.", (new byte[] {40}), 2);
		
		//Branch lvl-4
		this.dialogueTree[32, 0] = new TreeNode(32, "Well yes, among other things", ( new byte[] {36}), 0);
		this.dialogueTree[33, 0] = new TreeNode(33, "Uhh, I'm a cat! So no.", ( new byte[] {37}), 0);
		this.dialogueTree[34, 0] = new TreeNode(34, "Don't worry about it ;)", ( new byte[] {38}), 0);
		this.dialogueTree[35, 0] = new TreeNode(35, "You heard me!", ( new byte[] {39}), 0);
		
		//Final branches
		this.dialogueTree[36, 0] = new TreeNode(36, "You know, you honestly felt like that was a pretty great date, you'll likely see them again!", new byte[]{}, 3);
		this.dialogueTree[37, 0] = new TreeNode(37, "Man that  was great, you were of course, after all, they're ok to look at I guess.", new byte[]{}, 3);
		this.dialogueTree[38, 0] = new TreeNode(38, "Oh, thank goodness, you didn't scare the away!", new byte[]{}, 3);
		this.dialogueTree[39, 0] = new TreeNode(39, "Maybe they're not the right one for you.", new byte[]{}, 3);
		this.dialogueTree[40, 0] = new TreeNode(40, "Geeze, looks like they need an attitude adjustment!", new byte[]{}, 3);
		this.dialogueTree[41, 0] = new TreeNode(41, "Not again!", new byte[]{}, 3);

	}
	
	private void BuildEndings()
	{
		
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
