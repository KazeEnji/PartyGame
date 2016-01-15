using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartGame : MonoBehaviour 
{
    public void Begin()
    {
        SceneManager.LoadScene("PlayerCount");
    }
}
