using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<QuestTarget> boxTargets;
    public List<QuestTarget> enemyTargets;


    public static LevelManager instance;
    public GameObject DeathPanel;
    public Transform respawnPoint;
    public GameObject playerPrefab;
    public float respawnTime;

    private void Awake()
    {
        instance = this;
    }

    public void Respawn()
    {
        StartCoroutine(IRespawn());
    }

    

    public IEnumerator IRespawn()
    {
        GameObject deathPosition = Instantiate(new GameObject("Player Death Position"),playerPrefab.GetComponent<Transform>().position, Quaternion.identity);
        deathPosition.AddComponent<AudioListener>();
        DeathPanel.SetActive(true);
        yield return new WaitForSecondsRealtime(respawnTime);
        DeathPanel.SetActive(false);
        Destroy(deathPosition);
        Instantiate(playerPrefab,respawnPoint.position,Quaternion.identity);
    }
}