using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerResources;
    public Text resourceText;

    [ContextMenu("Increase Score")]
    public void addResource()
    {
        playerResources = playerResources + 1;
        resourceText.text = string.Concat(playerResources.ToString() + "/40");
    }

}
