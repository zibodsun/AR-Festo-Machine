﻿// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
// using System.IO.Packaging;
using System.Xml.Linq;
using ThreeMf.Extensions;

namespace ThreeMf
{
    public class ThreeMfTexture2D : ThreeMfResource
    {
        private const string PathAttributeName = "path";
        private const string ContentTypeAttributeName = "contenttype";
        private const string BoxAttributeName = "box";
        private const string TileStyleUAttributeName = "tilestyleu";
        private const string TileStyleVAttributeName = "tilestylev";
        private const string TextureContentType = "application/vnd.ms-package.3dmanufacturing-3dmodeltexture";
        private const string TextureRelationshipType = "http://schemas.microsoft.com/3dmanufacturing/2013/01/3dtexture";

        private byte[] _textureBytes;

        public ThreeMfImageContentType ContentType { get; set; }
        public ThreeMfBoundingBox BoundingBox { get; set; }
        public ThreeMfTileStyle TileStyleU { get; set; }
        public ThreeMfTileStyle TileStyleV { get; set; }

        public byte[] TextureBytes
        {
            get => _textureBytes;
            set => _textureBytes = value ?? throw new ArgumentNullException(nameof(value));
        }

        public ThreeMfTexture2D(byte[] textureBytes, ThreeMfImageContentType contentType)
        {
            BoundingBox = ThreeMfBoundingBox.Default;
            TextureBytes = textureBytes;
            ContentType = contentType;
        }

        internal override XElement ToXElement(Dictionary<ThreeMfResource, int> resourceMap, ThreeMfArchiveBuilder archiveBuilder)
        {
            var path = $"/3D/Textures/{Guid.NewGuid().ToString("N")}{ContentType.ToExtensionString()}";
            archiveBuilder.WriteBinaryDataToArchive(path, TextureBytes, TextureRelationshipType, TextureContentType);
            return new XElement(Texture2DName,
                new XAttribute(IdAttributeName, Id),
                new XAttribute(PathAttributeName, path),
                new XAttribute(ContentTypeAttributeName, ContentType.ToContentTypeString()),
                BoundingBox.ToXAttribute(),
                TileStyleU == ThreeMfTileStyle.Wrap ? null : new XAttribute(TileStyleUAttributeName, TileStyleU.ToTileStyleString()),
                TileStyleV == ThreeMfTileStyle.Wrap ? null : new XAttribute(TileStyleVAttributeName, TileStyleV.ToTileStyleString()));
        }

        internal static ThreeMfTexture2D ParseTexture(XElement element, string package)
        {
            var path = element.AttributeValueOrThrow(PathAttributeName);
            var id = element.AttributeIntValueOrThrow(IdAttributeName);
            var textureBytes = new byte[0]; //  var textureBytes = package.GetPartBytes(path); // game4automation
            var contentType = ThreeMfImageContentTypeExtensions.ParseContentType(element.AttributeValueOrThrow(ContentTypeAttributeName));
            var texture = new ThreeMfTexture2D(textureBytes, contentType)
            {
                BoundingBox = ThreeMfBoundingBox.ParseBoundingBox(element.Attribute(ThreeMfBoundingBox.BoundingBoxAttributeName)?.Value),
                TileStyleU = ThreeMfTileStyleExtensions.ParseTileStyle(element.Attribute(TileStyleUAttributeName)?.Value),
                TileStyleV = ThreeMfTileStyleExtensions.ParseTileStyle(element.Attribute(TileStyleVAttributeName)?.Value)
            };

            texture.Id = id;
            return texture;
        }
    }
}
