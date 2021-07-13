using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTarget : MonoBehaviour
{
    void Start()
    {
        LevelManager.instance.boxTargets.Add(this);
    }

    private void OnDestroy()
    {
        LevelManager.instance.boxTargets.Remove(this);
    }
}