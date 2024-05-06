using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Condition : MonoBehaviour
{
    public SymbolType leftOperand;
    public SymbolType middleOperator;
    public TextMeshProUGUI rightOperand;

    private int _counter = 0;

    public enum SymbolType
    {
        SmallerThan,
        BiggerThan,
        Equals,
        xPos,
        yPos,
    }

    public bool IsTrue(Entity entity)
    {
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
        string stripped = "";
        foreach (var character in text)
        {
            if (char.IsDigit(character))
            {
                stripped += character;
            }
        }
        return int.Parse(stripped);
    }

    private string ParseText(string text)
    {
        return text.Substring(0, text.Length - 1);
    }

}
