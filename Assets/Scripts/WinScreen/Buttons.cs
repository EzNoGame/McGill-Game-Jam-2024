using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    public void mainMenu() {
        Debug.Log("menu");
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void restart() {
        Debug.Log("restart");
        SceneManager.LoadSceneAsync("MainLevel");
    }
}
