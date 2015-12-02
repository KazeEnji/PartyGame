using UnityEngine;
using System.Collections;

public partial class CharacterSelectLocalManager : MonoBehaviour
{
    public void Confirm()
    {
        Application.LoadLevel(2);
    }
}
