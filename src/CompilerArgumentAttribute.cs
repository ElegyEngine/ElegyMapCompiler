// SPDX-FileCopyrightText: 2023 Admer Šuko
// SPDX-License-Identifier: MIT

// This does not actually work yet

namespace Elegy.MapCompiler
{
	public enum ArgumentType
	{
		Path,
		Enum,
		Number,
		Flag
	}

	[AttributeUsage( AttributeTargets.Property, AllowMultiple = false )]
	public abstract class CompilerArgAttribute : Attribute
	{
		public string Name { get; set; }

		public CompilerArgAttribute( string name )
		{
			Name = name;
		}
	}

	[AttributeUsage( AttributeTargets.Property, AllowMultiple = false )]
	public class PathArgAttribute : CompilerArgAttribute
	{
		public PathArgAttribute( string name )
			: base( name )
		{
		}
	}

	[AttributeUsage( AttributeTargets.Property, AllowMultiple = false )]
	public class EnumArgAttribute : CompilerArgAttribute
	{
		public EnumArgAttribute( string name )
			: base( name )
		{
		}
	}

	[AttributeUsage( AttributeTargets.Property, AllowMultiple = false )]
	public class FloatArgAttribute : CompilerArgAttribute
	{
		public FloatArgAttribute( string name )
			: base( name )
		{
		}
	}
}
