﻿// SPDX-FileCopyrightText: 2023 Admer Šuko
// SPDX-License-Identifier: MIT

namespace Elegy.MapCompiler.Data.Processing
{
	public class Material
	{
		public string Name { get; set; } = string.Empty;
		public int Width { get; set; } = 0;
		public int Height { get; set; } = 0;
		public MaterialFlag Flags { get; set; } = MaterialFlag.None;

		public bool HasFlag( MaterialFlag flag ) => Flags.HasFlag( flag );
	}
}
