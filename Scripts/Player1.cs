using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{
	//TODO: Hacer un selector de personajes,  formar el codigo mediante comunicacion de scripts, Obtener lo datos de la lista de botones con los nombres de personajes.
	public Gen_Person scripPerson;
	public TextMeshPro txtPlayer1;
	public GameObject imgPlayer1;
	public Vector3 posTest1;
	//public Vector3 posTest2;
	public List<string> list;
	public bool blockbtn = false;
	public int pos_Character;


	private void Start()
	{
		list = ControllerDates.instance.listperson;
		posTest1 = this.gameObject.transform.position;
	}
	private void OnTriggerEnter(Collider other)
	{
		int i;
		if (other.gameObject.CompareTag("Characters"))
		{
			i = 0;

			while (other.name != scripPerson.btn_objs[i].name)
				i++;
			this.gameObject.transform.position = scripPerson.btn_objs[i].transform.position;
			Change_Person(scripPerson.btn_objs[i].name);
			GnSprite_Player1(scripPerson.btn_objs[i].name, i);

		}
	}
	//--------------------------------Cambia la seleccion de txt del personaje---------------------------------//
	public void Change_Person(string name)
	{
		if (txtPlayer1.GetComponent<TextMeshPro>() != null)
		{
			txtPlayer1.GetComponent<TextMeshPro>().enableAutoSizing = true;
			txtPlayer1.GetComponent<TextMeshPro>().fontSizeMax = 50f;
			txtPlayer1.GetComponent<TextMeshPro>().fontSizeMin = 12f;
		}
		txtPlayer1.text = name;
	}
	//-------------------------------Genera la selecion del player1-------------------------------//
	public void GnSprite_Player1(string str, int i)
	{
		string name = list[i];


		//name = list[i].Substring(0, Ultimate_char(list[i], '.'));
		if (name == str)
		{
			Debug.Log(str);
			Sprite genPlayer1 = Resources.Load<Sprite>("Dragon_Ball_Sagas/1_Select_characters/" + str);
			imgPlayer1.GetComponent<RawImage>().texture = genPlayer1.texture;
			pos_Character = i;
		}
	}

	public int Ultimate_char(string str, char c)
	{
		int i;

		i = str.Length - 1;
		while (str[i] != c && i > 0)
			i--;
		return (i);
	}
}
