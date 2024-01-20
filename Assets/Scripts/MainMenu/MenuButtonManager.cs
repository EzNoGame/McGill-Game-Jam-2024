using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonManager : Singleton<MenuButtonManager>
{
    [SerializeField]
    private AudioClip _mainMenuBGM;

    private void Start()
    {
        SaveSystem.Instance.NewRun();
        AudioSystem.Instance.PlayBGM(_mainMenuBGM);
    }

    public void Begin()
    {
        //TODO: Start the game
        SceneManager.LoadScene("Main");
    }

    // public void Continue()
    // {
    //     SceneTransitionSystem.Instance.LoadSceneTransist("Map");
    // }
    public void Settings() => SceneManager.LoadScene("Settings", LoadSceneMode.Additive);
    public void Menu()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit() => Application.Quit();
}
