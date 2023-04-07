// SPDX-FileCopyrightText: 2023 Admer Šuko
// SPDX-License-Identifier: MIT

using Elegy.MapCompiler.Data.Output;

namespace Elegy.MapCompiler.Assets
{
	public class ElegyMapDocument
	{
		//// <summary>
		//// Visibility data.
		//// </summary>
		//public List<MapLeaf> VisibilityLeaves { get; set; } = new();

		/// <summary>
		/// IDs of world meshes.
		/// </summary>
		public List<int> WorldMeshIds { get; set; } = new();

		/// <summary>
		/// Map entities.
		/// </summary>
		public List<Entity> Entities { get; set; } = new();

		/// <summary>
		/// Collision meshes for collision detection.
		/// </summary>
		public List<CollisionMesh> CollisionMeshes { get; set; } = new();

		/// <summary>
		/// Occluder meshes for real-time dynamic occlusion culling.
		/// </summary>
		public List<OccluderMesh> OccluderMeshes { get; set; } = new();

		/// <summary>
		/// Visual renderable meshes.
		/// </summary>
		public List<RenderMesh> RenderMeshes { get; set; } = new();

		public void WriteToFile( string path )
		{
			using var file = File.CreateText( path );

			// TODO: Utility to write & parse in this format
			// NOT JSON

			file.WriteLine( "ElegyLevelFile" );
			file.WriteLine( "{" );

			file.WriteLine( "	WorldMeshIds" );
			file.WriteLine( "	{" );
			file.Write( "		" );
			for ( int i = 0; i < WorldMeshIds.Count; i++ )
			{
				file.Write( $" {WorldMeshIds[i]}" );
			}
			file.WriteLine();
			file.WriteLine( "	}" );

			// Entities
			file.WriteLine( "	Entities" );
			file.WriteLine( "	{" );
			foreach ( var entity in Entities )
			{
				file.WriteLine( "		Entity" );
				file.WriteLine( "		{" );
				file.WriteLine( $"			RenderMeshId {entity.RenderMeshId}" );
				file.WriteLine( $"			CollisionMeshId {entity.CollisionMeshId}" );
				file.WriteLine( $"			OccluderMeshId {entity.OccluderMeshId}" );
				file.WriteLine( "			Attributes" );
				file.WriteLine( "			{" );
				foreach ( var attribute in entity.Attributes )
				{
					file.WriteLine( $"				{attribute.Key} \"{attribute.Value}\"" );
				}
				file.WriteLine( "			}" );
				file.WriteLine( "		}" );
			}
			file.WriteLine( "	}" );

			// Collision meshes
			file.WriteLine( "	CollisionMeshes" );
			file.WriteLine( "	{" );
			foreach ( var mesh in CollisionMeshes )
			{
				file.WriteLine( "		Meshlets" );
				file.WriteLine( "		{" );
				foreach ( var meshlet in mesh.Meshlets )
				{
					file.WriteLine( "			CollisionMeshlet" );
					file.WriteLine( "			{" );
					file.WriteLine( $"				MaterialName \"{meshlet.MaterialName}\"" );
					file.WriteLine( "				Positions" );
					file.WriteLine( "				{" );
					for ( int i = 0; i < meshlet.Positions.Count; i++ )
					{
						file.WriteLine( $"					( {meshlet.Positions[i].X} {meshlet.Positions[i].Y} {meshlet.Positions[i].Z} )" );
					}
					file.WriteLine( "				}" );
					file.WriteLine( "			}" );
				}
				file.WriteLine( "		}" );
			}
			file.WriteLine( "	}" );

			// Occluder meshes
			file.WriteLine( "	OccluderMeshes" );
			file.WriteLine( "	{" );
			foreach ( var mesh in OccluderMeshes )
			{
				file.WriteLine( "		OccluderMesh" );
				file.WriteLine( "		{" );
				file.WriteLine( "			Positions" );
				file.WriteLine( "			{" );
				for ( int i = 0; i < mesh.Positions.Count; i++ )
				{
					file.WriteLine( $"				( {mesh.Positions[i].X} {mesh.Positions[i].Y} {mesh.Positions[i].Z} )" );
				}
				file.WriteLine( "			}" );
				file.WriteLine( "			Indices" );
				file.WriteLine( "			{" );
				file.Write( "				" );
				for ( int i = 0; i < mesh.Indices.Count; i++ )
				{
					file.Write( $" {mesh.Indices[i]}" );
				}
				file.WriteLine();
				file.WriteLine( "			}" );
				file.WriteLine( "		}" );
			}
			file.WriteLine( "	}" );

			// Render meshes
			file.WriteLine( "	RenderMeshes" );
			file.WriteLine( "	{" );
			foreach ( var mesh in RenderMeshes )
			{
				file.WriteLine( "		RenderMesh" );
				file.WriteLine( "		{" );
				file.WriteLine( "			Surfaces" );
				file.WriteLine( "			{" );
				foreach ( var surface in mesh.Surfaces )
				{
					Vector3 boxPosition = surface.BoundingBox.Position;
					Vector3 boxSize = surface.BoundingBox.Size;

					file.WriteLine( "				RenderSurface" );
					file.WriteLine( "				{" );
					file.WriteLine( $"					BoundingBox ( {boxPosition.X} {boxPosition.Y} {boxPosition.Z} ) ( {boxSize.X} {boxSize.Y} {boxSize.Z} )" );
					file.WriteLine( $"					VertexCount {surface.VertexCount}" );
					file.WriteLine( $"					Material \"{surface.Material}\"" );
					file.WriteLine( $"					LightmapTexture \"{surface.LightmapTexture}\"" );
					file.WriteLine( "					Positions" );
					file.WriteLine( "					{" );
					foreach ( var p in surface.Positions )
					{
						file.WriteLine( $"						( {p.X} {p.Y} {p.Z} )" );
					}
					file.WriteLine( "					}" );
					file.WriteLine( "					Normals" );
					file.WriteLine( "					{" );
					foreach ( var p in surface.Normals )
					{
						file.WriteLine( $"						( {p.X} {p.Y} {p.Z} )" );
					}
					file.WriteLine( "					}" );
					file.WriteLine( "					Uvs" );
					file.WriteLine( "					{" );
					foreach ( var p in surface.Uvs )
					{
						file.WriteLine( $"						( {p.X} {p.Y} )" );
					}
					file.WriteLine( "					}" );
					file.WriteLine( "					LightmapUvs" );
					file.WriteLine( "					{" );
					foreach ( var p in surface.LightmapUvs )
					{
						file.WriteLine( $"						( {p.X} {p.Y} )" );
					}
					file.WriteLine( "					}" );
					file.WriteLine( "					Colours" );
					file.WriteLine( "					{" );
					foreach ( var p in surface.Colours )
					{
						file.WriteLine( $"						( {p.X} {p.Y} {p.Z} {p.W} )" );
					}
					file.WriteLine( "					}" );
					file.WriteLine( "					Indices" );
					file.WriteLine( "					{" );
					file.Write( "						" );
					foreach ( var i in surface.Indices )
					{
						file.Write( $" {i}" );
					}
					file.WriteLine();
					file.WriteLine( "					}" );
					file.WriteLine( "				}" );
				}
				file.WriteLine( "			}" );
				file.WriteLine( "		}" );
			}
			file.WriteLine( "	}" );

			file.WriteLine( "}" );
		}
	}
}
