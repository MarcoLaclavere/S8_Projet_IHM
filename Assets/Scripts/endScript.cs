using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class endScript : MonoBehaviour
{

    public VideoClip[] videoClips;
    public VideoPlayer videoPlayer;
    private int currentClipIndex = 0;

    void Start()
    {
        
    }

    // Fonction pour lire une vidéo spécifique en fonction de la valeur donnée
    public void PlayVideo()
    {
        if(GlobalCustomization.getMoney()>0){
            Debug.Log("i");
            videoPlayer.clip = videoClips[0];
            videoPlayer.Play();
        }
        else if(GlobalCustomization.getMoney()<0){
            Debug.Log("ii");
            videoPlayer.clip= videoClips[1];
            videoPlayer.Play();
        }
        else{
            Debug.Log("iii");
            videoPlayer.clip= videoClips[2];
            videoPlayer.Play();

        }

    }
}
