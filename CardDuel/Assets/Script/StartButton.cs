using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public AudioSource audioSource;
    public void ClickStartButton()
    {
        audioSource.Play();
        SceneManager.LoadScene("CardGameScene");
    }

}
