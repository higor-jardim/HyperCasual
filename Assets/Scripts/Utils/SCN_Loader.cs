using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCN_Loader : MonoBehaviour
{
    public void Level(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void Level(string s)
    {
        SceneManager.LoadScene(s);
    }
}
