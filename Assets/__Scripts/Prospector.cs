using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Prospector : MonoBehaviour {

	static public Prospector 	S;
	public Deck					deck;
	public TextAsset			deckXML;

	public Layout 				layout;
	public TextAsset 			layoutXML;

	public List<CardProspector> drawpile;

	void Awake(){
		S = this;
	}

	void Start() {
		deck = GetComponent<Deck> ();
		deck.InitDeck (deckXML.text);
		Deck.Shuffle (ref deck.cards);

		layout = GetComponent<Layout> ();
		layout.ReadLayout (layoutXML.text);
		drawpile = ConvertListCardsToListCardProspectors(deck.cards);
	}

	List<CardProspector> ConvertListCardsToListCardProspectors(List<Card> lCD)
	{
			List<CardProspector> lCP = new List<CardProspector>();
			CardProspector tCP;
			foreach(Card tCD in lCD)
			{
				tCP =tCD as CardProspector;
				lCP.Add(tCP);
			}
			return(lCP);
	}

}
