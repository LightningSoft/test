using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class Translations : MonoBehaviour
{
    public enum GAME_language { English = 0, Czech = 1, Polish = 2};
    public GAME_language language;
    Dictionary<string, string> englishTexts = new Dictionary<string, string>();
    Dictionary<string, string> czechTexts = new Dictionary<string, string>();
    Dictionary<string, string> polishTexts = new Dictionary<string, string>();

    // Start is called before the first frame update
    void Start()
    {
        prefsLang = PlayerPrefs.GetInt("language", -1);
        
        if (prefsLang == -1)
        {
        prefsLang = 0;
        PlayerPrefs.SetInt("language",0);
        }
        
        if (prefsLang == 0) language = GAME_language.English;
        if (prefsLang == 1) language = GAME_language.Czech;
        if (prefsLang == 2) language = GAME_language.Polish;
        

#if !DISABLESTEAMSTAFF
        //nastav výchozí jazyk podle steamu
        if (prefsLang == -1) 
        {
           string language = Steamworks.SteamApps.GetCurrentGameLanguage();
           language = GAME_language.English; 
        if (language == "czech") language = GAME_language.Czech;
        if (language == "polish") language = GAME_language.Polish;
        }
#endif
//TRANSLATIONS USED FROM EXPORT #104 [LIGHTNING TRANSLATOR]englishTexts.Add("menu_newgame", "New Game");czechTexts.Add("menu_newgame", "Nová hra");polishTexts.Add("menu_newgame", "Nowa Gra");englishTexts.Add("green", "green");czechTexts.Add("green", "zelená");polishTexts.Add("green", "zwelewna");englishTexts.Add("ACHIEVEMENT_ExplorerH1", "Explorer");czechTexts.Add("ACHIEVEMENT_ExplorerH1", "Průzkumník");polishTexts.Add("ACHIEVEMENT_ExplorerH1", "poszukiwacz");englishTexts.Add("ACHIEVEMENT_ExplorerDesc", "Find all newspaper clippings in town");czechTexts.Add("ACHIEVEMENT_ExplorerDesc", "Najdi všechny úryvky novin ve městě");polishTexts.Add("ACHIEVEMENT_ExplorerDesc", "Znajdź wszystkie wycinki z gazet w mieście");englishTexts.Add("menu_continue", "Continue");czechTexts.Add("menu_continue", "Pokračovat");polishTexts.Add("menu_continue", "");englishTexts.Add("menu_achievements", "Achievements");czechTexts.Add("menu_achievements", "Achievementy");polishTexts.Add("menu_achievements", "");englishTexts.Add("ACHIEVEMENT_GoodGuyH1", "Good Guy");czechTexts.Add("ACHIEVEMENT_GoodGuyH1", "Dobrý člověk");polishTexts.Add("ACHIEVEMENT_GoodGuyH1", "");englishTexts.Add("ACHIEVEMENT_GoodGuyDesc", "Deal with the homeless");czechTexts.Add("ACHIEVEMENT_GoodGuyDesc", "Vyrovnej se s bezdomovcem");polishTexts.Add("ACHIEVEMENT_GoodGuyDesc", "");englishTexts.Add("siska", "");czechTexts.Add("siska", "");polishTexts.Add("siska", "");englishTexts.Add("ve", "");czechTexts.Add("ve", "<X>, <Y> ");polishTexts.Add("ve", "");englishTexts.Add("<br>pod", "");czechTexts.Add("<br>pod", "podko");polishTexts.Add("<br>pod", "");englishTexts.Add("<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br", "");czechTexts.Add("<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br", "");polishTexts.Add("<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br", "");   }
    public string GetTranslatedString(string targetKey)
    {
        string resultVar = "undefined";
        if (language = GAME_language.English)
        {
            englishTexts.TryGetValue(targetKey, out resultVar);
        }
        if (language = GAME_language.Czech)
        {
            czechTexts.TryGetValue(targetKey, out resultVar);
        }
        if (language = GAME_language.Polish)
        {
            polishTexts.TryGetValue(targetKey, out resultVar);
        }
        return resultVar;
    }
}
