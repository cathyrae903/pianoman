// https://medium.com/@felixnoller/getting-started-with-simple-3d-buttons-using-unity-and-leap-motion-40d9efded317
using UnityEngine;
using System.Collections;
using System;

public class ButtonPressV2 : MonoBehaviour
{

	public AudioSource key;
	
    public bool lockX;
    public bool lockY;
    public bool lockZ;

    public float activationDistance;



    protected Vector3 startPosition;

    void Start()
    {
        // Remember start position of button
        startPosition = transform.localPosition;
		
		key = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Use local position instead of global, so button can be rotated in any direction
        Vector3 localPos = transform.localPosition;
        if (lockX) {
			localPos.x = startPosition.x;
		}
        if (lockY) {
			localPos.y = startPosition.y;
		}
        if (lockZ) {
			localPos.z = startPosition.z;
		}
		Debug.Log(localPos.y);
		Debug.Log(startPosition.y);
		Debug.Log("---------------------------");
		
		if (Math.Abs(localPos.y - startPosition.y) >= activationDistance) {
			localPos.y = startPosition.y - activationDistance;
			transform.localPosition = new Vector3(startPosition.x, startPosition.y, startPosition.z);
			if (!key.isPlaying) {
				key.Play();
			}
		} else if (localPos.z > startPosition.z) {
			localPos.z = startPosition.z;
			transform.localPosition = new Vector3(startPosition.x, startPosition.y, startPosition.z);	
		}   
    }
}