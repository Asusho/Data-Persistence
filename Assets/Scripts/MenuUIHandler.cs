using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        DataPersistenceManager.Instance.currentPlayerName = nameInputField.text;
    }
}
