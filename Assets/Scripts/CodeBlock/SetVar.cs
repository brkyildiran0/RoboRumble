using TMPro;
using UnityEngine;

namespace Gameplay.CodeBlock
{
    public class SetVar: Execute
    {
            public TextMeshProUGUI amount;
            public override void ExecuteContent()
            {
                int increment = ParseText(amount.text.Substring(0, amount.text.Length - 1));
                Debug.Log("SetVar: " + increment); 
                entity.SetValue(Condition.SymbolType.i,increment);
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