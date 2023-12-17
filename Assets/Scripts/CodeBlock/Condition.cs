using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Condition : MonoBehaviour
{
    public TextMeshProUGUI leftOperand;
    public TextMeshProUGUI middleOperator;
    public TextMeshProUGUI rightOperand;

    private enum SymbolType
    {
        SmallerThan,
        BiggerThan,
        Equals,
    }

    public bool IsTrue(Entity entity)
    {
        switch (InterpretOperator(middleOperator.text))
        {
            case (SymbolType.Equals):
                return InterpretOperand(entity, leftOperand.text) == InterpretOperand(entity, rightOperand.text);
            case (SymbolType.BiggerThan):
                return InterpretOperand(entity, leftOperand.text) > InterpretOperand(entity, rightOperand.text);
            case (SymbolType.SmallerThan):
                return InterpretOperand(entity, leftOperand.text) < InterpretOperand(entity, rightOperand.text);
            default:
                return false;
        }
        
    }

    private SymbolType InterpretOperator(string text)
    {
        switch (text)
        {
            case ("smaller than"):
                return SymbolType.SmallerThan;
            case ("bigger than"):
                return SymbolType.BiggerThan;
            case ("equals"):
                return SymbolType.Equals;
            default:
                return SymbolType.Equals;
        }
    }

    private int InterpretOperand(Entity entity, string text)
    {
        switch (text)
        {
            case ("x pos"):
                return entity.GetValue(text);
            case ("y pos"):
                return entity.GetValue(text); 
            default:
                return int.Parse(text);
        }
            
    }

}
