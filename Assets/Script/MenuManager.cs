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
    }
    public void DisableGameWindow()
    {
        game.SetActive(false);
    }
    public void ActiveOptionsWindow()
    {
        options.SetActive(true);
    }
    public void DisableOptionsWindow()
    {
        options.SetActive(false);
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
}
