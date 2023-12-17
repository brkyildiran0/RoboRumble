using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalkHorizontal : Execute
{

    public bool isReverse;
    public TextMeshProUGUI columnMovementAmount;
    public override void ExecuteContent()
    {
        int amount = ParseText(columnMovementAmount.text.Substring(0, columnMovementAmount.text.Length - 1));
        if (amount > 0)
        {
            if (isReverse)
            {
                amount = -1 * amount;
            }
            entity.GetMovementController().DisplaceFromCurrentTileHorizontally(amount);
        }
        base.ExecuteContent();
    }

    private int ParseText(string text)
    {
        Debug.Log(text);
        int result = 0;
        int.TryParse(text, out result);
        return result;
    }
}
