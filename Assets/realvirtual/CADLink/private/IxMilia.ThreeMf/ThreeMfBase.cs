﻿// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Xml.Linq;
using ThreeMf.Extensions;

namespace ThreeMf
{
    public class ThreeMfBase : IThreeMfPropertyItem
    {
        private const string NameAttributeName = "name";
        private const string DisplayColorAttributeName = "displaycolor";

        internal static XName BaseName = XName.Get("base", ThreeMfModel.ModelNamespace);

        public string Name { get; set; }
        public ThreeMfsRGBColor Color { get; set; }

        public ThreeMfBase(string name, ThreeMfsRGBColor color)
        {
            Name = name;
            Color = color;
        }

        internal XElement ToXElement()
        {
            return new XElement(BaseName,
                new XAttribute(NameAttributeName, Name),
                new XAttribute(DisplayColorAttributeName, Color.ToString()));
        }

        internal static ThreeMfBase ParseBaseMaterial(XElement baseElement)
        {
            var name = baseElement.AttributeValueOrThrow(NameAttributeName);
            var color = ThreeMfsRGBColor.Parse(baseElement.AttributeValueOrThrow(DisplayColorAttributeName));
            return new ThreeMfBase(name, color);
        }
    }
}
