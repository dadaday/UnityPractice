using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public bool IsPaused = true;

	public GameObject menu;
	public GameObject quitMenu;
	public GameObject helpMenu;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	void Update() {
		if (Input.GetKeyUp (KeyCode.Escape)) {
			Pause ();

			helpMenu.SetActive (false);

			if (quitMenu.activeSelf) {
				quitMenu.SetActive (false);
				menu.SetActive (true);
			}
		}
	}

	public void Exit() {
		Application.Quit ();
	}

	public void Play() {
		IsPaused = false;
		menu.SetActive(false);
	}

	public void Pause() {
		IsPaused = true;
		menu.SetActive(true);
	}

	public void HelpPress() {
		helpMenu.SetActive (!helpMenu.activeSelf);
	}

	public void ExitPress() {
		quitMenu.SetActive (true);
		menu.SetActive (false);
	}

	public void ChooseNo() {
		quitMenu.SetActive (false);
		menu.SetActive (true);
	}

	public void ChooseYes() {
		Application.Quit ();
	}

	public void LoadScene(string name) {
		SceneManager.LoadScene (name);
	}

}
