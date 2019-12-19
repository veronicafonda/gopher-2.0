using UnityEngine;
using UnityEngine.SceneManagement;


public class sharedpref : MonoBehaviour
{
    public void text_slow()
    {
        PlayerPrefs.SetFloat("txt",0.065f);
    }

    public void text_norm()
    {
        PlayerPrefs.SetFloat("txt", 0.04f);
    }

    public void text_fast()
    {
        PlayerPrefs.SetFloat("txt", 0.005f);
    }

    public void sound_on()
    {
        PlayerPrefs.SetInt("sfx", 1);
        FindObjectOfType<AudioManager>().Unmuteall();
    }

    public void sound_off()
    {
        PlayerPrefs.SetInt("sfx", 0);
        FindObjectOfType<AudioManager>().Muteall();
    }

    public void to_menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
