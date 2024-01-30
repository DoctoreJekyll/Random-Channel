using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
	//public ScoreManager score;

	//float tempEncaje = 2.65f; //JOSE PARA ENCAJAR SUELO
	//public GameObject[] groundObject;
	//public GameObject[] obj;

	//[SerializeField] float[] tiempoSuelo; //= { 2.2f, 2.65f, 2.95f, 2.2001f };
	//[SerializeField] float[] tiempoAparicion; //= { 2f, 3f };

	//private bool fin = false;
			
	//bool dificultad;
	//int tiempoIzqDificultad;
	//int tiempoDerDificultad;
	////Y esto para que no comiencen desde justo el principio a aparecer enemigos
	//bool gameIsStart = false;
	////
	

	//// Use this for initialization
	//void Start()
	//{
	//	//Generar ();
	//	//NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeEmpiezaACorrer");
	//	//NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
		
	//	//Para generar enemigos no justo al principio
	//	StartCoroutine(generarEnemigosOk());
	//}

	//void PersonajeHaMuerto()
	//{
	//	fin = true;
	//}


	////void PersonajeEmpiezaACorrer(Notification notification)
	////{
	////	Generar();
	////}

	
	//void controlarDificultad()
	//{
	//	if (score.meters > 240f)
	//	{
	//		tiempoIzqDificultad = 0;
	//		tiempoDerDificultad = 1;
	//	}
	//	else if (score.meters < 240f && score.meters > 180f)
	//	{
	//		tiempoIzqDificultad = 2;
	//		tiempoDerDificultad = 3;
	//	}
	//	else if (score.meters < 180f && score.meters > 120f)
	//	{
	//		tiempoIzqDificultad = 4;
	//		tiempoDerDificultad = 5;
	//	}
	//	else if (score.meters < 120f && score.meters > 60f)
	//	{
	//		tiempoIzqDificultad = 6;
	//		tiempoDerDificultad = 7;
	//	}
	//	else if (score.meters < 60f)
	//	{
	//		tiempoIzqDificultad = 8;
	//		tiempoDerDificultad = 9;
	//	}

	//}

	//public IEnumerator generarEnemigosOk()
	//{ //Prueba Moyo para que los enemigos empiecen guay
	//	yield return new WaitForSeconds(7.0f);
	//	//comienzoEnemigosOk = true;

	//}


	//void Generar()
	//{
	//	controlarDificultad();
	//	if (!fin)
	//	{
	//		if (this.gameObject.name == "GeneradorEnemigo1" || this.gameObject.name == "GeneradorEnemigo2" || this.gameObject.name == "GeneradorEnemigo3")
	//		{

	//			//if (comienzoEnemigosOk)
	//			//{

	//				Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
	//				//Instantiate (obj [Random.Range (0, obj.Length)], new Vector3(transform.position.x, (transform.position.y + valorDiferencia), transform.position.z), Quaternion.identity);
	//			//}

	//			Invoke("Generar", tiempoAparicion[Random.Range(tiempoIzqDificultad, tiempoDerDificultad)]);
	//			Debug.Log("Tiempo enemigos aparicion");
	//			Debug.Log(tiempoIzqDificultad);
	//		}



	//		if (this.gameObject.name == "GeneradorVentana")
	//		{
	//			Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
	//			Invoke("Generar", tiempoAparicion[Random.Range(0, tiempoAparicion.Length)]);

	//		}

	//		if (this.gameObject.name == "GeneradorItem")
	//		{
	//			Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
	//			Invoke("Generar", tiempoAparicion[Random.Range(0, tiempoAparicion.Length)]);
	//		}


	//		if (this.gameObject.name == "Generador")
	//		{
	//			if (tempEncaje == 2.2f)
	//			{
	//				Instantiate(groundObject[0], transform.position, Quaternion.identity);
	//			}
	//			else if (tempEncaje == 2.2001f)
	//			{
	//				Instantiate(groundObject[0], transform.position, Quaternion.identity);
	//			}
	//			else if (tempEncaje == 2.65f)
	//			{
	//				Instantiate(groundObject[1], transform.position, Quaternion.identity);
	//			}
	//			else
	//			{
	//				Instantiate(groundObject[2], transform.position, Quaternion.identity);
	//			}

	//			tempEncaje = tiempoSuelo[Random.Range(0, tiempoSuelo.Length)];
	//			Debug.Log(tempEncaje);
	//			Invoke("Generar", tempEncaje);
	//		}
	//	}

	//}
}
