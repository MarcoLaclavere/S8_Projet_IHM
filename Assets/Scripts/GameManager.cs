
using System.Collections; using UnityEngine;
public class GameManager : MonoBehaviour
{
   //public PlayerControls playerControls;
   public CarAI[] aiControls;
   public CarControllerTD1 playerControls;
   //public LapManager lapTracker;
   public TricolorLights tricolorLights;

    public AudioClip sound1; 
    public AudioClip sound2; 
    public AudioSource audioSource;
    public AudioSource audioSource2;

    public AudioClip loopSound; // Le clip audio à jouer en boucle
    public AudioSource loopAudioSource;
   void Awake()
   {
       StartGame();
   }
   public void StartGame()
   {
       FreezePlayers(true);
       StartCoroutine("Countdown");
   }
   IEnumerator Countdown()
   {
       yield return new WaitForSeconds(1);
       Debug.Log("3");
       audioSource.PlayOneShot(sound1);
       tricolorLights.SetProgress(1);
       yield return new WaitForSeconds(1);
       audioSource.PlayOneShot(sound1);
       Debug.Log("2");
       tricolorLights.SetProgress(2);
       yield return new WaitForSeconds(1);
       Debug.Log("1");
       audioSource.PlayOneShot(sound1);
       tricolorLights.SetProgress(3);
       yield return new WaitForSeconds(1);
       
       Debug.Log("GO");
       tricolorLights.SetProgress(4);
         audioSource2.PlayOneShot(sound2);
       StartRacing();
       yield return new WaitForSeconds(2f);
       tricolorLights.SetAllLightsOff();

        loopAudioSource.clip = loopSound; // Définir le clip audio pour la boucle
        loopAudioSource.Play();

   }
   public void StartRacing()
   {
       FreezePlayers(false);
   }
   void FreezePlayers(bool freeze)
   {
        if(freeze) playerControls.Freeze();
        else playerControls.UnfreezePlayer();

        foreach (var ai in aiControls)
        {
            if (freeze){
                ai.Freeze();
            } 
            else ai.UnfreezePlayer();
        }
   }
}