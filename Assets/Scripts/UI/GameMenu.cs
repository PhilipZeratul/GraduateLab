using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject gameMenu;
    public string titleSceneName = "Title";

    private SceneController sceneController;
    private DataManager dataManager;
    private PlayerMovement playerMovment;


    private void Awake()
    {
        sceneController = FindObjectOfType<SceneController>();
        dataManager = FindObjectOfType<DataManager>();
        playerMovment = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {           
            // Pause or Resume game.
            if (Time.timeScale == 0)
                ResumeGame();
            else
                StartCoroutine(PauseGame());
        }
    }

    public void OnSaveButtonClick()
    {
        Debug.Log("Save Button Click");
        dataManager.ManualSaveGame();
    }

    public void OnLoadButtonClick()
    {
        Debug.Log("Load Button Click");
        dataManager.LoadGame();
    }

    public void OnBackToTitleButtonClick()
    {
        sceneController.FadeAndLoadScene(titleSceneName);
        ResumeGame();
    }

    private IEnumerator PauseGame()
    {
        playerMovment.Stop();
        yield return new WaitForEndOfFrame();
        Time.timeScale = 0;
        gameMenu.SetActive(true);
    }

    private void ResumeGame()
    {
        gameMenu.SetActive(false);
        Time.timeScale = 1;
    }
}