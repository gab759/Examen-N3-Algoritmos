using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }
    [SerializeField] private GameObject game;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject credits;
    [SerializeField] private Animator animDifficult;
    [SerializeField] private Animator optionsAnim;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void ActiveGameWindow()
    {
        game.SetActive(true);
        animDifficult.SetBool("isActive", true);
    }
    public void DisableGameWindow()
    {
        game.SetActive(false);
        Debug.Log("Se apago");
        animDifficult.SetBool("isActive", false);
    }
    public void ActiveOptionsWindow()
    {
        options.SetActive(true);
        optionsAnim.SetBool("isOptions", true);
    }
    public void DisableOptionsWindow()
    {
        options.SetActive(false);
        optionsAnim.SetBool("isOptions", false);
    }
    public void ActiveCreditsWindow()
    {
        credits.SetActive(true);
    }
    public void DisableCreditsWindow()
    {
        credits.SetActive(false);
    }
   public void ChangeScene(string Wazaaa)
    {
        SceneManager.LoadScene(Wazaaa);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Saliendo");
    }
}
