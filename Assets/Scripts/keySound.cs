using UnityEngine;
using System.Collections;

public class KeySound : MonoBehavior
{
  public AudioSource key;

  void Start() { key = GetComponent<AudioSource>;  }

  void Update() {}

  void OnCollisionEnter (Collision collision)
  {
    if (collision.gameObject.tag == "Target")
      key.Play();
  }
}
