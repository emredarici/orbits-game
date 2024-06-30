using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private VisualElement root;
    private VisualElement htpScreen;
    private void Awake()
    {
        root = this.GetComponent<UIDocument>().rootVisualElement;
        htpScreen = root.Q<VisualElement>("htp-screen");
        htpScreen.style.display = DisplayStyle.None;

        root.Q<Button>("start-btn").clicked += () => StartGame();
        root.Q<Button>("quit-btn").clicked += () => QuitGame();
        root.Q<Button>("htp-btn").clicked += () => htpScreenButton();
        root.Q<Button>("htp-screen-close").clicked += () => htpScreenCloseButton();
    }
    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    private void QuitGame()
    {
        Application.Quit();
    }
    private void htpScreenButton()
    {
        htpScreen.style.display = DisplayStyle.Flex;
        htpScreen.AddToClassList("htp-screen-open");
    }
    private void htpScreenCloseButton()
    {
        htpScreen.style.display = DisplayStyle.None;
        htpScreen.RemoveFromClassList("htp-screen-open");
    }


}
