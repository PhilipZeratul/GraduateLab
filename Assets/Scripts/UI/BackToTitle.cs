using UnityEngine;


public class BackToTitle : MonoBehaviour
{
    public string sceneToReturn = "Title";

    private SceneController sceneController;


    private void Awake()
    {
        sceneController = FindObjectOfType<SceneController>();
    }

	private void Start ()
    {
        sceneController.FadeAndLoadScene(sceneToReturn);	
	}
}
