using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour {
	public Battle battle;
	[Range(0,3)]
	public int moveIndex;
	public Text buttonText;

	BattleMove move;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		move = battle.playerMonster.moves[moveIndex];

		if (move != null) {
			buttonText.text = string.Format("{0}\nTYPE: {1}    POW: {2}    ACC: {3}",
				move.attackName,
				move.element.ToString(),
				move.baseDamage,
				move.baseAccuracy
			);
		} else {
			buttonText.text = "NO MOVE";
		}
	}

	public void ClickAction(){
		battle.UseBattleMove (moveIndex, battle.GetTarget (battle.playerMonster, move.targetingType));
	}

}
