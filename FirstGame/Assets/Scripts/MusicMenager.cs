using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            if (FindObjectOfType<AudioListener>() == null)
            {
                gameObject.AddComponent<AudioListener>();
                Debug.Log("AudioListener zosta� dodany do MusicManager.");
            }
            audioSource.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void OnLevelWasLoaded(int level)
    {
        // Sprawd� obecno�� innych AudioListener i usu� nadmiarowe
        AudioListener[] listeners = FindObjectsOfType<AudioListener>();
        for (int i = 1; i < listeners.Length; i++)
        {
            Destroy(listeners[i]);
            Debug.Log("Zduplikowany AudioListener zosta� usuni�ty.");
        }
    }
}