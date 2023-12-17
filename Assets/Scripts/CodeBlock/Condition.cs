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
        int result = 0;
        if (text.Length <= 1)
        {
            return result;
        }

        bool parsed = int.TryParse(text, out result);
        if (!parsed)
        {
            text = text.Substring(0, 1);
            int.TryParse(text, out result);
        }
        return result;
    }

    private string ParseText(string text)
    {
        return text.Substring(0, text.Length - 1);
    }

}
