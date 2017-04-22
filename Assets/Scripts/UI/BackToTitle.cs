using UnityEngine;
using UnityEngine.SceneManagement;


public class BackToTitle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SceneManager.LoadSceneAsync("1_Title");
	}
}
