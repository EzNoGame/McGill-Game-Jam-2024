using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{

    // Update is called once per frame
    public void win() {
        SceneManager.LoadSceneAsync("WinScreen");
    }

    public void die() {
        SceneManager.LoadSceneAsync("DeathCutscene");
    }

    public void lose() {
        SceneManager.LoadSceneAsync("LoseScreen");
    }



}
