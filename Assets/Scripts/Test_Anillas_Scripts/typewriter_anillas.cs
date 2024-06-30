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

	public AudioSource audioSource;
	public AudioClip anillas1;
	public AudioClip anillas2;
	public AudioClip anillas3;
	public AudioClip anillas4;
	public AudioClip anillas5;
	public AudioClip preparado;

	public int anillasBtnCounter = 0;

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

	public void Update()
	{

		if (Input.GetKeyDown(KeyCode.S))
		{
			pressed = true;
		}

	}


	public void soundClicked1()
	{
		anillasBtnCounter++;
		audioSource.clip = anillas1;
		audioSource.Play();
	}

	public void soundClicked2()
	{
		anillasBtnCounter++;
		audioSource.clip = anillas2;
		audioSource.Play();
	}

	public void soundClicked3()
	{
		anillasBtnCounter++;
		audioSource.clip = anillas3;
		audioSource.Play();
	}

	public void soundClicked4()
	{
		anillasBtnCounter++;
		audioSource.clip = anillas4;
		audioSource.Play();
	}

	public void soundClicked5()
	{
		anillasBtnCounter++;
		audioSource.clip = anillas5;
		audioSource.Play();
	}

	public void soundClicked6()
	{
		anillasBtnCounter++;
		audioSource.clip = preparado;
		audioSource.Play();
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