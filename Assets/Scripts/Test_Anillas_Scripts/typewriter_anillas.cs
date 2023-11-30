using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class typewriter_anillas : MonoBehaviour
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

	public bool _finishWritting = false;
	bool pressed = false;

	public void Start()
	{
		_tmpProText = GetComponent<TMP_Text>()!;

		if (_tmpProText != null)
		{
			writer = _tmpProText.text;
			_tmpProText.text = "";
			StartCoroutine("TypeWriterTMP");
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			pressed = true;
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
			if (pressed == false)
			{
				yield return new WaitForSeconds(timeBtwChars);
			}


		}

		if (leadingChar != "")
		{
			_tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
		}
		else
		{
			_finishWritting = true;
			pressed = false;

			
			typewriter_anillas typewriter = GameObject.Find("Anillas").GetComponent<typewriter_anillas>();
			if (typewriter != null)
			{
				typewriter._finishWritting = true;
			}
			anillas anillas = GameObject.Find("Anillas").GetComponent<anillas>();
			if (anillas != null)
			{
				anillas.checkFinish();
			}

		}
	}
}