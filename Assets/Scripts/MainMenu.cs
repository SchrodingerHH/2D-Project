using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public InputField playerName;

    public void Accept()
    {
        PlayerPrefs.SetString("playerName",playerName.text);
        SceneManager.LoadScene("SampleScene");
    }
}