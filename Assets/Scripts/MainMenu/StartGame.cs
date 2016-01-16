using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartGame : MonoBehaviour 
{
    [SerializeField] private int sceneNumber;

    public void Begin()
    {
        sceneNumber = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(sceneNumber + 1);
    }
}
