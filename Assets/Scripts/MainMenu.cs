using UnityEngine;
using System.Collections;
using System.Collections.Generic;


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
			Application.LoadLevel("mainScene");
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
