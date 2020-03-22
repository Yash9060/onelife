using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        Debug.Log("Btoon clicked ");

        SceneManager.LoadScene("current");
        //Application.LoadLevel("Gameplay");
    }

    AudioSource audioSource;
    public GameObject cross;


    [SerializeField]
    private GameObject instructionsPanel;

    [SerializeField]
    private GameObject testing;

    private GameObject MenuPanel;




    void Start()
    {
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        MenuPanel = GameObject.Find("Menu");

        //cross = GameObject.Find("Cross");
        //cross.SetActive(false);
        //instructionsPanel.SetActive(false);

    }

    public void ChangeSound()
    {
        Debug.Log("sound button clicked ");

        audioSource.mute = !audioSource.mute;
        if (cross.activeSelf)
            cross.SetActive(false);
        else
            cross.SetActive(true);
        //Application.LoadLevel("Gameplay");
    }

    public void showInstructions()
    {
        Debug.Log("inst button clicked ");
        //testing.SetActive(true);
        instructionsPanel.SetActive(true);
        MenuPanel.SetActive(false);
        



        //Application.LoadLevel("Gameplay");
    }

    public void backToMenu()
    {
        Debug.Log("menu button clicked ");
        instructionsPanel.SetActive(false);

        MenuPanel.SetActive(true);

        //Application.LoadLevel("Gameplay");
    }


}
