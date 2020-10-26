using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ControlMixer : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        AudioMixer mixer = Resources.Load("MasterMixer") as AudioMixer;
        GetComponent<AudioSource>().outputAudioMixerGroup = mixer.FindMatchingGroups("Master")[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
