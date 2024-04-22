using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Objective : MonoBehaviour
{
    public string description;
    public bool isCompleted;

    public Objective(string desc)
    {
        description = desc;
        isCompleted = false;
    }

    public void CompleteObjective()
    {
        isCompleted = true;
        EventManager.OnObjectiveCompleted?.Invoke(description);
    }
}