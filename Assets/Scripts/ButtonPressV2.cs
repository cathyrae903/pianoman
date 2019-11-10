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
	
	public Rigidbody rb;


	public bool pressed = false;
    protected Vector3 startPosition;

    void Start()
    {
        // Remember start position of button
        startPosition = transform.localPosition;
		
		key = GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody>();
		
    }

    void Update()
    {
        // Use local position instead of global, so button can be rotated in any direction
        Vector3 localPos = transform.localPosition;
		Debug.Log(localPos);
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
		
		if ((startPosition.z - localPos.z) >= activationDistance && !pressed) {
			//localPos.y = startPosition.y - activationDistance;
			rb.velocity = new Vector3(0, 0, 0);
			transform.localPosition = new Vector3(startPosition.x, startPosition.y, startPosition.z);
			if (!key.isPlaying) {
				key.Play();
			}
		} else if (localPos.z > startPosition.z) {
			//localPos.z = startPosition.z;
			rb.velocity = new Vector3(0, 0, 0);
			transform.localPosition = new Vector3(startPosition.x, startPosition.y, startPosition.z);	
			
		} else if (pressed) {
			if (localPos.z >= startPosition.z) {
				pressed = false;
			} else {
				Debug.Log("RISE");
				transform.localPosition = transform.localPosition + new Vector3(0, .05f * (Time.deltaTime), 0);
			}
			
		}
    }
}