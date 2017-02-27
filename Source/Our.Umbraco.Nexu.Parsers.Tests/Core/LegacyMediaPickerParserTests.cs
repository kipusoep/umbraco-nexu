﻿namespace Our.Umbraco.Nexu.Parsers.Tests.Core
{
    using System.Linq;

    using global::Umbraco.Core.Models;

    using NUnit.Framework;

    using Our.Umbraco.Nexu.Core.Enums;
    using Our.Umbraco.Nexu.Parsers.Core;

    /// <summary>
    /// The legacy media picker parser tests.
    /// </summary>
    [TestFixture]
    public class LegacyMediaPickerParserTests
    {
        /// <summary>
        /// Test IsParserFor of parser with correct proptype
        /// </summary>       
        [Test]
        [Category("Parsers")]
        [Category("CoreParsers")]
        public void TestIsParserForValidProptype()
        {
            // arrange
            var property = new PropertyType(
                               global::Umbraco.Core.Constants.PropertyEditors.MediaPickerAlias,
                               DataTypeDatabaseType.Integer,
                               "cp1");

            var parser = new LegacyMediaPickerParser();

            // act
            var result = parser.IsParserFor(property);

            // verify
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test IsParserFor of parser with incorrect proptype
        /// </summary>
        [Test]
        [Category("Parsers")]
        [Category("CoreParsers")]
        public void TestIsParserForInValidProptype()
        {
            // arrange
            var property = new PropertyType(
                               "foo",
                               DataTypeDatabaseType.Integer,
                               "cp1");

            var parser = new LegacyMediaPickerParser();

            // act
            var result = parser.IsParserFor(property);

            // verify
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Test getting linked entities with a value
        /// </summary>
        [Test]
        [Category("Parsers")]
        [Category("CoreParsers")]
        public void TestGetLinkedEntitiesWithValue()
        {
            // arrange
            var parser = new LegacyMediaPickerParser();

            var propertyType = new PropertyType(
                              global::Umbraco.Core.Constants.PropertyEditors.MediaPickerAlias,
                              DataTypeDatabaseType.Integer,
                              "cp1");

            var property = new Property(propertyType, 1500);

            // act
            var result = parser.GetLinkedEntities(property);

            // verify
            Assert.IsNotNull(result);
            var entities = result.ToList();
            Assert.AreEqual(1, entities.Count());

            var entity = entities.First();

            Assert.AreEqual(LinkedEntityType.Media, entity.LinkedEntityType);
            Assert.AreEqual(1500, entity.Id);
        }

        /// <summary>
        /// Test getting linked entities with a empty value
        /// </summary>
        [Test]
        [Category("Parsers")]
        [Category("CoreParsers")]
        public void TestGetLinkedEntitiesWithEmptyValue()
        {
            // arrange
            var parser = new LegacyMediaPickerParser();

            var propertyType = new PropertyType(
                              global::Umbraco.Core.Constants.PropertyEditors.MediaPickerAlias,
                              DataTypeDatabaseType.Integer,
                              "cp1");

            var property = new Property(propertyType, null);

            // act
            var result = parser.GetLinkedEntities(property);

            // verify
            Assert.IsNotNull(result);
            var entities = result.ToList();
            Assert.AreEqual(0, entities.Count());
        }
    }
}
