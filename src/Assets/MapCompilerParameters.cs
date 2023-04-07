// SPDX-FileCopyrightText: 2023 Admer Šuko
// SPDX-License-Identifier: MIT

namespace Elegy.MapCompiler.Assets
{
	public class MapCompilerParameters
	{
		[PathArg( "-map" )]
		public string MapFile { get; set; } = string.Empty;

		[PathArg( "-out" )]
		public string OutputPath { get; set; } = string.Empty;

		[PathArg( "-gamedirectory" )]
		public string GameDirectory { get; set; } = string.Empty;

		[FloatArg( "-debugfreeze" )]
		public float DebugFreeze { get; set; } = 0.0f;
	}
}
