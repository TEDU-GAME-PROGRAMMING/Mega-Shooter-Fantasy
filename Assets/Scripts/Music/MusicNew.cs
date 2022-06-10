using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNew : MonoBehaviour
{
    public List<AudioSource> musicList;
    public List<AudioSource> damageEffects;

    private AudioSource currentlyPlaying;
    private AudioSource currentlyDamage;

    private AudioSource previousMusic;
    private int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentlyPlaying == null)
        {
            Debug.Log("currentlyPlaying " + currentIndex);
            if (currentIndex < musicList.Count)
            {
                musicList[currentIndex].Play();

            }
            else
            {
                currentIndex = 0;
                musicList[currentIndex].Play();

            }

            currentlyPlaying = musicList[currentIndex];

            currentIndex++;


        }
        else
        {
            //check if it is playing or not.
            //if it is not playing then, play it
            if (!currentlyPlaying.isPlaying)
            {
                Debug.Log("nowPlayingz " + currentIndex);

                if (currentIndex < musicList.Count)
                {
                    musicList[currentIndex].Play();

                }
                else
                {
                    currentIndex = 0;
                    musicList[currentIndex].Play();

                }

                //ambientMusicList[currentIndex].PlayOneShot(ambientMusicList[currentIndex].clip);
                currentlyPlaying = musicList[currentIndex];
                currentIndex++;

            }
            /*            else
                        {
                            //the current song is finished so set the current to null
                            currentlyPlaying = null;
                        }*/

        }
    }
}
