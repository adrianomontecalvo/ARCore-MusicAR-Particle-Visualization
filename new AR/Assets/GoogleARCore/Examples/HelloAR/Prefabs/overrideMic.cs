using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overrideMic : MonoBehaviour {
	public AudioSource aud;

	void Start() {
			aud.clip = UnityEngine.Microphone.Start(null, true, 1, 44100);
			aud.loop = true;
			while (!(Microphone.GetPosition(null) > 0)) {}
			aud.Play();
			aud.mute = false;
	 }
}
