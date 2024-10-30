using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Difficult", menuName = "ScriptableObjectsDifficult/Difficult", order = 1)]
public class SODiifficult : ScriptableObject
{
    public bool elegido;

    public enum SelectDifficult
    {
        OnEasy,
        OnNormal,
        OnHard
    }

    public SelectDifficult selectedDifficult;

    public void SetDifficulty(SelectDifficult difficulty)
    {
        selectedDifficult = difficulty;
        elegido = true; 
    }
}
