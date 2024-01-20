using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonManager : Singleton<MenuButtonManager>
{
    public GameObject ButtonMenu;
    public GameObject ContinueButton;
    public GameObject ComfirmPopup;
    public GameObject CommanderSelectionMenu;

    public bool NotMainMenu;
    
    [SerializeField]
    private Transform MenuParent;

    [SerializeField]
    private AudioClip _mainMenuBGM;

    private void Start()
    {
        if(NotMainMenu)
            return;
        
        SaveSystem.Instance.NewRun();
            
        ButtonMenu.SetActive(true);

        AudioSystem.Instance.PlayBGM(_mainMenuBGM);
    }

    public void NewRun()
    {
        if(ContinueButton && ContinueButton.activeSelf)
            Instantiate(ComfirmPopup, MenuParent);
        else
            Instantiate(CommanderSelectionMenu, MenuParent);
    }

    // public void Continue()
    // {
    //     SceneTransitionSystem.Instance.LoadSceneTransist("Map");
    // }
    public void Option() => SceneManager.LoadScene("Option", LoadSceneMode.Additive);
    public void Menu()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit() => Application.Quit();
}
