using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SmartLocalization;

[RequireComponent(typeof(Button))]
public class ChangeLanguageOnClick : MonoBehaviour {
	public string isoLanguageToChangeTo = "en";
	Button button = null;
	
	void Start () {
		button = GetComponent<Button>();
		button.onClick.AddListener(OnLanguageChangeButtonClicked);
	}
	
	void OnDestroy(){
		button.onClick.RemoveListener(OnLanguageChangeButtonClicked);
	}
	
	void OnLanguageChangeButtonClicked ()
	{
		if(LanguageManager.HasInstance){
			LanguageManager.Instance.ChangeLanguage(isoLanguageToChangeTo);
		}
	}

}
