using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class Saving : MonoBehaviour
{
    Vector2 playerVelocity;
    Vector3 playerPos;
    public Text textstring;
    private string savePath;
    private int saveInteger = 0;
    private SaveVars _SaveVars = new SaveVars();
    
    void Start()
    {
        savePath = Path.Combine(Application.dataPath, "SaveData.json");

        if (File.Exists(savePath))
        {
            _SaveVars = JsonUtility.FromJson<SaveVars>(File.ReadAllText(savePath));

            playerVelocity = _SaveVars.playerVelocity;
            playerPos = _SaveVars.playerPos;
            GameObject.FindWithTag("Player").GetComponent<Transform>().position = playerPos;
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity = playerVelocity;
            saveInteger = _SaveVars.saveinteger;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            saveInteger += 1;
            textstring.text = saveInteger.ToString();
            _SaveVars.saveinteger = saveInteger;
        }
    }

    private void OnApplicationQuit()
    {
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>().position;
        playerVelocity = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity;
        _SaveVars.playerVelocity = playerVelocity;
        _SaveVars.playerPos = playerPos;

        File.WriteAllText(savePath, JsonUtility.ToJson(_SaveVars));
    }
}

public class SaveVars
{
    public Vector2 playerVelocity;
    public Vector3 playerPos;
    public int saveinteger;
}