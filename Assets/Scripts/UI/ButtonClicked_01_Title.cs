using UnityEngine;


public class ButtonClicked_01_Title : MonoBehaviour
{
    private SceneController sceneController;


    private void Awake()
    {
        sceneController = FindObjectOfType<SceneController>();
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    public void SwitchScene(string sceneToLoad)
    {
        sceneController.FadeAndLoadScene(sceneToLoad);
    }
}
