using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameIdeaPlz : MonoBehaviour
{
    [Header("References")]
    public ListManagers Manager;

    public TMP_Text CharacterTxt;

    [Space(15f)]
    public TMP_Text GameGeneraTxt;
    public TMP_Text GameSubGeneraTxt;
    public TMP_Text ExamplesTxt;
    [Space(10f)]   
    public TMP_Text ThemesTxt;
    public TMP_Text GoalTxt;

    [Header("Enables Lists")]
    public bool AddedCharacter;
    public bool AddedThemes;
    public bool AddedGoal;
    public GameObject[] Panels;

    public TMP_Text notifyTxt;
    public Color YesColor;
    public Color NoColor;

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
    }
    public void EnableLists(int num)
    {
        if(num == 0)
        {
            AddedCharacter = true;
            notifyTxt.gameObject.SetActive(true);
            notifyTxt.color = YesColor;
            notifyTxt.text = "Characters are Enabled";
        }
        else if(num == 1)
        {
            AddedThemes = true;
            notifyTxt.gameObject.SetActive(true);
            notifyTxt.color = YesColor;
            notifyTxt.text = "Themes are Enabled";
        }
        else if(num == 2)
        {
            AddedGoal = true;
            notifyTxt.gameObject.SetActive(true);
            notifyTxt.color = YesColor;
            notifyTxt.text = "Goals are Enabled";
        }
        StartCoroutine(disableTxt());
    }
    IEnumerator disableTxt()
    {
        yield return new WaitForSeconds(3f);
        notifyTxt.gameObject.SetActive(false);
    }
    public void DisableLists(int num)
    {
        if(num == 0)
        {
            AddedCharacter = false;
            notifyTxt.gameObject.SetActive(true);
            notifyTxt.color = NoColor;
            notifyTxt.text = "Characters are Disabled";
        }
        else if(num == 1)
        {
            AddedThemes = false;
            notifyTxt.gameObject.SetActive(true);
            notifyTxt.color = NoColor;
            notifyTxt.text = "Themes are Disabled";
        }
        else if(num == 2)
        {
            AddedGoal = false;
            notifyTxt.gameObject.SetActive(true);
            notifyTxt.color = NoColor;
            notifyTxt.text = "Goals are Disabled";
        }
        StartCoroutine(disableTxt());
    }
    public void Generate()
    {
        CharacterTxt.gameObject.SetActive(false);
        ThemesTxt.gameObject.SetActive(false);
        GoalTxt.gameObject.SetActive(false);

        GameGeneraTxt.gameObject.SetActive(true);

        int randomNum = Random.Range(0 , Manager.ListofGeneras.Count);
        var genera = Manager.ListofGeneras[randomNum];

        GameGeneraTxt.text = "GameGenera : " + genera.Genera;

        if(genera.hasSubGenera == true)
        {
            GameSubGeneraTxt.gameObject.SetActive(true);
            ExamplesTxt.gameObject.SetActive(true);

            int randomSubGeneraNum = Random.Range(0 , genera.ListofSubGeneras.Length);
            GameSubGeneraTxt.text = "Game Type : " + genera.ListofSubGeneras[randomSubGeneraNum].SubGeneras;

            int randomExampleNum = Random.Range(0 , genera.ListofSubGeneras[randomSubGeneraNum].Examples.Length);
            ExamplesTxt.text = "Examples : " + genera.ListofSubGeneras[randomSubGeneraNum].Examples[randomExampleNum];
        }
        else
        {
            GameSubGeneraTxt.gameObject.SetActive(false);
            ExamplesTxt.gameObject.SetActive(false);
        }

        if(AddedCharacter)
        {
            CharacterTxt.gameObject.SetActive(true);
            CharacterTxt.text = "Character : " + GetCharacter();
        }

        if(AddedThemes) 
        {
            ThemesTxt.gameObject.SetActive(true);
            ThemesTxt.text = "Theme : " + GetThemes();
        }

        if(AddedGoal) 
        {
            GoalTxt.gameObject.SetActive(true);
            GoalTxt.text = "Goal : " + GetGoals();
        }
    }
    public string GetThemes()
    {
        int randomNum = Random.Range(0 , Manager.Themes.Count);
        return Manager.Themes[randomNum];
    }
    public string GetGoals()
    {
        int randomNum = Random.Range(0 , Manager.Goals.Count);
        return Manager.Goals[randomNum];
    }
    public string GetAddational()
    {
        int randomNum = Random.Range(0 , Manager.Addational.Count);
        return Manager.Addational[randomNum];
    }
    public string GetCharacter()
    {
        int randomNum = Random.Range(0 , Manager.Characters.Count);
        return Manager.Characters[randomNum];
    }

    public void Quit()
    {
        Application.Quit();
    }
}