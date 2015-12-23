using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadNextLevel : MonoBehaviour
{
    public void LoadLevel(string _levelName)
    {
        SceneManager.LoadSceneAsync(_levelName);
    }
}
