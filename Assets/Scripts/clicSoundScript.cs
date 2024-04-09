using UnityEngine;
using UnityEngine.UI;
public class clicSoundScript : MonoBehaviour
{

    public AudioClip clickSound;

    public AudioSource audioSource;
    // Start is called before the first frame update

    void Start()
    {
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            
            audioSource.clip = clickSound;
            audioSource.playOnAwake = false;

            button.onClick.AddListener(() => audioSource.PlayOneShot(clickSound));
        }
    }
}
