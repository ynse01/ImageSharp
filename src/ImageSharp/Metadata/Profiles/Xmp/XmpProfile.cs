// Copyright (c) Six Labors.
// Licensed under the Apache License, Version 2.0.

using System;
using System.IO;
using System.Xml.XPath;

namespace SixLabors.ImageSharp.Metadata.Profiles.Xmp
{
    /// <summary>
    /// Represents an XMP profile providing access to the values as an IXPathNavigable.
    /// </summary>
    public sealed class XmpProfile : IDeepCloneable<XmpProfile>
    {
        /// <summary>
        /// The byte array to read the XMP profile from.
        /// </summary>
        private readonly byte[] data;

        /// <summary>
        /// The XMP profile as a IXPathNavigable.
        /// </summary>
        private IXPathNavigable values;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmpProfile"/> class.
        /// </summary>
        public XmpProfile()
            : this((byte[])null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmpProfile"/> class.
        /// </summary>
        /// <param name="data">The byte array to read the XMP profile from.</param>
        public XmpProfile(byte[] data)
        {
            this.data = data;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmpProfile"/> class
        /// by making a copy from another XMP profile.
        /// </summary>
        /// <param name="other">The other XMP profile, where the clone should be made from.</param>
        /// <exception cref="ArgumentNullException"><paramref name="other"/> is null.</exception>>
        private XmpProfile(XmpProfile other)
        {
            Guard.NotNull(other, nameof(other));

            if (other.data != null)
            {
                this.data = new byte[other.data.Length];
                other.data.AsSpan().CopyTo(this.data);
            }
        }

        /// <summary>
        /// Gets the values of this XMP profile as a IXPathNavigable.
        /// </summary>
        public IXPathNavigable Values
        {
            get
            {
                this.LoadValues();
                return this.values;
            }
        }

        /// <summary>
        /// Gets the byte data for the XMP profile.
        /// </summary>
        public byte[] Data => this.data;

        /// <inheritdoc/>
        public XmpProfile DeepClone() => new XmpProfile(this);

        private void LoadValues()
        {
            using var memoryStream = new MemoryStream(this.data);
            this.values = new XPathDocument(memoryStream);
        }
    }
}
