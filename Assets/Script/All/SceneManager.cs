using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : SingletonMonoBehaviour<SceneManagerScript>
{

    public void LoadTitle()
    {

    }


    public void LoadInGame()
    {

    }


    public void LoadRisult()
    {
        SceneManager.LoadScene("Risult");
    }

    
}
