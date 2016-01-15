using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChooseNumberOfPlayers : MonoBehaviour
{
    [SerializeField] private GameObject universalGameManager;

    private void Awake()
    {
        universalGameManager = GameObject.FindGameObjectWithTag("UGM");
    }

    //List player methods
    public void SetPlayerQuantity1()
    {
        universalGameManager.GetComponent<UniversalGameManager>().SetNumberOfPlayers(1);
        SceneManager.LoadScene("CharacterSelect");
    }

    public void SetPlayerQuantity2()
    {
        universalGameManager.GetComponent<UniversalGameManager>().SetNumberOfPlayers(2);
        SceneManager.LoadScene("CharacterSelect");
    }

    public void SetPlayerQuantity3()
    {
        universalGameManager.GetComponent<UniversalGameManager>().SetNumberOfPlayers(3);
        SceneManager.LoadScene("CharacterSelect");
    }

    public void SetPlayerQuantity4()
    {
        universalGameManager.GetComponent<UniversalGameManager>().SetNumberOfPlayers(4);
        SceneManager.LoadScene("CharacterSelect");
    }
}
