using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour {
    //public float sensitivity = 50;
    //private float loudness = 0;
    //public int bitdepth = 256;
		public AudioSource audio;
    //public ParticleSystem particles;
    //public float threshold = 1.0f;
    void Start() {
        audio.loop = true; // Set the AudioClip to loop
        audio.clip = Microphone.Start(null, true, 1, 44100);
        audio.Play(); // Play the audio source!
    }

    void Update(){
        // loudness = GetAveragedVolume() * sensitivity;
        // if (loudness > threshold){
        //   particles.Emit(1);
        // }
    }

// float GetAveragedVolume()
//     {
//         float[] data = new float[bitdepth];
//         float a = 0;
//         audio.GetOutputData(data,0);
//         foreach(float s in data)
//         {
//             a += Mathf.Abs(s);
//         }
//         return a/bitdepth;
//     }
}
