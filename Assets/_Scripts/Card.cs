using UnityEngine;
using TMPro;
public class Card : MonoBehaviour
{
    public ListManagers Manager;
    public Transform viewContent;
    public GameGeneras type;
    public TMP_InputField inputField;
    public string previousChoice;
    public void AddPoint()
    {
        switch (type)
        {
            case GameGeneras.Genera : 
                GameGenera GG = new GameGenera(inputField.text , false);
                Manager.ListofGeneras.Add(GG);
                break;
            case GameGeneras.Character : 
                previousChoice = inputField.text;
                Manager.Characters.Add(previousChoice);
                break;
            case GameGeneras.Theme : 
                previousChoice = inputField.text;
                Manager.Themes.Add(previousChoice);
                break;
            case GameGeneras.Goal : 
                previousChoice = inputField.text;
                Manager.Goals.Add(previousChoice);
                break;
        }

        SettingsMenu.instance.useCard();
    }

    public void RemovePoint()
    {
        switch (type)
        {
            case GameGeneras.Genera : 
                Debug.Log("Nothing");
                break;
            case GameGeneras.Character : 
                if(Manager.Characters.Contains(previousChoice)) Manager.Characters.Remove(previousChoice);
                break;
            case GameGeneras.Theme : 
                if(Manager.Themes.Contains(previousChoice)) Manager.Themes.Remove(previousChoice);
                break;
            case GameGeneras.Goal : 
                if(Manager.Goals.Contains(previousChoice)) Manager.Goals.Remove(previousChoice);
                break;
        }

        SettingsMenu.instance.useCard();       
    }

}