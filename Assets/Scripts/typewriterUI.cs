using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class typewriterUI : MonoBehaviour
{
	TMP_Text _tmpProText;
	string writer;

	[SerializeField] 
	float delayBeforeStart = 0f;
	[SerializeField] 
	float timeBtwChars = 0.1f;
	[SerializeField] 
	string leadingChar = "";
	[SerializeField] 
	bool leadingCharBeforeDelay = false;
	[SerializeField]
	public bool _finishWritting = false;

	void Start()
	{
		_tmpProText = GetComponent<TMP_Text>()!;

		if (_tmpProText != null)
		{
			writer = _tmpProText.text;
			_tmpProText.text = "";

			StartCoroutine("TypeWriterTMP");
		}
	}

	IEnumerator TypeWriterTMP()
	{
		Debug.Log("en typewriterTMP al principio " + _finishWritting);
		_tmpProText.text = leadingCharBeforeDelay ? leadingChar : "";

		yield return new WaitForSeconds(delayBeforeStart);

		foreach (char c in writer)
		{
			if (_tmpProText.text.Length > 0)
			{
				_tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
			} 
			_tmpProText.text += c;
			_tmpProText.text += leadingChar;
			yield return new WaitForSeconds(timeBtwChars);
		}

		if (leadingChar != "")
		{
			_tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
		}
        else
        {
			_finishWritting = true;
			//Para la introducción al juego
			typewriterUI typewriter = GameObject.Find("Introduction").GetComponent<typewriterUI>();
			if (typewriter != null)
            {
				typewriter._finishWritting = true;
            }
			Start_Screen startScreen = GameObject.Find("Start_Screen").GetComponent<Start_Screen>();
			if (startScreen != null)
            {
				startScreen.checkFinish();
            }

			//Para explicar el test de stroop
			typewriterUI typewriter2 = GameObject.Find("test_intros").GetComponent<typewriterUI>();
			if (typewriter2 != null)
			{
				typewriter2._finishWritting = true;
			}
			stroop_explanation stroop_Explanation = GameObject.Find("test_intros").GetComponent<stroop_explanation>();
			if (stroop_Explanation != null)
			{
				stroop_Explanation.checkFinish();
			}
		}
	}
}
