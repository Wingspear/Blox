using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject userBlox;
    public GameObject uiMenu;
    public GameObject resetGameUI;
    public GameObject score;
    public GameObject scoreResult;
    public Spawn spawner;
    public GameObject audioPlayer;

    private bool restartGame;

    // Start is called before the first frame update
    void Start()
    {
        restartGame = false;   
    }

    public void StartGame()
    {
        if (!restartGame)
        {
            uiMenu.SetActive(false);
        }
        else
        {
            resetGameUI.SetActive(false);
        }
        score.SetActive(true);
        spawner.StartSpawning();
        audioPlayer.GetComponents<AudioSource>()[0].Play();
    }

    public void EndGame()
    {
        Camera.main.transform.SetParent(null);
        Camera.main.transform.position = Vector3.zero;
        userBlox.SetActive(false);
        spawner.StopSpawning();
        audioPlayer.GetComponents<AudioSource>()[0].Stop();
        audioPlayer.GetComponents<AudioSource>()[1].Play();

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Blox"))
        {
            Destroy(g);
        }
        resetGameUI.SetActive(true);
        scoreResult.GetComponent<Text>().text = "Score: " + ((int)spawner.totalTimePassed).ToString();
        spawner.totalTimePassed = 0; //resetting time
        restartGame = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
