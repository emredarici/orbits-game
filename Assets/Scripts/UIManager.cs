using UnityEngine.UIElements;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject GameObjects;
    private VisualElement root;
    private VisualElement deathScreen;

    void Start()
    {
        root = this.GetComponent<UIDocument>().rootVisualElement;
        deathScreen = root.Q<VisualElement>("deathscreen");
        deathScreen.style.display = DisplayStyle.None;

        root.Q<Button>("play").clicked += () => StartGame();
        root.Q<Button>("quit").clicked += () => QuitGame();
        root.Q<Button>("menu").clicked += () => MainMenu();
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    private void QuitGame()
    {
        Application.Quit();
    }
    private void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public IEnumerator loseGame()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(GameObjects);
        deathScreen.style.display = DisplayStyle.Flex;
    }
}
