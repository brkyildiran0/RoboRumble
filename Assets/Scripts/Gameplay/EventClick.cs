using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using UnityEditor;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject ObjectOne;
    public CodeController s;

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        /*for (int i = 0; i < s.startingBlocks.Count; i++)
        {
            if (s.startingBlocks[i].GetComponent<Execute>().GetEntity() == gameObject.GetComponent<Entity>())
            {
                ObjectOne = s.startingBlocks[i];
            }
        }
        bool currentState = ObjectOne.activeSelf;

        currentState = !currentState;

        ObjectOne.SetActive(currentState);*/


        int activeEntity = 0;
        for (int i = 0; i < s.startingBlocks.Count; i++)
        {
            //if (s.startingBlocks[i].GetComponent<Execute>().GetEntity() == gameObject.GetComponent<Entity>())
            if (s.startingEntities[i].GetComponent<Entity>() == gameObject.GetComponent<Entity>())
            {
                ObjectOne = s.startingBlocks[i];
                activeEntity = i;
            }
        }

        bool currentState = ObjectOne.activeSelf;

        if (currentState == false)
        {
            AudioManager.Instance.PlaySFX("EntityClick");
            currentState = !currentState;
        }

        ObjectOne.SetActive(currentState);

        if (currentState)
        {
            gameObject.GetComponent<Entity>().setSelected(true);

            for (int i = 0; i < s.startingEntities.Count; i++)
            {
                if (s.startingEntities[i].GetComponent<Entity>().getSelected() == true && i != activeEntity)
                {
                    s.startingEntities[i].GetComponent<Entity>().setSelected(false);
                }
            }

            s.entityText.SetActive(true);
            TMP_Text temp = s.entityText.GetComponent<TMP_Text>();
            if (activeEntity == 0)
            {
                temp.text = "Player";
            } else
            {
                temp.text = "Entity #" + activeEntity;
            }
            
        } else
        {
            gameObject.GetComponent<Entity>().setSelected(false);

            s.entityText.SetActive(false);
        }

        for (int i = 0; i < s.startingBlocks.Count; i++)
        {
            //if (s.startingBlocks[i].GetComponent<Execute>().GetEntity() == gameObject.GetComponent<Entity>())
            if (s.startingBlocks[i] != ObjectOne)
            {
                s.startingBlocks[i].SetActive(false);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.GetComponent<Entity>().getSelected() == false)
        {
            for (int i = 0; i < s.startingEntities.Count; i++)
            {
                if (s.startingEntities[i].GetComponent<Entity>() == gameObject.GetComponent<Entity>())
                {
                    s.startingEntities[i].GetComponent<Image>().enabled = false;
                    AudioManager.Instance.PlaySFX("EntitySelect");
                    s.startingEntities[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                }
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (gameObject.GetComponent<Entity>().getSelected() == false)
        {
            for (int i = 0; i < s.startingEntities.Count; i++)
            {
                if (s.startingEntities[i].GetComponent<Entity>() == gameObject.GetComponent<Entity>())
                {
                    s.startingEntities[i].GetComponent<Image>().enabled = true;
                    s.startingEntities[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                }
            }
        }
    }
}
