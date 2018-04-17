# MusicAR: Particle Visualization
MusicAR is a real-time audio visualization experiment using ARCore built with Unity.</br>
Using the microphone as input, a beat detection algorithm decides when particles are to be emitted from a speaker prefab.

# Installation
The app should work on any ARCore supported device. To see if your device is supported, please check out the following link: https://developers.google.com/ar/discover/#supported_devices.
Before you can install it on your phone you will need to make sure that third-party apps are allowed on your device. Go to Menu > Settings > Security > and check Unknown Sources to allow your phone to install apps from sources other than the Google Play Store.
Once that is done, download the MusicAR.apk to your device and install.
The app requires microphone functionality, and therefore needs permission to acces your devices microphone. This should be enabled upon installation, but during testing there was an issue with it not being enabled and so, in order to enable this, go to Menu > Settings > Apps > MusicAR and navigate to permissions, and make sure that microphone is enabled.

# Issues Addressed
Unity's Microphone support does not allow for real-time audio processing, and so the "Beat Detection" algorithm has been adapted to record an average bpm for a given interval, essentially making it a beat "predection" algorithm.</br></br>
In order to reduce the amount of noise from low-volume/non-musical audio input, a volume threshold was added to the beat detection, which prevents particles from being emitted, unless the input at the detected beat is loud enough.</br></br>
In order for the virtual objects to cast a shadow, a plane with a custom transparent shader was placed. This shader renders only received shadows and occludes anything behind it, which occludes the "tracked plane visualization", but also occludes any particles that should clip through that plane or spawn beneath it.</br></br>
In order to allow multiple speaker prefabs to be placed and allow for particles to be emitted at the same time, a global audio processor prefab is instantiated on startup, and holds the beat detection script which triggers onBeat events for the speaker prefabs to respond to.</br></br>
Custom shaders were written for every material to maintain performance on mobile, while maintaining aesthetic quality, although the shadow receiver may be reworked in order to reduce the pixely look of its shadows by blurring its output. 
