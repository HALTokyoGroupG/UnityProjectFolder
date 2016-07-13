using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
	private LocalMove localmove;
	public LayerMask layermask;

	//==============================
	// ゲームの初期化処理
	//==============================
	void Awake()
	{
		localmove = GameManager.instance.GetComponent<LocalMove>();
	}

	//==============================
	// ゲームの更新処理
	//==============================
	void Update()
	{
		Vector3 pos = transform.position;
		Vector2 vect = new Vector2(0,0);

		if (localmove.LimitHit())
		{
			vect.x -= localmove.GetMovement();
			RaycastHit2D hit = Physics2D.Raycast(pos, vect, 0.1f, layermask);
			if (hit.collider != null)
			{
				if (hit.collider.gameObject.GetComponent<AreaMoveTrigger>().GetNextAreaID() == 0)
				{
					GameManager.instance.GetComponent<LocalMove>().StopMove();
					vect.x = 0.0f;
				}
			}
			pos.x += vect.x;

		}

		if ( Mathf.Abs(pos.x) < 0.04f)
		{
			pos.x = 0.0f;
			localmove.SetLimitFlag(false);
		}


		transform.position = pos;
	}

}

