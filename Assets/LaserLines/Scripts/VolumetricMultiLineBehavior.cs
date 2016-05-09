using UnityEngine;
using System.Collections;

namespace VolumetricLines
{
	/// <summary>
	/// Render a line strip consisting of multiple VolumetricLineBehavior pieces stitched together
	/// 
	/// Based on the Volumetric lines algorithm by Sébastien Hillaire
	/// http://sebastien.hillaire.free.fr/index.php?option=com_content&view=article&id=57&Itemid=74
	/// 
	/// Thread in the Unity3D Forum:
	/// http://forum.unity3d.com/threads/181618-Volumetric-lines
	/// 
	/// Unity3D port by Johannes Unterguggenberger
	/// johannes.unterguggenberger@gmail.com
	/// 
	/// Thanks to Michael Probst for support during development.
	/// 
	/// Thanks for bugfixes and improvements to Unity Forum User "Mistale"
	/// http://forum.unity3d.com/members/102350-Mistale
	/// </summary>
	public class VolumetricMultiLineBehavior : MonoBehaviour 
	{
		/// <summary>
		/// Set to true to update the line vertices every frame.
		/// Use this option for lines multi lines which change their shape.
		/// Set to false for better performance.
		/// </summary>
		public bool m_dynamic;

		/// <summary>
		/// Prefab for a single volumetric line to be instantiated multiple times
		/// </summary>
		public GameObject m_volumetricLinePrefab;

		/// <summary>
		/// The vertices where 2 adjacent multi lines touch each other. 
		/// The end of line 1 is the start of line 2, etc.
		/// </summary>
		public Vector3[] m_lineVertices;

		private VolumetricLineBehavior[] m_volumetricLines;

		void Start () 
		{
			m_volumetricLines = new VolumetricLineBehavior[m_lineVertices.Length - 1];
			for (int i=0; i < m_lineVertices.Length - 1; ++i)
			{
				var go = GameObject.Instantiate(m_volumetricLinePrefab) as GameObject;
				go.transform.parent = gameObject.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localRotation = Quaternion.identity;
				
				var volLine = go.GetComponent<VolumetricLineBehavior>();
				volLine.StartPos = m_lineVertices[i];
				volLine.EndPos = m_lineVertices[i+1];
				
				m_volumetricLines[i] = volLine;
			}
		}

		/// <summary>
		/// Update the vertices of this multi line.
		/// </summary>
		/// <param name="newSetOfVertices">New set of vertices.</param>
		public void UpdateLineVertices(Vector3[] newSetOfVertices)
		{
			m_lineVertices = newSetOfVertices;
			for (int i=0; i < m_lineVertices.Length - 1; ++i)
			{
				m_volumetricLines[i].SetStartAndEndPoints(m_lineVertices[i], m_lineVertices[i+1]);
			}
		}
		
		void Update () 
		{
			if (m_dynamic)
			{
				// Dynamic behavior means: update vertices in every frame. (probably expensive)
				UpdateLineVertices(m_lineVertices);
			}
		}
		
		void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			for (int i=0; i < m_lineVertices.Length - 1; ++i)
			{
				Gizmos.DrawLine(gameObject.transform.TransformPoint(m_lineVertices[i]), gameObject.transform.TransformPoint(m_lineVertices[i+1]));
			}
		}
	}
}