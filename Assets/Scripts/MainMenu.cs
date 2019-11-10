using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	public bool isStart;
	public bool isCredit;
	public bool isQuit;
	
	void OnMouseUp()
	{
		if(isStart)
		{
			GetComponent<Renderer>().material.color=Color.cyan;
			Application.LoadLevel(1);
		}
		if(isCredit)
		{
			Application.LoadLevel(2);
		}
		if(isQuit)
		{
			Application.Quit();
		}
	}
}
