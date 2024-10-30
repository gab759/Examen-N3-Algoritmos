using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DificultySelectorController : MonoBehaviour
{
    [SerializeField] private GameObject buttonEasy;
    [SerializeField] private GameObject buttonNormal;
    [SerializeField] private GameObject buttonHard;

    [SerializeField] private SODiifficult difficultySettings; 

    public void SelectEasy()
    {
        SelectDifficulty(SODiifficult.SelectDifficult.OnEasy);
        SceneManager.LoadScene("Game");
    }

    public void SelectNormal()
    {
        SelectDifficulty(SODiifficult.SelectDifficult.OnNormal);
        SceneManager.LoadScene("Game");
    }

    public void SelectHard()
    {
        SelectDifficulty(SODiifficult.SelectDifficult.OnHard);
        SceneManager.LoadScene("Game");
    }

    private void SelectDifficulty(SODiifficult.SelectDifficult difficulty)
    {
        switch (difficulty)
        {
            case SODiifficult.SelectDifficult.OnEasy:
                Debug.Log("Dificultad seleccionada: Fácil");
                difficultySettings.SetDifficulty(SODiifficult.SelectDifficult.OnEasy);
                break;
            case SODiifficult.SelectDifficult.OnNormal:
                Debug.Log("Dificultad seleccionada: Normal");
                difficultySettings.SetDifficulty(SODiifficult.SelectDifficult.OnNormal);
                break;
            case SODiifficult.SelectDifficult.OnHard:
                Debug.Log("Dificultad seleccionada: Difícil");
                difficultySettings.SetDifficulty(SODiifficult.SelectDifficult.OnHard);
                break;
        }
    }
}
