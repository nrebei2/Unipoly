using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public bool isOver = false;

	public GameObject ImageOfCard;

	private Image spriteRenderer;

	public Sprite CardImage;

	public void Start()
	{
		spriteRenderer = ImageOfCard.GetComponent<Image>(); // we are accessing the Image that is attached to the Gameobject
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("Mouse enter");
		isOver = true;
		ImageOfCard.SetActive(true);
		spriteRenderer.sprite = CardImage;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("Mouse exit");
		ImageOfCard.SetActive(false);
		isOver = false;
	}
}