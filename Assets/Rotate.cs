using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rotate : Execute
{
    public TextMeshProUGUI rotationAmount;
    // Start is called before the first frame update
    public override void ExecuteContent()
    {
        int amount = ParseText(rotationAmount.text.Substring(0, rotationAmount.text.Length - 1));
        EventManager.RotateEntity?.Invoke(entity, amount);
        base.ExecuteContent();
    }
    
    private int ParseText(string text)
    {
        int result = 0;
        int.TryParse(text, out result);
        return result;
    }
}
