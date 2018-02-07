using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicoSound : MonoBehaviour {
	public AudioClip[] sfx;
	void OnTriggerEnter (Collider other)
	{
		SoundManager.instance.PlayRandSfx (sfx);
	}
}
