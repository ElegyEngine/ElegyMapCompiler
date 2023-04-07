// SPDX-FileCopyrightText: 2023 Admer Šuko
// SPDX-License-Identifier: MIT

// This could maybe get moved to Elegy.Common

namespace Elegy.MapCompiler.Data
{
	[Flags]
	public enum MaterialFlag
	{
		None = 0,

		/// <summary>
		/// This is a tool material.
		/// It will not be visually present in the level.
		/// </summary>
		Tool = 1,

		/// <summary>
		/// This surface isn't drawn.
		/// </summary>
		NoDraw = 2,

		/// <summary>
		/// This is used to determine centres of brush entities.
		/// </summary>
		Origin = 4,

		/// <summary>
		/// This surface acts as a runtime occluder.
		/// </summary>
		Occluder = 8,

		/// <summary>
		/// Explicitly disable all shadowmaps on this surface.
		/// </summary>
		ForceNoShadows = 16,

		/// <summary>
		/// This surface is marked explicitly as a back face.
		/// Not to be confused with backface culling/twosidedness.
		/// </summary>
		Culled = 32,

		/// <summary>
		/// Same as ForceNoShadows, but for lightmapping.
		/// </summary>
		ForceNoShadowsLightmap = 64,

		/// <summary>
		/// This surface has no collision.
		/// </summary>
		NoCollision = 128,


	};
}
