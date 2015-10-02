﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;
    
    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items;
    using GW2NET.V1.Items.Json;

    public sealed partial class ItemConverter : IConverter<ItemDTO, Item>
	{
	    private readonly ITypeConverterFactory<ItemDTO, Item> converterFactory;

		private ItemConverter(ITypeConverterFactory<ItemDTO, Item> converterFactory)
		{
		    if (converterFactory == null)
    		{
    		    throw new ArgumentNullException("converterFactory");
    		}

		    this.converterFactory = converterFactory;
		}

		 /// <inheritdoc />
        Item IConverter<ItemDTO, Item>.Convert(ItemDTO value, object state)
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

		// Implement this method in a buddy class to set properties that are specific to 'Item' (if any)
    	partial void Merge(Item entity, ItemDTO dto, object state);

		/*
		// Use this template
		public partial class ItemConverter
		{
		    partial void Merge(Item entity, ItemDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
	}

#region Backpack
    /// <summary>Converts objects of type <see cref="ItemDTO"/> to objects of type <see cref="Backpack"/>.</summary>
    public sealed partial class BackpackConverter : IConverter<ItemDTO, Backpack>
    {
	    /// <inheritdoc />
        public Backpack Convert(ItemDTO value, object state)
        {    
    		var entity = new Backpack();
            this.Merge(entity, value, state);
    		return entity;
        }
    
    	// Implement this method in a buddy class to set properties that are specific to 'Backpack' (if any)
    	partial void Merge(Backpack entity, ItemDTO dto, object state);

		/*
		// Use this template
		public partial class BackpackConverter
		{
		    partial void Merge(Backpack entity, ItemDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region Bag
    /// <summary>Converts objects of type <see cref="ItemDTO"/> to objects of type <see cref="Bag"/>.</summary>
    public sealed partial class BagConverter : IConverter<ItemDTO, Bag>
    {
	    /// <inheritdoc />
        public Bag Convert(ItemDTO value, object state)
        {    
    		var entity = new Bag();
            this.Merge(entity, value, state);
    		return entity;
        }
    
    	// Implement this method in a buddy class to set properties that are specific to 'Bag' (if any)
    	partial void Merge(Bag entity, ItemDTO dto, object state);

		/*
		// Use this template
		public partial class BagConverter
		{
		    partial void Merge(Bag entity, ItemDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region CraftingMaterial
    /// <summary>Converts objects of type <see cref="ItemDTO"/> to objects of type <see cref="CraftingMaterial"/>.</summary>
    public sealed partial class CraftingMaterialConverter : IConverter<ItemDTO, CraftingMaterial>
    {
	    /// <inheritdoc />
        public CraftingMaterial Convert(ItemDTO value, object state)
        {    
    		var entity = new CraftingMaterial();
            this.Merge(entity, value, state);
    		return entity;
        }
    
    	// Implement this method in a buddy class to set properties that are specific to 'CraftingMaterial' (if any)
    	partial void Merge(CraftingMaterial entity, ItemDTO dto, object state);

		/*
		// Use this template
		public partial class CraftingMaterialConverter
		{
		    partial void Merge(CraftingMaterial entity, ItemDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region Miniature
    /// <summary>Converts objects of type <see cref="ItemDTO"/> to objects of type <see cref="Miniature"/>.</summary>
    public sealed partial class MiniatureConverter : IConverter<ItemDTO, Miniature>
    {
	    /// <inheritdoc />
        public Miniature Convert(ItemDTO value, object state)
        {    
    		var entity = new Miniature();
            this.Merge(entity, value, state);
    		return entity;
        }
    
    	// Implement this method in a buddy class to set properties that are specific to 'Miniature' (if any)
    	partial void Merge(Miniature entity, ItemDTO dto, object state);

		/*
		// Use this template
		public partial class MiniatureConverter
		{
		    partial void Merge(Miniature entity, ItemDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region TraitGuide
    /// <summary>Converts objects of type <see cref="ItemDTO"/> to objects of type <see cref="TraitGuide"/>.</summary>
    public sealed partial class TraitGuideConverter : IConverter<ItemDTO, TraitGuide>
    {
	    /// <inheritdoc />
        public TraitGuide Convert(ItemDTO value, object state)
        {    
    		var entity = new TraitGuide();
            this.Merge(entity, value, state);
    		return entity;
        }
    
    	// Implement this method in a buddy class to set properties that are specific to 'TraitGuide' (if any)
    	partial void Merge(TraitGuide entity, ItemDTO dto, object state);

		/*
		// Use this template
		public partial class TraitGuideConverter
		{
		    partial void Merge(TraitGuide entity, ItemDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region Trophy
    /// <summary>Converts objects of type <see cref="ItemDTO"/> to objects of type <see cref="Trophy"/>.</summary>
    public sealed partial class TrophyConverter : IConverter<ItemDTO, Trophy>
    {
	    /// <inheritdoc />
        public Trophy Convert(ItemDTO value, object state)
        {    
    		var entity = new Trophy();
            this.Merge(entity, value, state);
    		return entity;
        }
    
    	// Implement this method in a buddy class to set properties that are specific to 'Trophy' (if any)
    	partial void Merge(Trophy entity, ItemDTO dto, object state);

		/*
		// Use this template
		public partial class TrophyConverter
		{
		    partial void Merge(Trophy entity, ItemDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

#region UnknownItem
    /// <summary>Converts objects of type <see cref="ItemDTO"/> to objects of type <see cref="UnknownItem"/>.</summary>
    public sealed partial class UnknownItemConverter : IConverter<ItemDTO, UnknownItem>
    {
	    /// <inheritdoc />
        public UnknownItem Convert(ItemDTO value, object state)
        {    
    		var entity = new UnknownItem();
            this.Merge(entity, value, state);
    		return entity;
        }
    
    	// Implement this method in a buddy class to set properties that are specific to 'UnknownItem' (if any)
    	partial void Merge(UnknownItem entity, ItemDTO dto, object state);

		/*
		// Use this template
		public partial class UnknownItemConverter
		{
		    partial void Merge(UnknownItem entity, ItemDTO dto, object state)
			{
			    throw new NotImplementedException();
			}
		}
		*/
    }
#endregion

}
