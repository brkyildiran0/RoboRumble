using TMPro;
using UnityEngine;

namespace Gameplay.CodeBlock
{
    public class Increment: Execute
    {
        public TextMeshProUGUI amount;
        public override void ExecuteContent()
        {
            int increment = ParseText(amount.text.Substring(0, amount.text.Length - 1));
            
            var cur = entity.GetValue(Condition.SymbolType.i);
            entity.SetValue(Condition.SymbolType.i,cur + increment);
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
}