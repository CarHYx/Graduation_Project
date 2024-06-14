using System.Collections;
using System.Collections.Generic;
using UIManinPanel;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class GameOverPanel : BasePanel
{
    public Button btnStart;
    public Button btnQuite;
    private Character character;
    private PlayerController playerController;
    protected override void Awake()
    {
        base.Awake(); 
        character = GameObject.Find("Player").GetComponent<Character>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    protected override void Start()
    {
      
        btnStart.onClick.AddListener(() =>
        {
            UIManager.GetInstance().HidePanel("GameOverPanel");
            character.maxHP = 100;
            character.currentHP = 100;
            playerController.isDead = false;
            playerController.inputControl.GamePlayer.Enable();
        }); ;

        //GameOver Quite
        btnQuite.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}
