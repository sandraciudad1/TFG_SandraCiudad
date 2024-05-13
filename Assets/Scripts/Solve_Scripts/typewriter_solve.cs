using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class typewriter_solve : MonoBehaviour
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
	public AudioClip solve1;

	public int solveBtnCounter = 0;

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
		solveBtnCounter++;
		audioSource.clip = solve1;
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
			typewriter_solve typewriter = GameObject.Find("Solve").GetComponent<typewriter_solve>();
			if (typewriter != null)
			{
				typewriter._finishWritting = true;
			}
			Solve solve = GameObject.Find("Solve").GetComponent<Solve>();
			if (solve != null)
			{

				solve.checkFinish();
			}

		}
	}
}
