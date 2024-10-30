using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class DificultySelectorController : MonoBehaviour
{
    [SerializeField] private GameObject buttonEasy;
    [SerializeField] private GameObject buttonNormal;
    [SerializeField] private GameObject buttonHard;

    [SerializeField] private SODiifficult difficultySettings; 

    public void SelectEasy()
    {
        SelectDifficulty(SODiifficult.SelectDifficult.OnEasy);
    }

    public void SelectNormal()
    {
        SelectDifficulty(SODiifficult.SelectDifficult.OnNormal);
    }

    public void SelectHard()
    {
        SelectDifficulty(SODiifficult.SelectDifficult.OnHard);
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
