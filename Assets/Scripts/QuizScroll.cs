using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using System.Reflection;
using static WordHunt;

public class QuizScroll : MonoBehaviour
{
    private RectTransform rect;
    public static QuizScroll instance;
    public GameObject wordCellPrefab;
    public Transform scrollViewContent;
    private WordHunt wordHuntPrefab;

    private void Awake()
    {
        instance = this;
        wordHuntPrefab = WordHunt.instance;
    }
    public void SpawnWordsFromCategory(string categoryName)
    {
        List<string> words = WordDataStore.CategoryWordMap[categoryName];
        MenuScript.instance.StartGame();
        wordHuntPrefab.PrepareWords(words);
        wordHuntPrefab.Setup();
        
            
    }
    public void SpawnQuizCell(string word, float delay)
    {
        GameObject cell = Instantiate(wordCellPrefab, scrollViewContent);
        print("Button spawned");
        Button cellButton = cell.GetComponent<Button>();
        cell.GetComponentInChildren<Text>().text = word.ToUpper();
        cellButton.onClick.AddListener(() => SpawnWordsFromCategory(word));
        cell.transform.DOScale(0, 0.3f).SetEase(Ease.OutBack).From().SetDelay(delay);
    }
}
