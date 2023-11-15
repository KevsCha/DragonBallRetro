using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerDates : MonoBehaviour
{
	public static ControllerDates instance;
	public List<string> listperson;

	public List<Powers> powers;

	private void Awake()
	{
		listperson = List_Person();
		//Debug.Log(listperson[0]);
		GenPower();
		Test();
		if (!instance)
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
	private void Test()
	{
		int i = 0;

		while (i < powers.Count)
		{
			Debug.Log(powers[i++].name);
		}
	}
	//-----------------------Genera una lista de  todos los personajes------------------------------//
	//!Cambiar la forma en la que se genera la lista dinamica, 
	/*
	public List<string> List_Person()
	{
		int i = 0;
		int ultimate_pos;
		string[] img_files;
		string character;
		string ruta = Directory.GetCurrentDirectory();
		//string ruta = "Asset/Resources//Dragon_Ball_Sagas/1_Select_characters";
		List<string> listPerson = new();

		ruta += "\\Assets\\Resources\\Dragon_Ball_Sagas\\1_Select_characters";
		if (Directory.Exists(ruta))
		{
			img_files = Directory.GetFiles(ruta, "*.png");
			//Debug.Log(img_files[0]);
			while (i < img_files.Length)
			{
				ultimate_pos = Ultimate_char(img_files[i], '\\');
				character = Str_person(img_files[i], ultimate_pos + 1); ;
				listPerson.Add(character);
				//Debug.Log(character);
				i++;
			}
		}
		return (listPerson);
	}
	*/
	public List<string> List_Person()
	{
		Sprite[] spr = Resources.LoadAll<Sprite>("Dragon_Ball_Sagas/1_Select_characters");
		string[] img_files = spr.Select(sprite => sprite.name).ToArray();
		return new List<string>(img_files);
	}
	public int Ultimate_char(string str, char c)
	{
		int i;

		i = str.Length - 1;
		while (i > 0 && str[i] != c)
			i--;
		return (i);
	}

	public string Str_person(string str, int pos)
	{
		string sub;

		sub = str.Substring(pos);
		return (sub);
	}
	public void GenPower()
	{
		int i;

		i = 0;
		powers = new List<Powers>
		{
			//new Powers {attack = }
		};
		/*
			while (i < listperson.Count)
				powers.Add(new Powers { name = listperson[i++] });
		*/
	}
	public class Powers
	{
		public string name { get; set; }
		public string attack { get; set; } = "";
		public string power1 { get; set; } = "";
		public string power2 { get; set; } = "";
	}
}
