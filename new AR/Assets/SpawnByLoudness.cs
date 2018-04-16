// using UnityEngine;
// using System.Collections;
//
// public class SpawnByLoudness : MonoBehaviour {
//
//     public float threshold = 1.0f;
//     public ParticleSystem particles;
//     public MicrophoneInput micIn;
//
//     void Start() {}
//
//     void Update () {
//         float l = micIn.loudness;
//         if (l > threshold)
//         {
//             particles.Emit(1);
//         }
//    }
// }
