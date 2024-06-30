using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class typewriter_stroop : MonoBehaviour
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
	public AudioClip stroop1;
	public AudioClip stroop2;
	public AudioClip stroop3;
	public AudioClip stroop4;
	public AudioClip stroop5;
	public AudioClip preparado;

	public int stroopBtnCounter = 0;


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
		stroopBtnCounter++;
		audioSource.clip = stroop1;
		audioSource.Play();
	}

	public void soundClicked2()
	{
		stroopBtnCounter++;
		audioSource.clip = stroop2;
		audioSource.Play();
	}

	public void soundClicked3()
	{
		stroopBtnCounter++;
		audioSource.clip = stroop3;
		audioSource.Play();
	}

	public void soundClicked4()
	{
		stroopBtnCounter++;
		audioSource.clip = stroop4;
		audioSource.Play();
	}

	public void soundClicked5()
	{
		stroopBtnCounter++;
		audioSource.clip = stroop5;
		audioSource.Play();
	}

	public void soundClicked6()
	{
		stroopBtnCounter++;
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