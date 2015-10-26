using UnityEngine;
using System.Collections;
using SmartLocalization;
using System.Collections.Generic;

public class ChangeLanguageDebugScript : MonoBehaviour {

	private List<SmartCultureInfo> availableLanguages;
	private LanguageManager languageManager;
	
	
	void Start() 
	{
		languageManager = LanguageManager.Instance;
		availableLanguages = languageManager.GetSupportedLanguages();
	}
	
	void OnGUI() 
	{
		if(availableLanguages != null && availableLanguages.Count > 0)
		{
			if(languageManager.CurrentlyLoadedCulture != null)
			{
				GUILayout.Label("Current Language:" + languageManager.CurrentlyLoadedCulture.ToString());
			}
			
			foreach(SmartCultureInfo language in availableLanguages)
			{
				if(GUILayout.Button(language.englishName, GUILayout.MinWidth(Screen.height * 0.05f)))
				{
					languageManager.ChangeLanguage(language);
				}
			}
		}
	}
}
