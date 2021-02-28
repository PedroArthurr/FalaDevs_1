/*

 Bem vindo ao FalaDevs!

 Seu codigo começa aqui, edite ele para poder usar a chave para abrir a porta!

 Depois Grave um breve video e envie seu projeto para o GitHub, e no grupo Unity Brasil no Facebook,
 poste o link do GitHub com seu projeto e o video feito por você.

 Boa sorte!

 Link GitHub:  https://github.com/RafaelReis891/FalaDevs

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Locked_Door : MonoBehaviour
{
	private bool _locked = true;
	private bool _haveKey;
	private RaycastHit _hit;
	
	private void Update()
	{
		if (! Input.GetKeyDown(KeyCode.E)) return;
		
		if (!Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out _hit, 5f)) return;
		
		if (_hit.collider.CompareTag("Key"))
		{
			Destroy(_hit.transform.gameObject);
			_haveKey = true;
			_locked = false;
		}

		if (_hit.collider.CompareTag("Door") && _haveKey && !_locked)
		{
			GameObject door = _hit.collider.gameObject;
			door.GetComponentInParent<Animator>().SetBool("Open", true);
		}
	}
}
