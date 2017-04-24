using UnityEngine;


public class ButtonClicked_3_Library : MonoBehaviour
{
    private SceneController sceneController;


    private void Awake()
    {
        sceneController = FindObjectOfType<SceneController>();
    }

	public void SwitchScene(string sceneToLoad)
	{
        sceneController.FadeAndLoadScene(sceneToLoad);
	}
}
