using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchTime : MonoBehaviour
{
    public KeyCode witchTime;
    public AudioClip witchtime;
    private float intitialTime = 1f;
    private void Start()
    {
        intitialTime += Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(witchTime))
        {
            StartCoroutine(_WitchTime());
        }
    }
    IEnumerator _WitchTime() 
    {
        AudioSource src = AudioManager.instance.PlayAudio(witchtime, "witchtime");
        Time.timeScale *= 0.25f;
        while(src && src.isPlaying) 
        { 
            yield return null;
        }
        Time.timeScale = intitialTime;
    }
}
