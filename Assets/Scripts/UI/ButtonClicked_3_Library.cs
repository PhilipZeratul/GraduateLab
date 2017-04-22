using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonClicked_3_Library : MonoBehaviour {

	public void OnBackButtonClicked()
	{
		SceneManager.LoadSceneAsync("1_Title");
	}
}
