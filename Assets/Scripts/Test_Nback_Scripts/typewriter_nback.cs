using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class typewriter_nback : MonoBehaviour
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
	public AudioClip cartas1;
	public AudioClip cartas2;
	public AudioClip cartas3;
	public AudioClip cartas4;
	public AudioClip cartas5;
	public AudioClip preparado;

	public int cartasBtnCounter = 0;

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
		cartasBtnCounter++;
		audioSource.clip = cartas1;
		audioSource.Play();
	}

	public void soundClicked2()
	{
		cartasBtnCounter++;
		audioSource.clip = cartas2;
		audioSource.Play();
	}

	public void soundClicked3()
	{
		cartasBtnCounter++;
		audioSource.clip = cartas3;
		audioSource.Play();
	}

	public void soundClicked4()
	{
		cartasBtnCounter++;
		audioSource.clip = cartas4;
		audioSource.Play();
	}

	public void soundClicked5()
	{
		cartasBtnCounter++;
		audioSource.clip = cartas5;
		audioSource.Play();
	}

	public void soundClicked6()
	{
		cartasBtnCounter++;
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


			typewriter_nback typewriter = GameObject.Find("card_deck").GetComponent<typewriter_nback>();
			if (typewriter != null)
			{
				typewriter._finishWritting = true;
			}
			card_deck cd = GameObject.Find("card_deck").GetComponent<card_deck>();
			if (cd != null)
			{
				cd.checkFinish();
			}

		}
	}
}