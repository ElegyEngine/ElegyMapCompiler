// SPDX-FileCopyrightText: 2023 Admer Šuko
// SPDX-License-Identifier: MIT

namespace Elegy.MapCompiler.Data.Output
{
	public class CollisionMeshlet
	{
		/// <summary>
		/// Triplets of vector positions, forming collision triangles.
		/// </summary>
		public List<Vector3> Positions { get; set; } = new();

		/// <summary>
		/// Material that this mesh is associated with.
		/// </summary>
		public string MaterialName { get; set; } = string.Empty;
	}

	public class CollisionMesh
	{
		public List<CollisionMeshlet> Meshlets { get; set; } = new();
	}
}
