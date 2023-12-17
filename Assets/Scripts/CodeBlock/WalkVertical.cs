using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalkVertical : Execute
{

    public bool isReverse = false;
    public TextMeshProUGUI rowMovementAmount;
    public override void ExecuteContent()
    {
        int amount = ParseText(rowMovementAmount.text.Substring(0, rowMovementAmount.text.Length - 1));
        if (amount > 0)
        {
            if (isReverse)
            {
                amount = -1 * amount;
            }
            entity.GetMovementController().DisplaceFromCurrentTileVertically(amount);
        }
        base.ExecuteContent();
    }
    private int ParseText(string text)
    {
        int result = 0;
        int.TryParse(text, out result);
        return result;
    }
}
