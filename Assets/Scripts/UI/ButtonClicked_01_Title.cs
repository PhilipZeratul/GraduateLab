using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonClicked_01_Title : MonoBehaviour {

	public void OnStartButtonClicked()
	{
		SceneManager.LoadSceneAsync("3_Library");
	}

    public void OnThanksButtonClicked()
    {
        SceneManager.LoadSceneAsync("2_Thanks");
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
