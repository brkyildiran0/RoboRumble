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

    public enum SymbolType
    {
        SmallerThan,
        BiggerThan,
        Equals,
        xPos,
        yPos,
        Number
    }

    public bool IsTrue(Entity entity)
    {
        switch (middleOperator)
        {
            case (SymbolType.Equals):
                return InterpretOperand(entity, leftOperand) == InterpretOperand(entity, SymbolType.Number);
            case (SymbolType.BiggerThan):
                return InterpretOperand(entity, leftOperand) > InterpretOperand(entity, SymbolType.Number);
            case (SymbolType.SmallerThan):
                
                return InterpretOperand(entity, leftOperand) < InterpretOperand(entity, SymbolType.Number);
            default:
                return false;
        }
        
    }

    private int InterpretOperand(Entity entity, SymbolType symbolType)
    {
        switch (symbolType)
        {
            case (SymbolType.xPos):
                
                Debug.Log("returned from entity: " + entity.GetValue(symbolType));
                return entity.GetValue(symbolType);
            case (SymbolType.yPos):
                return entity.GetValue(symbolType);
            case (SymbolType.Number):
                return ParseInteger(rightOperand.text); 
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
