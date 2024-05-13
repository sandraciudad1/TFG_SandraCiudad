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

	public bool _finishWritting = false;
	bool pressed = false;

	public AudioSource audioSource;
	public AudioClip caras1;
	public AudioClip caras2;
	public AudioClip caras3;
	public AudioClip caras4;
	public AudioClip caras5;
	public AudioClip caras6;
	public AudioClip preparado;

	public int carasBtnCounter = 0;

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
		carasBtnCounter++;
		audioSource.clip = caras1;
		audioSource.Play();
	}

	public void soundClicked2()
	{
		carasBtnCounter++;
		audioSource.clip = caras2;
		audioSource.Play();
	}

	public void soundClicked3()
	{
		carasBtnCounter++;
		audioSource.clip = caras3;
		audioSource.Play();
	}

	public void soundClicked4()
	{
		carasBtnCounter++;
		audioSource.clip = caras4;
		audioSource.Play();
	}

	public void soundClicked5()
	{
		carasBtnCounter++;
		audioSource.clip = caras5;
		audioSource.Play();
	}

	public void soundClicked6()
	{
		carasBtnCounter++;
		audioSource.clip = caras6;
		audioSource.Play();
	}

	public void soundClicked7()
	{
		carasBtnCounter++;
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

			//Para explicar el test de caras
			typewriter_caras typewriter = GameObject.Find("remoteControl").GetComponent<typewriter_caras>();
			if (typewriter != null)
			{
				typewriter._finishWritting = true;
			}
			Television tv = GameObject.Find("remoteControl").GetComponent<Television>();
			if (tv != null)
			{

				tv.checkFinish();
			}

		}
	}
}
