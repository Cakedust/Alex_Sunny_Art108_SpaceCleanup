using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerResources;
    public int playerMaxResources;
    public Text resourceText;
    void Start()
    {
        playerMaxResources = 20;
        resourceText.text = string.Concat(playerResources.ToString() + "/" + playerMaxResources.ToString());
    }
    [ContextMenu("Increase Score")]
    public void addResource()
    {
        playerResources = playerResources + 1;
        resourceText.text = string.Concat(playerResources.ToString() + "/" + playerMaxResources.ToString());
    }
    public void removeResource()
    {
        playerResources = playerResources - 1;
        resourceText.text = string.Concat(playerResources.ToString() + "/" + playerMaxResources.ToString());
    }
    public int getResource()
    {
        return playerResources;
    }
    public int getMaxResource()
    {
        return playerMaxResources;
    }
}