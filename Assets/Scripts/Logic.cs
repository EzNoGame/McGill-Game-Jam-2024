using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{

    // Update is called once per frame
    public void win() {
        Debug.Log("load win");
        SceneManager.LoadSceneAsync("WinScreen");
    }

    public void lose() {
        Debug.Log("load lose");
        SceneManager.LoadSceneAsync("LoseScreen");
    }



}
