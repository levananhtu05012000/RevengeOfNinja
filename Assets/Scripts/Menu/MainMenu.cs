using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        AudioManager.Play(AudioClipName.Button);
        AudioManager.Play(AudioClipName.Music);
        //SceneManager.LoadScene("ChooseLevel");        
        SceneManager.LoadScene("PlayScene");
        //AudioManager.Play(AudioClipName.Button);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        AudioManager.Play(AudioClipName.Button);
        Application.Quit();
    }
    public void Options()
    {
        AudioManager.Play(AudioClipName.Button);
    }
    public void Up()
    {
        AudioManager.Play(AudioClipName.Up);
    }
    public void Down()
    {
        AudioManager.Play(AudioClipName.Down);
    }
    public void PrimaryMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void SelectScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
