using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public List<AudioSource> musicList;
    private AudioSource currentlyPlaying;
    private AudioSource previousMusic;
    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < this.GetComponents<AudioSource>().Length; i++)
            musicList[i] = this.GetComponents<AudioSource>()[i];
        //Select a random int between 0(inclusive) and music list size(exclusive)
        //start playing that
        currentIndex = (int)Random.Range(0, musicList.Count);
        currentlyPlaying = musicList[currentIndex];

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentIndex);

        //if the currentlyPlaying audiosource is null, then it means it is not selected. 
        //so randomly select another music.
        if (currentlyPlaying == null)
        {
            Debug.Log("inside currecntly not play");

            currentIndex = (int)Random.Range(0, musicList.Count - 1);
            //if the newly selected music is equal to the previous music, then try to select another music 
            //by trying to excluding the newly selected index from the subset of the indexes.
            if(previousMusic == musicList[currentIndex])
            {
                //If there is only 1 existing music retrieved by the list,
                if(musicList.Count < 1)
                {

                }
                currentIndex = (int)(Random.Range(0, 2) > 1 ? 
                    Random.Range(0, musicList.Count) :
                    Random.Range(currentIndex, musicList.Count));


            } 

            currentlyPlaying = musicList[currentIndex];

            
        }
        else
        {
            Debug.Log("currently play");
            //else it means there is a selected music. 
            //check if it is playing or not.

            //if it is not playing then, play it
            if (!currentlyPlaying.isPlaying)
            {

                previousMusic = currentlyPlaying;
                int currentIndex = (int)Random.Range(0, musicList.Count);

                musicList[currentIndex].Play();
                //ambientMusicList[currentIndex].PlayOneShot(ambientMusicList[currentIndex].clip);

                currentlyPlaying = musicList[currentIndex];
            } else
            {
                //the current song is finished so set the current to null
                currentlyPlaying = null;
            }

        }

    }
}
