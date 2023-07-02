using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    public AudioClip audioSuccess;

    public AudioClip audioFail;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            AudioSource audioSource = GetComponent<AudioSource>();

            audioSource.PlayOneShot(audioSuccess);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            AudioSource audioSource = GetComponent<AudioSource>();

            audioSource.PlayOneShot(audioFail);
        }

    }
}
