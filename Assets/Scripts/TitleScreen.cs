using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {
    public GameObject menu;

    public GameObject mainMenu;
    public GameObject creditsMenu;

    void Awake() {
        StartCoroutine(Wait());
    }

    public void OnPressStart() {
        SceneManager.LoadScene(1);
    }

    public void OnPressCredits() {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void OnPressExitCredits() {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OnPressQuit() {
        Application.Quit();
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(5);
        menu.SetActive(true);
    }
}