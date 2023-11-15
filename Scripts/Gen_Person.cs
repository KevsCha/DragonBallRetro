using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class Gen_Person : MonoBehaviour
{
	public Canvas canvas;
	public Button btn_characters;
	public List<string> list_Person;
	public GameObject[] btn_objs;
	public GameObject[] btn_texts;
	public GameObject cubeplayer1;
	public GameObject cubeplayer2;
	public TextMeshPro txtPlayer1;
	public TextMeshPro txtPlayer2;
	public GameObject imgPlayer1;
	public GameObject imgPlayer2;
	public bool blockbtnPlayer1 = false;
	public bool blockbtnPlayer2 = false;
	public int pos_Character1 = 0;
	public int pos_Character2 = 8;


	//-------------------------Ejecuta un frame antes busca los objetos con su respectivo tag-----------------------------//
	private void Awake()
	{
		btn_objs = GameObject.FindGameObjectsWithTag("Characters");
		list_Person = ControllerDates.instance.listperson;
		Ch_text_Btn();
		Gn_sprites_Btn();
	}
	//--------------------------ft que genera cambios al txt de todos los botones-----------------------------//
	public void Ch_text_Btn()
	{
		int i = 0;
		//string subStr;
		btn_texts = GameObject.FindGameObjectsWithTag("Nomb_person");
		foreach (string str in list_Person)
		{
			//subStr = str.Substring(0, Ultimate_char(str, '.'));
			//btn_texts[i].GetComponent<TextMeshProUGUI>().text = subStr;
			btn_texts[i].GetComponent<TextMeshProUGUI>().text = str;
			i++;
		}
	}
	//---------------------------ft_genera cambio en los botones-------------------------------------------------------//
	public void Gn_sprites_Btn()
	{
		int i = 0;
		foreach (string str in list_Person)
		{
			//string sub = str.Substring(0, Ultimate_char(str, '.'));
			Sprite addSprite = Resources.Load<Sprite>("Dragon_Ball_Sagas/1_Select_characters/" + str);
			btn_objs[i].name = str;
			btn_objs[i].GetComponent<Image>().sprite = addSprite;
			i++;
		}

	}
	//----------------------------Guardar datos y cambiar de escena--------------------------------//
	private void ChangeScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	private void Update()
	{
		//-----------------------------Player1-----------------------------------//
		float posX = btn_objs[0].transform.position.x - btn_objs[1].transform.position.x;
		float posY = btn_objs[0].transform.position.y - btn_objs[9].transform.position.y;
		if (Input.GetKeyDown(KeyCode.A) && !blockbtnPlayer1)
			cubeplayer1.transform.position += new Vector3(posX, 0, 0);
		if (Input.GetKeyDown(KeyCode.D) && !blockbtnPlayer1)
			cubeplayer1.transform.position += new Vector3(-posX, 0, 0);
		if (Input.GetKeyDown(KeyCode.W) && !blockbtnPlayer1)
			cubeplayer1.transform.position += new Vector3(0, posY, 0);
		if (Input.GetKeyDown(KeyCode.S) && !blockbtnPlayer1)
			cubeplayer1.transform.position += new Vector3(0, -posY, 0);
		if (Input.GetKeyDown(KeyCode.Return))
		{
			pos_Character1 = cubeplayer1.GetComponent<Player1>().pos_Character;
			string name = btn_objs[pos_Character1].name;
			PlayerPrefs.SetString("Player1", name);
			blockbtnPlayer1 = true;
			Debug.Log(PlayerPrefs.GetString("Player1"));
		}
		if (Input.GetKeyDown(KeyCode.Escape))
			blockbtnPlayer1 = false;
		if (Input.GetKeyDown(KeyCode.O))
			PlayerPrefs.DeleteKey("Player1");
		//-----------------------------Player2-------------------------------------//
		if (Input.GetKeyDown(KeyCode.LeftArrow) && !blockbtnPlayer2)
			cubeplayer2.transform.position += new Vector3(posX, 0, 0);
		if (Input.GetKeyDown(KeyCode.RightArrow) && !blockbtnPlayer2)
			cubeplayer2.transform.position += new Vector3(-posX, 0, 0);
		if (Input.GetKeyDown(KeyCode.UpArrow) && !blockbtnPlayer2)
			cubeplayer2.transform.position += new Vector3(0, posY, 0);
		if (Input.GetKeyDown(KeyCode.DownArrow) && !blockbtnPlayer2)
			cubeplayer2.transform.position += new Vector3(0, -posY, 0);
		if (Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			pos_Character2 = cubeplayer2.GetComponent<Player1>().pos_Character;
			string name = btn_objs[pos_Character2].name;

			PlayerPrefs.SetString("Player2", name);
			blockbtnPlayer2 = true;
			Debug.Log(PlayerPrefs.GetString("Player2"));

		}
		if (Input.GetKeyDown(KeyCode.KeypadPlus))
			blockbtnPlayer2 = false;
		if (Input.GetKeyDown(KeyCode.O))
			PlayerPrefs.DeleteKey("Player2");

		if (PlayerPrefs.HasKey("Player1") && PlayerPrefs.HasKey("Player2"))
			ChangeScene();

	}
	/*	
	public void Salir() 
	{
		Application.Quit();
	}
	*/
	//-----------------------FT_adicionales------------------------//
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
		string subStr;
		subStr = str.Substring(pos);
		return (subStr);
	}
}
