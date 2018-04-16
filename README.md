# ARCore-MusicAR-Particle-Visualization
MusicAR is a real-time audio visualization experiment using ARCore built with Unity
Using the microphone as input, a beat detection algorithm decides when particles are to be emitted from a speaker prefab.


# Issues Addressed
Unity's Microphone support does not allow for real-time audio processing, and so the "Beat Detection" algorithm has been adapted to record an average bpm for a given interval, essentially making it a beat "predection" algorithm.</br></br>
In order to reduce the amount of noise from low-volume/non-musical audio input, a volume threshold was added to the beat detection, which prevents particles from being emitted, unless the input at the detected beat is loud enough.</br></br>
In order for the virtual objects to cast a shadow, a plane with a custom transparent shader was placed. This shader renders only received shadows and occludes anything behind it, which occludes the "tracked plane visualization", but also occludes any particles that should clip through that plane or spawn beneath it.</br></br>
In order to allow multiple speaker prefabs to be placed and allow for particles to be emitted at the same time, a global audio processor prefab is instantiated on startup, and holds the beat detection script which triggers onBeat events for the speaker prefabs to respond to.

