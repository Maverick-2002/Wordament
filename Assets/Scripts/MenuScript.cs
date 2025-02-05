using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    private CanvasGroup canvas;

   // public Button[] buttons;
  //  public TextAsset[] themes;
    public static MenuScript instance;
    public Transform miniMenu;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        canvas.alpha = 1;

        /*for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[index].onClick.AddListener(()=>StartGame(index));
            buttons[index].GetComponentInChildren<Text>().text = themes[index].name.ToUpper();
        }*/
       
    }

    public void StartGame(){

    

        canvas.alpha = 0;
        canvas.blocksRaycasts = false;

        miniMenu.DOMoveY(0,.6f).SetEase(Ease.OutBack);
        
    }

    public void Home(){
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

}
