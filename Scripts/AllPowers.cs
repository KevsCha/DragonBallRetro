using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class AllPowers : MonoBehaviour
{
	//public Gen_Person scGenPerson;
	public List<string> lstPower;
	public List<string> lstPerson;
	public List<List<string>> players;
	public string[] powerlst;

	public Dictionary<string, string[]> keyPlayer;
	public GameObject imgPlayer1;
	public GameObject imgPlayer2;
	public string playerName1;
	public string playerName2;
	public string[] attack = { "Attack", "Power1", "Power2" };
	//TODO: Obtener la lsta usando la tranparencia de datos con alguna forma de pasar la info entre escenas.
	//? ver la manera de como animar segun el personaje y obtener su seleccion
	private void Awake()
	{
		if (ControllerDates.instance != null)
		{
			lstPerson = ControllerDates.instance.listperson;
			if (PlayerPrefs.HasKey("Player1") || PlayerPrefs.HasKey("Player2"))
			{
				Debug.Log(PlayerPrefs.GetString("Player1"));
				playerName1 = PlayerPrefs.GetString("Player1");
				playerName2 = PlayerPrefs.GetString("Player2");
			}
			keyPlayer = new Dictionary<string, string[]>();
			keyPlayer.Add("0" + PlayerPrefs.GetString("Player1"), attack);
			keyPlayer.Add("1" + PlayerPrefs.GetString("Player2"), attack);
			players = new List<List<string>>();
			//Debug.Log(players[0]);
		}
		GenPlayer();
		GenPower();
	}
	private void Start()
	{
		//ControllerDates dates = ControllerDates.instance;
	}
	//-----------------------------------------------------------------//
	public int GenPower()
	{
		int i;
		string[] direc;
		string ruta = Directory.GetCurrentDirectory();
		ruta += "\\Assets\\Resources\\Dragon_Ball_Sagas\\Power\\" + keyPlayer["0" + PlayerPrefs.GetString("Player1")];
		//players[0][1] = "hola";
		//Debug.Log(keyPlayer["0" + PlayerPrefs.GetString("Player1")]);
		if (Directory.Exists(ruta))
		{
			i = 0;
			direc = Directory.GetFiles(ruta);
			/*
			powerlst = Directory.GetFiles(direc[1], "*.png");
			while (i < direc.Length)
			{
				Debug.Log(direc[i]);
				i++;
			}*/
			//Debug.Log(powerlst[0]);
		}
		return (0);
	}
	private void GenPlayer()
	{
		Sprite addSprite1 = Resources.Load<Sprite>("Dragon_Ball_Sagas/1_Select_characters/" + playerName1);
		Sprite addSprite2 = Resources.Load<Sprite>("Dragon_Ball_Sagas/1_Select_characters/" + playerName2);
		imgPlayer1.GetComponent<RawImage>().texture = addSprite1.texture;
		imgPlayer2.GetComponent<RawImage>().texture = addSprite2.texture;
		imgPlayer1.name = playerName1;
		imgPlayer2.name = playerName2;
	}
}
