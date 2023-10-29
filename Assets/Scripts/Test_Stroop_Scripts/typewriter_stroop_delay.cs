using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class typewriter_stroop_delay : MonoBehaviour
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



    public void init()
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


			//Para explicar el test de stroop
			typewriter_stroop typewriter = GameObject.Find("pinboard").GetComponent<typewriter_stroop>();
			if (typewriter != null)
			{
				typewriter._finishWritting = true;
			}
			PinBoard pinboard = GameObject.Find("pinboard").GetComponent<PinBoard>();
			if (pinboard != null)
			{
				pinboard.checkFinish();

			}

		}
	}


}
