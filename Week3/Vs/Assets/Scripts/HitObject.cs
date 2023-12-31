using UnityEngine;
using System.Collections;

/*
 *	Collider を使ってヒットするものの基底クラス
 *	Maruchu
 */
public class HitObject : MonoBehaviour {

	//충돌 판정 그룹
	public enum HitGroup {
		 Player1		//플레이어1그룹
		,Player2		//플레이어2그룹
		,Other			//그 외(벽 등)
	}

	public HitGroup	m_hitGroup = HitGroup.Player1;      //자신의 충돌 판정 그룹

    /*
	 *	Collider 닿아도 괜찮은지 확인
	 */
    protected bool	IsHitOK( GameObject hittedObject) {

		//상대가 같은 스크립트 가지고 있는지 확인
		HitObject	hit	= hittedObject.GetComponent<HitObject>();

		//같은 스크립트 안 갖고 있으면 충돌 x
		if( null==hit) {
			return false;
		}

		//같은 그룹은 충돌 x
		if( m_hitGroup==hit.m_hitGroup) {
			return false;
		}

		//다른 그룹은 충돌 o
		return	true;
	}






}
