using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cegar : MonoBehaviour, IPowerUP
{

	Alien target;
	[SerializeField]
	Transform cegoSprite;

	Transform cegoSpriteClone;

	public void ExecutePowerUP(Alien target)
	{
		this.target = target;
		AtivarCongelar();
	}

	//Metodo chamado pelo Alien inimigo para ativar o cegamento
	void AtivarCongelar()
	{
		target.AtivarCegar(false);
		cegoSpriteClone = Instantiate(cegoSprite, new Vector3(target.transform.position.x, target.transform.position.y + 1.2f, target.transform.position.z),
										target.transform.rotation, target.transform);
		StartCoroutine(Descegar());
	}

	//Funcao para descegar
	IEnumerator Descegar()
	{
		yield return new WaitForSeconds(10.0f);
		Destroy(cegoSpriteClone.gameObject);
		target.AtivarCegar(true);
		Destroy(gameObject);
	}
}
