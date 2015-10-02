﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GW2NET.V1.Skins.Converters
{
    using System;
    
    using GW2NET.Common;
    using GW2NET.Skins;
    using GW2NET.V1.Skins.Json;

    public sealed partial class SkinConverter : IConverter<SkinDTO, Skin>
	{
	    private readonly ITypeConverterFactory<SkinDTO, Skin> converterFactory;

		private SkinConverter(ITypeConverterFactory<SkinDTO, Skin> converterFactory)
		{
		    if (converterFactory == null)
    		{
    		    throw new ArgumentNullException("converterFactory");
    		}

		    this.converterFactory = converterFactory;
		}

		 /// <inheritdoc />
        Skin IConverter<SkinDTO, Skin>.Convert(SkinDTO value, object state)
		{
		    if (value == null)
    		{
    		    throw new ArgumentNullException("value");
    		}

			string discriminator = value.Type;
			var converter = this.converterFactory.Create(discriminator);
			var entity = converter.Convert(value, value);
			this.Merge(entity, value, state);
			return entity;
		}

		// Implement this method in a buddy class to set properties that are specific to 'Skin' (if any)
    	partial void Merge(Skin entity, SkinDTO dto, object state);

		/*
		// Use this template
		public partial class SkinConverter
		{
		    partial void Merge(Skin entity, SkinDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
	}

#region BackpackSkin
    /// <summary>Converts objects of type <see cref="SkinDTO"/> to objects of type <see cref="BackpackSkin"/>.</summary>
    public sealed partial class BackpackSkinConverter : IConverter<SkinDTO, BackpackSkin>
    {
	    /// <inheritdoc />
        public BackpackSkin Convert(SkinDTO value, object state)
        {    
    		var entity = new BackpackSkin();
            this.Merge(entity, value, state);
    		return entity;
        }
    
    	// Implement this method in a buddy class to set properties that are specific to 'BackpackSkin' (if any)
    	partial void Merge(BackpackSkin entity, SkinDTO dto, object state);

		/*
		// Use this template
		public partial class BackpackSkinConverter
		{
		    partial void Merge(BackpackSkin entity, SkinDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region UnknownSkin
    /// <summary>Converts objects of type <see cref="SkinDTO"/> to objects of type <see cref="UnknownSkin"/>.</summary>
    public sealed partial class UnknownSkinConverter : IConverter<SkinDTO, UnknownSkin>
    {
	    /// <inheritdoc />
        public UnknownSkin Convert(SkinDTO value, object state)
        {    
    		var entity = new UnknownSkin();
            this.Merge(entity, value, state);
    		return entity;
        }
    
    	// Implement this method in a buddy class to set properties that are specific to 'UnknownSkin' (if any)
    	partial void Merge(UnknownSkin entity, SkinDTO dto, object state);

		/*
		// Use this template
		public partial class UnknownSkinConverter
		{
		    partial void Merge(UnknownSkin entity, SkinDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

}
