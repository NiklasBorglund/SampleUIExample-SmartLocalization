using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using SmartLocalization;

[RequireComponent(typeof(Dropdown))]
public class LocalizedDropdown : MonoBehaviour {
	public List<Dropdown.OptionData> optionData = new List<Dropdown.OptionData>();
	
	Dropdown dropdown;	

	void Start () {
		dropdown = GetComponent<Dropdown>();
		LanguageManager.Instance.OnChangeLanguage += OnLanguageChanged;
		
		OnLanguageChanged(LanguageManager.Instance);
	}
	
	void OnDestroy(){
		if(LanguageManager.HasInstance){
			LanguageManager.Instance.OnChangeLanguage -= OnLanguageChanged;
		}
	}
	

	void OnLanguageChanged (LanguageManager languageManager)
	{
		dropdown.options.Clear();
		foreach(var options in optionData){
			dropdown.options.Add(new Dropdown.OptionData(languageManager.GetTextValue(options.text), options.image));
		}
	}
}
