/*
 * Copyright (c) 2015 Allan Pichardo
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *  http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using UnityEngine;
using System;

public class RythmSpawnPoint : MonoBehaviour
{
public AudioProcessor processor;
public ParticleSystem particleSystem;
public float threshold = 1.0f;
	void Start ()
	{
		//Select the instance of AudioProcessor and pass a reference
		//to this object
		processor.onBeat.AddListener (onOnbeatDetected);
	}

	//this event will be called every time a beat is detected.
	//Change the threshold parameter in the inspector
	//to adjust the sensitivity
	void onOnbeatDetected ()
	{
		Debug.Log ("Beat!!!");
		if(processor.loudness > threshold){
		particleSystem.Emit(3);
		Debug.Log("Loud Enough!");
		}
	}
}
