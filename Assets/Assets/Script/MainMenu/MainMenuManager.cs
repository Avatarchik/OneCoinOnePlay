using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour {

    void Start()
    {
        GPG_Controller.InitGPG();
        GPG_Controller.LoginGPG();
    }
	public void GameStart()
    {
        SceneManager.LoadSceneAsync("InGame");
    }

    public void OnClickLeaderBoard()
    {
        GPG_Controller.ShowLeaderBoardUI();
    }

    public void OnClickAchivement()
    {
        GPG_Controller.ShowAchievementUI();
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
