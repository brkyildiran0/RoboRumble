using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public List<Objective> objectives = new List<Objective>();
    public TextMeshProUGUI TextField;

    private void Start()
    {
        EventManager.OnObjectiveCompleted += HandleObjectiveCompleted;
        ListObjectiveText();
    }

    private void OnDestroy()
    {
        EventManager.OnObjectiveCompleted -= HandleObjectiveCompleted;
    }

    private void HandleObjectiveCompleted(string objectiveDescription)
    {
        Debug.Log($"Objective Completed: {objectiveDescription}");
    }

    public void CheckObjectives()
    {
        foreach (Objective objective in objectives)
        {
            if (!objective.isCompleted)
            {
                TextField.color = new Color(0, 255, 0, 255);
            }
        }
    }

    public void ListObjectiveText(){
        String ObjectiveList = "";
        foreach (Objective objective in objectives){
            ObjectiveList += objective.description+"\n";
        }
        TextField.text = ObjectiveList;
    }
}
