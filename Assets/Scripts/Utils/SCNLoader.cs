using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCNLoader : MonoBehaviour

{
    public GameObject winScreen;
    public void Level(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void Level(string s)
    {
        SceneManager.LoadScene(s);
    }

    public void NextLevel()
    {
        PlayerController.Instance.StartToRun();
        ClearUI();
    }

    public void ClearUI()
    {
        winScreen.SetActive(false);
    }
}
