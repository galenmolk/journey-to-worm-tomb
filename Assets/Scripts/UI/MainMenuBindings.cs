using UnityEngine;

public class MainMenuBindings : MonoBehaviour
{
    public void PlayButtonClicked()
    {
        Debug.Log("Play Button Clicked!");
        SceneLoader.Instance.LoadScene("Level1");
    }
}
