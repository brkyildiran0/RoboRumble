using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Condition : MonoBehaviour
{
    public bool alwaysTrue;
    public SymbolType leftOperand;
    public SymbolType middleOperator;
    public TextMeshProUGUI rightOperand;

    private int _counter = 0;
    private Entity _entity;

    public enum SymbolType
    {
        SmallerThan,
        BiggerThan,
        Equals,
        xPos,
        yPos,
        i
    }

    public bool IsTrue(Entity entity)
    {
        _entity = entity;
        if (alwaysTrue)
        {
            return true;
        }
        
        switch (middleOperator)
        {
            case (SymbolType.Equals):
                return InterpretEntityOperand(entity, leftOperand) == ParseInteger(rightOperand.text);
            case (SymbolType.BiggerThan):
                return InterpretEntityOperand(entity, leftOperand) > ParseInteger(rightOperand.text);
            case (SymbolType.SmallerThan):
                return InterpretEntityOperand(entity, leftOperand) < ParseInteger(rightOperand.text);
            default:
                return false;
        }
    }

    public bool IsCounterFinished()
    {
        var isFinished = false;
        isFinished = _counter == ParseInteger(rightOperand.text);

        if (isFinished)
        {
            _counter = 0;
        }
        else
        {
            _counter += 1;
        }

        return isFinished;
    }

    private int InterpretEntityOperand(Entity entity, SymbolType symbolType)
    {
        switch (symbolType)
        {
            case (SymbolType.xPos):
                return entity.GetValue(symbolType);
            case (SymbolType.yPos):
                return entity.GetValue(symbolType);
            default:
                return 0;
        }
            
    }

    private int ParseInteger(string text)
    {
        if (text.IndexOf('i') > -1)
        {
            Debug.Log("returning: " + _entity.GetValue(SymbolType.i));
            return _entity.GetValue(SymbolType.i);
        }
        
        string stripped = "";
        foreach (var character in text)
        {
            if (char.IsDigit(character))
            {
                stripped += character;
            }
        }
        Debug.Log("returning stripped: " + int.Parse(stripped));
        return int.Parse(stripped);
    }

    private string ParseText(string text)
    {
        return text.Substring(0, text.Length - 1);
    }

}
