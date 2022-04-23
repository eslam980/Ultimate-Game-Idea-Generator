using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public static SettingsMenu instance; void Awake(){instance=this;}
    public Card currentCard;
    public ListManagers Manager;
    public GameObject[] Panels;
    public GameObject btnPrefab;

    void Start()
    {
        ChangePanel(0);
    }
    public void ChangePanel(int num)
    {
        foreach (GameObject panel in Panels)
        {
            panel.SetActive(false);
        }

        Panels[num].SetActive(true);

        currentCard = Panels[num].GetComponent<Card>();

        useCard();
    }

    public void useCard()
    {
        foreach (TMP_Text txt in currentCard.viewContent.GetComponentsInChildren<TMP_Text>())
        {
            Destroy(txt.gameObject);
        }
        
        switch (currentCard.type)
        {
            case GameGeneras.Genera : 

                foreach (GameGenera item in Manager.ListofGeneras)
                {
                    var wanted =  Instantiate(btnPrefab , currentCard.viewContent);
                    TMP_Text txt = wanted.GetComponent<TMP_Text>();
                    txt.text = item.Genera;
                }
                break;
            case GameGeneras.Character : 

                foreach (string item in Manager.Characters)
                {
                    var wanted =  Instantiate(btnPrefab , currentCard.viewContent);
                    TMP_Text txt = wanted.GetComponent<TMP_Text>();
                    txt.text = item;
                }
                break;
            case GameGeneras.Theme : 

                foreach (string item in Manager.Themes)
                {
                    var wanted =  Instantiate(btnPrefab , currentCard.viewContent);
                    TMP_Text txt = wanted.GetComponent<TMP_Text>();
                    txt.text = item;
                }
                break;
            case GameGeneras.Goal : 

                foreach (string item in Manager.Goals)
                {
                    var wanted =  Instantiate(btnPrefab , currentCard.viewContent);
                    TMP_Text txt = wanted.GetComponent<TMP_Text>();
                    txt.text = item;
                }
                break;
        }
      
    }
}
public enum GameGeneras
{
    Genera,
    Character,
    Theme,
    Goal,
}