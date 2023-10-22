using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class typewriter_caras : MonoBehaviour
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


			//Para explicar el test de caras
			typewriter_caras typewriter = GameObject.Find("test_intros").GetComponent<typewriter_caras>();
			if (typewriter != null)
			{
				typewriter._finishWritting = true;
			}
			cb_reason cb_Reason = GameObject.Find("test_intros").GetComponent<cb_reason>();
			if (cb_Reason != null)
			{

				cb_Reason.checkFinish();
			}

		}
	}
}
