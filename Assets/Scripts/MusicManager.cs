using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private List<AudioSource> music;

    [SerializeField]
    private int timeToPhase;
    #endregion

    #region Private Variables
    private AudioSource currentlyPlaying;
    #endregion

    private static GameObject musicManager;

    private void Awake()
    {
        if (musicManager == null)
        {
            musicManager = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        music[0].Play();
        currentlyPlaying = music[0];
    }
}
