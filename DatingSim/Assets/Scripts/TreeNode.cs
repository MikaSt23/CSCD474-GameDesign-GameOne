using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tree{
	
public class TreeNode
{
// TreeNode obj to hold info for updating the DateUI
	private byte flag;
	private byte id;
	private byte[] children;
	private string text;
		
	public TreeNode()
	{
		this.flag = 0;
		this.id = 0;
		this.text = "";
		byte[] temp = {0};
		this.children = temp;
	}
	
	public TreeNode(byte id, string text, byte[] children, byte flag)
	{
		this.flag = flag;
		this.id = id;
		this.text = text;
		this.children = new byte[children.Length] ;
		for(int i = 0; i < this.children.Length ; i++)
		{
			this.children[i] = children[i];
		}
	}
		
		
	public byte GetId()
	{
		return this.id;
	}
	
	public byte[] GetChildren()
	{
		return this.children;
	}
	
	public string GetText()
	{
		return this.text;
	}
		
	public byte GetFlag()
	{
		return this.flag;
	}	
	
}

}
