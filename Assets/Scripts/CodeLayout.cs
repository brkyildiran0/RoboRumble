using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeLayout : MonoBehaviour
{
    public GameObject gameObject;
    public LayoutElement layoutElement;
    [SerializeField] public List<CodeLayout> childCodes;
    public VerticalLayoutGroup verticalLayoutGroup;
    public int childCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        layoutElement.minHeight = (1+childCount)*32;
    }

    void AddChild(CodeLayout childCode)
    {
        childCodes.Add(childCode);
        childCount = ChildCounter(childCodes);
    }

    int ChildCounter(List<CodeLayout> subChilds)
    {
        int count = subChilds.Count;
        foreach (var item in subChilds)
        {
            count += ChildCounter(item.childCodes);
        }

        return count;
    }
}
