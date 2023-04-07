// SPDX-FileCopyrightText: 2023 Admer Šuko
// SPDX-License-Identifier: MIT

namespace Elegy.MapCompiler.Data.Output
{
	public class RenderSurface
	{
		public Aabb BoundingBox = new();
		public List<Vector3> Positions = new();
		public List<Vector3> Normals = new();
		public List<Vector2> Uvs = new();
		public List<Vector2> LightmapUvs = new();
		public List<Vector4> Colours = new();
		public List<int> Indices = new();
		public int VertexCount = 0;

		public string Material = string.Empty;
		public string LightmapTexture = string.Empty;
	}
}
